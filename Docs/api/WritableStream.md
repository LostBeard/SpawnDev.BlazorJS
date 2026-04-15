# WritableStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `WritableStream`  
**MDN Reference:** [WritableStream - MDN](https://developer.mozilla.org/en-US/docs/Web/API/WritableStream)

> The `WritableStream` interface provides a standard abstraction for writing streaming data to a destination, known as a sink. Built-in backpressure and queuing are provided.

## Constructors

| Signature | Description |
|---|---|
| `WritableStream(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Locked` | `bool` | Returns `true` if the stream is locked to a writer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Abort()` | `Task` | Aborts the stream, signaling that the producer can no longer write. |
| `Abort(string reason)` | `Task` | Aborts with a reason string. |
| `Close()` | `Task` | Closes the stream. |
| `GetWriter()` | `WritableStreamDefaultWriter` | Gets a writer and locks the stream. |

## Example

```csharp
// Pipe a readable stream to a writable stream
using var response = await JS.CallAsync<Response>("fetch", "/data");
using var readable = response.Body;

// Create a writable stream (e.g., from a TransformStream)
using var transform = new TransformStream();
using var writable = transform.Writable;

await readable.PipeTo(writable);
```
