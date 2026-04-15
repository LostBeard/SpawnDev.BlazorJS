# PageTransitionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/PageTransitionEvent.cs`  
**MDN Reference:** [PageTransitionEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PageTransitionEvent)

> The PageTransitionEvent event object is available inside handler functions for the pageshow and pagehide events, fired when a document is being loaded or unloaded. https://developer.mozilla.org/en-US/docs/Web/API/PageTransitionEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Persisted` | `bool` | get | Indicates if the document is loading from a cache. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PageTransitionEvent>(...)` or constructor `new PageTransitionEvent(...)`

```js
window.addEventListener("pageshow", (event) => {
  if (event.persisted) {
    alert("The page was cached by the browser");
  } else {
    alert("The page was NOT cached by the browser");
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PageTransitionEvent)*

