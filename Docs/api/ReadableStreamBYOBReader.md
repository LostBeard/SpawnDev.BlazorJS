# ReadableStreamBYOBReader

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ReadableStreamBYOBReader.cs`  

> The ReadableStreamBYOBReader interface of the Streams API defines a reader for a ReadableStream that supports zero-copy reading from an underlying byte source. It is used for efficient copying from underlying sources where the data is delivered as an "anonymous" sequence of bytes, such as files. An instance of this reader type should usually be obtained by calling ReadableStream.getReader() on the stream, specifying mode: "byob" in the options parameter.The readable stream must have an underlying byte source. In other words, it must have been constructed specifying an underlying source with type: "bytes"). Using this kind of reader, a read() request when the readable stream's internal queues are empty will result in a zero copy transfer from the underlying source (bypassing the stream's internal queues). If the internal queues are not empty, a read() will satisfy the request from the buffered data. Note that the methods and properties are similar to those for the default reader (ReadableStreamDefaultReader). The read() method differs in that it provides a view into which data should be written. https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamBYOBReader

## Constructors

| Signature | Description |
|---|---|
| `ReadableStreamBYOBReader(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Closed` | `Task` | get | Returns a Promise that resolves when the stream is closed. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Read(ArrayBufferView view)` | `Task<ReadableStreamReadResult>` | Returns a Promise that resolves with an object containing the next chunk from the stream's internal queues. |
| `ReleaseLock()` | `void` | Returns a Promise that resolves when the stream is released. |
| `Cancel()` | `Task` | Returns a Promise that resolves when the stream is canceled. |
| `Cancel(string reason)` | `Task` | Returns a Promise that resolves when the stream is canceled. |
