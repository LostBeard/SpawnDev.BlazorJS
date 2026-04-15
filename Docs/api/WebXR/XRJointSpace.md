# XRJointSpace

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XRSpace`  
**Source:** `JSObjects/WebXR/XRJointSpace.cs`  
**MDN Reference:** [XRJointSpace on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRJointSpace)

> https://developer.mozilla.org/en-US/docs/Web/API/XRJointSpace

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `JointName` | `string` | get | The name of the joint that is tracked. See XRHand for possible hand joint names. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRJointSpace>(...)` or constructor `new XRJointSpace(...)`

### Using `XRJointSpace` objects

```js
navigator.xr
  .requestSession({ optionalFeatures: ["hand-tracking"] })
  .then(/** … */);

function renderFrame(session, frame) {
  // …

  for (const inputSource of session.inputSources) {
    if (inputSource.hand) {
      const indexFingerTipJoint = inputSource.hand.get("index-finger-tip"); // XRJointSpace
      indexFingerTipJoint.jointName; // "index-finger-tip"
      frame.getJointPose(indexFingerTipJoint, referenceSpace); // XRJointPose
    }
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRJointSpace)*

