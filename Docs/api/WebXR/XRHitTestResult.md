# XRHitTestResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRHitTestResult.cs`  
**MDN Reference:** [XRHitTestResult on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestResult)

> https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestResult

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateAnchor()` | `Task<XRAnchor>` | The createAnchor() method of the XRHitTestResult interface creates an XRAnchor from a hit test result that is attached to a real-world object. |
| `GetPose(XRSpace baseSpace)` | `XRPose` | The getPose() method of the XRHitTestResult interface returns the XRPose of the hit test result relative to the given base space. An XRSpace to use as the base or origin for computing the relative position and orientation of hit test results. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRHitTestResult>(...)` or constructor `new XRHitTestResult(...)`

### Getting `XRHitTestResult` objects within the frame loop

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

### Getting the hit test result's pose

```js
let hitTestResults = xrFrame.getHitTestResults(hitTestSource);

if (hitTestResults.length > 0) {
  let pose = hitTestResults[0].getPose(referenceSpace);
}
```

### Creating an anchor from a hit test result

```js
hitTestResult.createAnchor().then(
  (anchor) => {
    // add anchored objects to the scene
  },
  (error) => {
    console.error(`Could not create anchor: ${error}`);
  },
);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRHitTestResult)*

