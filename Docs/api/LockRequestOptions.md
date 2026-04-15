# LockRequestOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/LockRequestOptions.cs`  
**MDN Reference:** [LockRequestOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request#options)

> An object describing characteristics of the lock you want to create. https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `LockRequestOptions` | `class` | get | An object describing characteristics of the lock you want to create. https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request#options |
| `IfAvailable` | `bool?` | get |  |
| `Steal` | `bool?` | get |  |
| `Signal` | `AbortSignal?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<LockRequestOptions>(...)` or constructor `new LockRequestOptions(...)`

### General Example

```js
await navigator.locks.request("my_resource", async (lock) => {
  // The lock was granted.
});
```

### `mode` example

```js
async function doRead() {
  await navigator.locks.request(
    "my_resource",
    { mode: "shared" },
    async (lock) => {
      // Read code here.
    },
  );
}
```

### `mode` example

```js
async function doWrite() {
  await navigator.locks.request(
    "my_resource",
    { mode: "exclusive" },
    async (lock) => {
      // Write code here.
    },
  );
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request)*

