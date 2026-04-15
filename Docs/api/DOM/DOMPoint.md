# DOMPoint

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `DOMPointReadOnly`  
**Source:** `JSObjects/DOM/DOMPoint.cs`  
**MDN Reference:** [DOMPoint on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMPoint)

> https://developer.mozilla.org/en-US/docs/Web/API/DOMPoint

## Constructors

| Signature | Description |
|---|---|
| `DOMPoint(double x, double y, double z, double w)` | The DOMPoint() constructor creates a new DOMPoint object representing a 2D or 3D point in a coordinate system. The x-coordinate of the point. Default is 0. The y-coordinate of the point. Default is 0. The z-coordinate of the point. Default is 0. The perspective value of the point. Default is 1. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `FromPoint(DOMPointInit point)` | `DOMPoint` | The DOMPoint.fromPoint() method creates a new DOMPoint object given a source point. A DOMPointInit dictionary or another DOMPoint object to initialize the new point with. A new DOMPoint object. |
| `MatrixTransform(DOMMatrixInit matrix)` | `DOMPoint` | The DOMPoint.matrixTransform() method returns a new DOMPoint object which is the result of the transformation of the point by the specified matrix. A DOMMatrixInit dictionary or another DOMMatrixReadOnly object to transform the point with. A new DOMPoint object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<DOMPoint>(...)` or constructor `new DOMPoint(...)`

```js
function onXRFrame(time, xrFrame) {
  let viewerPose = xrFrame.getViewerPose(xrReferenceSpace);

  if (viewerPose) {
    let position = viewerPose.transform.position;
    let orientation = viewerPose.transform.orientation;

    console.log(
      `XR Viewer Position: {x: ${roundToTwo(position.x)}, y: ${roundToTwo(
        position.y,
      )}, z: ${roundToTwo(position.z)}`,
    );

    console.log(
      `XR Viewer Orientation: {x: ${roundToTwo(orientation.x)}, y: ${roundToTwo(
        orientation.y,
      )}, z: ${roundToTwo(orientation.z)}, w: ${roundToTwo(orientation.w)}`,
    );
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DOMPoint)*

