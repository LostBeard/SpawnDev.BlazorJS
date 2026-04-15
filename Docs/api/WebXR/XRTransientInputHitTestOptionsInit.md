# XRTransientInputHitTestOptionsInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRTransientInputHitTestOptionsInit.cs`  
**MDN Reference:** [XRTransientInputHitTestOptionsInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSourceForTransientInput#options)

> https://www.w3.org/TR/webxr-hit-test-1/#dictdef-xrtransientinputhittestoptionsinit https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSourceForTransientInput#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRTransientInputHitTestOptionsInit` | `class` | get | https://www.w3.org/TR/webxr-hit-test-1/#dictdef-xrtransientinputhittestoptionsinit https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSourceForTransientInput#options |
| `EntityTypes` | `IEnumerable<string>?` | get |  |
| `OffsetRay` | `XRRay?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRTransientInputHitTestOptionsInit>(...)` or constructor `new XRTransientInputHitTestOptionsInit(...)`

### Requesting a transient hit test source

```js
const xrSession = navigator.xr.requestSession("immersive-ar", {
  requiredFeatures: ["local", "hit-test"],
});

let transientHitTestSource = null;

xrSession
  .requestHitTestSourceForTransientInput({
    profile: "generic-touchscreen",
    offsetRay: new XRRay(),
  })
  .then((touchScreenHitTestSource) => {
    transientHitTestSource = touchScreenHitTestSource;
  });

// frame loop
function onXRFrame(time, xrFrame) {
  let hitTestResults = xrFrame.getHitTestResultsForTransientInput(
    transientHitTestSource,
  );

  // do things with the transient hit test results
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSourceForTransientInput)*

