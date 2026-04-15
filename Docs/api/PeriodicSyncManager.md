# PeriodicSyncManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PeriodicSyncManager.cs`  
**MDN Reference:** [PeriodicSyncManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncManager)

> The PeriodicSyncManager interface of the Web Periodic Background Synchronization API provides a way to register tasks to be run in a service worker at periodic intervals with network connectivity. These tasks are referred to as periodic background sync requests. Access PeriodicSyncManager through the ServiceWorkerRegistration.periodicSync. https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncManager

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Register(string tag, PeriodicSyncOptions? options)` | `Task` | The register() method of the PeriodicSyncManager interface registers a periodic sync request with the browser with the specified tag and options. It returns a Promise that resolves when the registration completes. A unique String identifier. |
| `Unregister(string tag)` | `Task` | The unregister() method of the PeriodicSyncManager interface unregisters the periodic sync request corresponding to the specified tag and returns a Promise that resolves when unregistration completes. The unique String descriptor for the specific background sync. |
| `GetTags()` | `Task<string[]>` | The getTags() method of the PeriodicSyncManager interface returns a Promise that resolves with a list of String objects representing the tags that are currently registered for periodic syncing. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PeriodicSyncManager>(...)` or constructor `new PeriodicSyncManager(...)`

### Requesting a Periodic Background Sync

```js
async function registerPeriodicNewsCheck() {
  const registration = await navigator.serviceWorker.ready;
  try {
    await registration.periodicSync.register("get-latest-news", {
      minInterval: 24 * 60 * 60 * 1000,
    });
  } catch {
    console.log("Periodic Sync could not be registered!");
  }
}
```

### Verifying a Background Periodic Sync by Tag

```js
navigator.serviceWorker.ready.then((registration) => {
  registration.periodicSync.getTags().then((tags) => {
    if (tags.includes("get-latest-news")) skipDownloadingLatestNewsOnPageLoad();
  });
});
```

### Removing a Periodic Background Sync Task

```js
navigator.serviceWorker.ready.then((registration) => {
  registration.periodicSync.unregister("get-latest-news");
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PeriodicSyncManager)*

