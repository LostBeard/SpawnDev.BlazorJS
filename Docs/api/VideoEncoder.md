# VideoEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `VideoEncoder`  
**MDN Reference:** [VideoEncoder - MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoEncoder)

> The `VideoEncoder` interface of the WebCodecs API encodes `VideoFrame` objects into encoded video chunks. It provides hardware-accelerated video encoding for real-time applications.

## Constructors

| Signature | Description |
|---|---|
| `VideoEncoder(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `EncodeQueueSize` | `int` | Number of pending encode requests. |
| `State` | `string` | Current state: `"unconfigured"`, `"configured"`, `"closed"`. |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `IsConfigSupported(object config)` | `Task<object>` | Checks whether the given configuration is supported. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(object config)` | `void` | Configures the encoder (codec, width, height, bitrate, etc.). |
| `Encode(VideoFrame frame)` | `void` | Encodes a frame. |
| `Encode(VideoFrame frame, object options)` | `void` | Encodes with options (e.g., keyFrame). |
| `Flush()` | `Task` | Flushes all pending encodes. |
| `Reset()` | `void` | Resets the encoder, discarding pending work. |
| `Close()` | `void` | Closes the encoder permanently. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fired when an encode completes and the queue shrinks. |

## Example

```csharp
// Note: WebCodecs is constructed via JS.New with callback configuration
// This is a simplified usage pattern
```
