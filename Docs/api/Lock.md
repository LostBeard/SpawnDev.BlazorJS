# Lock

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Lock.cs`  
**MDN Reference:** [Lock on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Lock)

> The Lock interface of the Web Locks API provides the name and mode of a lock. This may be a newly requested lock that is received in the callback to LockManager.request(), or a record of an active or queued lock returned by LockManager.query(). https://developer.mozilla.org/en-US/docs/Web/API/Lock

## Constructors

| Signature | Description |
|---|---|
| `Lock(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Mode` | `string` | get | Returns the access mode passed to LockManager.request() when the lock was requested. The mode is either "exclusive" (the default) or "shared". |
| `Name` | `string` | get | Returns the name passed to LockManager.request() when the lock was requested. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Lock>(...)` or constructor `new Lock(...)`

```js
navigator.locks.request("net_db_sync", showLockProperties);
navigator.locks.request("another_lock", { mode: "shared" }, showLockProperties);

function showLockProperties(lock) {
  console.log(`The lock name is: ${lock.name}`);
  console.log(`The lock mode is: ${lock.mode}`);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Lock)*

