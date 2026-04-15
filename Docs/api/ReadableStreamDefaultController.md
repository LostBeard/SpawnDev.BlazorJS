# ReadableStreamDefaultController

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ReadableStreamDefaultController.cs`  
**MDN Reference:** [ReadableStreamDefaultController on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultController)

> The ReadableStreamDefaultController interface of the Streams API represents a controller allowing control of a ReadableStream's state and internal queue. Default controllers are for streams that are not byte streams. https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultController

## Constructors

| Signature | Description |
|---|---|
| `ReadableStreamDefaultController(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Close()` | `void` | Closes the associated stream. |
| `Enqueue(object data)` | `void` | Enqueues a given chunk in the associated stream. |
| `Error()` | `void` | Causes any future interactions with the associated stream to error. |
| `Error(object error)` | `void` | Causes any future interactions with the associated stream to error. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ReadableStreamDefaultController>(...)` or constructor `new ReadableStreamDefaultController(...)`

```js
let interval;
const stream = new ReadableStream({
  start(controller) {
    interval = setInterval(() => {
      let string = randomChars();

      // Add the string to the stream
      controller.enqueue(string);

      // show it on the screen
      let listItem = document.createElement("li");
      listItem.textContent = string;
      list1.appendChild(listItem);
    }, 1000);

    button.addEventListener("click", () => {
      clearInterval(interval);
      fetchStream();
      controller.close();
    });
  },
  pull(controller) {
    // We don't really need a pull in this example
  },
  cancel() {
    // This is called if the reader cancels,
    // so we should stop generating strings
    clearInterval(interval);
  },
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultController)*

