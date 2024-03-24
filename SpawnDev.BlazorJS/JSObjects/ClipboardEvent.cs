using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ClipboardEvent interface of the Clipboard API represents events providing information related to modification of the clipboard, that is cut, copy, and paste events.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ClipboardEvent
    /// </summary>
    public class ClipboardEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ClipboardEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A DataTransfer object containing the data affected by the user-initiated cut, copy, or paste operation, along with its MIME type.
        /// </summary>
        public DataTransfer ClipboardData => JSRef.Get<DataTransfer>("clipboardData");
    }
}
