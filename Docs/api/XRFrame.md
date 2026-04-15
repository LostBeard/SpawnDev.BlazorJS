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

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetViewerPose(XRReferenceSpace referenceSpace)` | `XRViewerPose?` | Gets the viewer's pose relative to the reference space. |
| `GetPose(XRSpace space, XRSpace baseSpace)` | `XRPose?` | Gets the pose of one space relative to another. |
| `GetHitTestResults(XRHitTestSource hitTestSource)` | `XRHitTestResult[]` | Gets hit test results for AR plane detection. |
| `CreateAnchor(XRRigidTransform pose, XRSpace space)` | `Task<XRAnchor>` | Creates a spatial anchor at the given pose. |

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
