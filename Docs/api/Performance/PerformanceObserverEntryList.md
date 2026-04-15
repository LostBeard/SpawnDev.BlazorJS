# PerformanceObserverEntryList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Performance/PerformanceObserverEntryList.cs`  
**MDN Reference:** [PerformanceObserverEntryList on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserverEntryList)

> The PerformanceObserverEntryList interface is a list of performance events that were observed, and is delivered to the callback function of a PerformanceObserver. https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserverEntryList

## Constructors

| Signature | Description |
|---|---|
| `PerformanceObserverEntryList(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetEntries()` | `PerformanceEntry[]` | Returns a list of PerformanceEntry objects based on the given name and entry type. |
| `GetEntriesByType(string type)` | `PerformanceEntry[]` | Returns a list of PerformanceEntry objects based on the given name and entry type. |
| `GetEntriesByName(string name, string? type)` | `PerformanceEntry[]` | Returns a list of PerformanceEntry objects based on the given name and entry type. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PerformanceObserverEntryList>(...)` or constructor `new PerformanceObserverEntryList(...)`

### Using PerformanceObserverEntryList

```js
function perfObserver(list, observer) {
  list.getEntries().forEach((entry) => {
    if (entry.entryType === "mark") {
      console.log(`${entry.name}'s startTime: ${entry.startTime}`);
    }
    if (entry.entryType === "measure") {
      console.log(`${entry.name}'s duration: ${entry.duration}`);
    }
  });
}
const observer = new PerformanceObserver(perfObserver);
observer.observe({ entryTypes: ["measure", "mark"] });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserverEntryList)*

