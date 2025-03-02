using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DataTransferItem object represents one drag data item. During a drag operation, each drag event has a dataTransfer property which contains a list of drag data items. Each item in the list is a DataTransferItem object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem
    /// </summary>
    public class DataTransferItem : JSObject
    {
        /// <inheritdoc />
        public DataTransferItem(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The kind of drag data item, string or file.
        /// </summary>
        public string Kind => JSRef!.Get<string>("kind");
        /// <summary>
        /// The drag data item's type, typically a MIME type.
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        /// <summary>
        /// Returns the File object associated with the drag data item (or null if the drag item is not a file).
        /// </summary>
        /// <returns></returns>
        public File? GetAsFile() => JSRef!.Call<File?>("getAsFile");
        /// <summary>
        /// Returns a FileSystemFileHandle if the dragged item is a file, or a FileSystemDirectoryHandle if the dragged item is a directory.
        /// </summary>
        /// <returns></returns>
        public FileSystemHandle? GetAsFileSystemHandle() => JSRef!.Call<FileSystemHandle?>("getAsFileSystemHandle");
        /// <summary>
        /// Invokes the specified callback with the drag data item string as its argument.
        /// </summary>
        /// <returns></returns>
        public string? GetAsString() => JSRef!.Call<string?>("getAsString");
        private bool HasGetAsEntry => !JSRef!.IsUndefined("getAsEntry");
        private bool HasWebkitGetAsEntry => !JSRef!.IsUndefined("webkitGetAsEntry");
        /// <summary>
        /// Returns a FileSystemEntry object if the drag data item is a file or directory, or null otherwise.<br/>
        /// webkitGetAsEntry is used if it is found, getAsEntry is used if it is found, otherwise null is returned.
        /// </summary>
        /// <returns>A FileSystemDirectoryEntry, a FileSystemFileEntry, a FileSystemEntry, or null</returns>
        public FileSystemEntry? GetAsEntry()
        {
            FileSystemEntry? ret = null;
            if (HasWebkitGetAsEntry)
            {
                ret = JSRef!.Call<FileSystemEntry?>("webkitGetAsEntry");
            }
            else if (HasGetAsEntry)
            {
                ret = JSRef!.Call<FileSystemEntry?>("getAsEntry");
            }
            if (ret != null)
            {
                if (ret.IsDirectory) ret = ret.JSRefMove<FileSystemDirectoryEntry>();
                else if (ret.IsFile) ret = ret.JSRefMove<FileSystemFileEntry>();
            }
            return ret;
        }
    }
}
