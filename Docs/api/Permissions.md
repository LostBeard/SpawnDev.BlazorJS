# Permissions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Permissions.cs`  
**MDN Reference:** [Permissions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Permissions)

> The Permissions interface of the Permissions API provides the core Permission API functionality, such as methods for querying and revoking permissions https://developer.mozilla.org/en-US/docs/Web/API/Permissions

## Constructors

| Signature | Description |
|---|---|
| `Permissions(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Query(PermissionDescriptor permissionDescriptor)` | `Task<PermissionStatus>` | Returns the user permission status for a given API. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<Permissions>(...)` or constructor `new Permissions(...)`

```js
navigator.permissions.query({ name: "geolocation" }).then((result) => {
  if (result.state === "granted") {
    showLocalNewsWithGeolocation();
  } else if (result.state === "prompt") {
    showButtonToEnableLocalNews();
  }
  // Don't do anything if the permission was denied.
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Permissions)*

