using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRRay interface of the WebXR Device API is a geometric ray described by an origin point and a direction vector.<br/>
    /// XRRay objects can be passed to XRSession.requestHitTestSource() or XRSession.requestHitTestSourceForTransientInput() to perform hit testing.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRRay
    /// https://www.w3.org/TR/webxr-hit-test-1/#xrray
    /// </summary>
    public class XRRay : JSObject
    {
        static IJSInProcessObjectReference GetReference(DOMPointInit? origin = null, XRRayDirectionInit? direction = null)
        {
            if (origin != null) return direction == null ? JS.New(nameof(XRRay), origin) : JS.New(nameof(XRRay), origin, direction);
            return JS.New(nameof(XRRay));
        }
        /// <inheritdoc/>
        public XRRay(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRRay() constructor creates a new XRRay object which is a geometric ray described by an origin point and a direction vector.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="direction"></param>
        public XRRay(DOMPointInit? origin = null, XRRayDirectionInit? direction = null) : base(GetReference(origin, direction)) { }
        /// <summary>
        /// The XRRay() constructor creates a new XRRay object which is a geometric ray described by an origin point and a direction vector.
        /// </summary>
        /// <param name="transform"></param>
        public XRRay(XRRigidTransform transform) : base(JS.New(nameof(XRRay), transform)) { }
        /// <summary>
        /// A DOMPointReadOnly representing the ray's 3-dimensional directional vector.
        /// </summary>
        public DOMPointReadOnly Direction => JSRef!.Get<DOMPointReadOnly>("direction");
        /// <summary>
        /// A transform that can be used to position objects along the XRRay. This is a 4 by 4 matrix given as a 16 element Float32Array in column major order.
        /// </summary>
        public Float32Array Matrix => JSRef!.Get<Float32Array>("matrix");
        /// <summary>
        /// A DOMPointReadOnly representing the 3-dimensional point in space that the ray originates from, in meters.
        /// </summary>
        public DOMPointReadOnly Origin => JSRef!.Get<DOMPointReadOnly>("origin");
    }
}
