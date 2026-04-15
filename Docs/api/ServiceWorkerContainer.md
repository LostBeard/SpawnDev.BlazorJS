# ServiceWorkerContainer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/ServiceWorkerContainer.cs`  
**MDN Reference:** [ServiceWorkerContainer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer)

> The ServiceWorkerContainer interface of the Service Worker API provides an object representing the service worker as an overall unit in the network ecosystem, including facilities to register, unregister and update service workers, and access the state of service workers and their registrations. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer

## Constructors

| Signature | Description |
|---|---|
| `ServiceWorkerContainer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Controller` | `ServiceWorker?` | get | Returns a ServiceWorker object if its state is activating or activated (the same object returned by ServiceWorkerRegistration.active). This property returns null during a force-refresh request (Shift + refresh) or if there is no active worker. |
| `Ready` | `Task<ServiceWorkerRegistration>` | get | Provides a way of delaying code execution until a service worker is active. It returns a Promise that will never reject, and which waits indefinitely until the ServiceWorkerRegistration associated with the current page has an ServiceWorkerRegistration.active worker. Once that condition is met, it resolves with the ServiceWorkerRegistration. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetRegistrations()` | `Task<ServiceWorkerRegistration[]>` | Returns all ServiceWorkerRegistration objects associated with a ServiceWorkerContainer in an array. The method returns a Promise that resolves to an array of ServiceWorkerRegistration. |
| `GetRegistration()` | `Task<ServiceWorkerRegistration?>` | Gets a ServiceWorkerRegistration object whose scope matches the provided document URL. The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined. |
| `StartMessages()` | `void` | Explicitly starts the flow of messages being dispatched from a service worker to pages under its control (e.g. sent via Client.postMessage()). This can be used to react to sent messages earlier, even before that page's content has finished loading. |
| `GetRegistration(string clientUrl)` | `Task<ServiceWorkerRegistration?>` | Gets a ServiceWorkerRegistration object whose scope matches the provided document URL. The method returns a Promise that resolves to a ServiceWorkerRegistration or undefined. |
| `Register(string scriptURL, ServiceWorkerRegistrationOptions? options)` | `Task<ServiceWorkerRegistration>` | Creates or updates a ServiceWorkerRegistration for the given scriptURL. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnControllerChange` | `ActionEvent<Event>` | Occurs when the document's associated ServiceWorkerRegistration acquires a new active worker. |
| `OnMessage` | `ActionEvent<MessageEvent>` | Occurs when incoming messages are received by the ServiceWorkerContainer object (e.g. via a MessagePort.postMessage() call). |
| `OnMessageError` | `ActionEvent<MessageEvent>` | Fired when incoming messages can not deserialized by the ServiceWorkerContainer object (e.g. via a MessagePort.postMessage() call). |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ServiceWorkerContainer>(...)` or constructor `new ServiceWorkerContainer(...)`

```js
if ("serviceWorker" in navigator) {
  // Register a service worker hosted at the root of the
  // site using the default scope.
  navigator.serviceWorker
    .register("/sw.js")
    .then((registration) => {
      console.log("Service worker registration succeeded:", registration);

      // At this point, you can optionally do something
      // with registration. See https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration
    })
    .catch((error) => {
      console.error(`Service worker registration failed: ${error}`);
    });

  // Independent of the registration, let's also display
  // information about whether the current page is controlled
  // by an existing service worker, and when that
  // controller changes.

  // First, do a one-off check if there's currently a
  // service worker in control.
  if (navigator.serviceWorker.controller) {
    console.log(
      "This page is currently controlled by:",
      navigator.serviceWorker.controller,
    );
  }

  // Then, register a handler to detect when a new or
  // updated service worker takes control.
  navigator.serviceWorker.oncontrollerchange = () => {
    console.log(
      "This page is now controlled by",
      navigator.serviceWorker.controller,
    );
  };
} else {
  console.log("Service workers are not supported.");
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerContainer)*

