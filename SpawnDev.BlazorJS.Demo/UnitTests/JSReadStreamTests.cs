using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Toolbox;
using System.Linq;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    /// <summary>
    /// Tests the IJSReadStream contract on BlobStream and ArrayBufferStream: ReadUint8ArrayAsync returns the
    /// correct bytes (read JS-side, leaving the data in JS) from the current Position and advances it, the
    /// end-of-stream case returns an empty Uint8Array, and CanReadSync reports each stream's sync-read support.
    /// </summary>
    public class JSReadStreamTests(BlazorJSRuntime JS)
    {
        // Non-trivial, reproducible content so an offset/length bug can't pass by coincidence.
        static readonly byte[] Data = Enumerable.Range(0, 1000).Select(i => (byte)((i * 31 + 7) & 0xFF)).ToArray();

        static void AssertRange(byte[] got, int srcOffset, int count)
        {
            if (got.Length != count) throw new Exception($"length {got.Length} != expected {count}");
            for (int i = 0; i < count; i++)
                if (got[i] != Data[srcOffset + i]) throw new Exception($"byte mismatch at {i}: got {got[i]}, expected {Data[srcOffset + i]}");
        }

        [TestMethod]
        public async Task ArrayBufferStream_ReadUint8ArrayAsync_CorrectBytes_AndSyncFlag()
        {
            using var u8 = new Uint8Array(Data);
            using var stream = new ArrayBufferStream(u8);
            IJSReadStream js = stream;
            if (!js.CanReadSync) throw new Exception("ArrayBufferStream.CanReadSync should be true (data already in JS memory)");

            stream.Position = 100;
            using var read = await js.ReadUint8ArrayAsync(50);
            AssertRange(read.ReadBytes(), 100, 50);
            if (stream.Position != 150) throw new Exception($"Position {stream.Position} != 150 after read");
        }

        [TestMethod]
        public async Task BlobStream_ReadUint8ArrayAsync_CorrectBytes_AndSyncFlag()
        {
            using var u8 = new Uint8Array(Data);
            using var blob = new Blob([u8]);
            using var stream = new BlobStream(blob);
            IJSReadStream js = stream;
            if (js.CanReadSync) throw new Exception("BlobStream.CanReadSync should be false (Blob.arrayBuffer() is async)");

            stream.Position = 100;
            using var read = await js.ReadUint8ArrayAsync(50);
            AssertRange(read.ReadBytes(), 100, 50);
            if (stream.Position != 150) throw new Exception($"Position {stream.Position} != 150 after read");
        }

        [TestMethod]
        public async Task JSReadStream_ReadAtEndOfStream_ReturnsEmpty()
        {
            using var u8 = new Uint8Array(Data);
            using var stream = new ArrayBufferStream(u8);
            IJSReadStream js = stream;
            stream.Position = Data.Length;          // exactly at end
            using var read = await js.ReadUint8ArrayAsync(50);
            if (read.Length != 0) throw new Exception($"expected empty Uint8Array at EOF, got length {read.Length}");
        }
    }
}
