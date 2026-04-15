# BackgroundFetchRegistration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/BackgroundFetchRegistration.cs`  
**MDN Reference:** [BackgroundFetchRegistration on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration)

> The BackgroundFetchRegistration interface of the Background Fetch API represents an individual background fetch. A BackgroundFetchRegistration instance is returned by the BackgroundFetchManager.fetch() or BackgroundFetchManager.get() methods, and therefore there has no constructor. https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Id` | `string` | get | A string containing the background fetch's ID. |
| `UploadTotal` | `long` | get | A number containing the total number of bytes to be uploaded. |
| `Uploaded` | `long` | get/set | A number containing the size in bytes successfully sent, initially 0. |
| `DownoadTotal` | `long` | get | A number containing the total size in bytes of this download. This is the value set when the background fetch was registered, or 0. |
| `Downoaded` | `long` | get | A number containing the size in bytes that has been downloaded, initially 0. |
| `Result` | `string` | get | Returns an empty string initially, on completion either the string "success" or "failure". |
| `FailureReason` | `string?` | get/set | A string with a value that indicates a reason for a background fetch failure. Can be one of the following values: "", "aborted", "bad-status", "fetch-error", "quota-exceeded", "download-total-exceeded". |
| `RecordsAvailable` | `bool` | get | A boolean indicating whether the recordsAvailable flag is set. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Abort()` | `Task<bool>` | Aborts the background fetch. Returns a Promise that resolves with true if the fetch was successfully aborted. |
| `Match(string request, BackgroundFetchMatchOptions options)` | `Task<BackgroundFetchRecord>` | Returns a single BackgroundFetchRecord object which is the first match for the arguments. |
| `Match(Request request)` | `Task<BackgroundFetchRecord>` | Returns a single BackgroundFetchRecord object which is the first match for the arguments. |
| `Match(Request request, BackgroundFetchMatchOptions options)` | `Task<BackgroundFetchRecord>` | Returns a single BackgroundFetchRecord object which is the first match for the arguments. |
| `Match(string request)` | `Task<BackgroundFetchRecord>` | Returns a single BackgroundFetchRecord object which is the first match for the arguments. |
| `MatchAll()` | `Task<BackgroundFetchRecord[]>` | Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses. |
| `MatchAll(Request request)` | `Task<BackgroundFetchRecord[]>` | Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses. |
| `MatchAll(Request request, BackgroundFetchMatchOptions options)` | `Task<BackgroundFetchRecord[]>` | Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses. |
| `MatchAll(string request)` | `Task<BackgroundFetchRecord[]>` | Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses. |
| `MatchAll(string request, BackgroundFetchMatchOptions options)` | `Task<BackgroundFetchRecord[]>` | Returns a Promise that resolves with an array of BackgroundFetchRecord objects containing requests and responses. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnProgress` | `ActionEvent<Event>` | Fired when there is a change to any of the following properties: uploaded, downloaded, result or failureReason. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchRegistration>(...)` or constructor `new BackgroundFetchRegistration(...)`

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

```js
console.log(bgFetch.id); // "my-fetch"
```

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration)*

