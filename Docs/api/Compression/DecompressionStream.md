# DecompressionStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Compression/DecompressionStream.cs`  

> The DecompressionStream interface of the Compression Streams API is an API for decompressing a stream of data.

## Constructors

| Signature | Description |
|---|---|
| `DecompressionStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `DecompressionStream(string format)` | Creates a new DecompressionStream. The compression format. One of: "gzip", "deflate", "deflate-raw". |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Readable` | `ReadableStream` | get | Returns a ReadableStream instance that can be used to read decompressed data from the stream. |
| `Writable` | `WritableStream` | get | Returns a WritableStream instance that can be used to write compressed data to the stream. |

