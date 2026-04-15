# XRHitTestSource

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebXR/XRHitTestSource.cs`  
**MDN Reference:** [XRHitTestSource on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestSource)

> The XRHitTestSource interface of the WebXR Device API handles hit test subscriptions. You can get an XRHitTestSource object by using the XRSession.requestHitTestSource() method. This object doesn't itself contain hit test results, but it is used to compute hit tests for each XRFrame by calling XRFrame.getHitTestResults(), which returns XRHitTestResult objects. https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestSource

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Cancel()` | `void` | The cancel() method of the XRHitTestSource interface unsubscribes a hit test. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRHitTestSource>(...)` or constructor `new XRHitTestSource(...)`

### Getting an `XRHitTestSource` object for a session

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

// frame loop
function onXRFrame(time, xrFrame) {
  let hitTestResults = xrFrame.getHitTestResults(hitTestSource);

  // do things with the hit test results
}
```

### Unsubscribe from hit test

```js
hitTestSource.cancel();
hitTestSource = null;
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestSource)*

