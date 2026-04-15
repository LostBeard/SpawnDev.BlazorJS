# ReportingObserverOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/Reporting/ReportingObserverOptions.cs`  
**MDN Reference:** [ReportingObserverOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver/ReportingObserver#options)

> Options utilized when creating a new ReportingObserver. https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver/ReportingObserver#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ReportingObserverOptions` | `class` | get | Options utilized when creating a new ReportingObserver. https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver/ReportingObserver#options |
| `Buffered` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ReportingObserverOptions>(...)` or constructor `new ReportingObserverOptions(...)`

### Display specific report types

```js
const options = {
  types: ["deprecation", "integrity-violation"],
  buffered: true,
};

const observer = new ReportingObserver((reports, observer) => {
  reportBtn.onclick = () => displayReports(reports);
}, options);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReportingObserver/ReportingObserver)*

