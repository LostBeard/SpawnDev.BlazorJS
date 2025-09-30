using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSession/domOverlayState#value
    /// https://www.w3.org/TR/webxr/#xrsession
    /// </summary>
    public class XRDOMOverlayState : JSObject
    {
        /// <inheritdoc/>
        public XRDOMOverlayState(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A string indicating how the DOM overlay is being displayed. Possible values:<br/>
        /// screen<br/>
        /// - The overlay is drawn on the entire screen-based device(for handheld AR devices).<br/>
        /// head-locked<br/>
        /// - The overlay is drawn at a head-locked UI that fills the renderable viewport and follows the user's head movement.<br/>
        /// floating<br/>
        /// - The overlay appears as a rectangle floating in space that's kept in front of the user. It doesn't necessarily fill up the entire space and/or is strictly head-locked.
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
    }
}
