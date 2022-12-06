using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    // TODO - NEEDS TESTING SINCE JSINTEROP CHANGE!!!!
    // https://developer.mozilla.org/en-US/docs/Web/API/File
    [JsonConverter(typeof(JSObjectConverter<FileSystemDirectoryHandle>))]
    public class FileSystemDirectoryHandle : FileSystemHandle
    {
        public FileSystemDirectoryHandle(IJSInProcessObjectReference _ref) : base(_ref) { }

        public async Task<File> GetFile() => await JSRef.CallAsync<File>("getFile");

        public static async Task<List<FileSystemHandle>> IterateDirectoryAsync(JSObject iteratee, bool includeFiles, bool includeDirectories)
        {
            var ret = new List<FileSystemHandle>();
            while (true)
            {
                try
                {
                    using (var next = await iteratee.JSRef.CallAsync<JSObject>("next"))
                    {
                        if (next.JSRef.Get<bool>("done")) break;
                        using (FileSystemHandle f = next.JSRef.Get<FileSystemHandle>("value"))
                        {
                            FileSystemHandle fid = null;
                            switch (f.Kind)
                            {
                                case "directory":
                                    if (includeDirectories)
                                    {
                                        fid = f.ConvertToIJSObject<FileSystemDirectoryHandle>();
                                    }
                                    break;
                                case "file":
                                    if (includeFiles)
                                    {
                                        fid = f.ConvertToIJSObject<FileSystemFileHandle>();
                                    }
                                    break;
                            }
                            if (fid != null) ret.Add(fid);
                        }
                    }
                } 
                catch
                {
#if DEBUG
                    Console.WriteLine("IterateDirectoryAsync exception. Folder may not be available.");
#endif
                    break;
                }
            }
            return ret;
        }

        public async Task<FileSystemHandle> GetEntryExt(string path)
        {
            FileSystemDirectoryHandle tmp = JS.CopyReference<FileSystemDirectoryHandle>(this);
            path = path.Trim('/');
            if (string.IsNullOrEmpty(path) || path == ".") return tmp;
            FileSystemHandle ret = null;
            var pparts = path.Split("/");
            for (var i = 0; i < pparts.Length; i++)
            {
                var p = pparts[i];
                FileSystemHandle f = await tmp.GetEntry(p);
                if (i > 0) tmp?.Dispose();
                if (i == pparts.Length - 1)
                {
                    ret = f;
                } 
                else if (f.Kind == "directory")
                {
                    tmp = f.ConvertToIJSObject<FileSystemDirectoryHandle>();
                } 
                else
                {
                    break;
                }
            }
            tmp?.Dispose();
            return ret;
        }
        public async Task<FileSystemFileHandle> GetFileExt(string path)
        {
            var ret = await GetEntryExt(path);
            if (ret == null) return null;
            if (ret.Kind == "directory")
            {
                ret.Dispose();
                return null;
            }
            return ret == null ? null : ret.ConvertToIJSObject<FileSystemFileHandle>();
        }

        public async Task<FileSystemDirectoryHandle> GetDirExt(string path)
        {
            var ret = await GetEntryExt(path);
            if (ret == null) return null;
            if (ret.Kind != "directory")
            {
                ret.Dispose();
                return null;
            }
            return ret == null ? null : ret.ConvertToIJSObject<FileSystemDirectoryHandle>();
        }

        public async Task<FileSystemHandle> GetEntry(string name, StringComparison stringComp = StringComparison.OrdinalIgnoreCase)
        {
            // temporary workaround
            // not sure why but the Promise returned by getDirectoryHandle is never resolved
#if true
            FileSystemHandle ret = null;
            var entries = await Entries();
            foreach (var d in entries)
            {
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

        public async Task<FileSystemFileHandle> GetFileHandle(string name, bool create = false, StringComparison stringComp = StringComparison.OrdinalIgnoreCase)
        {
            // temporary workaround
            // not sure why but the Promise returned by getDirectoryHandle is never resolved
#if true
            FileSystemFileHandle ret = null;
            var entries = await GetFileEntries();
            foreach (var d in entries)
            {
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

        public async Task<FileSystemDirectoryHandle> GetDirectoryHandle(string name, bool create = false, StringComparison stringComp = StringComparison.OrdinalIgnoreCase)
        {
            // temporary workaround
            // not sure why but the Promise returned by getDirectoryHandle is never resolved
#if true
            FileSystemDirectoryHandle ret = null;
            var dirs = await GetDirectoryEntries();
            foreach (var d in dirs)
            {
                if (d.Name.Equals(name, stringComp)) ret = d;
                else d.Dispose();
            }
            return ret;
#else
            dynamic options = new ExpandoObject();
            options.create = create;
            var ret = await GetPropertyAsync<FileSystemDirectoryHandle>("getDirectoryHandle", name, options);
            return ret;
#endif
        }

        public async Task<List<FileSystemHandle>> Entries()
        {
            List<FileSystemHandle> files = null;
            using (var valuesIterator = JSRef.Get<JSObject>("values"))
            {
                files = await IterateDirectoryAsync(valuesIterator, true, true);
            }
            return files;
        }

        public async Task<List<FileSystemFileHandle>> GetFileEntries()
        {
            List<FileSystemFileHandle> files = new List<FileSystemFileHandle>();
            using (var valuesIterator = JSRef.Call<JSObject>("values"))
            {
                var tmp = await IterateDirectoryAsync(valuesIterator, true, false);
                foreach (var t in tmp) files.Add((FileSystemFileHandle)t);
            }
            return files;
        }

        public async Task<List<FileSystemDirectoryHandle>> GetDirectoryEntries()
        {
            List<FileSystemDirectoryHandle> files = new List<FileSystemDirectoryHandle>();
            using (var valuesIterator = JSRef.Call<JSObject>("values"))
            {
                var tmp = await IterateDirectoryAsync(valuesIterator, false, true);
                foreach(var t in tmp) files.Add((FileSystemDirectoryHandle)t);
            }
            return files;
        }
    }
}
