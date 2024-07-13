using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VisualViewport interface of the Visual Viewport API represents the visual viewport for a given window. For a page containing iframes, each iframe, as well as the containing page, will have a unique window object. Each window on a page will have a unique VisualViewport representing the properties associated with that window.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/VisualViewport
    /// </summary>
    public class VisualViewport : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public VisualViewport(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// Returns the height of the visual viewport in CSS pixels.
        /// </summary>
        public float Height => JSRef!.Get<float>("height");
        /// <summary>
        /// Returns the offset of the left edge of the visual viewport from the left edge of the layout viewport in CSS pixels.
        /// </summary>
        public float OffsetLeft => JSRef!.Get<float>("offsetLeft");
        /// <summary>
        /// Returns the offset of the top edge of the visual viewport from the top edge of the layout viewport in CSS pixels.
        /// </summary>
        public float OffsetTop => JSRef!.Get<float>("offsetTop");
        /// <summary>
        /// Returns the x coordinate of the visual viewport relative to the initial containing block origin of the top edge in CSS pixels.
        /// </summary>
        public float PageLeft => JSRef!.Get<float>("pageLeft");
        /// <summary>
        /// Returns the y coordinate of the visual viewport relative to the initial containing block origin of the top edge in CSS pixels.
        /// </summary>
        public float PageTop => JSRef!.Get<float>("pageTop");
        /// <summary>
        /// Returns the pinch-zoom scaling factor applied to the visual viewport.
        /// </summary>
        public float Scale => JSRef!.Get<float>("scale");
        /// <summary>
        /// Returns the width of the visual viewport in CSS pixels.
        /// </summary>
        public float Width => JSRef!.Get<float>("width");
        #endregion

        #region Events
        /// <summary>
        /// Fired when the visual viewport is resized. Also available via the onresize property.
        /// </summary>
        public JSEventCallback<Event> OnResize { get => new JSEventCallback<Event>("resize", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the visual viewport is scrolled. Also available via the onscroll property.
        /// </summary>
        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>("scroll", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }

}
