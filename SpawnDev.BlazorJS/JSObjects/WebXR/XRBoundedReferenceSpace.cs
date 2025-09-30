using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebXR Device API's XRBoundedReferenceSpace interface describes a virtual world reference space which has preset boundaries. This extends XRReferenceSpace, which describes an essentially unrestricted space around the viewer's position. These bounds are defined using an array of points, each of which defines a vertex in a polygon inside which the user is allowed to move.<br/>
    /// https://www.w3.org/TR/webxr/#xrboundedreferencespace
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRBoundedReferenceSpace
    /// </summary>
    public class XRBoundedReferenceSpace : XRReferenceSpace
    {
        /// <inheritdoc/>
        public XRBoundedReferenceSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An array of DOMPointReadOnly objects, each of which defines a vertex in the polygon defining the boundaries within which the user will be required to remain. These vertices must be sorted such that they move clockwise around the viewer's position.
        /// </summary>
        public Array<DOMPointReadOnly> BoundsGeometry => JSRef!.Get<Array<DOMPointReadOnly>>("boundsGeometry");
    }
}
