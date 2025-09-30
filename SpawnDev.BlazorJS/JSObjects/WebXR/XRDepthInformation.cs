using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRDepthInformation
    /// </summary>
    public class XRDepthInformation : JSObject
    {
        /// <inheritdoc/>
        public XRDepthInformation(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Contains the width of the depth buffer (number of columns).
        /// </summary>
        public int Width => JSRef!.Get<int>("width");
        /// <summary>
        /// Contains the height of the depth buffer (number of rows).
        /// </summary>
        public int Height => JSRef!.Get<int>("height");
        /// <summary>
        /// An XRRigidTransform that needs to be applied when indexing into the depth buffer. The transformation that the matrix represents changes the coordinate system from normalized view coordinates to normalized depth-buffer coordinates that can then be scaled by depth buffer's width and height to obtain the absolute depth buffer coordinates.
        /// </summary>
        public XRRigidTransform NormDepthBufferFromNormView => JSRef!.Get<XRRigidTransform>("normDepthBufferFromNormView");
        /// <summary>
        /// Contains the scale factor by which the raw depth values must be multiplied in order to get the depths in meters.
        /// </summary>
        public float RawValueToMeters => JSRef!.Get<float>("rawValueToMeters");
    }
}
