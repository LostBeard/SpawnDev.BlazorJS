# PermissionStatus

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/PermissionStatus.cs`  
**MDN Reference:** [PermissionStatus on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PermissionStatus)

> The PermissionStatus interface of the Permissions API provides the state of an object and an event handler for monitoring changes to said state. https://developer.mozilla.org/en-US/docs/Web/API/PermissionStatus

## Constructors

| Signature | Description |
|---|---|
| `PermissionStatus(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Name` | `string` | get | Returns the name of a requested permission, identical to the name passed to Permissions.query |
| `State` | `string` | get | Returns the state of a requested permission; one of 'granted', 'denied', or 'prompt'. |
| `Status` | `string` | get | Returns the state of a requested permission; one of 'granted', 'denied', or 'prompt'. Later versions of the specification replace this with PermissionStatus.state. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnChange` | `ActionEvent<Event>` | The change event of the PermissionStatus interface fires whenever the PermissionStatus.state property changes. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PermissionStatus>(...)` or constructor `new PermissionStatus(...)`

```js
navigator.permissions
  .query({ name: "geolocation" })
  .then((permissionStatus) => {
    console.log(`geolocation permission status is ${permissionStatus.state}`);
    permissionStatus.onchange = () => {
      console.log(
        `geolocation permission status has changed to ${permissionStatus.state}`,
      );
    };
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PermissionStatus)*

