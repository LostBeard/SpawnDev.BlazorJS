# PerformanceObserver

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Performance/PerformanceObserver.cs`  
**MDN Reference:** [PerformanceObserver on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver)

> The PerformanceObserver interface is used to observe the following performance measurement events to be notified of new performance entries as they are recorded in the browser's performance timeline. https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver

## Constructors

| Signature | Description |
|---|---|
| `PerformanceObserver(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `PerformanceObserver(Action<PerformanceObserverEntryList, PerformanceObserver> callback)` | Creates a new PerformanceObserver object which will invoke a specified callback function when new performance entries are recorded. A function which is called when performance entries are recorded. The callback receives as input two parameters: list: A PerformanceObserverEntryList object containing the reported entries. observer: The PerformanceObserver object itself. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `SupportedEntryTypes` | `string[]` | get | Returns an array of the supported performance entry types. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Disconnect()` | `void` | Stops the PerformanceObserver object from receiving performance notifications. |
| `Observe(PerformanceObserverInit options)` | `void` | Specifies the set of entry types to observe. The observer's callback function will be invoked when a performance entry is recorded for one of the specified entry types. A PerformanceObserverInit object specifying the entry types to observe. |
| `TakeRecords()` | `PerformanceEntry[]` | Returns the current list of performance entries stored in the performance observer, emptying it out. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PerformanceObserver>(...)` or constructor `new PerformanceObserver(...)`

### Creating a PerformanceObserver

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceObserver)*

