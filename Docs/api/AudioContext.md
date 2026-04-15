# AudioContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `EventTarget` -> `BaseAudioContext` -> `AudioContext`  
**MDN Reference:** [AudioContext](https://developer.mozilla.org/en-US/docs/Web/API/AudioContext)

> The `AudioContext` class represents an audio-processing graph built from audio modules linked together, each represented by an `AudioNode`. It is the primary interface for creating and managing Web Audio API nodes. Audio contexts control the creation of nodes, the execution of audio processing, and the decoding of audio data. You must create an `AudioContext` before doing anything with Web Audio. Note that browsers require a user gesture (click, tap) before an `AudioContext` can start producing sound.

## Constructors

| Signature | Description |
|-----------|-------------|
| `AudioContext()` | Creates a new audio context with default settings. |
| `AudioContext(AudioContextOptions options)` | Creates a new audio context with the specified options (sample rate, latency hint, sink ID). |
| `AudioContext(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties (inherited from BaseAudioContext)

| Property | Type | Description |
|----------|------|-------------|
| `CurrentTime` | `double` | An ever-increasing hardware time in seconds used for scheduling. Starts at 0. |
| `Destination` | `AudioDestinationNode` | The final destination of all audio in the context (the audio output device). |
| `Listener` | `AudioListener` | The `AudioListener` used for 3D audio spatialization. |
| `SampleRate` | `float` | The sample rate in samples per second used by all nodes in this context. Cannot be changed after creation. |
| `State` | `string` | Current state: `"suspended"`, `"running"`, or `"closed"`. |
| `AudioWorklet` | `AudioWorklet` | The `AudioWorklet` object for creating custom audio processing nodes. |

## Methods

### AudioContext-Specific Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Close()` | `Task` | Closes the audio context, releasing system audio resources. |
| `Resume()` | `Task` | Resumes a suspended audio context (required after user gesture). |
| `Suspend()` | `Task` | Suspends the audio context, halting audio hardware access and reducing CPU/battery usage. |
| `GetOutputTimestamp()` | `AudioTimestamp` | Returns timestamp information relating to the current audio context. |
| `SetSinkId(string sinkId)` | `Task` | Sets the output audio device by device ID (from `MediaDevices.EnumerateDevices()`). |
| `SetSinkId(AudioSinkOptions options)` | `Task` | Sets the output sink options. Use `type: "none"` to process audio without playing it. |
| `CreateMediaStreamSource(MediaStream stream)` | `MediaStreamAudioSourceNode` | Creates a source node from a `MediaStream` (e.g., microphone input). |
| `CreateMediaElementSource(HTMLMediaElement element)` | `MediaElementAudioSourceNode` | Creates a source node from an HTML `<audio>` or `<video>` element. |
| `CreateMediaStreamTrackSource(MediaStreamTrack track)` | `MediaStreamTrackAudioSourceNode` | Creates a source node from a single `MediaStreamTrack`. |

### Node Factory Methods (inherited from BaseAudioContext)

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateAnalyser()` | `AnalyserNode` | Creates a node for real-time frequency and time-domain analysis. |
| `CreateBiquadFilter()` | `BiquadFilterNode` | Creates a configurable filter (high-pass, low-pass, band-pass, etc.). |
| `CreateBuffer(int channels, long length, float sampleRate)` | `AudioBuffer` | Creates an empty audio buffer for programmatic audio data. |
| `CreateBufferSource()` | `AudioBufferSourceNode` | Creates a source node that plays audio from an `AudioBuffer`. |
| `CreateChannelMerger(int numberOfInputs = 6)` | `ChannelMergerNode` | Creates a node that combines multiple audio channels into one stream. |
| `CreateChannelSplitter(int numberOfOutputs = 6)` | `ChannelSplitterNode` | Creates a node that splits an audio stream into individual channels. |
| `CreateConvolver()` | `ConvolverNode` | Creates a convolution node for reverb and spatial effects. |
| `CreateDelay(float? maxDelayTime = null)` | `DelayNode` | Creates a delay node. |
| `CreateDynamicsCompressor()` | `DynamicsCompressorNode` | Creates a dynamics compressor for audio compression. |
| `CreateGain()` | `GainNode` | Creates a gain (volume) control node. |
| `CreateIIRFilter(Float32Array feedforward, Float32Array feedback)` | `IIRFilterNode` | Creates an infinite impulse response filter. |
| `CreateMediaStreamDestination()` | `MediaStreamAudioDestinationNode` | Creates a destination node that outputs to a `MediaStream`. |
| `CreateOscillator()` | `OscillatorNode` | Creates an oscillator (tone generator) node. |
| `CreatePanner()` | `PannerNode` | Creates a 3D panning node for spatial audio. |
| `CreatePeriodicWave(Float32Array real, Float32Array imag)` | `PeriodicWave` | Creates a custom waveform for use with an `OscillatorNode`. |
| `CreateStereoPanner()` | `StereoPannerNode` | Creates a stereo panning node (left/right). |
| `CreateWaveShaper()` | `WaveShaperNode` | Creates a wave shaper node for non-linear distortion. |
| `DecodeAudioData(ArrayBuffer audioData)` | `Task<AudioBuffer>` | Decodes audio file data (MP3, WAV, OGG, etc.) into an `AudioBuffer`. |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `OnStateChange` | `ActionEvent<Event>` | Fired when the context state changes (`"suspended"`, `"running"`, `"closed"`). |

## Example

```csharp
// Create an audio context
using var audioCtx = new AudioContext();
Console.WriteLine($"Sample rate: {audioCtx.SampleRate} Hz");
Console.WriteLine($"State: {audioCtx.State}");

// Resume after user gesture (browsers require this)
await audioCtx.Resume();

// Play a simple tone with an oscillator
using var oscillator = audioCtx.CreateOscillator();
using var gainNode = audioCtx.CreateGain();

oscillator.Type = OscillatorType.Sine;
oscillator.Frequency.Value = 440; // A4 note
gainNode.Gain.Value = 0.5f;      // 50% volume

oscillator.Connect(gainNode);
gainNode.Connect(audioCtx.Destination);

oscillator.Start();
// Stop after 2 seconds
oscillator.Stop((float)(audioCtx.CurrentTime + 2.0));

// Process microphone input with an analyser
using var stream = await mediaDevices.GetUserMedia(new MediaStreamConstraints { Audio = true });
using var source = audioCtx.CreateMediaStreamSource(stream);
using var analyser = audioCtx.CreateAnalyser();

analyser.FftSize = 2048;
source.Connect(analyser);
analyser.Connect(audioCtx.Destination);

// Decode and play an audio file
using var response = await JS.CallAsync<Response>("fetch", "audio/music.mp3");
using var buffer = await response.ArrayBuffer();
using var audioBuffer = await audioCtx.DecodeAudioData(buffer);

using var bufferSource = audioCtx.CreateBufferSource();
bufferSource.Buffer = audioBuffer;
bufferSource.Connect(audioCtx.Destination);
bufferSource.Start();

// Apply a low-pass filter
using var filter = audioCtx.CreateBiquadFilter();
filter.Type = "lowpass";
filter.Frequency.Value = 1000;
source.Disconnect();
source.Connect(filter);
filter.Connect(audioCtx.Destination);

// Monitor state changes
audioCtx.OnStateChange += (evt) =>
{
    Console.WriteLine($"Audio context state: {audioCtx.State}");
    evt.Dispose();
};

// Suspend to save battery
await audioCtx.Suspend();

// Close when completely done
await audioCtx.Close();
```
