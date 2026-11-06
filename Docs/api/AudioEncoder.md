# AudioEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `AudioEncoder`  
**MDN Reference:** [AudioEncoder - MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioEncoder)

> The `AudioEncoder` interface of the WebCodecs API encodes `AudioData` objects into encoded audio chunks. It provides hardware-accelerated audio encoding for real-time applications.

## Constructors

| Signature | Description |
|---|---|
| `AudioEncoder(IJSInProcessObjectReference _ref)` | Deserialization constructor. |
| `AudioEncoder(AudioEncoderInit init)` | Creates a new AudioEncoder. |

## Properties

| Property | Type | Description |
|---|---|---|
| `EncodeQueueSize` | `int` | Number of pending encode requests. |
| `State` | `string` | Current state: `"unconfigured"`, `"configured"`, `"closed"`. |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `IsConfigSupported(object config)` | `Task<object>` | Checks whether the given configuration is supported. |
| `IsConfigSupported(AudioEncoderConfig config)` | `Task<AudioEncoderSupport>` | Checks if the given config is supported. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(object config)` | `void` | Configures the encoder (codec, sampleRate, numberOfChannels, bitrate). |
| `Encode(object audioData)` | `void` | Encodes audio data. |
| `Flush()` | `Task` | Flushes all pending encodes. |
| `Reset()` | `void` | Resets the encoder, discarding pending work. |
| `Close()` | `void` | Closes the encoder permanently. |
| `Configure(AudioEncoderConfig config)` | `void` | Configures the encoder. |
| `Encode(AudioData data)` | `void` | Enqueues a frame to be encoded. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fires when the encode queue size decreases. |

## Example

```csharp
// Note: WebCodecs audio encoders are constructed via JS.New with output/error callbacks
// Encoded chunks are delivered through the output callback
```
