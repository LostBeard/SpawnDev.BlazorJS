# XRView

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebXR`  
**Inheritance:** `JSObject` -> `XRView`  
**MDN Reference:** [XRView - MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRView)

> The `XRView` interface represents a single view into an XR scene - one per eye for stereoscopic rendering, or one for inline sessions. Provides the projection matrix and transform needed for rendering.

## Constructors

| Signature | Description |
|---|---|
| `XRView(IJSInProcessObjectReference _ref)` | Deserialization constructor. Obtained from `XRViewerPose.Views`. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Eye` | `string` | Which eye: `"left"`, `"right"`, or `"none"` (for inline/mono). |
| `ProjectionMatrix` | `Float32Array` | The 4x4 projection matrix for this view. |
| `Transform` | `XRRigidTransform` | The view's position and orientation. |
| `RecommendedViewportScale` | `float?` | Recommended viewport scale for performance. |
| `IsFirstPersonObserver` | `bool` | Returns a boolean indicating if the XRView is a first-person observer view. |
| `Camera` | `XRCamera?` | The camera property of the XRView interface returns an XRCamera object representing the camera for the view, if applicable for the session's XR device. Returns null if the feature is not enabled or supported. https://developer.mozilla.org/en-US/docs/Web/API/XRView/camera |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestViewportScale(float scale)` | `void` | The requestViewportScale() method of the XRView interface requests that the user agent sets the requested viewport scale for this viewport to the given value. This is used for dynamic viewport scaling which allows rendering to a subset of the WebXR viewport using a scale factor that can be changed every animation frame. |

## Example

```csharp
// In a render loop, iterate views from viewerPose
using var viewerPose = frame.GetViewerPose(refSpace);
if (viewerPose != null)
{
    foreach (var view in viewerPose.Views)
    {
        using (view)
        {
            Console.WriteLine($"Eye: {view.Eye}");
            using var projMatrix = view.ProjectionMatrix;
            float[] matrix = projMatrix.ToArray();
            // Use matrix for rendering
        }
    }
}
```
