# WritableStreamDefaultController

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WritableStreamDefaultController.cs`  
**MDN Reference:** [WritableStreamDefaultController on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultController)

> The WritableStreamDefaultController interface of the Streams API represents a controller allowing control of a WritableStream's state. When constructing a WritableStream, the underlying sink is given a corresponding WritableStreamDefaultController instance to manipulate. https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultController https://streams.spec.whatwg.org/#writablestreamdefaultcontroller

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Signal` | `AbortSignal` | get | Returns the AbortSignal associated with the controller. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Error(string message)` | `void` | The error() method of the WritableStreamDefaultController interface causes any future interactions with the associated stream to error. This method is rarely used, since usually it suffices to return a rejected promise from one of the underlying sink's methods. However, it can be useful for suddenly shutting down a stream in response to an event outside the normal lifecycle of interactions with the underlying sink. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WritableStreamDefaultController>(...)` or constructor `new WritableStreamDefaultController(...)`

```js
const writableStream = new WritableStream({
  start(controller) {
    // do stuff with controller

    // error stream if necessary
    controller.error("My stream is broken");
  },
  write(chunk, controller) {
    // …
  },
  close(controller) {
    // …
  },
  abort(err) {
    // …
  },
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultController)*

