using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemDirectoryHandle interface of the File System API provides a handle to a file system directory.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemDirectoryHandle
    /// </summary>
    public class FileSystemDirectoryHandle : FileSystemHandle
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FileSystemDirectoryHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public Task<FileSystemDirectoryHandle> GetDirectoryHandle(string name, bool create = false) => JSRef.CallAsync<FileSystemDirectoryHandle>("getDirectoryHandle", name, new GetHandleOptions { Create = create });
        /// <summary>
        /// Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.
        /// <summary>
        /// Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public Task<FileSystemFileHandle> GetFileHandle(string name, bool create = false) => JSRef.CallAsync<FileSystemFileHandle>("getFileHandle", name, new GetHandleOptions { Create = create });
        /// </summary>
        /// <param name="name"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public Task RemoveEntry(string name, bool recursive = false) => JSRef.CallVoidAsync("removeEntry", name, new RemoveEntryOptions { Recursive = recursive });
        /// <summary>
        /// The resolve() method of the FileSystemDirectoryHandle interface returns an Array of directory names from the parent handle to the specified child entry, with the name of the child entry as the last array item.
        /// </summary>
        /// <param name="possibleDescendant">The FileSystemHandle from which to return the relative path.</param>
        /// <returns>A Promise which resolves with an Array of strings, or null if possibleDescendant is not a descendant of this FileSystemDirectoryHandle.</returns>
        public Task<List<string>?> Resolve(FileSystemHandle possibleDescendant) => JSRef.CallAsync<List<string>?>("resolve", possibleDescendant);
        /// <summary>
        /// Returns a new async iterator of a given object's own enumerable property [key, value] pairs.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, FileSystemHandle>> Entries()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("values");
            var files = await valuesIterator.ToList<FileSystemHandle>();
            var typed = files.Select(o => o.ResolveType(true)).ToList();
            return typed.ToDictionary(o => o.Name, o => o);
        }
        /// <summary>
        /// Returns a new async iterator containing the values for each index in the FileSystemDirectoryHandle object.
        /// </summary>
        /// <returns></returns>
        public async Task<List<FileSystemHandle>> Values()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("values");
            var files = await valuesIterator.ToList<FileSystemHandle>();
            var typed = files.Select(o => o.ResolveType(true)).ToList();
            return typed;
        }
        /// <summary>
        /// Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle.
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> Keys()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("keys");
            var keys = await valuesIterator.ToList<string>();
            return keys;
        }
    }
}
