using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The DocumentPictureInPicture interface of the Document Picture-in-Picture API is the entry point for creating and handling document picture-in-picture windows.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/DocumentPictureInPicture
    /// </summary>
    public class DocumentPictureInPicture : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public DocumentPictureInPicture(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Window instance representing the browsing context inside the Picture-in-Picture window.
        /// </summary>
        public Window? Window => JSRef.Get<Window?>("window");
        /// <summary>
        /// Opens the Picture-in-Picture window for the current main browsing context. Returns a Promise that fulfills with a Window instance representing the browsing context inside the Picture-in-Picture window.
        /// </summary>
        /// <returns></returns>
        public Task<Window> RequestWindow() => JSRef.CallAsync<Window?>("requestWindow");
        /// <summary>
        /// Opens the Picture-in-Picture window for the current main browsing context. Returns a Promise that fulfills with a Window instance representing the browsing context inside the Picture-in-Picture window.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<Window> RequestWindow(PIPRequestWindowOptions options) => JSRef.CallAsync<Window?>("requestWindow", options);
        /// <summary>
        /// Fired when the Picture-in-Picture window is successfully opened.
        /// </summary>
        public JSEventCallback Enter { get => new JSEventCallback(o => AddEventListener("enter", o), o => RemoveEventListener("enter", o)); set { /** set MUST BE HERE TO ENABLE += -= operands **/ } }
    }
}
