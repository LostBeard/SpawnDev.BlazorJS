# LockManagerState

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/LockManagerState.cs`  
**MDN Reference:** [LockManagerState on MDN](https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#return_value)

> An object containing a snapshot of the LockManager state. https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#return_value

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `LockManagerState` | `class` | get | An object containing a snapshot of the LockManager state. https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#return_value |
| `Pending` | `LockInfo[]` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<LockManagerState>(...)` or constructor `new LockManagerState(...)`

```js
const state = await navigator.locks.query();
for (const lock of state.held) {
  console.log(`held lock: name ${lock.name}, mode ${lock.mode}`);
}
for (const request of state.pending) {
  console.log(`requested lock: name ${request.name}, mode ${request.mode}`);
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query)*

