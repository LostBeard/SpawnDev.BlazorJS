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
