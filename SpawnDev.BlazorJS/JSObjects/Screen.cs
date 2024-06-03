using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Screen interface represents a screen, usually the one on which the current window is being rendered, and is obtained using window.screen.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/Screen
    /// </summary>
    public class Screen : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public Screen(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Specifies the height of the screen, in pixels, minus permanent or semipermanent user interface features displayed by the operating system, such as the Taskbar on Windows.
        /// </summary>
        public int AvailHeight => JSRef!.Get<int>("availHeight");
        /// <summary>
        /// A number representing the x-coordinate (left-hand edge) of the available screen area.
        /// </summary>
        public int? AvailLeft => JSRef!.Get<int?>("availLeft");
        /// <summary>
        /// A number representing the y-coordinate (top edge) of the available screen area.
        /// </summary>
        public int? AvailTop => JSRef!.Get<int?>("availTop");
        /// <summary>
        /// Returns the amount of horizontal space in pixels available to the window.
        /// </summary>
        public int AvailWidth => JSRef!.Get<int>("availWidth");
        /// <summary>
        /// Returns the color depth of the screen.
        /// </summary>
        public int ColorDepth => JSRef!.Get<int>("colorDepth");
        /// <summary>
        /// Returns the height of the screen in pixels.
        /// </summary>
        public int Height => JSRef!.Get<int>("height");
        /// <summary>
        /// Returns true if the user's device has multiple screens, and false if not.
        /// </summary>
        public bool IsExtended => JSRef!.Get<bool>("isExtended");
        /// <summary>
        /// Returns the ScreenOrientation instance associated with this screen.<br/>
        /// inconsistent browser support
        /// </summary>
        public ScreenOrientation? Orientation => JSRef!.Get<ScreenOrientation?>("orientation");
        /// <summary>
        /// Gets the bit depth of the screen.
        /// </summary>
        public int PixelDepth => JSRef!.Get<int>("pixelDepth");
        /// <summary>
        /// Returns the width of the screen.
        /// </summary>
        public int Width => JSRef!.Get<int>("width");
        /// <summary>
        /// Fired on a specific screen when it changes in some way — width or height, available width or height, color depth, or orientation.
        /// </summary>
        public JSEventCallback<Event> OnChange { get => new JSEventCallback<Event>("change", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fires when the screen orientation changes.
        /// </summary>
        public JSEventCallback<Event> OnOrientationChange { get => new JSEventCallback<Event>("orientationchange", AddEventListener, RemoveEventListener); set { } }
    }
}
