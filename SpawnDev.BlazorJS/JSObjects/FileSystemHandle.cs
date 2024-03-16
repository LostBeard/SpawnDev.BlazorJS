using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle
    public class FileSystemHandle : JSObject {
        public FileSystemHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string Name => JSRef.Get<string>("name");
        public string Kind => JSRef.Get<string>("kind");
        public bool IsSameEntry(FileSystemHandle fsHandle) => JSRef.Call<bool>("isSameEntry", fsHandle);

        public FileSystemHandle ResolveType() => Kind == "directory" ? JS.ReturnMe<FileSystemDirectoryHandle>(this) : JS.ReturnMe<FileSystemFileHandle>(this);
        public FileSystemDirectoryHandle? ToFileSystemDirectoryHandle() => Kind == "directory" ? JS.ReturnMe<FileSystemDirectoryHandle>(this) : null;
        public FileSystemFileHandle? ToFileSystemFileHandle() => Kind == "file" ? JS.ReturnMe<FileSystemFileHandle>(this) : null;

        public async Task<string> GetReadWritePermissions() {
            if (await IsWritable()) return "rw";
            if (await IsReadable()) return "r";
            return "";
        }

        public async Task<bool> IsWritable() {
            try {
                return await VerifyPermission(true, false);
            }
            catch { }
            return false;
        }

        public async Task<bool> IsReadable() {
            try {
                return await VerifyPermission(false, false);
            }
            catch { }
            return false;
        }

        public class FilePermissionsOptions
        {
            public string Mode { get; set; } = "";
            public FilePermissionsOptions(bool readWriteMode = false)
            {
                Mode = readWriteMode ? MODE_READ_WRITE : MODE_READ;
            }
        }

        // Experimental
        // Compatibility:
        // Firefox  unsupported
        // Chrome   supported
        // non-standard implementation to prevent need to polyfill when used
        public async Task<string> QueryPermission(bool writePermission = false) {
            if (JSRef.PropertyType("queryPermission") == "undefined")
            {
                return PERMISSION_GRANTED;
            }
            return await JSRef.CallAsync<string>("queryPermission", new FilePermissionsOptions(writePermission));
        }

        public async Task<string> RequestPermission(bool writePermission = false) {
            if (JSRef.PropertyType("requestPermission") == "undefined")
            {
                return PERMISSION_GRANTED;
            }
            return await JSRef.CallAsync<string>("requestPermission", new FilePermissionsOptions(writePermission));
        }
        /// <summary>
        /// "granted"
        /// </summary>
        public static string PERMISSION_GRANTED = "granted";
        /// <summary>
        /// "denied"
        /// </summary>
        public static string PERMISSION_DENIED = "denied";
        /// <summary>
        /// "prompt"
        /// </summary>
        public static string PERMISSION_PROMPT = "prompt";
        /// <summary>
        /// "read"
        /// </summary>
        public static string MODE_READ = "read";
        /// <summary>
        /// "readwrite"
        /// </summary>
        public static string MODE_READ_WRITE = "readwrite";

        public async Task<bool> VerifyPermission(bool readWrite = true, bool askIfNeeded = true) {
            var permState = await QueryPermission(readWrite);
            if (!askIfNeeded || permState == PERMISSION_DENIED)
            {
                return permState == PERMISSION_GRANTED;
            }
            //if ((await QueryPermission(readWrite)) == PERMISSION_GRANTED) return true;
            if (askIfNeeded && (await RequestPermission(readWrite)) == PERMISSION_GRANTED) return true;
            return false;
        }
    }
}
