# ReportingObserver

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Reporting/ReportingObserver.cs`  
**MDN Reference:** [ReportingObserver on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver)

> The ReportingObserver interface of the Reporting API allows you to collect and access reports. https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver

## Constructors

| Signature | Description |
|---|---|
| `ReportingObserver(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `ReportingObserver(Action<Report[], ReportingObserver> callback, ReportingObserverOptions? options)` | Creates a new ReportingObserver object instance, which can be used to collect and access reports. A function which is called when the ReportingObserver detects a report. The function receives two parameters: reports: An array of Report objects. observer: The ReportingObserver object that detected the report. An object allowing you to configure the observer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Disconnect()` | `void` | The disconnect() method of the ReportingObserver interface stops the observer from collecting reports. |
| `Observe()` | `void` | The observe() method of the ReportingObserver interface tells the observer to start collecting reports. |
| `TakeRecords()` | `Report[]` | The takeRecords() method of the ReportingObserver interface returns the current list of reports contained in the observer and empties the list. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ReportingObserver>(...)` or constructor `new ReportingObserver(...)`

### Displaying deprecation reports

```js
const options = {
  types: ["deprecation"],
  buffered: true,
};

const observer = new ReportingObserver((reports, observer) => {
  reports.forEach((report) => {
    // console.log(report);
    log(JSON.stringify(report, null, 2));
  });
}, options);

// Start the observer
observer.observe();
```

### Displaying deprecation reports

```js
const xhr = new XMLHttpRequest();
xhr.open("GET", "/", false); // false = synchronous (deprecated)
xhr.send();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver)*

