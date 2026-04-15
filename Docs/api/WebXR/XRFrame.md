# XRFrame

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRFrame.cs`  
**MDN Reference:** [XRFrame on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRFrame)

> https://www.w3.org/TR/webxr/#xrframe-interface https://developer.mozilla.org/en-US/docs/Web/API/XRFrame

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Session` | `XRSession` | get | The XRSession that for which this XRFrame describes the tracking details for all objects. The information about a specific object can be obtained by calling one of the methods on the object. |
| `PredictedDisplayTime` | `double` | get | A DOMHighResTimeStamp indicating the time at which the frame's scene was computed. Used for animation timing, frame pacing, and interpolation. |
| `TrackedAnchors` | `XRAnchorSet` | get | An XRAnchorSet containing all anchors still tracked in the frame. |
| `DetectedPlanes` | `Set<XRPlane>?` | get | The detectedPlanes read-only property of the XRFrame interface returns an XRPlaneSet containing all detected planes in the frame. https://developer.mozilla.org/en-US/docs/Web/API/XRFrame/detectedPlanes |
| `DetectedMeshes` | `Set<XRMesh>?` | get | The detectedMeshes read-only property of the XRFrame interface returns an XRMeshSet containing all detected meshes in the frame. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateAnchor(XRRigidTransform pose, XRSpace space)` | `Task<XRAnchor>` | The createAnchor() method of the XRFrame interface creates a free-floating XRAnchor which will be fixed relative to the real world. See XRHitTestResult.createAnchor() for creating an anchor from a hit test result that is attached to a real-world object. An XRRigidTransform object with the initial pose where the anchor should be created. The system will make sure that the relationship with the physical world made at this moment in time is maintained as the tracking system's understanding of the world evolves. An XRSpace object the pose is relative to. A Promise resolving to an XRAnchor object. |
| `FillJointRadii(IEnumerable<XRJointSpace> jointSpaces, Float32Array radii)` | `bool` | The fillJointRadii() method of the XRFrame interface populates a Float32Array with radii for a list of hand joint spaces and returns true if successful for all spaces. An array of XRJointSpace objects for which to obtain the radii. A Float32Array that is populated with the radii of the jointSpaces. A boolean indicating if all of the spaces have a valid pose. |
| `FillPoses(IEnumerable<XRSpace> spaces, XRSpace baseSpace, Float32Array transforms)` | `bool` | The fillPoses() method of the XRFrame interface populates a Float32Array with the matrices of the poses relative to a given base space and returns true if successful for all spaces. An array of XRSpace objects for which to get the poses. An XRSpace object to use as the base or origin for the relative position and orientation. A Float32Array that is populated with the matrices of the poses relative to the given baseSpace. A boolean indicating if all of the spaces have a valid pose. |
| `GetDepthInformation(XRView view)` | `XRCPUDepthInformation` | The getDepthInformation() method of the XRFrame interface returns an XRCPUDepthInformation object containing CPU depth information for the active and animated frame. An XRView object obtained from a viewer pose. An XRCPUDepthInformation object. |
| `GetHitTestResults(XRHitTestSource hitTestSource)` | `XRHitTestResult[]` | The getHitTestResults() method of the XRFrame interface returns an array of XRHitTestResult objects containing hit test results for a given XRHitTestSource. An XRHitTestSource object that contains hit test subscriptions. |
| `GetJointPose(XRJointSpace joint, XRSpace baseSpace)` | `XRJointPose` | Returns an XRJointPose object providing the pose of a hand joint (see XRHand) relative to a given base space. |
| `GetLightEstimate(XRLightProbe lightProbe)` | `XRLightEstimate?` | The getLightEstimate() method of the XRFrame interface returns an XRLightEstimate object containing estimated lighting values for a given XRLightProbe. |
| `GetPose(XRSpace space, XRSpace baseSpace)` | `XRPose` | The XRFrame method getPose() returns the relative position and orientation-the pose-of one XRSpace to that of another space. With this, you can observe the motion of objects relative to each other and to fixed locations throughout the scene. For example, to get the position of a controller relative to the viewer's head, you would compare the controller's gripSpace to the XRReferenceSpace of type viewer. |
| `GetViewerPose(XRReferenceSpace referenceSpace)` | `XRViewerPose` | The getViewerPose() method, a member of the XRFrame interface, returns a XRViewerPose object which describes the viewer's pose (position and orientation) relative to the specified reference space. See the getPose() method for a way to calculate a pose that represents the difference between two spaces. |
| `GetHitTestResultsForTransientInput(XRTransientInputHitTestSource hitTestSource)` | `XRTransientInputHitTestResult[]` | The getHitTestResultsForTransientInput() method of the XRFrame interface returns an array of XRTransientInputHitTestResult objects containing transient input hit test results for a given XRTransientInputHitTestSource. https://developer.mozilla.org/en-US/docs/Web/API/XRFrame/getHitTestResultsForTransientInput An XRTransientInputHitTestSource object that contains transient input hit test subscriptions. |

