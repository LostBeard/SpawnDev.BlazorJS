# EncodedVideoChunk

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebCodecs/EncodedVideoChunk.cs`  

> The EncodedVideoChunk interface of the Web Codecs API represents a chunk of encoded video.

## Constructors

| Signature | Description |
|---|---|
| `EncodedVideoChunk(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `EncodedVideoChunk(EncodedVideoChunkInit init)` | Creates a new EncodedVideoChunk. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Type` | `EncodedVideoChunkType` | get | Returns a string indicating whether this chunk is a key chunk or a delta chunk. |
| `Timestamp` | `long` | get | Returns an integer indicating the timestamp of the video in microseconds. |
| `Duration` | `long?` | get | Returns an integer indicating the duration of the video in microseconds. |
| `ByteLength` | `long` | get | Returns the size in bytes of the encoded video data. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CopyTo(ArrayBuffer destination)` | `void` | Copies the encoded video data to the destination buffer. |

