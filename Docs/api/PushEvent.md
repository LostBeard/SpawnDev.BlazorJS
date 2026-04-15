# PushEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `ExtendableEvent`  
**Source:** `JSObjects/PushEvent.cs`  
**MDN Reference:** [PushEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushEvent)

> The PushEvent interface of the Push API represents a push message that has been received. This event is sent to the global scope of a ServiceWorker. It contains the information sent from an application server to a PushSubscription. https://developer.mozilla.org/en-US/docs/Web/API/PushEvent

## Constructors

| Signature | Description |
|---|---|
| `PushEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `PushMessageData` | get | Returns a reference to a PushMessageData object containing data sent to the PushSubscription. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PushEvent>(...)` or constructor `new PushEvent(...)`

```js
self.addEventListener("push", (event) => {
  if (!(self.Notification && self.Notification.permission === "granted")) {
    return;
  }

  const data = event.data?.json() ?? {};
  const title = data.title || "Something Has Happened";
  const message =
    data.message || "Here's something you might want to check out.";
  const icon = "images/new-notification.png";

  const notification = new self.Notification(title, {
    body: message,
    tag: "simple-push-demo-notification",
    icon,
  });

  notification.addEventListener("click", () => {
    clients.openWindow(
      "https://example.blog.com/2015/03/04/something-new.html",
    );
  });
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushEvent)*

