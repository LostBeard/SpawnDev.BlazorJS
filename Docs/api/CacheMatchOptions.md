# CacheMatchOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/CacheMatchOptions.cs`  
**MDN Reference:** [CacheMatchOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Cache/match#options)

> An object that sets options for the match operation https://developer.mozilla.org/en-US/docs/Web/API/Cache/match#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CacheMatchOptions` | `class` | get/set | An object that sets options for the match operation https://developer.mozilla.org/en-US/docs/Web/API/Cache/match#options |
| `IgnoreMethod` | `bool?` | get/set |  |
| `IgnoreVary` | `bool?` | get |  |
| `CacheName` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CacheMatchOptions>(...)` or constructor `new CacheMatchOptions(...)`

```js
self.addEventListener("fetch", (event) => {
  // We only want to call event.respondWith() if this is a GET request for an HTML document.
  if (
    event.request.method === "GET" &&
    event.request.headers.get("accept").includes("text/html")
  ) {
    console.log("Handling fetch event for", event.request.url);
    event.respondWith(
      fetch(event.request).catch((e) => {
        console.error("Fetch failed; returning offline page instead.", e);
        return caches
          .open(OFFLINE_CACHE)
          .then((cache) => cache.match(OFFLINE_URL));
      }),
    );
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Cache/match)*

