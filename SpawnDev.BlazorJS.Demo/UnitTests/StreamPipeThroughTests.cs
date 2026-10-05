using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using System.Text;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    /// <summary>
    /// ReadableStream.PipeThrough with CompressionStream, DecompressionStream, TextDecoderStream and TextEncoderStream.
    /// pipeThrough() takes any {writable, readable} pair; those four are pairs but not TransformStreams, and PipeThrough
    /// only took a TransformStream (same gap as SpawnDev.SpawnJS 3.0.0). Each test checks the bytes that come back.
    /// </summary>
    public class StreamPipeThroughTests(BlazorJSRuntime JS)
    {
        static byte[] Payload(int n)
        {
            var b = new byte[n];
            for (int i = 0; i < n; i++) b[i] = (byte)((i * 7 + i / 1000) & 0xFF);
            return b;
        }

        static async Task<byte[]> ReadAll(ReadableStream stream)
        {
            using var response = new Response(stream);
            return await response.ReadBytes();
        }

        static void SameBytes(byte[] expected, byte[] actual, string what)
        {
            if (actual.Length != expected.Length) throw new Exception($"{what}: {actual.Length} bytes back, expected {expected.Length}");
            for (int i = 0; i < expected.Length; i++)
                if (actual[i] != expected[i]) throw new Exception($"{what}: byte {i} is {actual[i]}, expected {expected[i]}");
        }

        [TestMethod]
        public async Task PipeThroughGzipRoundTrip()
        {
            var payload = Payload(256 * 1024);
            byte[] zipped;
            using (var blob = new Blob(new[] { payload }, new BlobOptions { Type = "application/octet-stream" }))
            using (var src = blob.Stream())
            using (var gzip = new CompressionStream("gzip"))
            using (var piped = src.PipeThrough(gzip))
                zipped = await ReadAll(piped);
            if (zipped.Length == 0 || zipped.Length >= payload.Length) throw new Exception($"gzip gave {zipped.Length} bytes for {payload.Length}");
            if (zipped[0] != 0x1F || zipped[1] != 0x8B) throw new Exception($"not a gzip stream: starts {zipped[0]:X2} {zipped[1]:X2}");
            using var zBlob = new Blob(new[] { zipped }, new BlobOptions { Type = "application/octet-stream" });
            using var zSrc = zBlob.Stream();
            using var gunzip = new DecompressionStream("gzip");
            using var back = zSrc.PipeThrough(gunzip);
            SameBytes(payload, await ReadAll(back), "gunzip");
        }

        [TestMethod]
        public async Task PipeThroughDeflateRawWithOptionsRoundTrip()
        {
            var payload = Payload(64 * 1024);
            byte[] packed;
            using (var blob = new Blob(new[] { payload }, new BlobOptions { Type = "application/octet-stream" }))
            using (var src = blob.Stream())
            using (var deflate = new CompressionStream("deflate-raw"))
            using (var piped = src.PipeThrough(deflate, new PipeThroughOptions { PreventCancel = false }))
                packed = await ReadAll(piped);
            if (packed.Length >= payload.Length) throw new Exception($"deflate-raw gave {packed.Length} bytes");
            using var pBlob = new Blob(new[] { packed }, new BlobOptions { Type = "application/octet-stream" });
            using var pSrc = pBlob.Stream();
            using var inflate = new DecompressionStream("deflate-raw");
            using var back = pSrc.PipeThrough(inflate, new PipeThroughOptions { PreventCancel = false });
            SameBytes(payload, await ReadAll(back), "inflate");
        }

        [TestMethod]
        public async Task PipeThroughTextDecoderThenEncoderKeepsText()
        {
            const string text = "BlazorJS pipeThrough - grüße, 日本語, emoji 🖖 and plain ASCII";
            var utf8 = Encoding.UTF8.GetBytes(text);
            using var blob = new Blob(new[] { utf8 }, new BlobOptions { Type = "text/plain" });
            using var src = blob.Stream();
            using var decoder = new TextDecoderStream("utf-8");
            using var strings = src.PipeThrough(decoder);
            using var encoder = new TextEncoderStream();
            if (encoder.Encoding != "utf-8") throw new Exception($"TextEncoderStream.Encoding is '{encoder.Encoding}'");
            using var bytes = strings.PipeThrough(encoder);
            SameBytes(utf8, await ReadAll(bytes), "text round trip");
        }
    }
}
