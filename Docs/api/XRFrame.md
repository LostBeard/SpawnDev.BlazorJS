# XRFrame

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebXR`  
**Inheritance:** `JSObject` -> `XRFrame`  
**MDN Reference:** [XRFrame - MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRFrame)

> The `XRFrame` interface provides a snapshot of the state of an XR scene at a particular point in time. It is passed to the `requestAnimationFrame` callback and provides methods to query spatial relationships.

## Constructors

| Signature | Description |
|---|---|
| `XRFrame(IJSInProcessObjectReference _ref)` | Deserialization constructor. Received in animation frame callbacks. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Session` | `XRSession` | The session this frame belongs to. |
| `PredictedDisplayTime` | `double` | A DOMHighResTimeStamp indicating the time at which the frame's scene was computed. Used for animation timing, frame pacing, and interpolation. |
| `TrackedAnchors` | `XRAnchorSet` | An XRAnchorSet containing all anchors still tracked in the frame. |
| `DetectedPlanes` | `Set<XRPlane>?` | The detectedPlanes read-only property of the XRFrame interface returns an XRPlaneSet containing all detected planes in the frame. https://developer.mozilla.org/en-US/docs/Web/API/XRFrame/detectedPlanes |
| `DetectedMeshes` | `Set<XRMesh>?` | The detectedMeshes read-only property of the XRFrame interface returns an XRMeshSet containing all detected meshes in the frame. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetViewerPose(XRReferenceSpace referenceSpace)` | `XRViewerPose?` | Gets the viewer's pose relative to the reference space. |
| `GetPose(XRSpace space, XRSpace baseSpace)` | `XRPose?` | Gets the pose of one space relative to another. |
| `GetHitTestResults(XRHitTestSource hitTestSource)` | `XRHitTestResult[]` | Gets hit test results for AR plane detection. |
| `CreateAnchor(XRRigidTransform pose, XRSpace space)` | `Task<XRAnchor>` | Creates a spatial anchor at the given pose. |
| `FillJointRadii(IEnumerable<XRJointSpace> jointSpaces, Float32Array radii)` | `bool` | The fillJointRadii() method of the XRFrame interface populates a Float32Array with radii for a list of hand joint spaces and returns true if successful for all spaces. |
| `FillPoses(IEnumerable<XRSpace> spaces, XRSpace baseSpace, Float32Array transforms)` | `bool` | The fillPoses() method of the XRFrame interface populates a Float32Array with the matrices of the poses relative to a given base space and returns true if successful for all spaces. |
| `GetDepthInformation(XRView view)` | `XRCPUDepthInformation` | The getDepthInformation() method of the XRFrame interface returns an XRCPUDepthInformation object containing CPU depth information for the active and animated frame. |
| `GetJointPose(XRJointSpace joint, XRSpace baseSpace)` | `XRJointPose` | Returns an XRJointPose object providing the pose of a hand joint (see XRHand) relative to a given base space. |
| `GetLightEstimate(XRLightProbe lightProbe)` | `XRLightEstimate?` | The getLightEstimate() method of the XRFrame interface returns an XRLightEstimate object containing estimated lighting values for a given XRLightProbe. |
| `GetHitTestResultsForTransientInput(XRTransientInputHitTestSource hitTestSource)` | `XRTransientInputHitTestResult[]` | The getHitTestResultsForTransientInput() method of the XRFrame interface returns an array of XRTransientInputHitTestResult objects containing transient input hit test results for a given XRTransientInputHitTestSource. https://developer.mozilla.org/en-US/docs/Web/API/XRFrame/getHitTestResultsForTransientInput |

## Example

```csharp
// Inside an XR animation frame callback:
// XRFrame frame is passed as a parameter
using var viewerPose = frame.GetViewerPose(referenceSpace);
if (viewerPose != null)
{
    var views = viewerPose.Views;
    foreach (var view in views)
    {
        // Render for each eye
        Console.WriteLine($"Eye: {view.Eye}");
        view.Dispose();
    }
}
```
