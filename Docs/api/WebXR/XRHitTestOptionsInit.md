# XRHitTestOptionsInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRHitTestOptionsInit.cs`  
**MDN Reference:** [XRHitTestOptionsInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSource#options)

> An XRHitTestOptionsInit dictionary represents a set of configurable values that affect the behavior of the hit test being performed. https://www.w3.org/TR/webxr-hit-test-1/#dictdef-xrhittestoptionsinit https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSource#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `XRHitTestOptionsInit` | `class` | get | An XRHitTestOptionsInit dictionary represents a set of configurable values that affect the behavior of the hit test being performed. https://www.w3.org/TR/webxr-hit-test-1/#dictdef-xrhittestoptionsinit https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSource#options |
| `EntityTypes` | `IEnumerable<string>?` | get |  |
| `OffsetRay` | `XRRay?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRHitTestOptionsInit>(...)` or constructor `new XRHitTestOptionsInit(...)`

### Requesting a hit test source

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/requestHitTestSource)*

