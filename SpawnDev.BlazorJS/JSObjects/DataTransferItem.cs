using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DataTransferItem object represents one drag data item. During a drag operation, each drag event has a dataTransfer property which contains a list of drag data items. Each item in the list is a DataTransferItem object.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DataTransferItem
    /// </summary>
    public class DataTransferItem : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
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
    }
}
