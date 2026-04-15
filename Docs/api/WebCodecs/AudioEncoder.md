# AudioEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebCodecs/AudioEncoder.cs`  

> The AudioEncoder interface of the Web Codecs API encodes AudioData into EncodedAudioChunks.

## Constructors

| Signature | Description |
|---|---|
| `AudioEncoder(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `AudioEncoder(AudioEncoderInit init)` | Creates a new AudioEncoder. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `State` | `string` | get | The state of the encoder. |
| `EncodeQueueSize` | `int` | get | The number of encode requests in the queue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(AudioEncoderConfig config)` | `void` | Configures the encoder. |
| `Encode(AudioData data)` | `void` | Enqueues a frame to be encoded. |
| `Flush()` | `Task` | Forces all pending encoded chunks to be output. |
| `Reset()` | `void` | Resets the encoder. |
| `Close()` | `void` | Closes the encoder and releases resources. |
| `IsConfigSupported(AudioEncoderConfig config)` | `Task<AudioEncoderSupport>` | Checks if the given config is supported. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fires when the encode queue size decreases. |

