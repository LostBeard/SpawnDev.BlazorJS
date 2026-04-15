# AudioContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `BaseAudioContext`  
**Source:** `JSObjects/WebAudio/AudioContext.cs`  
**MDN Reference:** [AudioContext on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioContext)

> The AudioContext interface represents an audio-processing graph built from audio modules linked together, each represented by an AudioNode. https://developer.mozilla.org/en-US/docs/Web/API/AudioContext

## Constructors

| Signature | Description |
|---|---|
| `AudioContext(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `AudioContext()` | The AudioContext() constructor creates a new AudioContext object which represents an audio-processing graph, built from audio modules linked together, each represented by an AudioNode. |
| `AudioContext(AudioContextOptions options)` | The AudioContext() constructor creates a new AudioContext object which represents an audio-processing graph, built from audio modules linked together, each represented by an AudioNode. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CreateMediaStreamSource(MediaStream mediaStream)` | `MediaStreamAudioSourceNode` | Creates a MediaStreamAudioSourceNode associated with a MediaStream representing an audio stream which may come from the local computer microphone or other sources. |
| `Close()` | `Task` | The close() method of the AudioContext Interface closes the audio context, releasing any system audio resources that it uses. This function does not automatically release all AudioContext-created objects, unless other references have been released as well; however, it will forcibly release any system audio resources that might prevent additional AudioContexts from being created and used, suspend the progression of audio time in the audio context, and stop processing audio data. The returned Promise resolves when all AudioContext-creation-blocking resources have been released. This method throws an INVALID_STATE_ERR exception if called on an OfflineAudioContext. |
| `CreateMediaElementSource(HTMLMediaElement mediaElement)` | `MediaElementAudioSourceNode` | The createMediaElementSource() method of the AudioContext Interface is used to create a new MediaElementAudioSourceNode object, given an existing HTML audio or video element, the audio from which can then be played and manipulated. |
| `CreateMediaStreamTrackSource(MediaStreamTrack track)` | `MediaStreamTrackAudioSourceNode` | The createMediaStreamTrackSource() method of the AudioContext interface creates and returns a MediaStreamTrackAudioSourceNode which represents an audio source whose data comes from the specified MediaStreamTrack. |
| `GetOutputTimestamp()` | `AudioTimestamp` | Returns a new AudioTimestamp object containing two audio timestamp values relating to the current audio context. |
| `Resume()` | `Task` | Resumes the progression of time in an audio context that has previously been suspended/paused. |
| `SetSinkId(string sinkId)` | `Task` | The setSinkId() method of the AudioContext interface sets the output audio device for the AudioContext. If a sink ID is not explicitly set, the default system audio output device will be used. A string representing the sink ID, retrieved for example via the deviceId property of the MediaDeviceInfo objects returned by MediaDevices.enumerateDevices(). |
| `SetSinkId(AudioSinkOptions options)` | `Task` | The setSinkId() method of the AudioContext interface sets the output audio device for the AudioContext. If a sink ID is not explicitly set, the default system audio output device will be used. An object representing different options for a sink ID. Currently this takes a single property, type, with a value of none. Setting this parameter causes the audio to be processed without being played through any audio output device. This is a useful option to minimize power consumption when you don't need playback along with processing. |
| `Suspend()` | `Task` | Suspends the progression of time in the audio context, temporarily halting audio hardware access and reducing CPU/battery usage in the process. |

## Example

```csharp
// Create an audio context
using var audioCtx = new AudioContext();

// Create an oscillator and a gain node for volume control
using var oscillator = audioCtx.CreateOscillator();
using var gainNode = audioCtx.CreateGain();

// Set oscillator frequency to 440 Hz (A4 note)
using var freq = oscillator.Frequency;
freq.Value = 440f;

// Set volume to 50%
using var gain = gainNode.Gain;
gain.Value = 0.5f;

// Connect: oscillator -> gain -> speakers
using var dest = audioCtx.Destination;
oscillator.Connect(gainNode);
gainNode.Connect(dest);

// Play for a short duration
oscillator.Start();
// Schedule stop at 2 seconds from now
oscillator.Stop(audioCtx.CurrentTime + 2.0f);

// Create an analyser for visualizations
using var analyser = audioCtx.CreateAnalyser();
analyser.FftSize = 2048;
gainNode.Connect(analyser);

// Suspend and resume the context to manage resources
await audioCtx.Suspend();
Console.WriteLine($"Audio context state: {audioCtx.State}");
await audioCtx.Resume();

// Close the context when done to release system audio resources
await audioCtx.Close();
```

