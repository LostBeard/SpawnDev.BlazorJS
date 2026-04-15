# ServiceWorker

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/ServiceWorker.cs`  
**MDN Reference:** [ServiceWorker on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorker)

> The ServiceWorker interface of the Service Worker API provides a reference to a service worker. Multiple browsing contexts (e.g. pages, workers, etc.) can be associated with the same service worker, each through a unique ServiceWorker object. The ServiceWorker object is not exposed to DedicatedWorkerGlobalScope and SharedWorkerGlobalScope. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorker

## Constructors

| Signature | Description |
|---|---|
| `ServiceWorker(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `State` | `string` | get | Returns the state of the service worker. It returns one of the following values: parsed installing installed activating activated redundant |
| `ScriptURL` | `string` | get | Returns the ServiceWorker serialized script URL defined as part of ServiceWorkerRegistration. The URL must be on the same origin as the document that registers the ServiceWorker. |
| `IsSupported` | `bool` | get | Returns true if navigator.serviceWorker is defined |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PostMessage(object message)` | `void` | Sends a message - consisting of any structured-cloneable JavaScript object - to the service worker. The message is transmitted to the service worker using a message event on its global scope. |
| `PostMessage(object message, object[] transfer)` | `void` | Sends a message - consisting of any structured-cloneable JavaScript object - to the service worker. The message is transmitted to the service worker using a message event on its global scope. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnStateChange` | `ActionEvent<Event>` | Fired when ServiceWorker.state changes. |
| `OnError` | `ActionEvent<Event>` | Fired when an error happens inside the ServiceWorker object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ServiceWorker>(...)` or constructor `new ServiceWorker(...)`

```js
if ("serviceWorker" in navigator) {
  navigator.serviceWorker
    .register("service-worker.js", {
      scope: "./",
    })
    .then((registration) => {
      let serviceWorker;
      if (registration.installing) {
        serviceWorker = registration.installing;
        document.querySelector("#kind").textContent = "installing";
      } else if (registration.waiting) {
        serviceWorker = registration.waiting;
        document.querySelector("#kind").textContent = "waiting";
      } else if (registration.active) {
        serviceWorker = registration.active;
        document.querySelector("#kind").textContent = "active";
      }
      if (serviceWorker) {
        // logState(serviceWorker.state);
        serviceWorker.addEventListener("statechange", (e) => {
          // logState(e.target.state);
        });
      }
    })
    .catch((error) => {
      // Something went wrong during registration. The service-worker.js file
      // might be unavailable or contain a syntax error.
    });
} else {
  // The current browser doesn't support service workers.
  // Perhaps it is too old or we are not in a Secure Context.
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorker)*

