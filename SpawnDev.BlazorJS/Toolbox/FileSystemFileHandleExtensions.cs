using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    public static class FileSystemFileHandleExtensions
    {
        #region Write
        public static async Task Write(this FileSystemFileHandle _this, ArrayBuffer data)
        {
            using var stream = await _this!.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, Blob data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, TypedArray data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Truncate(0);
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, byte[] data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, DataView data)
        {
            
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, string data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        public static async Task WriteJSON(this FileSystemFileHandle _this, string filename, object data, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);
            using var stream = await _this!.CreateWritable();
            await stream.Write(json);
            stream.Close();
        }
        public static async Task Write(this FileSystemFileHandle _this, FileSystemWriteOptions data)
        {
            using var stream = await _this.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        #region Append
        // TODO test append methods
        public static async Task Append(this FileSystemFileHandle _this, ArrayBuffer data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, Blob data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, TypedArray data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, byte[] data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, DataView data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, string data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        public static async Task Append(this FileSystemFileHandle _this, FileSystemWriteOptions data)
        {
            using var stream = await _this.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        #endregion

        public static async Task<T> ReadJSON<T>(this FileSystemFileHandle _this, string filename, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            using var file = await _this!.GetFile();
            var ret = await file.Text();
            var obj = JsonSerializer.Deserialize<T>(ret, jsonSerializerOptions);
            return obj;
        }
        public static async Task<string> ReadText(this FileSystemFileHandle _this, string filename)
        {
            using var file = await _this!.GetFile();
            var ret = await file.Text();
            return ret;
        }
        public static async Task<byte[]> ReadBytes(this FileSystemFileHandle _this, string filename)
        {
            using var file = await _this!.GetFile();
            using var ret = await file.ArrayBuffer();
            return ret.ReadBytes();
        }
        public static async Task<ArrayBuffer> ReadArrayBuffer(this FileSystemFileHandle _this, string filename)
        {
            using var file = await _this!.GetFile();
            var ret = await file.ArrayBuffer();
            return ret;
        }
        public static async Task<JSObjects.File> ReadFile(this FileSystemFileHandle _this, string filename)
        {
            var file = await _this!.GetFile();
            return file;
        }
    }
}
