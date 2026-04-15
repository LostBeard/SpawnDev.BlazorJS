# CompressionStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Compression/CompressionStream.cs`  

> The CompressionStream interface of the Compression Streams API is an API for compressing a stream of data.

## Constructors

| Signature | Description |
|---|---|
| `CompressionStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `CompressionStream(string format)` | Creates a new CompressionStream. The compression format. One of: "gzip", "deflate", "deflate-raw". |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Readable` | `ReadableStream` | get | Returns a ReadableStream instance that can be used to read compressed data from the stream. |
| `Writable` | `WritableStream` | get | Returns a WritableStream instance that can be used to write data to be compressed to the stream. |

