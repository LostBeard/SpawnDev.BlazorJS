# ServiceWorkerGlobalScope

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WorkerGlobalScope`  
**Source:** `JSObjects/ServiceWorkerGlobalScope.cs`  
**MDN Reference:** [ServiceWorkerGlobalScope on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope)

> The ServiceWorkerGlobalScope interface of the Service Worker API represents the global execution context of a service worker. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Registration` | `ServiceWorkerRegistration` | get | Contains the ServiceWorkerRegistration object that represents the service worker's registration. |
| `Clients` | `Clients` | get | Contains the Clients object associated with the service worker. |
| `Self` | `override ServiceWorkerGlobalScope` | get | Returns an object reference to the ServiceWorkerGlobalScope object itself |
| `CookieStore` | `CookieStore?` | get | Returns a reference to the CookieStore object, or null if not supported. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SkipWaiting()` | `Task` | The ServiceWorkerGlobalScope.skipWaiting() method of the ServiceWorkerGlobalScope forces the waiting service worker to become the active service worker Use this method with Clients.claim() to ensure that updates to the underlying service worker take effect immediately for both the current client and all other active Usually called in the service worker 'install' event |

## Events

| Event | Type | Description |
|---|---|---|
| `OnActivate` | `ActionEvent<ExtendableEvent>` | Occurs when a ServiceWorkerRegistration acquires a new ServiceWorkerRegistration.active worker. |
| `OnBackgroundFetchAbort` | `ActionEvent<BackgroundFetchEvent>` | Fired when a background fetch operation has been canceled by the user or the app. |
| `OnBackgroundFetchClick` | `ActionEvent<BackgroundFetchEvent>` | Fired when the user has clicked on the UI for a background fetch operation. |
| `OnBackgroundFetchFail` | `ActionEvent<BackgroundFetchUpdateUIEvent>` | Fired when at least one of the requests in a background fetch operation has failed. |
| `OnBackgroundFetchSuccess` | `ActionEvent<BackgroundFetchUpdateUIEvent>` | Fired when all of the requests in a background fetch operation have succeeded. |
| `OnCanMakePayment` | `ActionEvent<CanMakePaymentEvent>` | Fired on a payment app's service worker to check whether it is ready to handle a payment. Specifically, it is fired when the merchant website calls the PaymentRequest() constructor. |
| `OnContentDelete` | `ActionEvent<ContentIndexEvent>` | Occurs when an item is removed from the ContentIndex. |
| `OnCookieChange` | `ActionEvent<ExtendableCookieChangeEvent>` | Fired when a cookie change has occurred that matches the service worker's cookie change subscription list. |
| `OnFetch` | `ActionEvent<FetchEvent>` | Occurs when a fetch() is called. |
| `OnInstall` | `ActionEvent<ExtendableEvent>` | Occurs when a ServiceWorkerRegistration acquires a new ServiceWorkerRegistration.installing worker. |
| `OnMessage` | `ActionEvent<ExtendableMessageEvent>` | Occurs when incoming messages are received. Controlled pages can use the MessagePort.postMessage() method to send messages to service workers. |
| `OnMessageError` | `ActionEvent<ExtendableMessageEvent>` | Occurs when incoming messages can't be deserialized. |
| `OnNotificationClick` | `ActionEvent<NotificationEvent>` | Occurs when a user clicks on a displayed notification. |
| `OnNotificationClose` | `ActionEvent<NotificationEvent>` | Occurs when a user closes a displayed notification. |
| `OnPaymentRequest` | `ActionEvent<PaymentRequestEvent>` | Fired on a payment app when a payment flow has been initiated on the merchant website via the PaymentRequest.show() method. |
| `OnPeriodicSync` | `ActionEvent<PeriodicSyncEvent>` | Occurs at periodic intervals, which were specified when registering a PeriodicSyncManager. |
| `OnPush` | `ActionEvent<PushEvent>` | Occurs when a server push notification is received. |
| `OnPushSubscriptionChange` | `ActionEvent<PushSubscriptionChangeEvent>` | Occurs when a push subscription has been invalidated, or is about to be invalidated (e.g. when a push service sets an expiration time). |
| `OnSync` | `ActionEvent<SyncEvent>` | Triggered when a call to SyncManager.register is made from a service worker client page. The attempt to sync is made either immediately if the network is available or as soon as the network becomes available. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ServiceWorkerGlobalScope>(...)` or constructor `new ServiceWorkerGlobalScope(...)`

```js
self.addEventListener("fetch", (event) => {
  console.log("Handling fetch event for", event.request.url);

  event.respondWith(
    caches.match(event.request).then((response) => {
      if (response) {
        console.log("Found response in cache:", response);

        return response;
      }
      console.log("No response found in cache. About to fetch from network…");

      return fetch(event.request).then(
        (response) => {
          console.log("Response from network is:", response);

          return response;
        },
        (error) => {
          console.error("Fetching failed:", error);

          throw error;
        },
      );
    }),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerGlobalScope)*

