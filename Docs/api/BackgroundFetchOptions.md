# BackgroundFetchOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/BackgroundFetchOptions.cs`  
**MDN Reference:** [BackgroundFetchOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch#options)

> Used to customize the BackgroundFetchManager fetch progress dialog that the browser shows to the user. https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BackgroundFetchOptions` | `class` | get/set | Used to customize the BackgroundFetchManager fetch progress dialog that the browser shows to the user. https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch#options |
| `Icons` | `IEnumerable<IconInfo>?` | get |  |
| `DownloadTotal` | `long?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchOptions>(...)` or constructor `new BackgroundFetchOptions(...)`

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
          label: "Downloading a show",
        },
      ],
      downloadTotal: 60 * 1024 * 1024,
    },
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch)*

