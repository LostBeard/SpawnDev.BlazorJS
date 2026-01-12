using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DocumentPictureInPictureEvent interface of the Document Picture-in-Picture API is the event object for the enter event, which fires when the Picture-in-Picture window is opened.
    /// </summary>
    public class DocumentPictureInPictureEvent : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DocumentPictureInPictureEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Window instance representing the browsing context inside the DocumentPictureInPicture window the event was fired on.
        /// </summary>
        public Window? Window => JSRef!.Get<Window?>("window");
    }
}
