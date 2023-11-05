using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VisualViewport interface of the Visual Viewport API represents the visual viewport for a given window. For a page containing iframes, each iframe, as well as the containing page, will have a unique window object. Each window on a page will have a unique VisualViewport representing the properties associated with that window.
    /// </summary>
    public class VisualViewport : EventTarget
    {
        #region Constructors
        public VisualViewport(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public float Height => JSRef.Get<float>("height");
        public float OffsetLeft => JSRef.Get<float>("offsetLeft");
        public float OffsetTop => JSRef.Get<float>("offsetTop");
        public float PageLeft => JSRef.Get<float>("pageLeft");
        public float PageTop => JSRef.Get<float>("pageTop");
        public float Scale => JSRef.Get<float>("scale");
        public float Width => JSRef.Get<float>("width");
        #endregion

        #region Events
        /// <summary>
        /// Fired when the visual viewport is resized. Also available via the onresize property.
        /// </summary>
        public JSEventCallback<Event> OnResize { get => new JSEventCallback<Event>(o => AddEventListener("resize", o), o => RemoveEventListener("resize", o)); set { /** required **/ } }
        /// <summary>
        /// Fired when the visual viewport is scrolled. Also available via the onscroll property.
        /// </summary>
        public JSEventCallback<Event> OnScroll { get => new JSEventCallback<Event>(o => AddEventListener("scroll", o), o => RemoveEventListener("scroll", o)); set { /** required **/ } }
        #endregion
    }

}
