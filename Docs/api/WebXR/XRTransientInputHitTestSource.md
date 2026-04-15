# XRTransientInputHitTestSource

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRTransientInputHitTestSource.cs`  
**MDN Reference:** [XRTransientInputHitTestSource on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRTransientInputHitTestSource)

> The XRTransientInputHitTestSource interface of the WebXR Device API handles transient input hit test subscriptions. You can get an XRTransientInputHitTestSource object by calling the XRSession.requestHitTestSourceForTransientInput(). This object doesn't itself contain transient input hit test results, but it is used to compute hit tests for each XRFrame by calling XRFrame.getHitTestResultsForTransientInput(), which returns XRTransientInputHitTestResult objects. https://developer.mozilla.org/en-US/docs/Web/API/XRTransientInputHitTestSource

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Cancel()` | `void` | The cancel() method of the XRTransientInputHitTestSource interface unsubscribes a transient input hit test. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRTransientInputHitTestSource>(...)` or constructor `new XRTransientInputHitTestSource(...)`

### Getting an `XRTransientInputHitTestSource` object for a session

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

### Unsubscribe from a transient input hit test

```js
transientHitTestSource.cancel();
transientHitTestSource = null;
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRTransientInputHitTestSource)*

