# XRJointPose

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRPose`  
**Source:** `JSObjects/WebXR/XRJointPose.cs`  
**MDN Reference:** [XRJointPose on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRJointPose)

> https://developer.mozilla.org/en-US/docs/Web/API/XRJointPose

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Radius` | `float` | get | The read-only radius property of the XRJointPose interface indicates the radius (distance from skin) for a joint. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRJointPose>(...)` or constructor `new XRJointPose(...)`

### Using `XRJointPose` objects

```js
navigator.xr
  .requestSession({ optionalFeatures: ["hand-tracking"] })
  .then(/* … */);

function renderFrame(session, frame) {
  // …

  for (const inputSource of session.inputSources) {
    if (inputSource.hand) {
      const indexFingerTipJoint = inputSource.hand.get("index-finger-tip");
      frame.getJointPose(indexFingerTipJoint, referenceSpace); // XRJointPose
    }
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRJointPose)*

