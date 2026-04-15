# PermissionDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/PermissionDescriptor.cs`  
**MDN Reference:** [PermissionDescriptor on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Permissions/query)

> An object that sets options for the Permissions.query operation consisting of a comma-separated list of name-value pairs. https://developer.mozilla.org/en-US/docs/Web/API/Permissions/query

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PermissionDescriptor` | `class` | get | An object that sets options for the Permissions.query operation consisting of a comma-separated list of name-value pairs. https://developer.mozilla.org/en-US/docs/Web/API/Permissions/query |
| `UserVisibleOnly` | `bool?` | get |  |
| `Sysex` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PermissionDescriptor>(...)` or constructor `new PermissionDescriptor(...)`

### Display news based on geolocation permission

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

### Test support for various permissions

```js
// Array of permissions
const permissions = [
  "accelerometer",
  "accessibility-events",
  "ambient-light-sensor",
  "background-sync",
  "camera",
  "clipboard-read",
  "clipboard-write",
  "geolocation",
  "gyroscope",
  "local-fonts",
  "magnetometer",
  "microphone",
  "midi",
  "notifications",
  "payment-handler",
  "persistent-storage",
  "push",
  "screen-wake-lock",
  "storage-access",
  "top-level-storage-access",
  "window-management",
];

processPermissions();

// Iterate through the permissions and log the result
async function processPermissions() {
  for (const permission of permissions) {
    const result = await getPermission(permission);
    log(result);
  }
}

// Query a single permission in a try...catch block and return result
async function getPermission(permission) {
  try {
    let result;
    if (permission === "top-level-storage-access") {
      result = await navigator.permissions.query({
        name: permission,
        requestedOrigin: window.location.origin,
      });
    } else {
      result = await navigator.permissions.query({ name: permission });
    }
    return `${permission}: ${result.state}`;
  } catch (error) {
    return `${permission} (not supported)`;
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Permissions/query)*

