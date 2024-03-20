using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class FileSystemDirectoryHandleExtensions
    {
        #region Write
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, ArrayBuffer data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, Blob data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, TypedArray data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, byte[] data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, DataView data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, string data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task WriteJSON(this FileSystemDirectoryHandle _this, string filename, object data, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(json);
            stream.Close();
        }
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        #region Append
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, ArrayBuffer data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, Blob data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });;
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, TypedArray data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, byte[] data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, DataView data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, string data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        public static async Task<T> ReadJSON<T>(this FileSystemDirectoryHandle _this, string filename, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            var ret = await file.Text();
            var obj = JsonSerializer.Deserialize<T>(ret, jsonSerializerOptions);
            return obj;
        }
        public static async Task<string> ReadText(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            var ret = await file.Text();
            return ret;
        }
        public static async Task<byte[]> ReadBytes(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            using var ret = await file.ArrayBuffer();
            return ret.ReadBytes();
        }
        public static async Task<ArrayBuffer> ReadArrayBuffer(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            var ret = await file.ArrayBuffer();
            return ret;
        }
        /// <summary>
        /// Read a FileSystemFileHandle as a File
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static async Task<JSObjects.File> ReadFile(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            var file = await fileHandle.GetFile();
            return file;
        }
        // not ideal using keys instead of GetFileHandle...
        // the problem with GetFileHandle is that the exact error for the failure that indicates the file is not found is
        // not available due to serialization and Task/Promise error treatment
        /// <summary>
        /// Returns true if a file or directory exists with the given name
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static async Task<bool> Exists(this FileSystemDirectoryHandle _this, string name)
        {
            var keys = await _this.Keys();
            var exists = keys.Contains(name);
            return exists;
        }
    }
}
