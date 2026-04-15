# XRDOMOverlayState

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRDOMOverlayState.cs`  
**MDN Reference:** [XRDOMOverlayState on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/domOverlayState#value)

> https://developer.mozilla.org/en-US/docs/Web/API/XRSession/domOverlayState#value https://www.w3.org/TR/webxr/#xrsession

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `string` | get | A string indicating how the DOM overlay is being displayed. Possible values: screen - The overlay is drawn on the entire screen-based device(for handheld AR devices). head-locked - The overlay is drawn at a head-locked UI that fills the renderable viewport and follows the user's head movement. floating - The overlay appears as a rectangle floating in space that's kept in front of the user. It doesn't necessarily fill up the entire space and/or is strictly head-locked. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRDOMOverlayState>(...)` or constructor `new XRDOMOverlayState(...)`

### Checking which DOM overlay got enabled

```js
if (session.domOverlayState) {
  console.log(session.domOverlayState.type);
} else {
  console.log("DOM overlay not supported or enabled!");
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRSession/domOverlayState)*

