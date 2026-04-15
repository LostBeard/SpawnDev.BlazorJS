# GetNotificationsOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/GetNotificationsOptions.cs`  
**MDN Reference:** [GetNotificationsOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/getNotifications#options)

> An object containing options to filter the notifications returned. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/getNotifications#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GetNotificationsOptions` | `class` | get | An object containing options to filter the notifications returned. https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/getNotifications#options |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GetNotificationsOptions>(...)` or constructor `new GetNotificationsOptions(...)`

```js
navigator.serviceWorker.register("sw.js");

const options = { tag: "user_alerts" };

navigator.serviceWorker.ready.then((registration) => {
  registration.getNotifications(options).then((notifications) => {
    // do something with your notifications
  });
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ServiceWorkerRegistration/getNotifications)*

