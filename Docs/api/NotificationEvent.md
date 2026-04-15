# NotificationEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/NotificationEvent.cs`  
**MDN Reference:** [NotificationEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NotificationEvent)

> The NotificationEvent interface of the Notifications API represents a notification event dispatched on the ServiceWorkerGlobalScope of a ServiceWorker. https://developer.mozilla.org/en-US/docs/Web/API/NotificationEvent

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Notification` | `Notification` | get | Returns a Notification object representing the notification that was clicked to fire the event. |
| `Action` | `string?` | get | Returns the string ID of the notification button the user clicked. This value returns an empty string if the user clicked the notification somewhere other than an action button, or the notification does not have a button. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<NotificationEvent>(...)` or constructor `new NotificationEvent(...)`

```js
self.addEventListener("notificationclick", (event) => {
  console.log(`On notification click: ${event.notification.tag}`);
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
          if (client.url === "/" && "focus" in client) return client.focus();
        }
        if (clients.openWindow) return clients.openWindow("/");
      }),
  );
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/NotificationEvent)*

