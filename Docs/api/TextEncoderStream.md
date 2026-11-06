# TextEncoderStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/TextEncoderStream.cs`  

> The TextEncoderStream interface of the Encoding API converts a stream of strings into bytes in the UTF-8 encoding. It is the streaming equivalent of TextEncoder. https://developer.mozilla.org/en-US/docs/Web/API/TextEncoderStream

## Constructors

| Signature | Description |
|---|---|
| `TextEncoderStream()` | The TextEncoderStream() constructor creates a new TextEncoderStream object which is used to convert a stream of strings into bytes using UTF-8 encoding. |
| `TextEncoderStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Encoding` | `string` | get | Always "utf-8". |
| `Readable` | `ReadableStream` | get | Returns the ReadableStream instance controlled by this object. |
| `Writable` | `WritableStream` | get | Returns the WritableStream instance controlled by this object. |
