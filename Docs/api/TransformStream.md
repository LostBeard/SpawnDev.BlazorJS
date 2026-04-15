# TransformStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `TransformStream`  
**MDN Reference:** [TransformStream - MDN](https://developer.mozilla.org/en-US/docs/Web/API/TransformStream)

> The `TransformStream` interface represents a pair of streams: a writable side that accepts input, and a readable side that produces transformed output. Data written to the writable end emerges from the readable end after transformation.

## Constructors

| Signature | Description |
|---|---|
| `TransformStream()` | Creates a pass-through transform stream with default queuing strategy. |
| `TransformStream(TransformStreamCallbacks transformer)` | Creates with custom transform logic. |
| `TransformStream(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Readable` | `ReadableStream` | The readable end of the transform stream. |
| `Writable` | `WritableStream` | The writable end of the transform stream. |

## Example

```csharp
// Create a pass-through transform
using var transform = new TransformStream();
using var readable = transform.Readable;
using var writable = transform.Writable;

// Write to the writable side
using var writer = writable.GetWriter();
// Read from the readable side
using var reader = readable.GetReader();
```
