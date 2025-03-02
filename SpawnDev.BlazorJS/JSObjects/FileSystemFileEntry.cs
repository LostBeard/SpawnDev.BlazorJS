using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemFileEntry interface of the File and Directory Entries API represents a file in a file system. It offers properties describing the file's attributes, as well as the file() method, which creates a File object that can be used to read the file.<br/>
    /// NOTE: Chrome calls this class FileEntry, while Firefox calls it FileSystemFileEntry<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemFileEntry
    /// </summary>
    public class FileSystemFileEntry : FileSystemEntry
    {
        /// <inheritdoc />
        public FileSystemFileEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The FileSystemFileEntry interface's method file() returns a File object which can be used to read data from the file represented by the directory entry.
        /// </summary>
        /// <param name="successCallback"></param>
        public void File(ActionCallback<File> successCallback) => JSRef!.Call<FileSystemDirectoryEntry>("file", successCallback);
        /// <summary>
        /// The FileSystemFileEntry interface's method file() returns a File object which can be used to read data from the file represented by the directory entry.
        /// </summary>
        public void File(ActionCallback<File> successCallback, ActionCallback<DOMException> errorCallback) => JSRef!.CallVoid("file", successCallback, errorCallback);
        /// <summary>
        /// The FileSystemFileEntry interface's method file() returns a File object which can be used to read data from the file represented by the directory entry.
        /// </summary>
        public async Task<File> FileAsync()
        {
            var tcs = new TaskCompletionSource<File>();
            using var successCallback = new ActionCallback<File>(tcs.SetResult);
            using var errorCallback = new ActionCallback<DOMException>((ex) => tcs.SetException(new Exception(ex.Message)));
            File(successCallback, errorCallback);
            return await tcs.Task;
        }
    }
}
