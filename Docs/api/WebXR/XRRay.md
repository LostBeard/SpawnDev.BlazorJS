# XRRay

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRRay.cs`  
**MDN Reference:** [XRRay on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRRay)

> The XRRay interface of the WebXR Device API is a geometric ray described by an origin point and a direction vector. XRRay objects can be passed to XRSession.requestHitTestSource() or XRSession.requestHitTestSourceForTransientInput() to perform hit testing. https://developer.mozilla.org/en-US/docs/Web/API/XRRay https://www.w3.org/TR/webxr-hit-test-1/#xrray

## Constructors

| Signature | Description |
|---|---|
| `XRRay(DOMPointInit? origin, XRRayDirectionInit? direction)` | The XRRay() constructor creates a new XRRay object which is a geometric ray described by an origin point and a direction vector. |
| `XRRay(XRRigidTransform transform)` | The XRRay() constructor creates a new XRRay object which is a geometric ray described by an origin point and a direction vector. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Direction` | `DOMPointReadOnly` | get | A DOMPointReadOnly representing the ray's 3-dimensional directional vector. |
| `Matrix` | `Float32Array` | get | A transform that can be used to position objects along the XRRay. This is a 4 by 4 matrix given as a 16 element Float32Array in column major order. |
| `Origin` | `DOMPointReadOnly` | get | A DOMPointReadOnly representing the 3-dimensional point in space that the ray originates from, in meters. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRRay>(...)` or constructor `new XRRay(...)`

### Using `XRRay` to request a hit test source

```js
const xrSession = navigator.xr.requestSession("immersive-ar", {
  requiredFeatures: ["local", "hit-test"],
});

let hitTestSource = null;

xrSession
  .requestHitTestSource({
    space: viewerSpace, // obtained from xrSession.requestReferenceSpace("viewer");
    offsetRay: new XRRay({ y: 0.5 }),
  })
  .then((viewerHitTestSource) => {
    hitTestSource = viewerHitTestSource;
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRRay)*

