# XRLightProbe

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebXR/XRLightProbe.cs`  
**MDN Reference:** [XRLightProbe on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRLightProbe)

> The XRLightProbe interface of the WebXR Device API contains lighting information at a given point in the user's environment. You can get an XRLighting object using the XRSession.requestLightProbe() method. This object doesn't itself contain lighting values, but it is used to collect lighting states for each XRFrame. See XRLightEstimate for the estimated lighting values for an XRLightProbe. https://developer.mozilla.org/en-US/docs/Web/API/XRLightProbe

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ProbeSpace` | `XRSpace` | get | An XRSpace tracking the position and orientation the lighting estimations are relative to. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnReflectionChange` | `ActionEvent<Event>` | Whenever the reflectionchange event fires on a light probe, you can retrieve an updated cube map by calling XRWebGLBinding.getReflectionCubeMap(). This is less expensive than retrieving lighting information with every XRFrame. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRLightProbe>(...)` or constructor `new XRLightProbe(...)`

### Getting an `XRLightProbe` object for a session

```js
const lightProbe = await xrSession.requestLightProbe();
```

### Getting a probe pose within an `XRFrame`

```js
const probePose = xrFrame.getPose(lightProbe.probeSpace, xrReferenceSpace);
```

### Using the `reflectionchange` event

```js
const glBinding = new XRWebGLBinding(xrSession, gl);
const lightProbe = await xrSession.requestLightProbe();
let glCubeMap = glBinding.getReflectionCubeMap(lightProbe);

lightProbe.addEventListener("reflectionchange", () => {
  glCubeMap = glBinding.getReflectionCubeMap(lightProbe);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRLightProbe)*

