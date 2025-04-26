using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ClipboardItem interface of the Clipboard API represents a single item format, used when reading or writing clipboard data using clipboard.read() and clipboard.write() respectively.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ClipboardItem
    /// </summary>
    public class ClipboardItem : JSObject
    {
        /// <inheritdoc/>
        public ClipboardItem(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public ClipboardItem(Dictionary<string, Union<string, Blob, Task<string>, Task<Blob>>> data, ClipboardItemOptions? options = null) : base(JS.New(nameof(ClipboardItem), data, options)) { }
        /// <summary>
        /// The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public ClipboardItem(Dictionary<string, string> data, ClipboardItemOptions? options = null) : base(JS.New(nameof(ClipboardItem), data, options)) { }
        /// <summary>
        /// The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public ClipboardItem(Dictionary<string, Blob> data, ClipboardItemOptions? options = null) : base(JS.New(nameof(ClipboardItem), data, options)) { }
        /// <summary>
        /// The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public ClipboardItem(Dictionary<string, Task<string>> data, ClipboardItemOptions? options = null) : base(JS.New(nameof(ClipboardItem), data, options)) { }
        /// <summary>
        /// The ClipboardItem() constructor creates a new ClipboardItem object, which represents data to be stored or retrieved via the Clipboard API clipboard.write() and clipboard.read() methods, respectively.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public ClipboardItem(Dictionary<string, Task<Blob>> data, ClipboardItemOptions? options = null) : base(JS.New(nameof(ClipboardItem), data, options)) { }
        /// <summary>
        /// Returns an Array of MIME types available within the ClipboardItem.
        /// </summary>
        public string[] Types => JSRef!.Call<string[]>("types");
        /// <summary>
        /// Returns one of the following: "unspecified", "inline" or "attachment".<br/>
        /// Support varies by browser<br/>
        /// </summary>
        public string? PresentationStyle => JSRef!.Call<string?>("presentationStyle");
        /// <summary>
        /// Checks whether a given MIME type is supported by the clipboard. This enables a website to detect whether a MIME type is supported before attempting to write data.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool Supports(string type) => JS.Call<bool>("ClipboardItem.supports", type);
        /// <summary>
        /// Returns a Promise that resolves with a Blob of the requested MIME type, or an error if the MIME type is not found.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Task<Blob> GetType(string type) => JSRef!.CallAsync<Blob>("getType", type);
    }
}
