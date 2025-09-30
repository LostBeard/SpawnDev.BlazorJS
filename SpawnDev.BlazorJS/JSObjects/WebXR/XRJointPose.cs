using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRJointPose
    /// </summary>
    public class XRJointPose : XRPose
    {
        /// <inheritdoc/>
        public XRJointPose(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The read-only radius property of the XRJointPose interface indicates the radius (distance from skin) for a joint.
        /// </summary>
        public float Radius => JSRef!.Get<float>("radius");
    }
}
