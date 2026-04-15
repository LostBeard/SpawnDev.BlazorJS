# CookieStoreManager

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/CookieStoreManager.cs`  
**MDN Reference:** [CookieStoreManager on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieStoreManager)

> The CookieStoreManager interface of the Cookie Store API allows service workers to subscribe to cookie change events. Call subscribe() on a particular service worker registration to receive change events. A CookieStoreManager has an associated ServiceWorkerRegistration. Each service worker registration has a cookie change subscription list, which is a list of cookie change subscriptions each containing a name and URL. The methods in this interface allow the service worker to add and remove subscriptions from this list, and to get a list of all subscriptions. https://developer.mozilla.org/en-US/docs/Web/API/CookieStoreManager

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetSubscriptions()` | `Task<CookieSubscription[]>` | Returns a Promise which resolves to a list of the cookie change subscriptions for this service worker registration. |
| `Subscribe(IEnumerable<CookieSubscription> subscriptions)` | `Task` | Subscribes to changes to cookies. It returns a Promise which resolves when the subscription is successful. |
| `Unsubscribe(IEnumerable<CookieSubscription> subscriptions)` | `Task` | Unsubscribes the registered service worker from changes to cookies. It returns a Promise which resolves when the operation is successful. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<CookieStoreManager>(...)` or constructor `new CookieStoreManager(...)`

```js
const subscriptions = [{ name: "cookie1", url: `/path1` }];
await registration.cookies.subscribe(subscriptions);
```

```js
const subscriptions = await self.registration.cookies.getSubscriptions();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/CookieStoreManager)*

