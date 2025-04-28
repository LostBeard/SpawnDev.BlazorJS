using SpawnDev.BlazorJS.JSObjects;
using System.IO;
using System.Text.Json;

namespace SpawnDev.BlazorJS.Toolbox
{
    /// <summary>
    /// Adds methods to FileSystemFileHandle
    /// </summary>
    public static class FileSystemFileHandleExtensions
    {
        #region Write
        /// <summary>
        /// Asynchronously write a stream to the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task Write(this FileSystemFileHandle _this, Stream stream)
        {
            using var handleStream = await FileSystemHandleWritableStream.Create(_this);
            await stream.CopyToAsync(handleStream);
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(json);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
        }
        /// <summary>
        /// Append data to the end of the file
        /// </summary>
        /// <param name="_this"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static async Task Append(this FileSystemFileHandle _this, Stream stream)
        {
            using var handleStream = await FileSystemHandleWritableStream.Create(_this, true);
            await stream.CopyToAsync(handleStream);
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
            await stream.Write(data);
            stream.Close();
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
        /// Read a Stream from the file
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
