# AnalyserNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `EventTarget` -> `AudioNode` -> `AnalyserNode`  
**MDN Reference:** [AnalyserNode](https://developer.mozilla.org/en-US/docs/Web/API/AnalyserNode)

> The `AnalyserNode` class provides real-time frequency and time-domain analysis information for audio visualizations. It passes audio through unchanged from input to output, but lets you read the generated data to create visual representations of the audio (spectrum analyzers, waveform displays, VU meters, etc.). Created via `AudioContext.CreateAnalyser()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `AnalyserNode(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `FftSize` | `ulong` | The FFT (Fast Fourier Transform) size. Must be a power of 2 between 32 and 32768. Default is `2048`. Larger values give more frequency detail but less time resolution. |
| `FrequencyBinCount` | `ulong` | Read-only. Half of `FftSize`. This is the number of data values available for frequency visualization. |
| `MinDecibels` | `double` | Minimum power value in the scaling range for FFT data, used when converting to byte values. Default is `-100`. |
| `MaxDecibels` | `double` | Maximum power value in the scaling range for FFT data, used when converting to byte values. Default is `-30`. |
| `SmoothingTimeConstant` | `double` | Averaging constant with the last analysis frame. Range `0` to `1`. Default is `0.8`. Higher values produce smoother, less responsive visualizations. |

### Inherited Properties (from AudioNode)

| Property | Type | Description |
|----------|------|-------------|
| `Context` | `BaseAudioContext` | The associated audio context. |
| `NumberOfInputs` | `int` | Always `1`. |
| `NumberOfOutputs` | `int` | Always `1`. Audio passes through unchanged. |
| `ChannelCount` | `int` | Number of channels. |

## Methods

### Analysis Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetByteFrequencyData(Uint8Array array)` | `void` | Copies frequency data into a `Uint8Array` (0-255 range, scaled between `MinDecibels` and `MaxDecibels`). Array length should be `FrequencyBinCount`. |
| `GetFloatFrequencyData(Float32Array array)` | `void` | Copies frequency data into a `Float32Array` (decibel values). Array length should be `FrequencyBinCount`. |
| `GetByteTimeDomainData(Uint8Array array)` | `void` | Copies time-domain (waveform) data into a `Uint8Array` (0-255 range, 128 = silence). Array length should be `FftSize`. |
| `GetFloatTimeDomainData(Float32Array array)` | `void` | Copies time-domain (waveform) data into a `Float32Array` (-1.0 to 1.0 range). Array length should be `FftSize`. |

### Inherited Methods (from AudioNode)

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Connect(AudioNode node)` | `AudioNode` | Connects output to another node. |
| `Connect(AudioParam param)` | `void` | Connects output to an `AudioParam`. |
| `Disconnect()` | `void` | Disconnects from all connected nodes. |

## Example

```csharp
using var audioCtx = new AudioContext();
await audioCtx.Resume();

// Create an analyser for audio visualization
using var analyser = audioCtx.CreateAnalyser();
analyser.FftSize = 2048;
analyser.SmoothingTimeConstant = 0.85;
analyser.MinDecibels = -90;
analyser.MaxDecibels = -10;

Console.WriteLine($"Frequency bins: {analyser.FrequencyBinCount}"); // 1024

// Connect a source to the analyser
using var oscillator = audioCtx.CreateOscillator();
oscillator.Frequency.Value = 440;
oscillator.Connect(analyser);
analyser.Connect(audioCtx.Destination);
oscillator.Start();

// Read frequency data for a spectrum analyzer visualization
var bufferLength = (int)analyser.FrequencyBinCount;
using var frequencyData = new Uint8Array(bufferLength);

analyser.GetByteFrequencyData(frequencyData);
byte[] freqBytes = (byte[])frequencyData;
// Each element is 0-255, representing the amplitude at that frequency bin
for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Bin {i}: {freqBytes[i]}");
}

// Read time-domain data for a waveform/oscilloscope display
using var timeDomainData = new Float32Array((int)analyser.FftSize);

analyser.GetFloatTimeDomainData(timeDomainData);
float[] waveform = timeDomainData.ToArray();
// Each element is -1.0 to 1.0, representing the audio signal amplitude

// High-precision frequency analysis with Float32Array
using var floatFreqData = new Float32Array(bufferLength);
analyser.GetFloatFrequencyData(floatFreqData);
float[] freqFloats = floatFreqData.ToArray();
// Each element is in decibels (e.g., -90 to -10)

// Real-time visualization loop (use requestAnimationFrame)
// In Blazor, typically use a timer or animation frame callback:
void DrawVisualization()
{
    analyser.GetByteFrequencyData(frequencyData);
    byte[] data = (byte[])frequencyData;

    // Draw spectrum bars on a canvas
    for (int i = 0; i < bufferLength; i++)
    {
        float barHeight = data[i] / 255.0f; // Normalize to 0-1
        // ... draw bar at position i with height barHeight
    }
}

// Analyze microphone input
using var stream = await mediaDevices.GetUserMedia(
    new MediaStreamConstraints { Audio = true });
using var micSource = audioCtx.CreateMediaStreamSource(stream);
micSource.Connect(analyser);
// Don't connect analyser to destination to avoid feedback!
```
