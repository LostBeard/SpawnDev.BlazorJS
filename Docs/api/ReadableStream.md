# ReadableStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `ReadableStream`  
**MDN Reference:** [ReadableStream - MDN](https://developer.mozilla.org/en-US/docs/Web/API/ReadableStream)

> The `ReadableStream` interface represents a readable stream of byte data. The Fetch API offers a concrete instance via the `body` property of a `Response` object. Streams allow incremental processing of data as it arrives, without loading the entire payload into memory.

## Constructors

| Signature | Description |
|---|---|
| `ReadableStream(IJSInProcessObjectReference _ref)` | Deserialization constructor. |
| `ReadableStream(ReadableStreamDefaultSource underlyingSource)` | Creates a default-type stream with a pull source. |
| `ReadableStream(ReadableByteStreamSource underlyingSource)` | Creates a byte-type stream. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Locked` | `bool` | Returns `true` if the stream is locked to a reader. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Cancel()` | `Task` | Cancels the stream. |
| `Cancel(string reason)` | `Task` | Cancels with a reason. |
| `GetReader()` | `ReadableStreamDefaultReader` | Gets a default reader and locks the stream. |
| `PipeTo(WritableStream destination)` | `Task` | Pipes to a writable stream. |
| `Tee()` | `ReadableStream[]` | Splits the stream into two independent branches. |

## Example

```csharp
// Read a Fetch response body as a stream, processing chunks as they arrive
using var response = await JS.CallAsync<Response>("fetch", "/large-file.bin");
using var stream = response.Body;

// Check if the stream is already locked by another reader
if (!stream.Locked)
{
    using var reader = stream.GetReader();
    long totalBytes = 0;

    while (true)
    {
        using var result = await reader.Read();
        if (result.Done) break;

        // Each chunk is a Uint8Array
        using var chunk = result.Value;
        if (chunk != null)
        {
            byte[] bytes = (byte[])chunk;
            totalBytes += bytes.Length;
            Console.WriteLine($"Received chunk: {bytes.Length} bytes");
        }
    }
    Console.WriteLine($"Total: {totalBytes} bytes");
}

// Split a stream into two branches with Tee
using var response2 = await JS.CallAsync<Response>("fetch", "/data.json");
using var stream2 = response2.Body;
var branches = stream2.Tee();
using var branch1 = branches[0]; // process one way
using var branch2 = branches[1]; // process another way

// Pipe a stream to a writable destination
using var response3 = await JS.CallAsync<Response>("fetch", "/file.bin");
using var stream3 = response3.Body;
// await stream3.PipeTo(someWritableStream);

// Cancel a stream
// await stream3.Cancel("No longer needed");

// Create a stream from a Blob
using var blob = new Blob(new[] { "Hello, Streams!" });
using var blobStream = blob.Stream();
using var blobReader = blobStream.GetReader();
using var blobResult = await blobReader.Read();
```
