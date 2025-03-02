using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The File and Directory Entries API interface FileSystem is used to represent a file system. These objects can be obtained from the filesystem property on any file system entry. Some browsers offer additional APIs to create and manage file systems, such as Chrome's requestFileSystem() method.<br/>
    /// This interface will not grant you access to the users' filesystem. Instead, you will have a "virtual drive" within the browser sandbox if you want to gain access to the users' file system, you need to invoke the user, for example by installing a Chrome extension. The relevant Chrome API can be found here.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/FileSystem
    /// </summary>
    public class FileSystem : JSObject
    {
        /// <inheritdoc />
        public FileSystem(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string representing the file system's name. This name is unique among the entire list of exposed file systems.
        /// </summary>
        public string Name => JSRef!.Get<string>("name");
        /// <summary>
        /// A FileSystemDirectoryEntry object which represents the file system's root directory. Through this object, you can gain access to all files and directories in the file system.
        /// </summary>
        public FileSystemEntry Root => JSRef!.Get<FileSystemEntry>("root");
    }
}
