using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Adds methods to FileSystemDirectoryHandle
    /// </summary>
    public static class FileSystemDirectoryHandleExtensions
    {
        #region Write
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, ArrayBuffer data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, Blob data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, TypedArray data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, byte[] data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, DataView data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, string data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static async Task WriteJSON(this FileSystemDirectoryHandle _this, string filename, object data, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            var json = JsonSerializer.Serialize(data, jsonSerializerOptions);
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(json);
            stream.Close();
        }
        /// <summary>
        /// Write the data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemDirectoryHandle _this, string filename, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable();
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        #region Append
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, ArrayBuffer data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, Blob data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });;
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, TypedArray data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, byte[] data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, DataView data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, string data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the file, the file will be created if it does not exist
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemDirectoryHandle _this, string filename, FileSystemWriteOptions data)
        {
            using var fileHandle = await _this.GetFileHandle(filename, true);
            using var stream = await fileHandle.CreateWritable(new FileSystemCreateWritableOptions { KeepExistingData = true });
            await stream.Write(data);
            stream.Close();
        }
        #endregion
        /// <summary>
        /// Read the data from the file as T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <param name="jsonSerializerOptions"></param>
        /// <returns></returns>
        public static async Task<T> ReadJSON<T>(this FileSystemDirectoryHandle _this, string filename, JsonSerializerOptions? jsonSerializerOptions = null)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            var ret = await file.Text();
            var obj = JsonSerializer.Deserialize<T>(ret, jsonSerializerOptions);
            return obj;
        }
        /// <summary>
        /// Read the data from the file as a string
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static async Task<string> ReadText(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            var ret = await file.Text();
            return ret;
        }
        /// <summary>
        /// Read the data from the file as a byte array
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static async Task<byte[]> ReadBytes(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            using var ret = await file.ArrayBuffer();
            return ret.ReadBytes();
        }
        /// <summary>
        /// Read the data from the file as an ArrayBuffer
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static async Task<ArrayBuffer> ReadArrayBuffer(this FileSystemDirectoryHandle _this, string filename)
        {
            using var fileHandle = await _this.GetFileHandle(filename, false);
            using var file = await fileHandle.GetFile();
            var ret = await file.ArrayBuffer();
            return ret;
        }
        /// <summary>
        /// Read the data from the file as File
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
