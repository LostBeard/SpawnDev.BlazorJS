# WritableStreamDefaultWriter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WritableStreamDefaultWriter.cs`  
**MDN Reference:** [WritableStreamDefaultWriter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultWriter)

> The WritableStreamDefaultWriter interface of the Streams API is the object returned by WritableStream.getWriter() and once created locks the writer to the WritableStream ensuring that no other streams can write to the underlying sink. https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultWriter

## Constructors

| Signature | Description |
|---|---|
| `WritableStreamDefaultWriter(WritableStream writableStream)` | The WritableStreamDefaultWriter() constructor creates a new WritableStreamDefaultWriter object instance. |
| `WritableStreamDefaultWriter(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Closed` | `Task` | get | Allows you to write code that responds to an end to the streaming process. Returns a promise that fulfills if the stream becomes closed, or rejects if the stream errors or the writer's lock is released. |
| `DesiredSize` | `int` | get | Returns the desired size required to fill the stream's internal queue. |
| `Ready` | `Task` | get | Returns a Promise that resolves when the desired size of the stream's internal queue transitions from non-positive to positive, signaling that it is no longer applying backpressure. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Abort(string? reason)` | `Task` | Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded. |
| `Close()` | `Task` | Closes the associated writable stream. |
| `ReleaseLock()` | `void` | Releases the writer's lock on the corresponding stream. After the lock is released, the writer is no longer active. If the associated stream is errored when the lock is released, the writer will appear errored in the same way from now on; otherwise, the writer will appear closed. |
| `Write(TypedArray chunk)` | `Task` | Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation. A block of binary data to pass to the WritableStream. |
| `Write(ArrayBuffer chunk)` | `Task` | Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation. A block of binary data to pass to the WritableStream. |
| `Write(DataView chunk)` | `Task` | Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation. A block of binary data to pass to the WritableStream. |
| `Write(byte[] chunk)` | `Task` | Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation. A block of binary data to pass to the WritableStream. |
| `Write(Blob chunk)` | `Task` | Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation. A block of binary data to pass to the WritableStream. |
| `Write(string chunk)` | `Task` | Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation. A block of binary data to pass to the WritableStream. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WritableStreamDefaultWriter>(...)` or constructor `new WritableStreamDefaultWriter(...)`

```js
const list = document.querySelector("ul");

async function sendMessage(message, writableStream) {
  // defaultWriter is of type WritableStreamDefaultWriter
  const defaultWriter = writableStream.getWriter();
  const encoder = new TextEncoder();
  const encoded = encoder.encode(message);

  try {
    for (const chunk of encoded) {
      await defaultWriter.ready;
      await defaultWriter.write(chunk);
      console.log("Chunk written to sink.");
    }
    // Call ready again to ensure that all chunks are written
    // before closing the writer.
    await defaultWriter.ready;
    await defaultWriter.close();
    console.log("All chunks written");
  } catch (err) {
    console.log("Error:", err);
  }
}

const decoder = new TextDecoder("utf-8");
const queuingStrategy = new CountQueuingStrategy({ highWaterMark: 1 });
let result = "";
const writableStream = new WritableStream(
  {
    // Implement the sink
    write(chunk) {
      return new Promise((resolve, reject) => {
        const buffer = new ArrayBuffer(1);
        const view = new Uint8Array(buffer);
        view[0] = chunk;
        const decoded = decoder.decode(view, { stream: true });
        const listItem = document.createElement("li");
        listItem.textContent = `Chunk decoded: ${decoded}`;
        list.appendChild(listItem);
        result += decoded;
        resolve();
      });
    },
    close() {
      const listItem = document.createElement("li");
      listItem.textContent = `[MESSAGE RECEIVED] ${result}`;
      list.appendChild(listItem);
    },
    abort(err) {
      console.log("Sink error:", err);
    },
  },
  queuingStrategy,
);

sendMessage("Hello, world.", writableStream);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultWriter)*

