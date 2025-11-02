using Microsoft.JSInterop;
using SpawnDev.BlazorJS.Toolbox;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemSyncAccessHandle
    /// </summary>
    public class FileSystemSyncAccessHandle : JSObject
    {
        /// <inheritdoc/>
        public FileSystemSyncAccessHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The close() method of the FileSystemSyncAccessHandle interface closes an open synchronous file handle, disabling any further operations on it and releasing the exclusive lock previously put on the file associated with the file handle.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// The flush() method of the FileSystemSyncAccessHandle interface persists any changes made to the file associated with the handle via the write() method to disk.<br/>
        /// Bear in mind that you only need to call this method if you need the changes committed to disk at a specific time, otherwise you can leave the underlying operating system to handle this when it sees fit, which should be OK in most cases.
        /// </summary>
        public void Flush() => JSRef!.CallVoid("flush");
        /// <summary>
        /// The getSize() method of the FileSystemSyncAccessHandle interface returns the size of the file associated with the handle in bytes.
        /// </summary>
        /// <returns></returns>
        public long GetSize() => JSRef!.Call<long>("getSize");
        /// <summary>
        /// The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Read(ArrayBuffer buffer, FileSystemSyncReadWriteOptions? options = null) 
            => options == null ? JSRef!.Call<long>("read", buffer) : JSRef!.Call<long>("read", buffer, options);
        /// <summary>
        /// The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Read(TypedArray buffer, FileSystemSyncReadWriteOptions? options = null)
            => options == null ? JSRef!.Call<long>("read", buffer) : JSRef!.Call<long>("read", buffer, options);
        /// <summary>
        /// The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Read(DataView buffer, FileSystemSyncReadWriteOptions? options = null)
            => options == null ? JSRef!.Call<long>("read", buffer) : JSRef!.Call<long>("read", buffer, options);
        /// <summary>
        /// The read() method of the FileSystemSyncAccessHandle interface reads the content of the file associated with the handle into a specified buffer, optionally at a given offset.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Read(byte[] buffer, FileSystemSyncReadWriteOptions? options = null)
        {
            using var heapView = (HeapView)buffer;
            return options == null ? JSRef!.Call<long>("read", buffer) : JSRef!.Call<long>("read", heapView, options);
        }
        /// <summary>
        /// The truncate() method of the FileSystemSyncAccessHandle interface resizes the file associated with the handle to a specified number of bytes.
        /// </summary>
        public void Truncate(long newSize) => JSRef!.CallVoid("truncate", newSize);
        /// <summary>
        /// The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset.<br/>
        /// Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Write(ArrayBuffer buffer, FileSystemSyncReadWriteOptions? options = null)
            => options == null ? JSRef!.Call<long>("write", buffer) : JSRef!.Call<long>("write", buffer, options);
        /// <summary>
        /// The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset.<br/>
        /// Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Write(TypedArray buffer, FileSystemSyncReadWriteOptions? options = null)
            => options == null ? JSRef!.Call<long>("write", buffer) : JSRef!.Call<long>("write", buffer, options);
        /// <summary>
        /// The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset.<br/>
        /// Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Write(DataView buffer, FileSystemSyncReadWriteOptions? options = null)
            => options == null ? JSRef!.Call<long>("write", buffer) : JSRef!.Call<long>("write", buffer, options);
        /// <summary>
        /// The write() method of the FileSystemSyncAccessHandle interface writes the content of a specified buffer to the file associated with the handle, optionally at a given offset.<br/>
        /// Files within the origin private file system are not visible to end-users, therefore are not subject to the same security checks as methods running on files within the user-visible file system. As a result, writes performed using FileSystemSyncAccessHandle.write() are much more performant. This makes them suitable for significant, large-scale file updates such as SQLite database modifications.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public long Write(byte[] buffer, FileSystemSyncReadWriteOptions? options = null)
        {
            using var heapView = (HeapView)buffer;
            return options == null ? JSRef!.Call<long>("write", buffer) : JSRef!.Call<long>("write", buffer, options);
        }
    }
}
