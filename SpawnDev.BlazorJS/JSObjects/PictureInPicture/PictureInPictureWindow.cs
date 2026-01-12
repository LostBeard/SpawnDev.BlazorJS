using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The PictureInPictureWindow interface represents an object able to programmatically obtain the Width and Height of the floating video window. An object with this interface is obtained by the promise returned by the HTMLVideoElement.requestPictureInPicture() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/PictureInPictureWindow
    /// </summary>
    public class PictureInPictureWindow : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public PictureInPictureWindow(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The width of the floating video window.
        /// </summary>
        public int Width => JSRef!.Get<int>("width");
        /// <summary>
        /// The height of the floating video window.
        /// </summary>
        public int Height => JSRef!.Get<int>("height");
        /// <summary>
        /// Fired when the floating video window is resized.
        /// </summary>
        public ActionEvent<Event> OnResize { get => new ActionEvent<Event>("resize", AddEventListener, RemoveEventListener); set { } }
    }
}
