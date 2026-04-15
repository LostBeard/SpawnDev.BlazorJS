# FetchEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/FetchEvent.cs`  
**MDN Reference:** [FetchEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FetchEvent)

> This is the event type for fetch events dispatched on the service worker global scope. It contains information about the fetch, including the request and how the receiver will treat the response. It provides the event.respondWith() method, which allows us to provide a response to this fetch. https://developer.mozilla.org/en-US/docs/Web/API/FetchEvent

## Constructors

| Signature | Description |
|---|---|
| `FetchEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ClientId` | `string` | get | The id of the same-origin client that initiated the fetch. |
| `Handled` | `Promise` | get | A promise that is pending while the event has not been handled, and fulfilled once it has. |
| `PreloadResponse` | `Task<Response>` | get | The Request the browser intends to make. |
| `ReplacesClientId` | `string` | get | The id of the client that is being replaced during a page navigation. |
| `ResultingClientId` | `string` | get | The id of the client that replaces the previous client during a page navigation. |
| `Request` | `Request` | get | The Request the browser intends to make. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RespondWith(Task<Response> response)` | `void` | Prevent the browser's default fetch handling, and provide (a promise for) a response yourself. |
| `RespondWith(Promise<Response> response)` | `void` | Prevent the browser's default fetch handling, and provide (a promise for) a response yourself. |
| `RespondWith(Response response)` | `void` | Prevent the browser's default fetch handling, and provide (a promise for) a response yourself. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<FetchEvent>(...)` or constructor `new FetchEvent(...)`

```js
self.addEventListener("fetch", (event) => {
  // Let the browser do its default thing
  // for non-GET requests.
  if (event.request.method !== "GET") return;

  // Prevent the default, and handle the request ourselves.
  event.respondWith(
    (async () => {
      // Try to get the response from a cache.
      const cache = await caches.open("dynamic-v1");
      const cachedResponse = await cache.match(event.request);

      if (cachedResponse) {
        // If we found a match in the cache, return it, but also
        // update the entry in the cache in the background.
        event.waitUntil(cache.add(event.request));
        return cachedResponse;
      }

      // If we didn't find a match in the cache, use the network.
      return fetch(event.request);
    })(),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/FetchEvent)*

## Examples

**JavaScript (MDN):**

```js
self.addEventListener("fetch", (event) => {
  // Let the browser do its default thing
  // for non-GET requests.
  if (event.request.method !== "GET") return;

  // Prevent the default, and handle the request ourselves.
  event.respondWith(
    (async () => {
      // Try to get the response from a cache.
      const cache = await caches.open("dynamic-v1");
      const cachedResponse = await cache.match(event.request);

      if (cachedResponse) {
        // If we found a match in the cache, return it, but also
        // update the entry in the cache in the background.
        event.waitUntil(cache.add(event.request));
        return cachedResponse;
      }

      // If we didn't find a match in the cache, use the network.
      return fetch(event.request);
    })(),
  );
});
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

self.addEventListener("fetch", (event) => {
// Let the browser do its default thing
// for non-GET requests.
if (event.Request.method != "GET") return;

// Prevent the default, and handle the request ourselves.
event.RespondWith(
(async () => {
// Try to get the response from a cache.
using var cache = await caches.open("dynamic-v1");
using var cachedResponse = await cache.match(event.Request);

if (cachedResponse) {
// If we found a match in the cache, return it, but also
// update the entry in the cache in the background.
event.waitUntil(cache.add(event.Request));
return cachedResponse;
}

// If we didn't find a match in the cache, use the network.
return await JS.CallAsync<Response>("fetch", event.Request);
})(),
);
});
```

