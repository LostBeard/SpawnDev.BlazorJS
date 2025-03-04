using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemEntry interface of the File and Directory Entries API represents a single entry in a file system. The entry can be a file or a directory (directories are represented by the FileSystemDirectoryEntry interface). It includes methods for working with files—including copying, moving, removing, and reading files—as well as information about a file it points to—including the file name and its path from the root to the entry.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemEntry
    /// </summary>
    public class FileSystemEntry : JSObject
    {
        /// <inheritdoc />
        public FileSystemEntry(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A FileSystem object representing the file system in which the entry is located.
        /// </summary>
        public FileSystem FileSystem => JSRef!.Get<FileSystem>("filesystem");
        /// <summary>
        /// A string which provides the full, absolute path from the file system's root to the entry; it can also be thought of as a path which is relative to the root directory, prepended with a "/" character.
        /// </summary>
        public string FullPath => JSRef!.Get<string>("fullPath");
        /// <summary>
        /// A boolean value which is true if the entry represents a directory; otherwise, it's false.
        /// </summary>
        public bool IsDirectory => JSRef!.Get<bool>("isDirectory");
        /// <summary>
        /// A Boolean which is true if the entry represents a file. If it's not a file, this value is false.
        /// </summary>
        public bool IsFile => JSRef!.Get<bool>("isFile");
        /// <summary>
        /// A string containing the name of the entry (the final part of the path, after the last "/" character).
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// The FileSystemEntry interface's method getParent() obtains a FileSystemDirectoryEntry.
        /// </summary>
        /// <returns></returns>
        public void GetParent(ActionCallback<FileSystemDirectoryEntry> successCallback) => JSRef!.CallVoid("getParent", successCallback);
        /// <summary>
        /// The FileSystemEntry interface's method getParent() obtains a FileSystemDirectoryEntry.
        /// </summary>
        /// <param name="successCallback"></param>
        /// <param name="errorCallback"></param>
        public void GetParent(ActionCallback<FileSystemDirectoryEntry> successCallback, ActionCallback<DOMException> errorCallback) => JSRef!.CallVoid("getParent", successCallback, errorCallback);
        /// <summary>
        /// The FileSystemEntry interface's method getParent() obtains a FileSystemDirectoryEntry.
        /// </summary>
        /// <returns></returns>
        public async Task<FileSystemDirectoryEntry> GetParentAsync()
        {
            var tcs = new TaskCompletionSource<FileSystemDirectoryEntry>();
            using var successCallback = new ActionCallback<FileSystemDirectoryEntry>(tcs.SetResult);
            using var errorCallback = new ActionCallback<DOMException>((ex) => tcs.SetException(new Exception(ex.Message)));
            GetParent(successCallback, errorCallback);
            return await tcs.Task;
        }
        /// <summary>
        /// Returns a FileSystemDirectoryEntry if IsDirectory, FileSystemFileEntry if IsFile, else FileSystemEntry
        /// </summary>
        /// <param name="moveJSRef">If true, the IJSInProcessReference from this JSObject is moved to the new type instead of copied</param>
        /// <returns></returns>
        public FileSystemEntry ResolveType(bool moveJSRef = false)
        {
            if (IsDirectory)
            {
                return moveJSRef ? JSRefMove<FileSystemDirectoryEntry>() : JSRefCopy<FileSystemDirectoryEntry>();
            }
            else if (IsFile)
            {
                return moveJSRef ? JSRefMove<FileSystemFileEntry>() : JSRefCopy<FileSystemFileEntry>();
            }
            else
            {
                return moveJSRef ? JSRefMove<FileSystemEntry>() : JSRefCopy<FileSystemEntry>();
            }
        }
        /// <summary>
        /// Returns a FileSystemDirectoryEntry JSObject for this entry if this entry IsDirectory
        /// </summary>
        /// <returns></returns>
        public FileSystemDirectoryEntry? ToFileSystemDirectoryEntry(bool moveJSRef = false) => IsDirectory ? (moveJSRef ? JSRefMove<FileSystemDirectoryEntry>() : JSRefCopy<FileSystemDirectoryEntry>()) : null;
        /// <summary>
        /// Returns a FileSystemFileEntry JSObject for this entry if this entry IsFile
        /// </summary>
        /// <param name="moveJSRef"></param>
        /// <returns></returns>
        public FileSystemFileEntry? ToFileSystemFileEntry(bool moveJSRef = false) => IsFile ? (moveJSRef ? JSRefMove<FileSystemFileEntry>() : JSRefCopy<FileSystemFileEntry>()) : null;
    }
}
