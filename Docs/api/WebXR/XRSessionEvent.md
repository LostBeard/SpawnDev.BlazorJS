# XRSessionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebXR/XRSessionEvent.cs`  
**MDN Reference:** [XRSessionEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSessionEvent)

> https://developer.mozilla.org/en-US/docs/Web/API/XRSessionEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Session` | `XRSession` | get | The XRSession to which the event refers. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRSessionEvent>(...)` or constructor `new XRSessionEvent(...)`

```js
xrSession.addEventListener("visibilitychange", (e) => {
  switch (e.session.visibilityState) {
    case "visible":
    case "visible-blurred":
      mySessionVisible(true);
      break;
    case "hidden":
      mySessionVisible(false);
      break;
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSessionEvent)*

