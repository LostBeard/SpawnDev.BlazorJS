# ServiceWorkerRegistration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/ServiceWorkerRegistration.cs`  
**MDN Reference:** [ServiceWorkerRegistration on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration)

> The ServiceWorkerRegistration interface of the Service Worker API represents the service worker registration. You register a service worker to control one or more pages that share the same origin. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Active` | `ServiceWorker?` | get | Returns a service worker whose state is activating or activated. This is initially set to null. An active worker will control a Client if the client's URL falls within the scope of the registration (the scope option set when ServiceWorkerContainer.register is first called.) |
| `BackgroundFetch` | `BackgroundFetchManager?` | get | Returns a reference to a BackgroundFetchManager object, which manages background fetch operations. |
| `Cookies` | `CookieStoreManager?` | get | Returns a reference to the CookieStoreManager interface, which allows subscribe and unsubscribe to cookie change events. |
| `NavigationPreload` | `NavigationPreloadManager` | get/set | Returns the instance of NavigationPreloadManager associated with the current service worker registration. |
| `Installing` | `ServiceWorker?` | get/set | Returns a service worker whose state is installing. This is initially set to null. |
| `Waiting` | `ServiceWorker?` | get | Returns a service worker whose state is installed. This is initially set to null. |
| `PaymentManager` | `PaymentManager?` | get | Returns a payment app's PaymentManager instance, which is used to manage various payment app functionality. |
| `PushManager` | `PushManager?` | get | Returns a reference to the PushManager interface for managing push subscriptions including subscribing, getting an active subscription, and accessing push permission status. |
| `Sync` | `SyncManager?` | get | Returns a reference to the SyncManager interface, which manages background synchronization processes. |
| `PeriodicSync` | `PeriodicSyncManager?` | get | Returns a reference to the PeriodicSyncManager interface, which allows for registering of tasks to run at specific intervals. |
| `UpdateViaCache` | `string` | get | Returns a string indicating what is the cache strategy to use when updating the service worker scripts. It can be one of the following: imports, all, or none. |
| `Scope` | `string` | get | Returns a string representing a URL that defines a service worker's registration scope; that is, the range of URLs the service worker can control. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetNotifications()` | `Task<Array<Notification>>` | Returns a list of the notifications in the order that they were created from the current origin via the current service worker registration. |
| `GetNotifications(GetNotificationsOptions options)` | `Task<Array<Notification>>` | Returns a list of the notifications in the order that they were created from the current origin via the current service worker registration. |
| `ShowNotification(string title)` | `Task` | Displays the notification with the requested title. |
| `ShowNotification(string title, ShowNotificationsOptions options)` | `Task` | Displays the notification with the requested title. |
| `Unregister()` | `Task<bool>` | Unregisters the service worker registration and returns a Promise. The service worker will finish any ongoing operations before it is unregistered. |
| `Update()` | `Task<ServiceWorkerRegistration>` | Checks the server for an updated version of the service worker without consulting caches. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnUpdateFound` | `ActionEvent<Event>` | The updatefound event of the ServiceWorkerRegistration interface is fired any time the ServiceWorkerRegistration.installing property acquires a new service worker. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ServiceWorkerRegistration>(...)` or constructor `new ServiceWorkerRegistration(...)`

```js
if ("serviceWorker" in navigator) {
  navigator.serviceWorker
    .register("/sw.js")
    .then((registration) => {
      registration.addEventListener("updatefound", () => {
        // If updatefound is fired, it means that there's
        // a new service worker being installed.
        const installingWorker = registration.installing;
        console.log(
          "A new service worker is being installed:",
          installingWorker,
        );

        // You can listen for changes to the installing service worker's
        // state via installingWorker.onstatechange
      });
    })
    .catch((error) => {
      console.error(`Service worker registration failed: ${error}`);
    });
} else {
  console.error("Service workers are not supported.");
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration)*

