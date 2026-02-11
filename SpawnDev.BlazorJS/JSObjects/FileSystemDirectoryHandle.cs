using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemDirectoryHandle interface of the File System API provides a handle to a file system directory.<br/>
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
        public Task<FileSystemDirectoryHandle> GetDirectoryHandle(string name, bool create = false) => JSRef!.CallAsync<FileSystemDirectoryHandle>("getDirectoryHandle", name, new GetHandleOptions { Create = create });
        /// <summary>
        /// Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public Task<FileSystemFileHandle> GetFileHandle(string name, bool create = false) => JSRef!.CallAsync<FileSystemFileHandle>("getFileHandle", name, new GetHandleOptions { Create = create });
        /// <summary>
        /// Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.
        /// </summary>
        /// <param name="name">A string representing the FileSystemHandle.name of the entry you wish to remove.</param>
        /// <param name="recursive">A boolean value, which defaults to false. When set to true entries will be removed recursively.</param>
        /// <returns></returns>
        public Task RemoveEntry(string name, bool recursive = false) => JSRef!.CallVoidAsync("removeEntry", name, new RemoveEntryOptions { Recursive = recursive });
        /// <summary>
        /// The resolve() method of the FileSystemDirectoryHandle interface returns an Array of directory names from the parent handle to the specified child entry, with the name of the child entry as the last array item.
        /// </summary>
        /// <param name="possibleDescendant">The FileSystemHandle from which to return the relative path.</param>
        /// <returns>A Promise which resolves with an Array of strings, or null if possibleDescendant is not a descendant of this FileSystemDirectoryHandle.</returns>
        public Task<List<string>?> Resolve(FileSystemHandle possibleDescendant) => JSRef!.CallAsync<List<string>?>("resolve", possibleDescendant);
        /// <summary>
        /// Returns a new async iterator of a given object's own enumerable property [key, value] pairs.
        /// </summary>
        /// <returns></returns>
        public AsyncIterator<(string, FileSystemHandle)> Entries() => JSRef!.Call<AsyncIterator<(string, FileSystemHandle)>>("entries");
        /// <summary>
        /// Returns Entries as a Dictionary
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, FileSystemHandle>> EntriesDictionary() => (await EntriesList()).ToDictionary(o => o.Item1, o => o.Item2);
        /// <summary>
        /// Returns Entries as a List<br/>
        /// FileSystemHandle types are resolved to FileSystemFileHandle, or FileSystemDirectoryHandle depending on their type
        /// </summary>
        /// <returns></returns>
        public async Task<List<(string, FileSystemHandle)>> EntriesList()
        {
            using var entries = Entries();
            var files = await entries.ToList();
            return files.Select(kvp => (kvp.Item1, kvp.Item2.ResolveType(true))).ToList();
        }
        /// <summary>
        /// Returns a new async iterator of a given object's own enumerable property [key, value] pairs.
        /// </summary>
        /// <returns></returns>
        public async IAsyncEnumerable<(string, FileSystemHandle)> EntriesEnumerable()
        {
            using var entries = Entries();
            var files = entries.ToAsyncEnumerable();
            await foreach (var kvp in files)
            {
                yield return (kvp.Item1, kvp.Item2.ResolveType(true));
            }
        }
        /// <summary>
        /// Returns a new async iterator containing the values for each index in the FileSystemDirectoryHandle object.
        /// </summary>
        /// <returns></returns>
        public async IAsyncEnumerable<FileSystemHandle> ValuesEnumerable()
        {
            using var entries = Values();
            var files = entries.ToAsyncEnumerable();
            await foreach (var kvp in files)
            {
                yield return kvp.ResolveType(true);
            }
        }
        /// <summary>
        /// Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle.
        /// </summary>
        /// <returns></returns>
        public IAsyncEnumerable<string> KeysEnumerable() => Keys().ToAsyncEnumerable();
        /// <summary>
        /// Returns a new async iterator containing the values for each index in the FileSystemDirectoryHandle object.
        /// </summary>
        /// <returns></returns>
        public AsyncIterator<FileSystemHandle> Values() => JSRef!.Call<AsyncIterator<FileSystemHandle>>("values");
        /// <summary>
        /// Returns Values as a List<br/>
        /// FileSystemHandle types are resolved to FileSystemFileHandle, or FileSystemDirectoryHandle depending on their type
        /// </summary>
        /// <returns></returns>
        public Task<List<FileSystemHandle>> ValuesList() => Values().UsingAsync(async o => (await o.ToList()).Select(o => o.ResolveType(true)).ToList());
        /// <summary>
        /// Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle.
        /// </summary>
        /// <returns></returns>
        public AsyncIterator<string> Keys() => JSRef!.Call<AsyncIterator<string>>("keys");
        /// <summary>
        /// Returns a new async iterator containing the keys for each item in FileSystemDirectoryHandle.
        /// </summary>
        /// <returns></returns>
        public Task<List<string>> KeysList() => JSRef!.Call<AsyncIterator<string>>("keys").UsingAsync(async o => await o.ToList());
    }
}
