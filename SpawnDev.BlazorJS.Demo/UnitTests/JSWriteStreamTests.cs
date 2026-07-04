using SpawnDev.Blazor.UnitTesting;
using SpawnDev.BlazorJS.JSObjects;
using SpawnDev.BlazorJS.Toolbox;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.Demo.UnitTests
{
    /// <summary>
    /// Tests the IJSWriteStream contract on ArrayBufferStream and FileSystemHandleWritableStream, and the
    /// JSCopyTo / JSCopyToAsync helpers (IJSReadStream -> IJSWriteStream, kept JS-side). Bytes are written /
    /// copied as Uint8Arrays (never through the .NET heap); readback asserts the exact content and that the
    /// CanWriteSync flag reports each stream's sync-write support.
    /// </summary>
    public class JSWriteStreamTests(BlazorJSRuntime JS)
    {
        // Non-trivial, reproducible content so an offset/length bug can't pass by coincidence.
        static readonly byte[] Data = Enumerable.Range(0, 1000).Select(i => (byte)((i * 31 + 7) & 0xFF)).ToArray();

        static void AssertEqual(byte[] got, byte[] expected)
        {
            if (got.Length != expected.Length) throw new Exception($"length {got.Length} != expected {expected.Length}");
            for (int i = 0; i < expected.Length; i++)
                if (got[i] != expected[i]) throw new Exception($"byte mismatch at {i}: got {got[i]}, expected {expected[i]}");
        }

        [TestMethod]
        public async Task ArrayBufferStream_WriteUint8ArrayAsync_CorrectBytes_AndSyncFlag()
        {
            using var stream = new ArrayBufferStream(Data.Length);
            IJSWriteStream js = stream;
            if (!js.CanWriteSync) throw new Exception("ArrayBufferStream.CanWriteSync should be true (buffer resident in JS memory)");

            using var src = new Uint8Array(Data);
            await js.WriteUint8ArrayAsync(src);
            if (stream.Position != Data.Length) throw new Exception($"Position {stream.Position} != {Data.Length} after write");

            AssertEqual(stream.Source.ReadBytes(), Data);
        }

        [TestMethod]
        public void ArrayBufferStream_WriteUint8Array_Sync_CorrectBytes()
        {
            using var stream = new ArrayBufferStream(Data.Length);
            IJSWriteStream js = stream;
            using var src = new Uint8Array(Data);
            js.WriteUint8Array(src);
            AssertEqual(stream.Source.ReadBytes(), Data);
        }

        [TestMethod]
        public void ArrayBufferStream_IsDuplex_ReadAndWrite()
        {
            using var stream = new ArrayBufferStream(Data.Length);
            // Same stream satisfies both interfaces.
            if (stream is not IJSReadStream) throw new Exception("ArrayBufferStream should implement IJSReadStream");
            if (stream is not IJSWriteStream) throw new Exception("ArrayBufferStream should implement IJSWriteStream");
        }

        // Standard Stream.CopyToAsync: the BlobStream override detects the IJSWriteStream destination and
        // pumps Uint8Array chunks JS-side (never through the .NET heap) instead of the base managed path.
        [TestMethod]
        public async Task CopyToAsync_BlobStream_To_ArrayBufferStream_UsesJSPath()
        {
            using var u8 = new Uint8Array(Data);
            using var blob = new Blob([u8]);
            using var source = new BlobStream(blob);
            using var dest = new ArrayBufferStream(Data.Length);

            // Small buffer forces the multi-chunk loop.
            await source.CopyToAsync(dest, bufferSize: 128);

            AssertEqual(dest.Source.ReadBytes(), Data);
        }

        // Standard sync Stream.CopyTo: ArrayBufferStream -> ArrayBufferStream (both sync-capable) uses the
        // JS sync path via the override.
        [TestMethod]
        public void CopyTo_Sync_ArrayBufferStream_To_ArrayBufferStream()
        {
            using var srcU8 = new Uint8Array(Data);
            using var source = new ArrayBufferStream(srcU8);
            using var dest = new ArrayBufferStream(Data.Length);

            source.CopyTo(dest, bufferSize: 256);

            AssertEqual(dest.Source.ReadBytes(), Data);
        }

        // Sync CopyTo from an async-only Blob source cannot use a sync read, so the override defers to the
        // base Stream.CopyTo, whose synchronous BlobStream.Read throws - the correct, fail-loud behavior.
        [TestMethod]
        public void CopyTo_Sync_Throws_On_AsyncBlobSource()
        {
            using var u8 = new Uint8Array(Data);
            using var blob = new Blob([u8]);
            using var source = new BlobStream(blob);       // CanReadSync == false
            using var dest = new ArrayBufferStream(Data.Length);

            bool threw = false;
            try { source.CopyTo(dest); }
            catch (NotSupportedException) { threw = true; }
            if (!threw) throw new Exception("Sync CopyTo from an async-only Blob source must throw NotSupportedException.");
        }

        [TestMethod]
        public async Task FileSystemHandleWritableStream_WriteUint8ArrayAsync_OPFS_RoundTrip()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();

            var fileName = "jswritestream_" + Guid.NewGuid().ToString() + ".bin";
            using var fileHandle = await root.GetFileHandle(fileName, true);
            if (fileHandle.JSRef!.IsUndefined("createWritable")) return; // Browser limitation check

            try
            {
                // Write the GPU-save-style path: Uint8Array straight to OPFS, chunk by chunk, JS-side.
                // await using so the OPFS close() commit is awaited before the read-back below.
                await using (var ws = await fileHandle.GetWritableStream())
                {
                    IJSWriteStream js = ws;
                    if (js.CanWriteSync) throw new Exception("FileSystemHandleWritableStream.CanWriteSync should be false (OPFS write is async)");

                    bool threw = false;
                    using (var tiny = new Uint8Array(Data))
                    {
                        try { js.WriteUint8Array(tiny); }   // sync write must throw
                        catch (NotSupportedException) { threw = true; }
                    }
                    if (!threw) throw new Exception("FileSystemHandleWritableStream.WriteUint8Array must throw (async-only).");

                    // Async write in two chunks to exercise position advance.
                    using var c1 = new Uint8Array(Data.Take(400).ToArray());
                    using var c2 = new Uint8Array(Data.Skip(400).ToArray());
                    await js.WriteUint8ArrayAsync(c1);
                    await js.WriteUint8ArrayAsync(c2);
                }

                // Read back via the file's Blob.
                using var file = await fileHandle.GetFile();
                using var ab = await file.ArrayBuffer();
                using var rb = new Uint8Array(ab);
                AssertEqual(rb.ReadBytes(), Data);
            }
            finally
            {
                await root.RemoveEntry(fileName);
            }
        }

        // End-to-end save path: in-memory JS buffer -> OPFS file via standard Stream.CopyToAsync (the
        // ArrayBufferStream override routes to the JS-side path), mirroring a GPU readback save.
        [TestMethod]
        public async Task CopyToAsync_ArrayBufferStream_To_OPFS()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();

            var fileName = "jscopyto_" + Guid.NewGuid().ToString() + ".bin";
            using var fileHandle = await root.GetFileHandle(fileName, true);
            if (fileHandle.JSRef!.IsUndefined("createWritable")) return;

            try
            {
                using var srcU8 = new Uint8Array(Data);
                using var source = new ArrayBufferStream(srcU8);
                // await using so the OPFS close() commit is awaited before the read-back below.
                await using (var dest = await fileHandle.GetWritableStream())
                {
                    await source.CopyToAsync(dest, bufferSize: 137); // odd chunk to stress the loop
                }

                using var file = await fileHandle.GetFile();
                using var ab = await file.ArrayBuffer();
                using var rb = new Uint8Array(ab);
                AssertEqual(rb.ReadBytes(), Data);
            }
            finally
            {
                await root.RemoveEntry(fileName);
            }
        }

        // Regression guard for the OPFS swap-leak / partial-commit fix (2026-07-04). createWritable() allocates a
        // swap file and (keepExistingData:false) truncates on open; the original is only replaced atomically on
        // close(). WriteAndCommit must ABORT the writable when the write action throws (e.g. QuotaExceededError
        // mid-write) - releasing the swap AND leaving the original content intact - and must RETHROW the original
        // error. If a regression made it Close() on error instead, the truncated/partial write would COMMIT and the
        // original would be lost - this test catches exactly that.
        [TestMethod]
        public async Task WriteAndCommit_ThrowingWrite_AbortsWithoutCommitting_AndRethrows()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();
            var fileName = "writeandcommit_throw_" + Guid.NewGuid().ToString() + ".bin";
            using var fileHandle = await root.GetFileHandle(fileName, true);
            if (fileHandle.JSRef!.IsUndefined("createWritable")) return;
            try
            {
                using (var orig = new Uint8Array(Data)) await fileHandle.Write(orig);   // commit known original content

                using var stream = await fileHandle.CreateWritable();                   // truncates via swap
                bool threw = false;
                try
                {
                    await stream.WriteAndCommit(async () =>
                    {
                        using var half = new Uint8Array(Data.Take(400).ToArray());
                        await stream.Write(half);                                        // partial data into the swap
                        throw new InvalidOperationException("simulated QuotaExceededError mid-write");
                    });
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("simulated")) { threw = true; }
                if (!threw) throw new Exception("WriteAndCommit must RETHROW the write action's exception, not swallow it");

                // Original intact => the failed write was ABORTED (swap discarded), not Close()d (which would have
                // committed the truncated/partial write).
                using var file = await fileHandle.GetFile();
                using var ab = await file.ArrayBuffer();
                using var rb = new Uint8Array(ab);
                AssertEqual(rb.ReadBytes(), Data);
            }
            finally { await root.RemoveEntry(fileName); }
        }

        // Happy-path guard: WriteAndCommit (the primitive every FileSystemFileHandle.Write overload now routes
        // through) commits normally when the write succeeds.
        [TestMethod]
        public async Task FileSystemFileHandle_Write_RoundTrips_ViaWriteAndCommit()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();
            var fileName = "fshandle_write_" + Guid.NewGuid().ToString() + ".bin";
            using var fileHandle = await root.GetFileHandle(fileName, true);
            if (fileHandle.JSRef!.IsUndefined("createWritable")) return;
            try
            {
                using (var src = new Uint8Array(Data)) await fileHandle.Write(src);
                using var file = await fileHandle.GetFile();
                using var ab = await file.ArrayBuffer();
                using var rb = new Uint8Array(ab);
                AssertEqual(rb.ReadBytes(), Data);
            }
            finally { await root.RemoveEntry(fileName); }
        }

        // FileSystemHandleWritableStream.AbortAsync must DISCARD uncommitted writes: after writing to the swap and
        // aborting (instead of CloseAsync), the original file content must survive. Proves the error-path teardown
        // the Stream copy path relies on.
        [TestMethod]
        public async Task FileSystemHandleWritableStream_AbortAsync_DiscardsUncommittedWrite()
        {
            if (!StorageManager.Supported) return;
            using var storage = JS.Get<StorageManager>("navigator.storage");
            using var root = await storage.GetDirectory();
            var fileName = "abortasync_" + Guid.NewGuid().ToString() + ".bin";
            using var fileHandle = await root.GetFileHandle(fileName, true);
            if (fileHandle.JSRef!.IsUndefined("createWritable")) return;
            try
            {
                using (var orig = new Uint8Array(Data)) await fileHandle.Write(orig);   // commit known original content

                var ws = await fileHandle.GetWritableStream();                          // keepExistingData:false => truncates
                using (var newData = new Uint8Array(Enumerable.Repeat((byte)0xAB, 512).ToArray()))
                    await ws.WriteUint8ArrayAsync(newData);                             // buffered in the swap, NOT committed
                await ws.AbortAsync();                                                  // discard (not CloseAsync)
                ws.Dispose();

                using var file = await fileHandle.GetFile();
                using var ab = await file.ArrayBuffer();
                using var rb = new Uint8Array(ab);
                AssertEqual(rb.ReadBytes(), Data);   // original survives => AbortAsync discarded the swap
            }
            finally { await root.RemoveEntry(fileName); }
        }
    }
}
