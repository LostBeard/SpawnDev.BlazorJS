# BackgroundFetchEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/BackgroundFetchEvent.cs`  
**MDN Reference:** [BackgroundFetchEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchEvent)

> The BackgroundFetchEvent interface of the Background Fetch API is the event type for background fetch events dispatched on the service worker global scope. It is the event type passed to backgroundfetchclick event and backgroundfetchabort event. https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Registration` | `BackgroundFetchRegistration` | get | Returns the BackgroundFetchRegistration that the event was initialized to. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BackgroundFetchEvent>(...)` or constructor `new BackgroundFetchEvent(...)`

```js
addEventListener("backgroundfetchclick", (event) => {
  const bgFetch = event.registration;

  if (bgFetch.result === "success") {
    clients.openWindow("/latest-podcasts");
  } else {
    clients.openWindow("/download-progress");
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchEvent)*

