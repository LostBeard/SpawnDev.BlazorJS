using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrreferencespace
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRReferenceSpace
    /// </summary>
    public class XRReferenceSpace : XRSpace
    {
        /// <inheritdoc/>
        public XRReferenceSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRReferenceSpace interface's getOffsetReferenceSpace() method returns a new reference space object which describes the relative difference in position between the object on which the method is called and a given point in 3D space. The object returned by getOffsetReferenceSpace() is an XRReferenceSpace if called on an XRReferenceSpace, or an XRBoundedReferenceSpace if called on an object of that type.<br/>
        /// In other words, when you have an object in 3D space and need to position another object relative to that one, you can call getOffsetReferenceSpace(), passing into it the position and orientation you want the second object to have relative to the position and orientation of the object on which you call getOffsetReferenceSpace().<br/>
        /// Then, when drawing the scene, you can use the offset reference space to not only position objects relative to one another, but to apply the needed transforms to render objects properly based upon the viewer's position. This is demonstrated in the example Implementing rotation based on non-XR inputs, which demonstrates a way to use this method to let the user use their mouse to pitch and yaw their viewing angle.
        /// </summary>
        /// <param name="originOffset">An XRRigidTransform specifying the offset to the origin of the new reference space. These values are added to the position and orientation of the current reference space and then the result is used as the position and orientation of the newly created XRReferenceSpace.</param>
        /// <returns>A new XRReferenceSpace object describing a reference space with the same native origin as the reference space on which the method was called, but with an origin offset indicating the distance from the object to the point given by originOffset.<br/>
        /// If the object on which you call this method is an XRBoundedReferenceSpace, the returned object is one as well. The boundsGeometry of the new reference space is set to the original object's boundsGeometry with each of its points multiplied by the inverse of originOffset.</returns>
        public XRReferenceSpace GetOffsetReferenceSpace(XRRigidTransform originOffset) => JSRef!.Call<XRReferenceSpace>("getOffsetReferenceSpace", originOffset);
        /// <summary>
        /// The reset event is sent to an XRReferenceSpace object when the browser detects a discontinuity between the tracked object's origin and the user's environment or location. This can happen, for example, after the user recalibrates their XR device, or if the device automatically adjusts its origin after losing and regaining tracking.
        /// </summary>
        public ActionEvent<XRReferenceSpaceEvent> OnReset { get => new ActionEvent<XRReferenceSpaceEvent>("reset", AddEventListener, RemoveEventListener); set { } }
    }
}
