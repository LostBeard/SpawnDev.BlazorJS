using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaEncryptedEvent interface of the Encrypted Media Extensions API contains the information associated with an encrypted event sent to a HTMLMediaElement when some initialization data is encountered in the media.
    /// </summary>
    public class MediaEncryptedEvent : Event
    {
        public MediaEncryptedEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns an ArrayBuffer containing the initialization data found. If there is no initialization data associated with the format, it returns null.
        /// </summary>
        public ArrayBuffer? InitData => JSRef!.Get<ArrayBuffer?>("initData");
        /// <summary>
        /// Returns a case-sensitive string with the type of the format of the initialization data found.
        /// </summary>
        public string InitDataType => JSRef!.Get<string>("initDataType");
    }
}
