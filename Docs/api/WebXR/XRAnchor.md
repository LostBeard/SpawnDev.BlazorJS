# XRAnchor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRAnchor.cs`  
**MDN Reference:** [XRAnchor on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRAnchor)

> https://developer.mozilla.org/en-US/docs/Web/API/XRAnchor

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AnchorSpace` | `XRSpace` | get | Returns an XRSpace object to locate the anchor relative to other XRSpace objects. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Delete()` | `Task<XRAnchor>` | Removes the anchor. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRAnchor>(...)` or constructor `new XRAnchor(...)`

### Requesting a session with anchors enabled

```js
navigator.xr.requestSession("immersive-ar", {
  requireFeatures: ["anchors"],
});
```

### Adding anchors

```js
frame.createAnchor(anchorPose, referenceSpace).then(
  (anchor) => {
    // Do stuff with the anchor (assign objects that will be relative to this anchor)
  },
  (error) => {
    console.error(`Could not create anchor: ${error}`);
  },
);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRAnchor)*

