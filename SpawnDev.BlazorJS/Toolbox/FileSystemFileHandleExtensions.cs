using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Adds methods to FileSystemFileHandle
    /// </summary>
    public static class FileSystemFileHandleExtensions
    {
        /// <summary>
        /// Seeks the file handle's stream to the end
        /// </summary>
        /// <param name="fileHandle"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public static async Task<long> SeekToEnd(this FileSystemFileHandle fileHandle, FileSystemWritableFileStream fileStream)
        {
            var size = await fileHandle.GetSize();
            await fileStream.Seek((ulong)size);
            return size;
        }
        /// <summary>
        /// Seeks the file handle's stream to the end
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileHandle"></param>
        /// <returns></returns>
        public static async Task<long> SeekToEnd(this FileSystemWritableFileStream fileStream, FileSystemFileHandle fileHandle)
        {
            var size = await fileHandle.GetSize();
            await fileStream.Seek((ulong)size);
            return size;
        }
        /// <summary>
        /// Runs a write action against an OPFS/File-System-Access writable stream and then commits it with
        /// <c>close()</c>. If the write action OR the close throws (most importantly the browser's
        /// <c>QuotaExceededError</c> mid-write), the stream is <c>abort()</c>ed first, then the original
        /// exception is rethrown.
        /// <para>
        /// Why this matters: <c>createWritable()</c> allocates a temporary swap file that holds the in-progress
        /// data. A stream that is neither closed nor aborted leaks that swap file until JS garbage collection.
        /// Under a retry loop (e.g. a torrent re-saving a piece whose write keeps failing) the leak compounds
        /// one swap file per attempt into a runaway that exhausts the origin's storage quota - which then makes
        /// EVERY subsequent write fail, so the loop never recovers. Aborting on failure releases the swap
        /// immediately. Every write path in this library routes through here so no caller can leak.
        /// </para>
        /// </summary>
        /// <param name="stream">The writable stream to commit or abort.</param>
        /// <param name="writeAction">The write(s) to perform before committing.</param>
        public static async Task WriteAndCommit(this FileSystemWritableFileStream stream, Func<Task> writeAction)
        {
            try
            {
                await writeAction();
                await stream.Close();
            }
            catch
            {
                // Best-effort release of the swap file; the write failure is the error the caller must see.
                try { await stream.Abort(); } catch { }
                throw;
            }
        }
        #region Write
        /// <summary>
        /// Asynchronously write a stream to the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, Stream stream)
        {
            var handleStream = await FileSystemHandleWritableStream.Create(_this);
            try
            {
                await stream.CopyToAsync(handleStream);
                await handleStream.CloseAsync();   // AWAIT the commit (not the sync fire-and-forget Dispose)
            }
            catch
            {
                await handleStream.AbortAsync();    // release swap + discard the partial on failure (e.g. quota)
                throw;
            }
            finally { handleStream.Dispose(); }
        }
        /// <summary>
        /// Replace the contents of a file with an ArrayBuffer
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, ArrayBuffer data)
        {
            using var stream = await _this!.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        /// <summary>
        /// Replace the contents of a file with a Blob
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, Blob data)
        {
            using var stream = await _this.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        /// <summary>
        /// Replace the contents of a file with a TypedArray
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, TypedArray data)
        {
            using var stream = await _this.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        /// <summary>
        /// Replace the contents of a file with a byte array
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, byte[] data)
        {
            using var stream = await _this.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        /// <summary>
        /// Replace the contents of a file with a DataView
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, DataView data)
        {
            using var stream = await _this.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        /// <summary>
        /// Replace the contents of a file with an string
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, string data)
        {
            using var stream = await _this.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        /// <summary>
        /// Replace the contents of a file with JSON
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static async Task WriteJSON(this FileSystemFileHandle _this, object data, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);
            using var stream = await _this!.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(json));
        }
        /// <summary>
        /// Process FileSystemWriteOptions
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, FileSystemWriteOptions data)
        {
            using var stream = await _this.CreateWritable();
            await stream.WriteAndCommit(() => stream.Write(data));
        }
        #endregion
        #region Append
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, ArrayBuffer data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, Stream stream)
        {
            var handleStream = await FileSystemHandleWritableStream.Create(_this, true);
            try
            {
                await stream.CopyToAsync(handleStream);
                await handleStream.CloseAsync();   // AWAIT the commit (not the sync fire-and-forget Dispose)
            }
            catch
            {
                await handleStream.AbortAsync();    // release swap + discard the partial on failure (e.g. quota)
                throw;
            }
            finally { handleStream.Dispose(); }
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, Blob data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, TypedArray data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, byte[] data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, DataView data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, string data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, FileSystemWriteOptions data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.WriteAndCommit(async () => { await stream.SeekToEnd(_this); await stream.Write(data); });
        }
        #endregion
        /// <summary>
        /// Read JSON from the file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static async Task<T> ReadJSON<T>(this FileSystemFileHandle _this, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            using var file = await _this!.GetFile();
            var ret = await file.Text();
            var obj = JsonSerializer.Deserialize<T>(ret, jsonSerializerOptions);
            return obj!;
        }
        /// <summary>
        /// Read text from the file
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<string> ReadText(this FileSystemFileHandle _this)
        {
            using var file = await _this!.GetFile();
            var ret = await file.Text();
            return ret;
        }
        /// <summary>
        /// Read a byte array from the file
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<byte[]> ReadBytes(this FileSystemFileHandle _this)
        {
            using var file = await _this!.GetFile();
            using var ret = await file.ArrayBuffer();
            return ret.ReadBytes();
        }
        /// <summary>
        /// Read the file as an ArrayBufferStream Stream.<br/>
        /// Note: The entire contents of file is read into memory.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<ArrayBufferStream> ReadStream(this FileSystemFileHandle _this)
        {
            var arrayBuffer = await _this.ReadArrayBuffer();
            var stream = new ArrayBufferStream(arrayBuffer);
            return stream;
        }
        /// <summary>
        /// Read the file as an BlobStream Stream.<br/>
        /// Note: This allows streaming the file directly from disk.
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<BlobStream> ReadBlobStream(this FileSystemFileHandle _this)
        {
            var file = await _this!.GetFile();
            var stream = new BlobStream(file);
            return stream;
        }
        /// <summary>
        /// Read an ArrayBuffer from the file
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<ArrayBuffer> ReadArrayBuffer(this FileSystemFileHandle _this)
        {
            using var file = await _this!.GetFile();
            var ret = await file.ArrayBuffer();
            return ret;
        }
        /// <summary>
        /// Read an File from the file
        /// </summary>
        /// <param name="_this"></param>
        /// <returns></returns>
        public static async Task<JSObjects.File> ReadFile(this FileSystemFileHandle _this)
        {
            var file = await _this!.GetFile();
            return file;
        }
    }
}
