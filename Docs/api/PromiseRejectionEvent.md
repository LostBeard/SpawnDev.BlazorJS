# PromiseRejectionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/PromiseRejectionEvent.cs`  
**MDN Reference:** [PromiseRejectionEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PromiseRejectionEvent)

> The PromiseRejectionEvent interface represents events which are sent to the global script context when JavaScript Promises are rejected. These events are particularly useful for telemetry and debugging purposes. https://developer.mozilla.org/en-US/docs/Web/API/PromiseRejectionEvent

## Constructors

| Signature | Description |
|---|---|
| `PromiseRejectionEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Promise` | `Promise` | get | The JavaScript Promise that was rejected. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ReasonAs()` | `T` | A value or Object indicating why the promise was rejected, as passed to Promise.reject(). |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PromiseRejectionEvent>(...)` or constructor `new PromiseRejectionEvent(...)`

```js
window.onunhandledrejection = (e) => {
  console.log(e.reason);
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PromiseRejectionEvent)*

