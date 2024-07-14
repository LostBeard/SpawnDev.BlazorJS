using Microsoft.JSInterop;
using System.Dynamic;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The FileSystemHandle interface of the File System API is an object which represents a file or directory entry. Multiple handles can represent the same entry. For the most part you do not work with FileSystemHandle directly but rather its child interfaces FileSystemFileHandle and FileSystemDirectoryHandle.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystemHandle
    /// </summary>
    public class FileSystemHandle : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public FileSystemHandle(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the name of the associated entry.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// Returns the type of entry. This is 'file' if the associated entry is a file or 'directory'.
        /// </summary>
        public string Kind => JSRef!.Get<string>("kind");
        /// <summary>
        /// Compares two handles to see if the associated entries (either a file or directory) match.
        /// </summary>
        /// <param name="fsHandle"></param>
        /// <returns></returns>
        public bool IsSameEntry(FileSystemHandle fsHandle) => JSRef!.Call<bool>("isSameEntry", fsHandle);
        /// <summary>
        /// Returns a FileSystemDirectoryHandle or FileSystemFileHandle based on the FileSystemHandle.Kind
        /// </summary>
        /// <param name="moveJSRef">If true, the IJSInProcessReference from this JSObject is moved to the new type instead of copied</param>
        /// <returns></returns>
        public FileSystemHandle ResolveType(bool moveJSRef = false)
        {
            if (Kind == "directory")
            {
                return moveJSRef ? JSRefMove<FileSystemDirectoryHandle>() : JSRefCopy<FileSystemDirectoryHandle>();
            }
            else
            {
                return moveJSRef ? JSRefMove<FileSystemFileHandle>() : JSRefCopy<FileSystemFileHandle>();
            }
        }
        /// <summary>
        /// Returns a FileSystemDirectoryHandle JSObject for this entry if this entry Kind is directory
        /// </summary>
        /// <returns></returns>
        public FileSystemDirectoryHandle? ToFileSystemDirectoryHandle(bool moveJSRef = false) => Kind == "directory" ? (moveJSRef ? JSRefMove<FileSystemDirectoryHandle>() : JSRefCopy<FileSystemDirectoryHandle>()) : null;
        /// <summary>
        /// Returns a FileSystemFileHandle JSObject for this entry if this entry Kind is file
        /// </summary>
        /// <param name="moveJSRef"></param>
        /// <returns></returns>
        public FileSystemFileHandle? ToFileSystemFileHandle(bool moveJSRef = false) => Kind == "file" ? (moveJSRef ? JSRefMove<FileSystemFileHandle>() : JSRefCopy<FileSystemFileHandle>()) : null;
        /// <summary>
        /// Returns a string with "r", "rw", or "" indicating read, write permissions
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetReadWritePermissions()
        {
            if (await IsWritable()) return "rw";
            if (await IsReadable()) return "r";
            return "";
        }
        /// <summary>
        /// Returns true if the FileSystemHandle is writable
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsWritable()
        {
            try
            {
                return await VerifyPermission(true, false);
            }
            catch { }
            return false;
        }
        /// <summary>
        /// Returns true if the FileSystemHandle is readable
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsReadable()
        {
            try
            {
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
        public async Task<string> QueryPermission(bool writePermission = false)
        {
            if (JSRef!.PropertyType("queryPermission") == "undefined")
            {
                return PERMISSION_GRANTED;
            }
            return await JSRef!.CallAsync<string>("queryPermission", new FilePermissionsOptions(writePermission));
        }

        public async Task<string> RequestPermission(bool writePermission = false)
        {
            if (JSRef!.PropertyType("requestPermission") == "undefined")
            {
                return PERMISSION_GRANTED;
            }
            return await JSRef!.CallAsync<string>("requestPermission", new FilePermissionsOptions(writePermission));
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

        public async Task<bool> VerifyPermission(bool readWrite = true, bool askIfNeeded = true)
        {
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
