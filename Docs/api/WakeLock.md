# WakeLock

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WakeLock.cs`  
**MDN Reference:** [WakeLock on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WakeLock)

> The WakeLock interface of the Screen Wake Lock API can be used to request a lock that prevents device screens from dimming or locking when an application needs to keep running. https://developer.mozilla.org/en-US/docs/Web/API/WakeLock

## Constructors

| Signature | Description |
|---|---|
| `WakeLock(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Request(string type)` | `Task<WakeLockSentinel>` | Returns a Promise that fulfills with a WakeLockSentinel object if the screen wake lock is granted. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WakeLock>(...)` or constructor `new WakeLock(...)`

```js
try {
  const wakeLock = await navigator.wakeLock.request("screen");
} catch (err) {
  // the wake lock request fails - usually system related, such being low on battery
  console.log(`${err.name}, ${err.message}`);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WakeLock)*

