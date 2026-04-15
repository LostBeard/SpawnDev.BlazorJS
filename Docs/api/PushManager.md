# PushManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PushManager.cs`  
**MDN Reference:** [PushManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushManager)

> The PushManager interface of the Push API provides a way to receive notifications from third-party servers as well as request URLs for push notifications. https://developer.mozilla.org/en-US/docs/Web/API/PushManager

## Constructors

| Signature | Description |
|---|---|
| `PushManager(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Subscribe()` | `Task<PushSubscription>` | Subscribes to a push service. It returns a Promise that resolves to a PushSubscription object containing details of a push subscription. A new push subscription is created if the current service worker does not have an existing subscription. |
| `Subscribe(PushManagerSubscribeOptions options)` | `Task<PushSubscription>` | Subscribes to a push service. It returns a Promise that resolves to a PushSubscription object containing details of a push subscription. A new push subscription is created if the current service worker does not have an existing subscription. |
| `GetSubscription()` | `Task<PushSubscription?>` | Retrieves an existing push subscription. It returns a Promise that resolves to a PushSubscription object containing details of an existing subscription. If no existing subscription exists, this resolves to a null value. |
| `PermissionState()` | `Task<string>` | Returns a Promise that resolves to the permission state of the current PushManager, which will be one of 'granted', 'denied', or 'prompt'. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PushManager>(...)` or constructor `new PushManager(...)`

```js
this.onpush = (event) => {
  console.log(event.data);
  // From here we can write the data to IndexedDB, send it to any open
  // windows, display a notification, etc.
};

navigator.serviceWorker
  .register("serviceworker.js")
  .then((serviceWorkerRegistration) => {
    serviceWorkerRegistration.pushManager.subscribe().then(
      (pushSubscription) => {
        console.log(pushSubscription.endpoint);
        // The push subscription details needed by the application
        // server are now available, and can be sent to it using,
        // for example, the fetch() API.
      },
      (error) => {
        console.error(error);
      },
    );
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushManager)*

