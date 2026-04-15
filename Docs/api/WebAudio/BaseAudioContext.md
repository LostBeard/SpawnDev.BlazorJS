# BaseAudioContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebAudio/BaseAudioContext.cs`  
**MDN Reference:** [BaseAudioContext on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext)

> The BaseAudioContext interface of the Web Audio API acts as a base definition for online and offline audio-processing graphs, as represented by AudioContext and OfflineAudioContext respectively. You wouldn't use BaseAudioContext directly - you'd use its features via one of these two inheriting interfaces. https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `CurrentTime` | `double` | get | Returns a double representing an ever-increasing hardware time in seconds used for scheduling. It starts at 0. |
| `Destination` | `AudioDestinationNode` | get | Returns an AudioDestinationNode representing the final destination of all audio in the context. It can be thought of as the audio-rendering device. |
| `Listener` | `AudioListener` | get | Returns the AudioListener object, used for 3D spatialization. |
| `SampleRate` | `float` | get | Returns a float representing the sample rate (in samples per second) used by all nodes in this context. The sample-rate of an AudioContext cannot be changed. |
| `AudioWorklet` | `AudioWorklet` | get | Returns the AudioWorklet object, which can be used to create and manage AudioWorkletNode instances for custom audio processing. |
| `State` | `string` | get | Returns the current state of the AudioContext. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateAnalyser()` | `AnalyserNode` | Creates an AnalyserNode, which can be used to expose audio time and frequency data and for example to create data visualizations. |
| `CreateBiquadFilter()` | `BiquadFilterNode` | Creates a BiquadFilterNode, which represents a second order filter configurable as several different common filter types: high-pass, low-pass, band-pass, etc |
| `CreateBuffer(int numOfChannels, long length, float sampleRate)` | `AudioBuffer` | Creates a new, empty AudioBuffer object, which can then be populated by data and played via an AudioBufferSourceNode. An integer representing the number of channels this buffer should have. The default value is 1, and all user agents must support at least 32 channels. An integer representing the size of the buffer in sample-frames (where each sample-frame is the size of a sample in bytes multiplied by numOfChannels). To determine the length to use for a specific number of seconds of audio, use numSeconds * sampleRate. The sample rate of the linear audio data in sample-frames per second. All browsers must support sample rates in at least the range 8,000 Hz to 96,000 Hz. An AudioBuffer configured based on the specified options. |
| `CreateBufferSource()` | `AudioBufferSourceNode` | Creates an AudioBufferSourceNode, which can be used to play and manipulate audio data contained within an AudioBuffer object. AudioBuffers are created using AudioContext.createBuffer() or returned by AudioContext.decodeAudioData() when it successfully decodes an audio track. |
| `CreatePanner()` | `PannerNode` | The createPanner() method of the BaseAudioContext Interface is used to create a new PannerNode, which is used to spatialize an incoming audio stream in 3D space. The panner node is spatialized in relation to the AudioContext's AudioListener (defined by the AudioContext.listener attribute), which represents the position and orientation of the person listening to the audio. |
| `CreateGain()` | `GainNode` | The createGain() method of the BaseAudioContext interface creates a GainNode, which can be used to control the overall gain (or volume) of the audio graph. |
| `CreateDelay(float? maxDelayTime)` | `DelayNode` | Creates a DelayNode, which is used to delay the incoming audio signal by a certain amount. This node is also useful to create feedback loops in a Web Audio API graph. |
| `CreateConvolver()` | `ConvolverNode` | The createConvolver() method of the BaseAudioContext interface creates a ConvolverNode, which is commonly used to apply reverb effects to your audio. See the spec definition of Convolution for more information |
| `CreateChannelMerger(int numberOfInputs)` | `ChannelMergerNode` | Creates a ChannelMergerNode, which is used to combine channels from multiple audio streams into a single audio stream. |
| `CreateChannelSplitter(int numberOfOutputs)` | `ChannelSplitterNode` | Creates a ChannelSplitterNode, which is used to access the individual channels of an audio stream and process them separately. |
| `CreateStereoPanner()` | `StereoPannerNode` | Creates a StereoPannerNode, which can be used to apply a stereo panning effect to your audio source. |
| `CreateWaveShaper()` | `WaveShaperNode` | Creates a WaveShaperNode, which is used to create non-linear distortion effects. |
| `CreateDynamicsCompressor()` | `DynamicsCompressorNode` | Creates a DynamicsCompressorNode, which can be used to apply a compression effect to your audio. |
| `CreateIIRFilter(Float32Array feedforward, Float32Array feedback)` | `IIRFilterNode` | Creates an IIRFilterNode, which represents an infinite impulse response filter that can be configured as a low-pass filter, high-pass filter, etc. |
| `CreateMediaStreamDestination()` | `MediaStreamAudioDestinationNode` | Creates a MediaStreamAudioDestinationNode associated with a MediaStream representing an audio stream which may be stored in a file or sent to another computer. |
| `DecodeAudioData(ArrayBuffer audioData)` | `Task<AudioBuffer>` | Asynchronously decodes audio file data contained in an ArrayBuffer. The ArrayBuffer can be loaded from XMLHttpRequest, fetch(), or FileReader. The decoded AudioBuffer is resampled to the AudioContext's sample rate, then passed back as an AudioBuffer. An ArrayBuffer containing the audio data to decode (e.g., MP3, WAV, OGG, FLAC). An AudioBuffer containing the decoded PCM audio data. |
| `CreateOscillator()` | `OscillatorNode` | Creates an OscillatorNode, a source representing a periodic waveform. It basically generates a tone. |
| `CreatePeriodicWave(Float32Array real, Float32Array imag)` | `PeriodicWave` | Creates a PeriodicWave, used to define a periodic waveform that can be used to shape the output of an OscillatorNode. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnStateChange` | `ActionEvent<Event>` | A statechange event is fired at a BaseAudioContext object when its state member changes. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<BaseAudioContext>(...)` or constructor `new BaseAudioContext(...)`

```js
const audioContext = new AudioContext();

const oscillatorNode = audioContext.createOscillator();
const gainNode = audioContext.createGain();
const finish = audioContext.destination;
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext)*

