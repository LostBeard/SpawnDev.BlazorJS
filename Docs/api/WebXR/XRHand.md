# XRHand

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Map<string`, `XRJointSpace>`  
**Source:** `JSObjects/WebXR/XRHand.cs`  
**MDN Reference:** [XRHand on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRHand)

> The XRHand interface is pair iterator (an ordered map) with the key being the hand joints and the value being an XRJointSpace. https://developer.mozilla.org/en-US/docs/Web/API/XRHand

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRHand>(...)` or constructor `new XRHand(...)`

### Using `XRHand` objects

```js
const wristJoint = inputSource.hand.get("wrist");
const indexFingerTipJoint = inputSource.hand.get("index-finger-tip");

for (const [joint, jointSpace] of inputSource.hand) {
  console.log(joint);
  console.log(jointSpace);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRHand)*

