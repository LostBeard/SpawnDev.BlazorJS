# WindowClient

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Client`  
**Source:** `JSObjects/WindowClient.cs`  
**MDN Reference:** [WindowClient on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WindowClient)

> The WindowClient interface of the ServiceWorker API represents the scope of a service worker client that is a document in a browsing context, controlled by an active worker. The service worker client independently selects and uses a service worker for its own loading and sub-resources. https://developer.mozilla.org/en-US/docs/Web/API/WindowClient

## Constructors

| Signature | Description |
|---|---|
| `WindowClient(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Focused` | `bool` | get | A boolean that indicates whether the current client has focus. |
| `VisibilityState` | `string` | get | Indicates the visibility of the current client. This value can be one of "hidden", "visible", or "prerender". |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Focus()` | `Task<WindowClient>` | Gives user input focus to the current client. |
| `Navigate(string url)` | `Task<WindowClient>` | Loads a specified URL into a controlled client page. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WindowClient>(...)` or constructor `new WindowClient(...)`

```js
self.addEventListener("notificationclick", (event) => {
  console.log("On notification click: ", event.notification.tag);
  event.notification.close();

  // This looks to see if the current is already open and
  // focuses if it is
  event.waitUntil(
    clients
      .matchAll({
        type: "window",
      })
      .then((clientList) => {
        for (const client of clientList) {
          if (client.url === "/" && "focus" in client) {
            client.focus();
            break;
          }
        }
        if (clients.openWindow) return clients.openWindow("/");
      }),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WindowClient)*

