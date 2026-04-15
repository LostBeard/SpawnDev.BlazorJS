# PushSubscription

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PushSubscription.cs`  
**MDN Reference:** [PushSubscription on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushSubscription)

> The PushSubscription interface of the Push API provides a subscription's URL endpoint and allows unsubscribing from a push service. https://developer.mozilla.org/en-US/docs/Web/API/PushSubscription

## Constructors

| Signature | Description |
|---|---|
| `PushSubscription(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Endpoint` | `string` | get | A string containing the endpoint associated with the push subscription. |
| `ExpirationTime` | `double?` | get | A DOMHighResTimeStamp of the subscription expiration time associated with the push subscription, if there is one, or null otherwise. |
| `Options` | `PushManagerSubscribeOptions` | get | An object containing the options used to create the subscription. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Unsubscribe()` | `Task<bool>` | Starts the asynchronous process of unsubscribing from the push service, returning a Promise that resolves to a boolean value when the current subscription is successfully unregistered. |
| `GetKey(string keyName)` | `ArrayBuffer` | Returns an ArrayBuffer which contains the client's public key, which can then be sent to a server and used in encrypting push message data. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PushSubscription>(...)` or constructor `new PushSubscription(...)`

### Sending coding information to the server

```js
// Get a PushSubscription object
const pushSubscription =
  await serviceWorkerRegistration.pushManager.subscribe();

// Create an object containing the information needed by the app server
const subscriptionObject = {
  endpoint: pushSubscription.endpoint,
  keys: {
    p256dh: pushSubscription.getKey("p256dh"),
    auth: pushSubscription.getKey("auth"),
  },
  encoding: PushManager.supportedContentEncodings,
  /* other app-specific data, such as user identity */
};

// Stringify the object and post to the app server
fetch("https://example.com/push/", {
  method: "post",
  body: JSON.stringify(subscriptionObject),
});
```

### Unsubscribing from a push manager

```js
navigator.serviceWorker.ready
  .then((reg) => reg.pushManager.getSubscription())
  .then((subscription) => subscription.unsubscribe())
  .then((successful) => {
    // You've successfully unsubscribed
  })
  .catch((e) => {
    // Unsubscribing failed
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushSubscription)*

