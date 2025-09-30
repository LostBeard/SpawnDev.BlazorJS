using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRSpace interface of the WebXR Device API is an abstract interface providing a common basis for every class which represents a virtual coordinate system within the virtual world, in which its origin corresponds to a physical location. Spatial data in WebXR is always expressed relative to an object based upon one of the descendant interfaces of XRSpace, at the time at which a given XRFrame takes place.<br/>
    /// Numeric values such as pose positions are thus coordinates in the corresponding XRSpace, relative to that space's origin.<br/>
    /// https://www.w3.org/TR/webxr/#xrspace<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRSpace
    /// </summary>
    public class XRSpace : EventTarget
    {
        /// <inheritdoc/>
        public XRSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
