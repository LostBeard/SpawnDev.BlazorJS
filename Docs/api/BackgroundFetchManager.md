# BackgroundFetchManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/BackgroundFetchManager.cs`  
**MDN Reference:** [BackgroundFetchManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager)

> The BackgroundFetchManager interface of the Background Fetch API is a map where the keys are background fetch IDs and the values are BackgroundFetchRegistration objects. https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Fetch(string id, IEnumerable<Union<string, Request>> requests, BackgroundFetchOptions options)` | `Task<BackgroundFetchRegistration>` | Returns a Promise that resolves with a BackgroundFetchRegistration object for a supplied array of URLs and Request objects. |
| `Get(string id)` | `Task<BackgroundFetchRegistration?>` | Returns a Promise that resolves with the BackgroundFetchRegistration associated with the provided id or undefined if the id is not found. |
| `GetIds()` | `string[]` | Returns the IDs of all registered background fetches. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchManager>(...)` or constructor `new BackgroundFetchManager(...)`

```js
navigator.serviceWorker.ready.then(async (swReg) => {
  const bgFetch = await swReg.backgroundFetch.fetch(
    "my-fetch",
    ["/ep-5.mp3", "ep-5-artwork.jpg"],
    {
      title: "Episode 5: Interesting things.",
      icons: [
        {
          sizes: "300x300",
          src: "/ep-5-icon.png",
          type: "image/png",
        },
      ],
      downloadTotal: 60 * 1024 * 1024,
    },
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager)*

