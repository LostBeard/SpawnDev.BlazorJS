using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRViewerPose
    /// </summary>
    public class XRViewerPose : XRPose
    {
        /// <inheritdoc/>
        public XRViewerPose(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An array of XRView objects, one for each viewpoint on the scene which is needed to represent the scene to the user. A typical headset provides a viewer pose with two views whose eye property is either left or right, indicating which eye that view represents. Taken together, these views can reproduce the 3D effect when displayed on the XR device.
        /// </summary>
        public XRView[] Views => JSRef!.Get<XRView[]>("views");
    }
}
