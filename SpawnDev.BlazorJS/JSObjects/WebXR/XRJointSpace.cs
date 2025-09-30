using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRJointSpace
    /// </summary>
    public class XRJointSpace : XRSpace
    {
        /// <inheritdoc/>
        public XRJointSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The name of the joint that is tracked. See XRHand for possible hand joint names.
        /// </summary>
        public string JointName => JSRef!.Get<string>("jointName");
    }
}
