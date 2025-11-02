using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemFileHandle interface of the File System API represents a handle to a file system entry. The interface is accessed through the window.showOpenFilePicker() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileHandle
    /// </summary>
    public class FileSystemFileHandle : FileSystemHandle
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FileSystemFileHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise which resolves to a File object representing the state on disk of the entry represented by the handle.
        /// </summary>
        /// <returns></returns>
        public Task<File> GetFile() => JSRef!.CallAsync<File>("getFile");
        /// <summary>
        /// Returns a Promise which resolves to a newly created FileSystemWritableFileStream object that can be used to write to a file.
        /// </summary>
        /// <returns></returns>
        public Task<FileSystemWritableFileStream> CreateWritable() => JSRef!.CallAsync<FileSystemWritableFileStream>("createWritable");
        /// <summary>
        /// Returns a Promise which resolves to a newly created FileSystemWritableFileStream object that can be used to write to a file.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<FileSystemWritableFileStream> CreateWritable(FileSystemCreateWritableOptions options) => JSRef!.CallAsync<FileSystemWritableFileStream>("createWritable", options);
        /// <summary>
        /// Returns the file's size<br/>
        /// non-standard
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetSize()
        {
            using var file = await GetFile();
            return file.Size;
        }
        /// <summary>
        /// Returns the file's last modified value<br/>
        /// non-standard
        /// </summary>
        /// <returns></returns>
        public async Task<long> GetLastModified()
        {
            using var file = await GetFile();
            return file.LastModified;
        }
        /// <summary>
        /// The createSyncAccessHandle() method of the FileSystemFileHandle interface returns a Promise which resolves to a FileSystemSyncAccessHandle object that can be used to synchronously read from and write to a file. The synchronous nature of this method brings performance advantages, but it is only usable inside dedicated Web Workers for files within the origin private file system.<br/>
        /// Creating a FileSystemSyncAccessHandle takes an exclusive lock on the file associated with the file handle. This prevents the creation of further FileSystemSyncAccessHandles or FileSystemWritableFileStreams for the file until the existing access handle is closed.
        /// </summary>
        /// <returns></returns>
        public Task<FileSystemSyncAccessHandle> CreateSyncAccessHandle(FileSystemSyncAccessOptions? options = null)
            => options == null ? JSRef!.CallAsync<FileSystemSyncAccessHandle>("createSyncAccessHandle") : JSRef!.CallAsync<FileSystemSyncAccessHandle>("createSyncAccessHandle", options);
    }
}
