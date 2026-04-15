# LockInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/LockInfo.cs`  
**MDN Reference:** [LockInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#name)

> LockManager lock info https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#name

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `LockInfo` | `class` | get | LockManager lock info https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#name |
| `Mode` | `string` | get/set |  |
| `ClientId` | `string` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<LockInfo>(...)` or constructor `new LockInfo(...)`

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

