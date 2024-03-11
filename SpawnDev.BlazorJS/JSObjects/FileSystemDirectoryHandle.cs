using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects {
    // TODO - NEEDS TESTING SINCE JSINTEROP CHANGE!!!!
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    public class FileSystemDirectoryHandle : FileSystemHandle {
        public FileSystemDirectoryHandle(IJSInProcessObjectReference _ref) : base(_ref) { }

        public async Task<File> GetFile() => await JSRef.CallAsync<File>("getFile");

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

//        public static async Task<List<FileSystemHandle>> IterateDirectoryAsync(IJSInProcessObjectReference iteratee, bool includeFiles, bool includeDirectories) {
//            var ret = new List<FileSystemHandle>();
//            while (true) {
//                try {
//                    using (var next = await iteratee.CallAsync<IJSInProcessObjectReference>("next")) {
//                        if (next.Get<bool>("done")) break;
//                        using (var f = next.Get<FileSystemHandle>("value")) {
//                            FileSystemHandle? fid = null;
//                            switch (f.Kind) {
//                                case "directory":
//                                    if (includeDirectories) {
//                                        fid = next.Get<FileSystemDirectoryHandle>("value");
//                                    }
//                                    break;
//                                case "file":
//                                    if (includeFiles) {
//                                        fid = next.Get<FileSystemFileHandle>("value");
//                                    }
//                                    break;
//                            }
//                            if (fid != null) ret.Add(fid);
//                        }
//                    }
//                }
//                catch {
//#if DEBUG
//                    Console.WriteLine("IterateDirectoryAsync exception. Folder may not be available.");
//#endif
//                    break;
//                }
//            }
//            return ret;
//        }

        public async Task<FileSystemHandle> GetEntryExt(string path) {
            FileSystemDirectoryHandle tmp = JSRefCopy<FileSystemDirectoryHandle>();
            path = path.Trim('/');
            if (string.IsNullOrEmpty(path) || path == ".") return tmp;
            FileSystemHandle? ret = null;
            var pparts = path.Split("/");
            for (var i = 0; i < pparts.Length; i++) {
                var p = pparts[i];
                FileSystemHandle f = await tmp.GetEntry(p);
                if (i > 0) tmp?.Dispose();
                if (i == pparts.Length - 1) {
                    ret = f;
                }
                else if (f.Kind == "directory") {
                    tmp = f.JSRefMove<FileSystemDirectoryHandle>();
                }
                else {
                    break;
                }
            }
            tmp?.Dispose();
            return ret;
        }
        public async Task<FileSystemFileHandle> GetFileExt(string path) {
            var ret = await GetEntryExt(path);
            if (ret == null) return null;
            if (ret.Kind == "directory") {
                ret.Dispose();
                return null;
            }
            return ret == null ? null : ret.JSRefMove<FileSystemFileHandle>();
        }

        public async Task<FileSystemDirectoryHandle> GetDirExt(string path) {
            var ret = await GetEntryExt(path);
            if (ret == null) return null;
            if (ret.Kind != "directory") {
                ret.Dispose();
                return null;
            }
            return ret == null ? null : ret.JSRefMove<FileSystemDirectoryHandle>();
        }

        public async Task<FileSystemHandle> GetEntry(string name, StringComparison stringComp = StringComparison.OrdinalIgnoreCase) {
            // temporary workaround
            // not sure why but the Promise returned by getDirectoryHandle is never resolved
#if true
            FileSystemHandle ret = null;
            var entries = await Values();
            foreach (var d in entries) {
                if (d.Name.Equals(name, stringComp)) ret = d;
                else d.Dispose();
            }
            return ret;
#else
            dynamic options = new ExpandoObject();
            options.create = create;
            var ret = await GetPropertyAsync<FileSystemFileHandle>("getFileHandle", name, options);
            return ret;
#endif
        }

        public class RemoveEntryOptions
        {
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public bool? Recursive { get; set; }
        }
        public Task RemoveEntry(string name, bool recursive = false) => JSRef.CallVoidAsync("removeEntry", name, new RemoveEntryOptions { Recursive = recursive });

        public class GetHandleOptions
        {
            public bool Create { get; set; }
        }
        public Task<FileSystemFileHandle?> GetFileHandle(string name, bool create = false) => JSRef.CallAsync<FileSystemFileHandle?>("getFileHandle", name, new GetHandleOptions { Create = create });
        public Task<FileSystemDirectoryHandle?> GetDirectoryHandle(string name, bool create = false) => JSRef.CallAsync<FileSystemDirectoryHandle?>("getDirectoryHandle", name, new GetHandleOptions { Create = create });

        public async Task<Dictionary<string, FileSystemHandle>> Entries()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("values");
            //var files1 = valuesIterator.ToAsyncEnumerable<FileSystemFileHandle>();
            //await foreach(var f in files1)
            //{
            //}
            //var files = await IterateDirectoryAsync(valuesIterator, true, true);
            var files = await valuesIterator.ToList<FileSystemHandle>();
            var typed = files.Select(o => o.ResolveType()).ToList();
            files.DisposeAll();
            return typed.ToDictionary(o => o.Name, o => o);
        }
        public async Task<List<FileSystemHandle>> Values()
        {
            using var valuesIterator = JSRef.Call<AsyncIterator>("values");
            //var files1 = valuesIterator.ToAsyncEnumerable<FileSystemFileHandle>();
            //await foreach(var f in files1)
            //{
            //}
            //var files = await IterateDirectoryAsync(valuesIterator, true, true);
            var files = await valuesIterator.ToList<FileSystemHandle>();
            var typed = files.Select(o => o.ResolveType()).ToList();
            files.DisposeAll();
            return typed;
        }

        //public async Task<List<FileSystemHandle>> Entries() {
        //    using var valuesIterator = JSRef.Get<IJSInProcessObjectReference>("values");
        //    var files = await IterateDirectoryAsync(valuesIterator, true, true);
        //    return files;
        //}

        //public async Task<List<FileSystemFileHandle>> GetFileEntries() {
        //    List<FileSystemFileHandle> files = new List<FileSystemFileHandle>();
        //    using (var valuesIterator = JSRef.Call<AsyncIterator>("values")) {
        //        var tmp = await IterateDirectoryAsync(valuesIterator, true, false);
        //        foreach (var t in tmp) files.Add((FileSystemFileHandle)t);
        //    }
        //    return files;
        //}

        //public async Task<List<FileSystemDirectoryHandle>> GetDirectoryEntries() {
        //    List<FileSystemDirectoryHandle> files = new List<FileSystemDirectoryHandle>();
        //    using (var valuesIterator = JSRef.Call<AsyncIterator>("values")) {
        //        var tmp = await IterateDirectoryAsync(valuesIterator, false, true);
        //        foreach (var t in tmp) files.Add((FileSystemDirectoryHandle)t);
        //    }
        //    return files;
        //}
    }
}
