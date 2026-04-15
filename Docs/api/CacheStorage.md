# CacheStorage

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/CacheStorage.cs`  
**MDN Reference:** [CacheStorage on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CacheStorage)

> The CacheStorage interface represents the storage for Cache objects. https://developer.mozilla.org/en-US/docs/Web/API/CacheStorage

## Constructors

| Signature | Description |
|---|---|
| `CacheStorage(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CacheStorage()` | Non-standard constructor shortcut to just get an instance of the global caches object |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Delete(string cacheName)` | `Task<bool>` | Finds the Cache object matching the cacheName, and if found, deletes the Cache object and returns a Promise that resolves to true. If no Cache object is found, it resolves to false. |
| `Has(string cacheName)` | `Task<bool>` | Returns a Promise that resolves to true if a Cache object matching the cacheName exists. |
| `Keys()` | `Task<List<string>>` | Returns a Promise that will resolve with an array containing strings corresponding to all of the named Cache objects tracked by the CacheStorage. Use this method to iterate over a list of all the Cache objects |
| `Match(string request, CacheMatchOptions options)` | `Task<Response?>` | Checks if a given Request is a key in any of the Cache objects that the CacheStorage object tracks, and returns a Promise that resolves to that match. |
| `Match(Request request, CacheMatchOptions options)` | `Task<Response?>` | Checks if a given Request is a key in any of the Cache objects that the CacheStorage object tracks, and returns a Promise that resolves to that match. |
| `Match(string request)` | `Task<Response?>` | Checks if a given Request is a key in any of the Cache objects that the CacheStorage object tracks, and returns a Promise that resolves to that match. |
| `Match(Request request)` | `Task<Response?>` | Checks if a given Request is a key in any of the Cache objects that the CacheStorage object tracks, and returns a Promise that resolves to that match. |
| `Open(string cacheName)` | `Task<Cache>` | Returns a Promise that resolves to the Cache object matching the cacheName (a new cache is created if it doesn't already exist.) |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CacheStorage>(...)` or constructor `new CacheStorage(...)`

```js
self.addEventListener("install", (event) => {
  event.waitUntil(
    caches
      .open("v1")
      .then((cache) =>
        cache.addAll([
          "/",
          "/index.html",
          "/style.css",
          "/app.js",
          "/image-list.js",
          "/star-wars-logo.jpg",
          "/gallery/bountyHunters.jpg",
          "/gallery/myLittleVader.jpg",
          "/gallery/snowTroopers.jpg",
        ]),
      ),
  );
});

self.addEventListener("fetch", (event) => {
  event.respondWith(
    caches.match(event.request).then((response) => {
      // caches.match() always resolves
      // but in case of success response will have value
      if (response !== undefined) {
        return response;
      }
      return fetch(event.request)
        .then((response) => {
          // response may be used only once
          // we need to save clone to put one copy in cache
          // and serve second one
          let responseClone = response.clone();

          caches
            .open("v1")
            .then((cache) => cache.put(event.request, responseClone));
          return response;
        })
        .catch(() => caches.match("/gallery/myLittleVader.jpg"));
    }),
  );
});
```

```js
// Try to get data from the cache, but fall back to fetching it live.
async function getData() {
  const cacheVersion = 1;
  const cacheName = `myapp-${cacheVersion}`;
  const url = "https://jsonplaceholder.typicode.com/todos/1";
  let cachedData = await getCachedData(cacheName, url);

  if (cachedData) {
    console.log("Retrieved cached data");
    return cachedData;
  }

  console.log("Fetching fresh data");

  const cacheStorage = await caches.open(cacheName);
  await cacheStorage.add(url);
  cachedData = await getCachedData(cacheName, url);
  await deleteOldCaches(cacheName);

  return cachedData;
}

// Get data from the cache.
async function getCachedData(cacheName, url) {
  const cacheStorage = await caches.open(cacheName);
  const cachedResponse = await cacheStorage.match(url);

  if (!cachedResponse || !cachedResponse.ok) {
    return false;
  }

  return await cachedResponse.json();
}

// Delete any old caches to respect user's disk space.
async function deleteOldCaches(currentCache) {
  const keys = await caches.keys();

  for (const key of keys) {
    const isOurCache = key.startsWith("myapp-");
    if (currentCache === key || !isOurCache) {
      continue;
    }
    caches.delete(key);
  }
}

try {
  const data = await getData();
  console.log({ data });
} catch (error) {
  console.error({ error });
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CacheStorage)*

