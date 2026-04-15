# PeriodicWave

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebAudio/PeriodicWave.cs`  

> The PeriodicWave interface defines a periodic waveform that can be used to shape the output of an OscillatorNode. PeriodicWave has no inputs or outputs; it is used to define custom oscillators when calling OscillatorNode.setPeriodicWave(). The PeriodicWave itself is created/returned by BaseAudioContext.createPeriodicWave.

## Constructors

| Signature | Description |
|---|---|
| `PeriodicWave(AudioContext context, PeriodicWaveOptions? options)` | Initializes a new instance of the `PeriodicWave` class, representing a periodic waveform that can be used as a source in an audio context. The `AudioContext` in which this periodic waveform will be used. Optional configuration settings for the periodic waveform, such as the real and imaginary components of the waveform. If null, default options are used. |

