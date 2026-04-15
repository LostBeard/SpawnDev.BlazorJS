# PushMessageData

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/PushMessageData.cs`  
**MDN Reference:** [PushMessageData on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushMessageData)

> The PushMessageData interface of the Push API provides methods which let you retrieve the push data sent by a server in various formats. https://developer.mozilla.org/en-US/docs/Web/API/PushMessageData

## Constructors

| Signature | Description |
|---|---|
| `PushMessageData(IJSInProcessObjectReference _ref)` | Default deserialize constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ArrayBuffer()` | `ArrayBuffer` | Extracts the data as an ArrayBuffer object. |
| `Blob()` | `Blob` | Extracts the data as a Blob object. |
| `Json()` | `T` | Extracts the data as a JSON object. |
| `Text()` | `string` | Extracts the data as a plain text string. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PushMessageData>(...)` or constructor `new PushMessageData(...)`

```js
self.addEventListener("push", (event) => {
  const obj = event.data.json();

  if (obj.action === "subscribe" || obj.action === "unsubscribe") {
    fireNotification(obj, event);
    port.postMessage(obj);
  } else if (obj.action === "init" || obj.action === "chatMsg") {
    port.postMessage(obj);
  }
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PushMessageData)*

