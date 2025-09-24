using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRRigidTransform
    /// </summary>
    public class XRRigidTransform : JSObject
    {
        /// <inheritdoc/>
        public XRRigidTransform(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRRigidTransform() constructor creates a new XRRigidTransform object, representing the position and orientation of a point or object. Among other things, XRRigidTransform is used when providing a transform to translate between coordinate systems across spaces.
        /// </summary>
        /// <param name="position">An object which specifies the coordinates at which the point or object is located. These dimensions are specified in meters. If this parameter is left out or is invalid, the position used is assumed to be {x: 0, y: 0, z: 0, w: 1}. w must always be 1.</param>
        /// <param name="orientation">An object which specifies the direction in which the object is facing. The default value for orientation is {x: 0, y: 0, z: 0, w: 1}. The specified orientation gets normalized if it's not already.</param>
        public XRRigidTransform(object? position = null, object? orientation = null) : base(JS.New(nameof(XRRigidTransform), position, orientation)) { }
        /// <summary>
        /// A DOMPointReadOnly specifying a 3-dimensional point, expressed in meters, describing the translation component of the transform. The w property is always 1.0.
        /// </summary>
        public DOMPointReadOnly Position => JSRef!.Get<DOMPointReadOnly>("position");
        /// <summary>
        /// A DOMPointReadOnly which contains a unit quaternion describing the rotational component of the transform. As a unit quaternion, its length is always normalized to 1.0.
        /// </summary>
        public DOMPointReadOnly Orientation => JSRef!.Get<DOMPointReadOnly>("orientation");
        /// <summary>
        /// Returns the transform matrix in the form of a 16-member Float32Array. See the section Matrix format for how the array is used to represent a matrix.
        /// </summary>
        public Float32Array Matrix => JSRef!.Get<Float32Array>("matrix");
        /// <summary>
        /// Returns a XRRigidTransform which is the inverse of this transform. That is, if applied to an object that had been previously transformed by the original transform, it will undo the transform and return the original object.
        /// </summary>
        public XRRigidTransform Inverse => JSRef!.Get<XRRigidTransform>("inverse");
    }
}
