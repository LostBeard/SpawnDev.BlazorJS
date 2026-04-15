# XRLightEstimate

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRLightEstimate.cs`  
**MDN Reference:** [XRLightEstimate on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRLightEstimate)

> The XRLightEstimate interface of the WebXR Device API provides the estimated lighting values for an XRLightProbe at the time represented by an XRFrame. To get an XRLightEstimate object, call the XRFrame.getLightEstimate() method. https://developer.mozilla.org/en-US/docs/Web/API/XRLightEstimate

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PrimaryLightIntensity` | `DOMPointReadOnly` | get | A DOMPointReadOnly (with the x, y, z values mapped to RGB) representing the intensity of the primary light source from the probeSpace of an XRLightProbe. |
| `PrimaryLightDirection` | `DOMPointReadOnly` | get | A DOMPointReadOnly representing the direction to the primary light source from the probeSpace of an XRLightProbe. |
| `SphericalHarmonicsCoefficients` | `Float32Array` | get | A Float32Array containing 9 spherical harmonics coefficients. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRLightEstimate>(...)` or constructor `new XRLightEstimate(...)`

### Getting an `XRLightProbe` object

```js
const lightProbe = await xrSession.requestLightProbe();

// frame loop
function onXRFrame(time, xrFrame) {
  let lightEstimate = xrFrame.getLightEstimate(lightProbe);

  // Use light estimate data to light the scene

  // Available properties
  lightEstimate.sphericalHarmonicsCoefficients;
  lightEstimate.primaryLightDirection;
  lightEstimate.primaryLightIntensity;
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRLightEstimate)*

