# ReadableStreamBYOBRequest

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ReadableStreamBYOBRequest.cs`  
**MDN Reference:** [ReadableStreamBYOBRequest on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamBYOBRequest)

> The ReadableStreamBYOBRequest interface of the Streams API represents a "pull request" for data from an underlying source that will made as a zero-copy transfer to a consumer (bypassing the stream's internal queues). https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamBYOBRequest

## Constructors

| Signature | Description |
|---|---|
| `ReadableStreamBYOBRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ReadableStreamBYOBRequest>(...)` or constructor `new ReadableStreamBYOBRequest(...)`

```js
if (controller.byobRequest) {
  /* code to transfer data */
}
```

```js
const v = controller.byobRequest.view;
bytesRead = socket.readInto(v.buffer, v.byteOffset, v.byteLength);
controller.byobRequest.respond(bytesRead);
```

```js
const v = controller.byobRequest.view;
bytesRead = socket.readInto(v.buffer, v.byteOffset, v.byteLength);
const newView = new Uint8Array(v.buffer, v.byteOffset, bytesRead);
controller.byobRequest.respondWithNewView(newView);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamBYOBRequest)*

