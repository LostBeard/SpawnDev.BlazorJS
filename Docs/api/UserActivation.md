# UserActivation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/UserActivation.cs`  
**MDN Reference:** [UserActivation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/UserActivation)

> The UserActivation interface allows querying information about a window's user activation state. https://developer.mozilla.org/en-US/docs/Web/API/UserActivation https://developer.mozilla.org/en-US/docs/Web/Security/User_activation

## Constructors

| Signature | Description |
|---|---|
| `UserActivation(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HasBeenActive` | `bool` | get | Indicates whether the current window has sticky user activation. |
| `IsActive` | `bool` | get | Indicates whether the current window has transient user activation. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<UserActivation>(...)` or constructor `new UserActivation(...)`

### Checking if a user gesture was recently performed

```js
if (navigator.userActivation.isActive) {
  // proceed to request playing media, for example
}
```

### Checking if a user gesture was ever performed

```js
if (navigator.userActivation.hasBeenActive) {
  // proceed with auto-playing an animation, for example
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/UserActivation)*

