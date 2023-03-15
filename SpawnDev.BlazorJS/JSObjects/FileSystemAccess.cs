using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects {
    public class FileSystemAccessPickerFilter {
        public string description { get; set; } = "";
        public Dictionary<string, List<string>> accept = new Dictionary<string, List<string>>();
    }
    public class FileSystemAccess : IDisposable {
        // https://developer.mozilla.org/en-US/docs/Web/API/File_System_Access_API
        // https://web.dev/file-system-access/
        // 

        IJSInProcessObjectReference window;
        public static bool Supported => JS.TypeOf("window.showOpenFilePicker") != "undefined";

        public FileSystemAccess() {
            window = JS.Get<IJSInProcessObjectReference>("window");
            //Supported = IJSObject.TypeOf("window.showOpenFilePicker") == "undefined";
            Console.WriteLine("!!! The class FileSystemAccess is being used but has not beem tested completely. Please report bugs"); ;
        }

        public async Task<List<FileSystemFileHandle>> ShowOpenFilePicker(bool multiple = true, bool excludeAcceptAllOption = false, List<FileSystemAccessPickerFilter> filters = null) {
            dynamic pickerOptions = new ExpandoObject();
            pickerOptions.excludeAcceptAllOption = excludeAcceptAllOption;
            pickerOptions.multiple = multiple;
            if (filters != null) pickerOptions.accept = filters;
            List<FileSystemFileHandle> ret;
            using var fileSystemDirectoryHandle = await window.CallAsync<IJSInProcessObjectReference>("showOpenFilePicker", (object)pickerOptions);
            using var valuesIterator = fileSystemDirectoryHandle.Get<IJSInProcessObjectReference>("values");
            ret = await IterateAsync<FileSystemFileHandle>(valuesIterator);
            return ret;
        }

        public async Task<JSObject> ShowSaveFilePicker(ExpandoObject pickerOptions = null) {
            if (pickerOptions == null)
                return await window.CallAsync<JSObject>("showSaveFilePicker");
            else
                return await window.CallAsync<JSObject>("showSaveFilePicker", pickerOptions);
        }

        // https://developer.mozilla.org/en-US/docs/Web/API/Window/showDirectoryPicker
        public async Task<FileSystemDirectoryHandle> ShowDirectoryPicker() {
            try {
                return await window.CallAsync<FileSystemDirectoryHandle>("showDirectoryPicker");
            }
            catch { }
            return null;
        }

        //public async Task<bool> VerifyPermission(IJSObject fileHandle, bool readWrite = true, bool askIfNeeded = true)
        //{
        //    dynamic options = new ExpandoObject();
        //    if (readWrite) options.mode = "readwrite";
        //    if ((await fileHandle.GetPropertyAsync<string>("queryPermission", options)) == "granted") return true;
        //    if (askIfNeeded && (await fileHandle.GetPropertyAsync<string>("requestPermission", options)) == "granted") return true;
        //    return false;
        //}

        static async Task<List<T>> IterateAsync<T>(IJSInProcessObjectReference iteratee) {
            var ret = new List<T>();
            while (true) {
                using (var next = await iteratee.CallAsync<IJSInProcessObjectReference>("next")) {
                    if (next.Get<bool>("done")) break;
                    ret.Add(next.Get<T>("value"));
                }
            }
            return ret;
        }

        //public async Task<List<IJSObject>> DirectoryGetFileHandles(IJSObject fileSystemDirectoryHandle)
        //{
        //    List<IJSObject> files = null;
        //    using (IJSObject valuesIterator = fileSystemDirectoryHandle.GetProperty<IJSObject>("values"))
        //    {
        //        files = await IterateAsync<IJSObject>(valuesIterator);
        //    }
        //    return files;
        //}

        public bool IsDisposed { get; private set; } = false;
        public void Dispose() {
            if (IsDisposed) return;
            IsDisposed = true;
            window.Dispose();
        }
    }
}
