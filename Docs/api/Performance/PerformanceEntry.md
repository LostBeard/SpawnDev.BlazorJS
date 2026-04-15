# PerformanceEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Performance/PerformanceEntry.cs`  
**MDN Reference:** [PerformanceEntry on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceEntry)

> The PerformanceEntry interface encapsulates a single performance metric that is part of the performance timeline. A performance entry can be directly created by making a performance mark or measure (for example by calling the mark() method) at an explicit point in an application. Performance entries are also created in indirect ways such as loading a resource (such as an image). https://developer.mozilla.org/en-US/docs/Web/API/PerformanceEntry

## Constructors

| Signature | Description |
|---|---|
| `PerformanceEntry(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | A string representing the name of a performance entry. |
| `EntryType` | `string` | get | A string representing the type of performance entry. |
| `StartTime` | `double` | get | A double representing the starting time for the performance entry. |
| `Duration` | `double` | get | A double representing the duration of the performance entry. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PerformanceEntry>(...)` or constructor `new PerformanceEntry(...)`

### Working with performance entries

```js
// Place at a location in the code that starts login
performance.mark("login-started");

// Place at a location in the code that finishes login
performance.mark("login-finished");

// Measure login duration
performance.measure("login-duration", "login-started", "login-finished");

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PerformanceEntry)*

