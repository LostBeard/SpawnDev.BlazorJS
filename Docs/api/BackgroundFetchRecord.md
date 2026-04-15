# BackgroundFetchRecord

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/BackgroundFetchRecord.cs`  
**MDN Reference:** [BackgroundFetchRecord on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRecord)

> The BackgroundFetchRecord interface of the Background Fetch API represents an individual request and response. A BackgroundFetchRecord is created by the BackgroundFetchRegistration.matchAll() method, therefore there is no constructor for this interface. There will be one BackgroundFetchRecord for each resource requested by fetch(). https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRecord

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Request` | `Request` | get | Returns a Request. |
| `ResponseReady` | `Task<Response>` | get | Returns a promise that resolves with a Response. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchRecord>(...)` or constructor `new BackgroundFetchRecord(...)`

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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRecord)*

