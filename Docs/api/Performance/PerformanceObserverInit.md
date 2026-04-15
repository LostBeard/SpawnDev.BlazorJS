# PerformanceObserverInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/Performance/PerformanceObserverInit.cs`  
**MDN Reference:** [PerformanceObserverInit on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver/observe)

> Options utilized when calling PerformanceObserver.observe(). https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver/observe

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PerformanceObserverInit` | `class` | get | Options utilized when calling PerformanceObserver.observe(). https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver/observe |
| `EntryTypes` | `string[]?` | get |  |
| `Buffered` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PerformanceObserverInit>(...)` or constructor `new PerformanceObserverInit(...)`

### Watching multiple performance entry types

```js
const observer = new PerformanceObserver((list, obj) => {
  list.getEntries().forEach((entry) => {
    // Process "mark" and "measure" events
  });
});
observer.observe({ entryTypes: ["mark", "measure"] });
```

### Watching a single performance entry type

```js
const observer = new PerformanceObserver((list, obj) => {
  list.getEntries().forEach((entry) => {
    // Process "resource" events
  });
});
observer.observe({ type: "resource", buffered: true });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver/observe)*

