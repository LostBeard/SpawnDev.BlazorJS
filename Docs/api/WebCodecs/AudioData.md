# AudioData

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebCodecs/AudioData.cs`  

> The AudioData interface of the WebCodecs API represents an audio sample. AudioData is a transferable object. An audio track consists of a stream of audio samples, each sample representing a captured moment of sound. An AudioData object is a representation of such a sample. Working alongside the interfaces of the Insertable Streams API, you can break a stream into individual AudioData objects with MediaStreamTrackProcessor, or construct an audio track from a stream of frames with MediaStreamTrackGenerator. https://developer.mozilla.org/en-US/docs/Web/API/AudioData

## Constructors

| Signature | Description |
|---|---|
| `AudioData(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `AudioData(AudioDataOptions options)` | The AudioData() constructor creates a new AudioData object which represents an individual audio sample. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Format` | `string` | get | Returns the sample format of the audio. |
| `SampleRate` | `decimal` | get | Returns the sample rate of the audio in Hz. |
| `NumberOfFrames` | `int` | get | Returns the number of frames. |
| `NumberOfChannels` | `int` | get | Returns the number of audio channels. |
| `Duration` | `double` | get | Returns the duration of the audio in microseconds. |
| `Timestamp` | `long` | get | Returns the timestamp of the audio in microseconds. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AllocationSize(AudioDataAllocationSizeOptions options)` | `int` | Returns the number of bytes required to hold the sample as filtered by options passed into the method. |
| `CopyTo(ArrayBuffer destination, AudioDataCopyToOptions options)` | `Task` | Copies the samples from the specified plane of the AudioData object to the destination. |
| `CopyTo(TypedArray destination, AudioDataCopyToOptions options)` | `Task` | Copies the samples from the specified plane of the AudioData object to the destination. |
| `CopyTo(DataView destination, AudioDataCopyToOptions options)` | `Task` | Copies the samples from the specified plane of the AudioData object to the destination. |
| `Clone()` | `AudioData` | Creates a new AudioData object with reference to the same media resource as the original. |
| `Close()` | `void` | Clears all states and releases the reference to the media resource. |
