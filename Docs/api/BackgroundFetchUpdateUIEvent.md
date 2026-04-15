# BackgroundFetchUpdateUIEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `BackgroundFetchEvent`  
**Source:** `JSObjects/BackgroundFetchUpdateUIEvent.cs`  
**MDN Reference:** [BackgroundFetchUpdateUIEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent)

> The BackgroundFetchUpdateUIEvent interface of the Background Fetch API is an event type for the backgroundfetchsuccess and backgroundfetchfail events, and provides a method for updating the title and icon of the app to inform a user of the success or failure of a background fetch. https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent

## Methods

| Method | Return Type | Description |
|---|---|---|
| `UpdateUI(UpdateUIOptions? options)` | `Task` | The updateUI() method of the BackgroundFetchUpdateUIEvent interface updates the title and icon in the user interface to show the status of a background fetch. This method may only be run once, to notify the user on a failed or a successful fetch. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchUpdateUIEvent>(...)` or constructor `new BackgroundFetchUpdateUIEvent(...)`

```js
addEventListener("backgroundfetchsuccess", (event) => {
  const bgFetch = event.registration;

  event.waitUntil(
    (async () => {
      // Create/open a cache.
      const cache = await caches.open("downloads");
      // Get all the records.
      const records = await bgFetch.matchAll();
      // Copy each request/response across.
      const promises = records.map(async (record) => {
        const response = await record.responseReady;
        await cache.put(record.request, response);
      });

      // Wait for the copying to complete.
      await Promise.all(promises);

      // Update the progress notification.
      event.updateUI({ title: "Episode 5 ready to listen!" });
    })(),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent)*

