# XRTransientInputHitTestResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRTransientInputHitTestResult.cs`  
**MDN Reference:** [XRTransientInputHitTestResult on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRTransientInputHitTestResult)

> The XRTransientInputHitTestResult interface of the WebXR Device API contains an array of results of a hit test for transient input, grouped by input source. https://developer.mozilla.org/en-US/docs/Web/API/XRTransientInputHitTestResult

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `InputSource` | `XRInputSource` | get | Returns the XRInputSource that was used to compute the results array. |
| `Results` | `XRHitTestResult[]` | get | Returns an array of XRHitTestResult objects containing the hit test results for the input source, ordered by distance along the ray used to perform the hit test, with the closest result at position 0. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRTransientInputHitTestResult>(...)` or constructor `new XRTransientInputHitTestResult(...)`

### Accessing transient input hit test results

```js
// frame loop
function onXRFrame(time, xrFrame) {
  let hitTestResults = xrFrame.getHitTestResultsForTransientInput(
    transientHitTestSource,
  );

  hitTestResults.forEach((resultsPerInputSource) => {
    resultsPerInputSource.results.forEach((hitTest) => {
      // do something with the hit test
      hitTest.getPose(referenceSpace);
    });
  });
}
```

### Filtering input sources

```js
// frame loop
function onXRFrame(time, xrFrame) {
  let hitTestResults = xrFrame.getHitTestResultsForTransientInput(
    transientHitTestSource,
  );

  hitTestResults.forEach((resultsPerInputSource) => {
    if (resultsPerInputSource.inputSource === myPreferredInputSource) {
      // act on hit test results from the preferred input source
    }
  });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRTransientInputHitTestResult)*

