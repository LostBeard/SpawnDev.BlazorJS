# VideoDecoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `VideoDecoder`  
**MDN Reference:** [VideoDecoder - MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoDecoder)

> The `VideoDecoder` interface of the WebCodecs API decodes encoded video chunks into `VideoFrame` objects. It provides hardware-accelerated video decoding for real-time applications like video conferencing and game streaming.

## Constructors

| Signature | Description |
|---|---|
| `VideoDecoder(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|---|---|---|
| `DecodeQueueSize` | `int` | Number of pending decode requests. |
| `State` | `string` | Current state: `"unconfigured"`, `"configured"`, `"closed"`. |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `IsConfigSupported(object config)` | `Task<object>` | Checks whether the given codec configuration is supported. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(object config)` | `void` | Configures the decoder (codec, coded width/height, etc.). |
| `Decode(object chunk)` | `void` | Decodes an encoded video chunk. |
| `Flush()` | `Task` | Flushes all pending decodes. |
| `Reset()` | `void` | Resets the decoder, discarding pending work. |
| `Close()` | `void` | Closes the decoder permanently. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fired when a decode completes and the queue shrinks. |

## Example

```csharp
// Note: WebCodecs decoders are constructed via JS.New with output/error callbacks
// Decoded VideoFrame objects are delivered through the output callback
```
