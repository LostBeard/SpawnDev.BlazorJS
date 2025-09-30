using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#xrframe-interface
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRFrame
    /// </summary>
    public class XRFrame : JSObject
    {
        /// <inheritdoc/>
        public XRFrame(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRSession that for which this XRFrame describes the tracking details for all objects. The information about a specific object can be obtained by calling one of the methods on the object.
        /// </summary>
        public XRSession Session => JSRef!.Get<XRSession>("session");
        /// <summary>
        /// An XRAnchorSet containing all anchors still tracked in the frame.
        /// </summary>
        public XRAnchorSet TrackedAnchors => JSRef!.Get<XRAnchorSet>("trackedAnchors");
        /// <summary>
        /// The createAnchor() method of the XRFrame interface creates a free-floating XRAnchor which will be fixed relative to the real world.<br/>
        /// See XRHitTestResult.createAnchor() for creating an anchor from a hit test result that is attached to a real-world object.
        /// </summary>
        /// <param name="pose">An XRRigidTransform object with the initial pose where the anchor should be created. The system will make sure that the relationship with the physical world made at this moment in time is maintained as the tracking system's understanding of the world evolves.</param>
        /// <param name="space">An XRSpace object the pose is relative to.</param>
        /// <returns>A Promise resolving to an XRAnchor object.</returns>
        public Task<XRAnchor> CreateAnchor(XRRigidTransform pose, XRSpace space) => JSRef!.CallAsync<XRAnchor>("createAnchor", pose, space);
        /// <summary>
        /// The fillJointRadii() method of the XRFrame interface populates a Float32Array with radii for a list of hand joint spaces and returns true if successful for all spaces.
        /// </summary>
        /// <param name="jointSpaces">An array of XRJointSpace objects for which to obtain the radii.</param>
        /// <param name="radii">A Float32Array that is populated with the radii of the jointSpaces.</param>
        /// <returns>A boolean indicating if all of the spaces have a valid pose.</returns>
        public bool FillJointRadii(IEnumerable<XRJointSpace> jointSpaces, Float32Array radii) => JSRef!.Call<bool>("fillJointRadii", jointSpaces, radii);
        /// <summary>
        /// The fillPoses() method of the XRFrame interface populates a Float32Array with the matrices of the poses relative to a given base space and returns true if successful for all spaces.
        /// </summary>
        /// <param name="spaces">An array of XRSpace objects for which to get the poses.</param>
        /// <param name="baseSpace">An XRSpace object to use as the base or origin for the relative position and orientation.</param>
        /// <param name="transforms">A Float32Array that is populated with the matrices of the poses relative to the given baseSpace.</param>
        /// <returns>A boolean indicating if all of the spaces have a valid pose.</returns>
        public bool FillPoses(IEnumerable<XRSpace> spaces, XRSpace baseSpace, Float32Array transforms) => JSRef!.Call<bool>("fillPoses", spaces, baseSpace, transforms);
        /// <summary>
        /// The getDepthInformation() method of the XRFrame interface returns an XRCPUDepthInformation object containing CPU depth information for the active and animated frame.
        /// </summary>
        /// <param name="view">An XRView object obtained from a viewer pose.</param>
        /// <returns>An XRCPUDepthInformation object.</returns>
        public XRCPUDepthInformation GetDepthInformation(XRView view) => JSRef!.Call<XRCPUDepthInformation>("getDepthInformation", view);
        /// <summary>
        /// The getHitTestResults() method of the XRFrame interface returns an array of XRHitTestResult objects containing hit test results for a given XRHitTestSource.
        /// </summary>
        /// <param name="hitTestSource">An XRHitTestSource object that contains hit test subscriptions.</param>
        /// <returns></returns>
        public XRHitTestResult[] GetHitTestResults(XRHitTestSource hitTestSource) => JSRef!.Call<XRHitTestResult[]>("getHitTestResults", hitTestSource);
        /// <summary>
        /// Returns an XRJointPose object providing the pose of a hand joint (see XRHand) relative to a given base space.
        /// </summary>
        /// <param name="joint"></param>
        /// <param name="baseSpace"></param>
        /// <returns></returns>
        public XRJointPose GetJointPose(XRJointSpace joint, XRSpace baseSpace) => JSRef!.Call<XRJointPose>("getJointPose", joint, baseSpace);
        /// <summary>
        /// The getLightEstimate() method of the XRFrame interface returns an XRLightEstimate object containing estimated lighting values for a given XRLightProbe.
        /// </summary>
        /// <param name="lightProbe"></param>
        /// <returns></returns>
        public XRLightEstimate? GetLightEstimate(XRLightProbe lightProbe) => JSRef!.Call<XRLightEstimate?>("getLightEstimate", lightProbe);
        /// <summary>
        /// The XRFrame method getPose() returns the relative position and orientation—the pose—of one XRSpace to that of another space. With this, you can observe the motion of objects relative to each other and to fixed locations throughout the scene.<br/>
        /// For example, to get the position of a controller relative to the viewer's head, you would compare the controller's gripSpace to the XRReferenceSpace of type viewer.
        /// </summary>
        /// <param name="space"></param>
        /// <param name="baseSpace"></param>
        /// <returns></returns>
        public XRPose GetPose(XRSpace space, XRSpace baseSpace) => JSRef!.Call<XRPose>("getPose", space, baseSpace);
        /// <summary>
        /// The getViewerPose() method, a member of the XRFrame interface, returns a XRViewerPose object which describes the viewer's pose (position and orientation) relative to the specified reference space.<br/>
        /// See the getPose() method for a way to calculate a pose that represents the difference between two spaces.
        /// </summary>
        /// <param name="referenceSpace"></param>
        /// <returns></returns>
        public XRViewerPose GetViewerPose(XRReferenceSpace referenceSpace) => JSRef!.Call<XRViewerPose>("getViewerPose", referenceSpace);
    }
}
