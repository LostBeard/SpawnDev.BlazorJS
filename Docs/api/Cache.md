# Cache

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Cache.cs`  
**MDN Reference:** [Cache on MDN](https://developer.mozilla.org/en-US/docs/Web/API/Cache)

> The Cache interface provides a persistent storage mechanism for Request / Response object pairs that are cached in long lived memory. How long a Cache object lives is browser dependent, but a single origin's scripts can typically rely on the presence of a previously populated Cache object. Note that the Cache interface is exposed to windowed scopes as well as workers. You don't have to use it in conjunction with service workers, even though it is defined in the service worker spec. https://developer.mozilla.org/en-US/docs/Web/API/Cache

## Constructors

| Signature | Description |
|---|---|
| `Cache(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `OpenCache(string name)` | `Task<Cache>` | Non-standard shortcut method to open a cache using the global caches object |
| `CacheNames()` | `Task<List<string>>` | Non-standard method to get a list of the existing cache names using the global caches object |
| `Match(Request request)` | `Task<Response?>` | Returns a Promise that resolves to the response associated with the first matching request in the Cache object. |
| `Match(Request request, CacheMatchOptions options)` | `Task<Response?>` | Returns a Promise that resolves to the response associated with the first matching request in the Cache object. |
| `Match(string request)` | `Task<Response?>` | Returns a Promise that resolves to the response associated with the first matching request in the Cache object. |
| `Match(string request, CacheMatchOptions options)` | `Task<Response?>` | Returns a Promise that resolves to the response associated with the first matching request in the Cache object. |
| `MatchAll()` | `Task<Response[]>` | Returns a Promise that resolves to an array of all matching responses in the Cache object. |
| `MatchAll(string request)` | `Task<Response[]>` | Returns a Promise that resolves to an array of all matching responses in the Cache object. |
| `MatchAll(string request, CacheMatchOptions options)` | `Task<Response[]>` | Returns a Promise that resolves to an array of all matching responses in the Cache object. |
| `Add(Request request)` | `Task` | Takes a URL, retrieves it and adds the resulting response object to the given cache. This is functionally equivalent to calling fetch(), then using put() to add the results to the cache. |
| `AddAll(List<Request> requests)` | `Task` | Takes an array of URLs, retrieves them, and adds the resulting response objects to the given cache. |
| `Add(string request)` | `Task` | Takes a URL, retrieves it and adds the resulting response object to the given cache. This is functionally equivalent to calling fetch(), then using put() to add the results to the cache. |
| `AddAll(List<string> requests)` | `Task` | Takes an array of URLs, retrieves them, and adds the resulting response objects to the given cache. |
| `Put(string request, Response response)` | `Task` | Takes both a request and its response and adds it to the given cache. |
| `Put(Request request, Response response)` | `Task` | Takes both a request and its response and adds it to the given cache. |
| `Delete(string request)` | `Task<bool>` | Finds the Cache entry whose key is the request, returning a Promise that resolves to true if a matching Cache entry is found and deleted. If no Cache entry is found, the promise resolves to false. |
| `Delete(string request, CacheMatchOptions options)` | `Task<bool>` | Finds the Cache entry whose key is the request, returning a Promise that resolves to true if a matching Cache entry is found and deleted. If no Cache entry is found, the promise resolves to false. |
| `Delete(Request request)` | `Task<bool>` | Finds the Cache entry whose key is the request, returning a Promise that resolves to true if a matching Cache entry is found and deleted. If no Cache entry is found, the promise resolves to false. |
| `Delete(Request request, CacheMatchOptions options)` | `Task<bool>` | Finds the Cache entry whose key is the request, returning a Promise that resolves to true if a matching Cache entry is found and deleted. If no Cache entry is found, the promise resolves to false. |
| `Keys()` | `Task<Request[]>` | Returns a Promise that resolves to an array of Cache keys which are Request objects |
| `Keys(string request)` | `Task<Request[]>` | Returns a Promise that resolves to an array of Cache keys which are Request objects |
| `Keys(string request, CacheMatchOptions options)` | `Task<Request[]>` | Returns a Promise that resolves to an array of Cache keys which are Request objects |
| `Keys(Request request)` | `Task<Request[]>` | Returns a Promise that resolves to an array of Cache keys which are Request objects |
| `Keys(Request request, CacheMatchOptions options)` | `Task<Request[]>` | Returns a Promise that resolves to an array of Cache keys which are Request objects |

## Example

```csharp
// List all existing cache names
var cacheNames = await Cache.CacheNames();
foreach (var name in cacheNames)
{
    Console.WriteLine($"Cache: {name}");
}

// Open (or create) a named cache using the static shortcut
using var cache = await Cache.OpenCache("my-app-v1");

// Cache a URL - fetches and stores the response
await cache.Add("https://example.com/api/config.json");

// Cache multiple URLs at once
await cache.AddAll(new List<string>
{
    "/styles/app.css",
    "/scripts/app.js",
    "/images/logo.png"
});

// Look up a cached response by URL
using var response = await cache.Match("https://example.com/api/config.json");
if (response != null)
{
    var text = await response.Text();
    Console.WriteLine($"Cached response: {text}");
}

// Manually put a request/response pair into the cache
using var fetchResponse = await JS.CallAsync<Response>("fetch", "/api/data");
await cache.Put("/api/data", fetchResponse);

// List all cached request keys
var keys = await cache.Keys();
foreach (var key in keys)
{
    Console.WriteLine($"Cached: {key.Url}");
    key.Dispose();
}

// Delete a cached entry
var deleted = await cache.Delete("/api/data");
Console.WriteLine($"Deleted: {deleted}");
```

