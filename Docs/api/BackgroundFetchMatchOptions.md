# BackgroundFetchMatchOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/BackgroundFetchMatchOptions.cs`  
**MDN Reference:** [BackgroundFetchMatchOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration/match#options)

> Options used with BackgroundFetchRegistration.Match() https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration/match#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BackgroundFetchMatchOptions` | `class` | get | Options used with BackgroundFetchRegistration.Match() https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration/match#options |
| `IgnoreMethod` | `bool?` | get |  |
| `IgnoreVary` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchMatchOptions>(...)` or constructor `new BackgroundFetchMatchOptions(...)`

```js
bgFetch.match("/ep-5.mp3").then(async (record) => {
  if (!record) {
    console.log("No record found");
    return;
  }

  console.log(`Here's the request`, record.request);
  const response = await record.responseReady;
  console.log(`And here's the response`, response);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration/match)*

