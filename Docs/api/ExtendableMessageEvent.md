# ExtendableMessageEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/ExtendableMessageEvent.cs`  
**MDN Reference:** [ExtendableMessageEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ExtendableMessageEvent)

> The ExtendableMessageEvent interface of the Service Worker API represents the event object of a message event fired on a service worker (when a message is received on the ServiceWorkerGlobalScope from another context) - extends the lifetime of such events. https://developer.mozilla.org/en-US/docs/Web/API/ExtendableMessageEvent

## Constructors

| Signature | Description |
|---|---|
| `ExtendableMessageEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `JSObject?` | get | Returns the data as a JSObject, whcih can represent any data type. |
| `Origin` | `string` | get | Returns the origin of the Client that sent the message. |
| `LastEventID` | `string` | get | Represents, in server-sent events, the last event ID of the event source. |
| `Source` | `Client` | get | Returns a reference to the Client object that sent the message. |
| `Ports` | `Array<MessagePort>` | get | Returns the array containing the MessagePort objects representing the ports of the associated message channel. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetData()` | `T` | Returns the event's data. It can be any data type. If dispatched in messageerror event, the property will be null. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ExtendableMessageEvent>(...)` or constructor `new ExtendableMessageEvent(...)`

```js
// in the page being controlled
if (navigator.serviceWorker) {
  navigator.serviceWorker.register("service-worker.js");

  navigator.serviceWorker.addEventListener("message", (event) => {
    // event is a MessageEvent object
    console.log(`The service worker sent me a message: ${event.data}`);
  });

  navigator.serviceWorker.ready.then((registration) => {
    registration.active.postMessage("Hi service worker");
  });
}
```

```js
// in the service worker
addEventListener("message", (event) => {
  // event is an ExtendableMessageEvent object
  console.log(`The client sent me a message: ${event.data}`);

  event.source.postMessage("Hi client");
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ExtendableMessageEvent)*

## Examples

**JavaScript (MDN):**

```js
// in the page being controlled
if (navigator.serviceWorker) {
  navigator.serviceWorker.register("service-worker.js");

  navigator.serviceWorker.addEventListener("message", (event) => {
    // event is a MessageEvent object
    console.log(`The service worker sent me a message: ${event.data}`);
  });

  navigator.serviceWorker.ready.then((registration) => {
    registration.active.postMessage("Hi service worker");
  });
}
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

// in the page being controlled
if (JS.Get<Navigator>("navigator").ServiceWorker) {
JS.Get<Navigator>("navigator").ServiceWorker.register("service-worker.js");

JS.Get<Navigator>("navigator").ServiceWorker.addEventListener("message", (event) => {
// event is a MessageEvent object
Console.WriteLine($"The service worker sent me a message: {event.Data}");
});

JS.Get<Navigator>("navigator").ServiceWorker.ready; // then: use await instead;
registration.active.postMessage("Hi service worker");
});
}
```

**JavaScript (MDN):**

```js
// in the service worker
addEventListener("message", (event) => {
  // event is an ExtendableMessageEvent object
  console.log(`The client sent me a message: ${event.data}`);

  event.source.postMessage("Hi client");
});
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

// in the service worker
addEventListener("message", (event) => {
// event is an ExtendableMessageEvent object
Console.WriteLine($"The client sent me a message: {event.Data}");

event.Source.postMessage("Hi client");
});
```

