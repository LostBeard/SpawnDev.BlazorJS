# ReadableStreamDefaultReader

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ReadableStreamDefaultReader.cs`  
**MDN Reference:** [ReadableStreamDefaultReader on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader)

> The ReadableStreamDefaultReader interface of the Streams API represents a default reader that can be used to read stream data supplied from a network (such as a fetch request). https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader

## Constructors

| Signature | Description |
|---|---|
| `ReadableStreamDefaultReader(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Closed` | `Task` | get | Returns a Promise that fulfills when the stream closes, or rejects if the stream throws an error or the reader's lock is released. This property enables you to write code that responds to an end to the streaming process. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Cancel()` | `Task` | Returns a Promise that resolves when the stream is canceled. Calling this method signals a loss of interest in the stream by a consumer. The supplied reason argument will be given to the underlying source, which may or may not use it. |
| `Read()` | `Task<ReadableStreamReaderReadResponse>` | Returns a promise providing access to the next chunk in the stream's internal queue. |
| `ReleaseLock()` | `void` | Releases the reader's lock on the stream. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<ReadableStreamDefaultReader>(...)` or constructor `new ReadableStreamDefaultReader(...)`

```js
fetch("https://www.example.org/").then((response) => {
  const reader = response.body.getReader();
  const stream = new ReadableStream({
    start(controller) {
      // The following function handles each data chunk
      function push() {
        // "done" is a Boolean and value a "Uint8Array"
        return reader.read().then(({ done, value }) => {
          // Is there no more data to read?
          if (done) {
            // Tell the browser that we have finished sending data
            controller.close();
            return;
          }

          // Get the data and send it to the browser via the controller
          controller.enqueue(value);
          push();
        });
      }

      push();
    },
  });

  return new Response(stream, { headers: { "Content-Type": "text/html" } });
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader)*

