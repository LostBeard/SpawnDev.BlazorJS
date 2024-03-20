using Microsoft.JSInterop;
using System.Text.Json.Serialization;

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
        static async Task<List<FileSystemHandle>> IterateDirectoryAsync(AsyncIterator iteratee, bool includeFiles, bool includeDirectories)
        {
            var ret = new List<FileSystemHandle>();
            while (true)
            {
                JS.Set("_iteratee", iteratee);
                using (var next = await iteratee.Next())
                {
                    if (next.Done) break;
                    using (var f = next.GetValue<FileSystemHandle>())
                    {
                        FileSystemHandle? fid = null;
                        switch (f.Kind)
                        {
                            case "directory":
                                if (includeDirectories)
                                {
                                    fid = next.GetValue<FileSystemDirectoryHandle>();
                                }
                                break;
                            case "file":
                                if (includeFiles)
                                {
                                    fid = next.GetValue<FileSystemFileHandle>();
                                }
                                break;
                        }
                        if (fid != null) ret.Add(fid);
                    }
                }
            }
            return ret;
        }
        public async Task<FileSystemHandle?> GetEntryExt(string path)
        {
            var tmp = JSRefCopy<FileSystemDirectoryHandle>();
            path = path.Trim('/');
            if (string.IsNullOrEmpty(path) || path == ".") return tmp;
            FileSystemHandle? ret = null;
            var pparts = path.Split("/");
            for (var i = 0; i < pparts.Length; i++)
            {
                var p = pparts[i];
                var f = await tmp.GetEntry(p);
                if (i > 0) tmp?.Dispose();
                if (i == pparts.Length - 1)
                {
                    ret = f;
                }
                else if (f.Kind == "directory")
                {
                    tmp = f.JSRefMove<FileSystemDirectoryHandle>();
                }
                else
                {
                    break;
                }
            }
            tmp?.Dispose();
            return ret;
        }
        public async Task<FileSystemFileHandle?> GetFileExt(string path)
        {
            var ret = await GetEntryExt(path);
            if (ret == null) return null;
            if (ret.Kind == "directory")
            {
                ret.Dispose();
                return null;
            }
            return ret == null ? null : ret.JSRefMove<FileSystemFileHandle>();
        }
        public async Task<FileSystemDirectoryHandle?> GetDirExt(string path)
        {
            var ret = await GetEntryExt(path);
            if (ret == null) return null;
            if (ret.Kind != "directory")
            {
                ret.Dispose();
                return null;
            }
            return ret == null ? null : ret.JSRefMove<FileSystemDirectoryHandle>();
        }
        public async Task<FileSystemHandle?> GetEntry(string name, StringComparison stringComp = StringComparison.OrdinalIgnoreCase)
        {
            FileSystemHandle? ret = null;
            var entries = await Values();
            foreach (var d in entries)
            {
                if (d.Name.Equals(name, stringComp)) ret = d;
                else d.Dispose();
            }
            return ret;
        }
        public class RemoveEntryOptions
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool? Recursive { get; set; }
        }
        /// <summary>
        /// Attempts to asynchronously remove an entry if the directory handle contains a file or directory called the name specified.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public Task RemoveEntry(string name, bool recursive = false) => JSRef.CallVoidAsync("removeEntry", name, new RemoveEntryOptions { Recursive = recursive });
        public class GetHandleOptions
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool? Create { get; set; }
        }
        /// <summary>
        /// Returns a Promise fulfilled with a FileSystemFileHandle for a file with the specified name, within the directory the method is called.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public Task<FileSystemFileHandle> GetFileHandle(string name, bool create = false) => JSRef.CallAsync<FileSystemFileHandle>("getFileHandle", name, new GetHandleOptions { Create = create });
        /// <summary>
        /// Returns a Promise fulfilled with a FileSystemDirectoryHandle for a subdirectory with the specified name within the directory handle on which the method is called.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        public Task<FileSystemDirectoryHandle> GetDirectoryHandle(string name, bool create = false) => JSRef.CallAsync<FileSystemDirectoryHandle>("getDirectoryHandle", name, new GetHandleOptions { Create = create });
        /// <summary>
        /// Returns a new async iterator of a given object's own enumerable property [key, value] pairs.
        /// </summary>
        /// <returns></returns>
        public async Task<Dictionary<string, FileSystemHandle>> Entries()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("values");
            var files = await valuesIterator.ToList<FileSystemHandle>();
            var typed = files.Select(o => o.ResolveType()).ToList();
            files.DisposeAll();
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
            var typed = files.Select(o => o.ResolveType()).ToList();
            files.DisposeAll();
            return typed;
        }

        public async Task<List<string>> Keys()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("keys");
            var keys = await valuesIterator.ToList<string>();
            return keys;
        }
    }
}
