using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemWritableFileStream interface of the File System API is a WritableStream object with additional convenience methods, which operates on a single file on disk. The interface is accessed through the FileSystemFileHandle.createWritable() method.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemWritableFileStream
    /// </summary>
    public class FileSystemWritableFileStream : WritableStream
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FileSystemWritableFileStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(ArrayBuffer data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(Blob data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(TypedArray data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(byte[] data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(DataView data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(string data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// The write() method of the FileSystemWritableFileStream interface writes content into the file the method is called on, at the current file cursor offset.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task Write(FileSystemWriteOptions data) => JSRef.CallVoidAsync("write", data);
        /// <summary>
        /// Resizes the file associated with the stream to be the specified size in bytes.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Task Truncate(ulong size) => JSRef.CallVoidAsync("truncate", size);
        /// <summary>
        /// Updates the current file cursor offset to the position (in bytes) specified.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Task Seek(ulong position) => JSRef.CallVoidAsync("seek", position);
    }
}
