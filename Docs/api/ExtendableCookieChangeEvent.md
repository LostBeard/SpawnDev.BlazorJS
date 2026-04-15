# ExtendableCookieChangeEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/ExtendableCookieChangeEvent.cs`  
**MDN Reference:** [ExtendableCookieChangeEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ExtendableCookieChangeEvent)

> The cookiechange event of the ServiceWorkerGlobalScope interface is fired when a cookie change occurs that matches the service worker's cookie change subscription list. This event is not cancelable and does not bubble. https://developer.mozilla.org/en-US/docs/Web/API/ExtendableCookieChangeEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Changed` | `Cookie[]` | get | Returns an array containing the changed cookies. |
| `Deleted` | `Cookie[]` | get | Returns an array containing the deleted cookies. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ExtendableCookieChangeEvent>(...)` or constructor `new ExtendableCookieChangeEvent(...)`

```js
self.addEventListener("activate", (event) => {
  event.waitUntil(async () => {
    const subscriptions = await self.registration.cookies.getSubscriptions();

    await self.registration.cookies.unsubscribe(subscriptions);

    await self.registration.cookies.subscribe([
      {
        name: "COOKIE_NAME",
      },
    ]);
  });
});

self.addEventListener("cookiechange", (event) => {
  console.log(event);
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ExtendableCookieChangeEvent)*

## Examples

**JavaScript (MDN):**

```js
self.addEventListener("activate", (event) => {
  event.waitUntil(async () => {
    const subscriptions = await self.registration.cookies.getSubscriptions();

    await self.registration.cookies.unsubscribe(subscriptions);

    await self.registration.cookies.subscribe([
      {
        name: "COOKIE_NAME",
      },
    ]);
  });
});

self.addEventListener("cookiechange", (event) => {
  console.log(event);
});
```

**C# (SpawnDev.BlazorJS):**

```csharp
// Requires: builder.Services.AddBlazorJSRuntime();
// Inject BlazorJSRuntime in your component or service:
// [Inject] BlazorJSRuntime JS { get; set; }

self.addEventListener("activate", (event) => {
event.waitUntil(async () => {
using var subscriptions = await self.registration.cookies.getSubscriptions();

await self.registration.cookies.unsubscribe(subscriptions);

await self.registration.cookies.subscribe([;
{
name: "COOKIE_NAME",
},
]);
});
});

self.addEventListener("cookiechange", (event) => {
Console.WriteLine(event);
});
```

