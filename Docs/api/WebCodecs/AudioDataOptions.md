# AudioDataOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/AudioDataOptions.cs`  
**MDN Reference:** [AudioDataOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioData/AudioData#init)

> Options used when creating a new AudioData https://developer.mozilla.org/en-US/docs/Web/API/AudioData/AudioData#init

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AudioDataOptions` | `class` | get/set | Options used when creating a new AudioData https://developer.mozilla.org/en-US/docs/Web/API/AudioData/AudioData#init |
| `SampleRate` | `decimal` | get/set | A decimal containing the sample rate in Hz. |
| `NumberOfFrames` | `int` | get/set | An integer containing the number of frames in this sample. |
| `NumberOfChannels` | `int` | get/set | An integer containing the number of channels in this sample. |
| `Timestamp` | `long` | get/set | An integer indicating the data's time in microseconds. |
| `Data` | `TypedArray` | get | A typed array of the audio data for this sample. |
| `Transfer` | `IEnumerable<ArrayBuffer>?` | get |  |

