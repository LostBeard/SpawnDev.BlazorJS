# WakeLockSentinel

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WakeLockSentinel.cs`  
**MDN Reference:** [WakeLockSentinel on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WakeLockSentinel)

> The WakeLockSentinel interface of the Screen Wake Lock API can be used to monitor the status of the platform screen wake lock, and manually release the lock when needed. https://developer.mozilla.org/en-US/docs/Web/API/WakeLockSentinel

## Constructors

| Signature | Description |
|---|---|
| `WakeLockSentinel(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Released` | `bool` | get | Returns a boolean indicating whether the WakeLockSentinel has been released. |
| `Type` | `string` | get | Returns a string representation of the currently acquired WakeLockSentinel type. Return values are: screen: A screen wake lock. Prevents devices from dimming or locking the screen. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Release()` | `Task` | The release() method of the WakeLockSentinel interface releases the WakeLockSentinel, returning a Promise that is resolved once the sentinel has been successfully released. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnRelease` | `ActionEvent<Event>` | release event |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WakeLockSentinel>(...)` or constructor `new WakeLockSentinel(...)`

```js
// create a reference for the wake lock
let wakeLock = null;

// create an async function to request a wake lock
const requestWakeLock = async () => {
  try {
    wakeLock = await navigator.wakeLock.request("screen");

    // listen for our release event
    wakeLock.addEventListener("release", () => {
      // if wake lock is released alter the UI accordingly
    });
  } catch (err) {
    // if wake lock request fails - usually system related, such as battery
  }
};

wakeLockOnButton.addEventListener("click", () => {
  requestWakeLock();
});

wakeLockOffButton.addEventListener("click", () => {
  if (wakeLock !== null) {
    wakeLock.release().then(() => {
      wakeLock = null;
    });
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WakeLockSentinel)*

