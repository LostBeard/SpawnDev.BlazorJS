using Microsoft.JSInterop;

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
    }
}
