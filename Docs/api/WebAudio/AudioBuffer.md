# AudioBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebAudio/AudioBuffer.cs`  
**MDN Reference:** [AudioBuffer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioBuffer)

> The AudioBuffer interface represents a short audio asset residing in memory, created from an audio file using the AudioContext.decodeAudioData() method, or from raw data using AudioContext.createBuffer(). Once put into an AudioBuffer, the audio can then be played by being passed into an AudioBufferSourceNode. Objects of these types are designed to hold small audio snippets, typically less than 45 s. For longer sounds, objects implementing the MediaElementAudioSourceNode are more suitable. The buffer contains the audio signal waveform encoded as a series of amplitudes in the following format: non-interleaved IEEE754 32-bit linear PCM with a nominal range between -1 and +1, that is, a 32-bit floating point buffer, with each sample between -1.0 and 1.0. If the AudioBuffer has multiple channels, they are stored in separate buffers. https://developer.mozilla.org/en-US/docs/Web/API/AudioBuffer

## Constructors

| Signature | Description |
|---|---|
| `AudioBuffer(AudioBufferOptions options)` |  |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `long` | get | Returns an integer representing the length, in sample-frames, of the PCM data stored in the buffer. |
| `NumberOfChannels` | `int` | get | Returns an integer representing the number of discrete audio channels described by the PCM data stored in the buffer. |
| `Duration` | `double` | get | Returns a double representing the duration, in seconds, of the PCM data stored in the buffer. |
| `SampleRate` | `float` | get | Returns a float representing the sample rate, in samples per second, of the PCM data stored in the buffer. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetChannelData(int channel)` | `Float32Array` | Returns a Float32Array containing the PCM data associated with the channel, defined by the channel parameter (with 0 representing the first channel). The channel property is an index representing the particular channel to get data for. An index value of 0 represents the first channel. If the channel index value is greater than of equal to AudioBuffer.numberOfChannels, an INDEX_SIZE_ERR exception will be thrown. |
| `CopyFromChannel(Float32Array destination, int channelNumber, long startInChannel)` | `void` | The copyFromChannel() method of the AudioBuffer interface copies the audio sample data from the specified channel of the AudioBuffer to a specified Float32Array. A Float32Array to copy the channel's samples to. The channel number of the current AudioBuffer to copy the channel data from. An optional offset into the source channel's buffer from which to begin copying samples. If not specified, a value of 0 (the beginning of the buffer) is assumed by default. |
| `CopyToChannel(Float32Array source, int channelNumber, long startInChannel)` | `void` | The copyToChannel() method of the AudioBuffer interface copies the samples to the specified channel of the AudioBuffer, from the source array. A Float32Array that the channel data will be copied from. The channel number of the current AudioBuffer to copy the channel data to. If channelNumber is greater than or equal to AudioBuffer.numberOfChannels, an INDEX_SIZE_ERR will be thrown. An optional offset to copy the data to. If startInChannel is greater than AudioBuffer.length, an INDEX_SIZE_ERR will be thrown. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioBuffer>(...)` or constructor `new AudioBuffer(...)`

```js
const audioCtx = new AudioContext();

// Create an empty three-second stereo buffer at the sample rate of the AudioContext
const myArrayBuffer = audioCtx.createBuffer(
  2,
  audioCtx.sampleRate * 3,
  audioCtx.sampleRate,
);

// Fill the buffer with white noise;
// just random values between -1.0 and 1.0
for (let channel = 0; channel < myArrayBuffer.numberOfChannels; channel++) {
  // This gives us the actual array that contains the data
  const nowBuffering = myArrayBuffer.getChannelData(channel);
  for (let i = 0; i < myArrayBuffer.length; i++) {
    // Math.random() is in [0; 1.0]
    // audio needs to be in [-1.0; 1.0]
    nowBuffering[i] = Math.random() * 2 - 1;
  }
}

// Get an AudioBufferSourceNode.
// This is the AudioNode to use when we want to play an AudioBuffer
const source = audioCtx.createBufferSource();

// set the buffer in the AudioBufferSourceNode
source.buffer = myArrayBuffer;

// connect the AudioBufferSourceNode to the
// destination so we can hear the sound
source.connect(audioCtx.destination);

// start the source playing
source.start();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioBuffer)*

