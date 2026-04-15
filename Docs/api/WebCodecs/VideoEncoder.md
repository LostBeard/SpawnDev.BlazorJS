# VideoEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebCodecs/VideoEncoder.cs`  

> The VideoEncoder interface of the Web Codecs API encodes VideoFrames into EncodedVideoChunks.

## Constructors

| Signature | Description |
|---|---|
| `VideoEncoder(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `VideoEncoder(VideoEncoderInit init)` | Creates a new VideoEncoder. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `State` | `string` | get | The state of the encoder. |
| `EncodeQueueSize` | `int` | get | The number of encode requests in the queue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(VideoEncoderConfig config)` | `void` | Configures the encoder. |
| `Encode(VideoFrame frame, VideoEncoderEncodeOptions? options)` | `void` | Enqueues a frame to be encoded. |
| `Flush()` | `Task` | Forces all pending encoded chunks to be output. |
| `Reset()` | `void` | Resets the encoder. |
| `Close()` | `void` | Closes the encoder and releases resources. |
| `IsConfigSupported(VideoEncoderConfig config)` | `Task<VideoEncoderSupport>` | Checks if the given config is supported. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fires when the encode queue size decreases. |

## Example

```csharp
// Create callbacks for encoder output and errors
using var outputCallback = Callback.Create<EncodedVideoChunk, EncodedVideoChunkMetadata>(
    (chunk, metadata) =>
    {
        Console.WriteLine($"Encoded chunk: type={chunk.Type}, size={chunk.ByteLength}");
        chunk.Dispose();
    }
);
using var errorCallback = Callback.Create<DOMException>(
    (error) => Console.WriteLine($"Encoder error: {error.Message}")
);

// Create the encoder with output and error callbacks
using var encoder = new VideoEncoder(new VideoEncoderInit
{
    Output = outputCallback,
    Error = errorCallback,
});

// Configure the encoder for H.264 at 720p
encoder.Configure(new VideoEncoderConfig
{
    Codec = "avc1.42E01E",
    Width = 1280,
    Height = 720,
    Bitrate = 2_000_000,
    Framerate = 30,
});

Console.WriteLine($"Encoder state: {encoder.State}");

// Encode a VideoFrame (e.g., captured from a canvas)
// using var frame = new VideoFrame(canvasElement);
// encoder.Encode(frame);
// encoder.Encode(frame, new VideoEncoderEncodeOptions { KeyFrame = true });

// Flush to ensure all pending frames are processed
await encoder.Flush();
Console.WriteLine($"Queue size after flush: {encoder.EncodeQueueSize}");

// Close when done
encoder.Close();
```

