# TransformStreamDefaultController

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TransformStreamDefaultController.cs`  
**MDN Reference:** [TransformStreamDefaultController on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TransformStreamDefaultController)

> The TransformStreamDefaultController interface of the Streams API provides methods to manipulate the associated ReadableStream and WritableStream. When constructing a TransformStream, the TransformStreamDefaultController is created.It therefore has no constructor.The way to get an instance of TransformStreamDefaultController is via the callback methods of TransformStream(). https://developer.mozilla.org/en-US/docs/Web/API/TransformStreamDefaultController

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DesiredSize` | `int` | get | The desiredSize read-only property of the TransformStreamDefaultController interface returns the desired size to fill the queue of the associated ReadableStream. The internal queue of a ReadableStream contains chunks that have been enqueued, but not yet read.The browser determines the desired size to fill the stream, and it is this value returned by the desiredSize property. If the desiredSize is 0 then the queue is full.Therefore you can use this information to manually apply backpressure to manage the queue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Enqueue(object chunk)` | `void` | The enqueue() method of the TransformStreamDefaultController interface enqueues the given chunk in the readable side of the stream. For more information on readable streams and chunks see Using Readable Streams. The chunk being queued. A chunk is a single piece of data. It can be any type of data, and a stream can contain chunks of different types. |
| `Error(string reason)` | `void` | The error() method of the TransformStreamDefaultController interface errors both sides of the stream. Any further interactions with it will fail with the given error message, and any chunks in the queue will be discarded. A string containing the error message to be returned on any further interaction with the stream. |
| `Terminate()` | `void` | The terminate() method of the TransformStreamDefaultController interface closes the readable side and errors the writable side of the stream. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<TransformStreamDefaultController>(...)` or constructor `new TransformStreamDefaultController(...)`

```js
const transformContent = {
  start() {}, // required.
  async transform(chunk, controller) {
    chunk = await chunk;
    switch (typeof chunk) {
      case "object":
        // just say the stream is done I guess
        if (chunk === null) {
          controller.terminate();
        } else if (ArrayBuffer.isView(chunk)) {
          controller.enqueue(
            new Uint8Array(chunk.buffer, chunk.byteOffset, chunk.byteLength),
          );
        } else if (
          Array.isArray(chunk) &&
          chunk.every((value) => typeof value === "number")
        ) {
          controller.enqueue(new Uint8Array(chunk));
        } else if (
          typeof chunk.valueOf === "function" &&
          chunk.valueOf() !== chunk
        ) {
          this.transform(chunk.valueOf(), controller); // hack
        } else if ("toJSON" in chunk) {
          this.transform(JSON.stringify(chunk), controller);
        }
        break;
      case "symbol":
        controller.error("Cannot send a symbol as a chunk part");
        break;
      case "undefined":
        controller.error("Cannot send undefined as a chunk part");
        break;
      default:
        controller.enqueue(this.textencoder.encode(String(chunk)));
        break;
    }
  },
  flush() {
    /* do any destructor work here */
  },
};

class AnyToU8Stream extends TransformStream {
  constructor() {
    super({ ...transformContent, textencoder: new TextEncoder() });
  }
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TransformStreamDefaultController)*

