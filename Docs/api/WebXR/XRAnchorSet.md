# XRAnchorSet

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Set<XRAnchor>`  
**Source:** `JSObjects/WebXR/XRAnchorSet.cs`  
**MDN Reference:** [XRAnchorSet on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRAnchorSet)

> https://developer.mozilla.org/en-US/docs/Web/API/XRAnchorSet

## Constructors

| Signature | Description |
|---|---|
| `XRAnchorSet(IEnumerable<XRAnchor> iterable)` | Creates a new instance |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<XRAnchorSet>(...)` or constructor `new XRAnchorSet(...)`

### Handling anchor tracking loss

```js
const trackedAnchors = frame.trackedAnchors;

for (const anchor of previousFrameAnchors) {
  if (!trackedAnchors.has(anchor)) {
    // Handle anchor tracking loss
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRAnchorSet)*

