# NavigationPreloadManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/NavigationPreloadManager.cs`  
**MDN Reference:** [NavigationPreloadManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NavigationPreloadManager)

> The NavigationPreloadManager interface of the Service Worker API provides methods for managing the preloading of resources in parallel with service worker bootup. If supported, an object of this type is returned by ServiceWorkerRegistration.navigationPreload. The result of a preload fetch request is waited on using the promise returned by FetchEvent.preloadResponse. https://developer.mozilla.org/en-US/docs/Web/API/NavigationPreloadManager

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Enable()` | `Task` | Enables navigation preloading, returning a Promise that resolves with undefined. |
| `SetHeaderValue(string value)` | `Task` | Sets the value of the Service-Worker-Navigation-Preload HTTP header sent in preloading requests and returns an empty Promise. An arbitrary string value, which the target server uses to determine what should returned for the requested resource. |
| `GetState()` | `Task<NavigationPreloadState>` | Returns a Promise that resolves to an object with properties that indicate whether preloading is enabled, and what value will be sent in the Service-Worker-Navigation-Preload HTTP header in preloading requests. |
| `Disable()` | `Task` | Disables navigation preloading, returning a Promise that resolves with undefined. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<NavigationPreloadManager>(...)` or constructor `new NavigationPreloadManager(...)`

### Feature detection and enabling navigation preloading

```js
addEventListener("activate", (event) => {
  event.waitUntil(
    (async () => {
      if (self.registration.navigationPreload) {
        // Enable navigation preloads!
        await self.registration.navigationPreload.enable();
      }
    })(),
  );
});
```

### Using a preloaded response

```js
addEventListener("fetch", (event) => {
  event.respondWith(
    (async () => {
      // Respond from the cache if we can
      const cachedResponse = await caches.match(event.request);
      if (cachedResponse) return cachedResponse;

      // Else, use the preloaded response, if it's there
      const response = await event.preloadResponse;
      if (response) return response;

      // Else try the network.
      return fetch(event.request);
    })(),
  );
});
```

### Custom responses

```js
navigator.serviceWorker.ready
  .then((registration) =>
    registration.navigationPreload.setHeaderValue(newValue),
  )
  .then(() => {
    console.log("Done!");
  });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NavigationPreloadManager)*

