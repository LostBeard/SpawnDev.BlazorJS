# AudioDecoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebCodecs/AudioDecoder.cs`  

> The AudioDecoder interface of the Web Codecs API decodes EncodedAudioChunks into AudioData.

## Constructors

| Signature | Description |
|---|---|
| `AudioDecoder(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `AudioDecoder(AudioDecoderInit init)` | Creates a new AudioDecoder. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `State` | `string` | get | The state of the decoder. |
| `DecodeQueueSize` | `int` | get | The number of decode requests in the queue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Configure(AudioDecoderConfig config)` | `void` | Configures the decoder. |
| `Decode(EncodedAudioChunk chunk)` | `void` | Enqueues a chunk to be decoded. |
| `Flush()` | `Task` | Forces all pending decoded frames to be output. |
| `Reset()` | `void` | Resets the decoder. |
| `Close()` | `void` | Closes the decoder and releases resources. |
| `IsConfigSupported(AudioDecoderConfig config)` | `Task<AudioDecoderSupport>` | Checks if the given config is supported. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnDequeue` | `ActionEvent<Event>` | Fires when the decode queue size decreases. |

