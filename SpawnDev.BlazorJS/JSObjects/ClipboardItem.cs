using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ClipboardItem interface of the Clipboard API represents a single item format, used when reading or writing clipboard data using clipboard.read() and clipboard.write() respectively.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ClipboardItem
    /// </summary>
    public class ClipboardItem : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ClipboardItem(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
