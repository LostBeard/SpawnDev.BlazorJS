# PeriodicSyncEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/PeriodicSyncEvent.cs`  
**MDN Reference:** [PeriodicSyncEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncEvent)

> The PeriodicSyncEvent interface of the Web Periodic Background Synchronization API provides a way to run tasks in the service worker with network connectivity. https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncEvent

## Constructors

| Signature | Description |
|---|---|
| `PeriodicSyncEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Tag` | `string` | get | Returns the developer-defined identifier for this PeriodicSyncEvent. Multiple tags can be used by the web app to run different periodic tasks at different frequencies. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PeriodicSyncEvent>(...)` or constructor `new PeriodicSyncEvent(...)`

```js
self.addEventListener("periodicsync", (event) => {
  if (event.tag === "get-latest-news") {
    event.waitUntil(fetchAndCacheLatestNews());
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncEvent)*

