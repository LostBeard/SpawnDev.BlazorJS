using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WindowControlsOverlayGeometryChangeEvent interface of the Window Controls Overlay API is passed to geometrychange when the size or visibility of a desktop Progress Web App's title bar region changes.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WindowControlsOverlayGeometryChangeEvent
    /// </summary>
    public class WindowControlsOverlayGeometryChangeEvent : Event
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WindowControlsOverlayGeometryChangeEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A DOMRect representing the position and size of the title bar region.
        /// </summary>
        public DOMRectReadOnly TitlebarAreaRect() => JSRef.Get<DOMRectReadOnly>("titlebarAreaRect");
        /// <summary>
        /// A Boolean that indicates whether the window controls overlay is visible or not.
        /// </summary>
        public bool Visible => JSRef.Get<bool>("visible");
    }
}
