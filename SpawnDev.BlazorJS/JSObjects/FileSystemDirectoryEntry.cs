using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemDirectoryEntry interface of the File and Directory Entries API represents a directory in a file system. It provides methods which make it possible to access and manipulate the files in a directory, as well as to access the entries within the directory.<br/>
    /// NOTE: Chrome calls this class DirectoryEntry, while Firefox calls it FileSystemDirectoryEntry<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryEntry
    /// </summary>
    public class FileSystemDirectoryEntry : FileSystemEntry
    {
        /// <inheritdoc />
        public FileSystemDirectoryEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The FileSystemDirectoryEntry interface's method createReader() returns a FileSystemDirectoryReader object which can be used to read the entries in the directory.
        /// </summary>
        /// <returns></returns>
        public FileSystemDirectoryReader CreateReader() => JSRef!.Call<FileSystemDirectoryReader>("createReader");
        /// <summary>
        /// The FileSystemDirectoryEntry interface's method getDirectory() returns a FileSystemDirectoryEntry object corresponding to a directory contained somewhere within the directory subtree rooted at the directory on which it's called.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <param name="successCallback"></param>
        /// <param name="errorCallback"></param>
        public void GetDirectory(string path, FileSystemGetEntryOptions? options, ActionCallback<FileSystemDirectoryEntry> successCallback, ActionCallback<DOMException> errorCallback) =>
            JSRef!.CallVoid("getDirectory", path, options ?? new FileSystemGetEntryOptions(), successCallback, errorCallback);
        /// <summary>
        /// Returns a FileSystemDirectoryEntry object representing a directory located at a given path, relative to the directory on which the method is called.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<FileSystemDirectoryEntry> GetDirectoryAsync(string path, FileSystemGetEntryOptions? options = null)
        {
            var tcs = new TaskCompletionSource<FileSystemDirectoryEntry>();
            using var successCallback = new ActionCallback<FileSystemDirectoryEntry>(tcs.SetResult);
            using var errorCallback = new ActionCallback<DOMException>((ex) => tcs.SetException(new Exception(ex.Message)));
            GetDirectory(path, options, successCallback, errorCallback);
            return await tcs.Task;
        }
        /// <summary>
        /// The FileSystemDirectoryEntry interface's method getFile() returns a FileSystemFileEntry object corresponding to a file contained somewhere within the directory subtree rooted at the directory on which it's called.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <param name="successCallback"></param>
        /// <param name="errorCallback"></param>
        public void GetFile(string path, FileSystemGetEntryOptions? options, ActionCallback<FileSystemFileEntry> successCallback, ActionCallback<DOMException> errorCallback) =>
            JSRef!.CallVoid("getDirectory", path, options ?? new FileSystemGetEntryOptions(), successCallback, errorCallback);
        /// <summary>
        /// Returns a FileSystemFileEntry object representing a file located within the directory's hierarchy, given a path relative to the directory on which the method is called.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<FileSystemFileEntry> GetFileAsync(string path, FileSystemGetEntryOptions? options = null)
        {
            var tcs = new TaskCompletionSource<FileSystemFileEntry>();
            using var successCallback = new ActionCallback<FileSystemFileEntry>(tcs.SetResult);
            using var errorCallback = new ActionCallback<DOMException>((ex) => tcs.SetException(new Exception(ex.Message)));
            GetFile(path, options, successCallback, errorCallback);
            return await tcs.Task;
        }
    }
}
