# EncodedAudioChunk

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebCodecs/EncodedAudioChunk.cs`  

> The EncodedAudioChunk interface of the Web Codecs API represents a chunk of encoded audio.

## Constructors

| Signature | Description |
|---|---|
| `EncodedAudioChunk(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `EncodedAudioChunk(EncodedAudioChunkInit init)` | Creates a new EncodedAudioChunk. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `EncodedAudioChunkType` | get | Returns a string indicating whether this chunk is a key chunk or a delta chunk. |
| `Timestamp` | `long` | get | Returns an integer indicating the timestamp of the audio in microseconds. |
| `Duration` | `long?` | get | Returns an integer indicating the duration of the audio in microseconds. |
| `ByteLength` | `long` | get | Returns the size in bytes of the encoded audio data. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CopyTo(ArrayBuffer destination)` | `void` | Copies the encoded audio data to the destination buffer. |

