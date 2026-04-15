# UnderlyingSink

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/UnderlyingSink.cs`  
**MDN Reference:** [UnderlyingSink on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStream/WritableStream#underlyingsink)

> The WritableStream() constructor accepts as its first argument a JavaScript object representing the underlying sink. Such objects can contain any of the following properties: https://streams.spec.whatwg.org/#underlying-sink-api https://developer.mozilla.org/en-US/docs/Web/API/WritableStream/WritableStream#underlyingsink

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `UnderlyingSink` | `class` | get | The WritableStream() constructor accepts as its first argument a JavaScript object representing the underlying sink. Such objects can contain any of the following properties: https://streams.spec.whatwg.org/#underlying-sink-api https://developer.mozilla.org/en-US/docs/Web/API/WritableStream/WritableStream#underlyingsink |
| `Write` | `FuncCallback<JSObject, WritableStreamDefaultController, Task>?` | get |  |
| `Close` | `FuncCallback<Task>?` | get |  |
| `Abort` | `FuncCallback<JSObject?, Task>?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<UnderlyingSink>(...)` or constructor `new UnderlyingSink(...)`

```js
const list = document.querySelector("ul");

function sendMessage(message, writableStream) {
  // defaultWriter is of type WritableStreamDefaultWriter
  const defaultWriter = writableStream.getWriter();
  const encoder = new TextEncoder();
  const encoded = encoder.encode(message);
  encoded.forEach((chunk) => {
    defaultWriter.ready
      .then(() => defaultWriter.write(chunk))
      .then(() => {
        console.log("Chunk written to sink.");
      })
      .catch((err) => {
        console.log("Chunk error:", err);
      });
  });
  // Call ready again to ensure that all chunks are written
  //   before closing the writer.
  defaultWriter.ready
    .then(() => {
      defaultWriter.close();
    })
    .then(() => {
      console.log("All chunks written");
    })
    .catch((err) => {
      console.log("Stream error:", err);
    });
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

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStream/WritableStream)*

