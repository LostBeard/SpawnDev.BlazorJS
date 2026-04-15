# VideoDecoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebCodecs/VideoDecoder.cs`  

> The VideoDecoder interface of the Web Codecs API decodes EncodedVideoChunks into VideoFrames.

## Constructors

| Signature | Description |
|---|---|
| `VideoDecoder(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `VideoDecoder(VideoDecoderInit init)` | Creates a new VideoDecoder. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `State` | `string` | get | The state of the decoder. |
| `DecodeQueueSize` | `int` | get | The number of decode requests in the queue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(VideoDecoderConfig config)` | `void` | Configures the decoder. |
| `Decode(EncodedVideoChunk chunk)` | `void` | Enqueues a chunk to be decoded. |
| `Flush()` | `Task` | Forces all pending decoded frames to be output. |
| `Reset()` | `void` | Resets the decoder. |
| `Close()` | `void` | Closes the decoder and releases resources. |
| `IsConfigSupported(VideoDecoderConfig config)` | `Task<VideoDecoderSupport>` | Checks if the given config is supported. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fires when the decode queue size decreases. |

## Example

```csharp
// Create callbacks for decoded frame output and errors
using var outputCallback = Callback.Create<VideoFrame>(
    (frame) =>
    {
        Console.WriteLine($"Decoded frame: {frame.DisplayWidth}x{frame.DisplayHeight}, ts={frame.Timestamp}");
        // Draw frame to canvas or process it, then close
        frame.Close();
        frame.Dispose();
    }
);
using var errorCallback = Callback.Create<DOMException>(
    (error) => Console.WriteLine($"Decoder error: {error.Message}")
);

// Create the decoder
using var decoder = new VideoDecoder(new VideoDecoderInit
{
    Output = outputCallback,
    Error = errorCallback,
});

// Check if a codec configuration is supported before using it
var support = await VideoDecoder.IsConfigSupported(new VideoDecoderConfig
{
    Codec = "avc1.42E01E",
});
Console.WriteLine($"H.264 baseline supported: {support.Supported}");

// Configure the decoder
decoder.Configure(new VideoDecoderConfig
{
    Codec = "avc1.42E01E",
});

Console.WriteLine($"Decoder state: {decoder.State}");

// Decode encoded chunks received from encoder or network
// decoder.Decode(encodedChunk);

// Flush to ensure all pending chunks are decoded
await decoder.Flush();

// Close when done
decoder.Close();
```

