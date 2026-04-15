# XRRigidTransform

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRRigidTransform.cs`  
**MDN Reference:** [XRRigidTransform on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRRigidTransform)

> The XRRigidTransform is a WebXR API interface that represents the 3D geometric transform described by a position and orientation. https://developer.mozilla.org/en-US/docs/Web/API/XRRigidTransform

## Constructors

| Signature | Description |
|---|---|
| `XRRigidTransform(object? position, object? orientation)` | The XRRigidTransform() constructor creates a new XRRigidTransform object, representing the position and orientation of a point or object. Among other things, XRRigidTransform is used when providing a transform to translate between coordinate systems across spaces. An object which specifies the coordinates at which the point or object is located. These dimensions are specified in meters. If this parameter is left out or is invalid, the position used is assumed to be {x: 0, y: 0, z: 0, w: 1}. w must always be 1. An object which specifies the direction in which the object is facing. The default value for orientation is {x: 0, y: 0, z: 0, w: 1}. The specified orientation gets normalized if it's not already. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Position` | `DOMPointReadOnly` | get | A DOMPointReadOnly specifying a 3-dimensional point, expressed in meters, describing the translation component of the transform. The w property is always 1.0. |
| `Orientation` | `DOMPointReadOnly` | get | A DOMPointReadOnly which contains a unit quaternion describing the rotational component of the transform. As a unit quaternion, its length is always normalized to 1.0. |
| `Matrix` | `Float32Array` | get | Returns the transform matrix in the form of a 16-member Float32Array. See the section Matrix format for how the array is used to represent a matrix. |
| `Inverse` | `XRRigidTransform` | get | Returns a XRRigidTransform which is the inverse of this transform. That is, if applied to an object that had been previously transformed by the original transform, it will undo the transform and return the original object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRRigidTransform>(...)` or constructor `new XRRigidTransform(...)`

```js
xrSession.requestReferenceSpace(refSpaceType).then((refSpace) => {
  xrReferenceSpace = refSpace;
  xrReferenceSpace = xrReferenceSpace.getOffsetReferenceSpace(
    new XRRigidTransform(viewerStartPosition, cubeOrientation),
  );
  animationFrameRequestID = xrSession.requestAnimationFrame(drawFrame);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRRigidTransform)*

