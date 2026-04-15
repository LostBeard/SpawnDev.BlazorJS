# AnalyserNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/AnalyserNode.cs`  
**MDN Reference:** [AnalyserNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AnalyserNode)

> The AnalyserNode interface represents a node able to provide real-time frequency and time-domain analysis information. It is an AudioNode that passes the audio stream unchanged from the input to the output, but allows you to take the generated data, process it, and create audio visualizations. https://developer.mozilla.org/en-US/docs/Web/API/AnalyserNode

## Constructors

| Signature | Description |
|---|---|
| `AnalyserNode(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `FftSize` | `ulong` | get | An unsigned long value representing the size of the FFT (Fast Fourier Transform) to be used to determine the frequency domain. Must be a power of 2 between 2^5 and 2^15 (32 to 32768). Defaults to 2048. |
| `FrequencyBinCount` | `ulong` | get | An unsigned long value half that of the FFT size. This generally equates to the number of data values you will have to play with for the visualization. |
| `MinDecibels` | `double` | get | A double value representing the minimum power value in the scaling range for the FFT analysis data, for conversion to unsigned byte values. Defaults to -100. |
| `MaxDecibels` | `double` | get | A double value representing the maximum power value in the scaling range for the FFT analysis data, for conversion to unsigned byte values. Defaults to -30. |
| `SmoothingTimeConstant` | `double` | get | A double value representing the averaging constant with the last analysis frame. Defaults to 0.8. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetByteFrequencyData(Uint8Array uint8Array)` | `void` | Copies the current frequency data into a Uint8Array (unsigned byte array) passed into it. Each item in the array represents the decibel value for a specific frequency. |
| `GetFloatFrequencyData(Float32Array float32Array)` | `void` | Copies the current frequency data into a Float32Array passed into it. Each item in the array represents the decibel value for a specific frequency. |
| `GetByteTimeDomainData(Uint8Array uint8Array)` | `void` | Copies the current waveform, or time-domain, data into a Uint8Array (unsigned byte array) passed into it. |
| `GetFloatTimeDomainData(Float32Array float32Array)` | `void` | Copies the current waveform, or time-domain, data into a Float32Array array passed into it. |

## Example

```csharp
using var audioCtx = new AudioContext();

// Create an analyser node for frequency/time-domain data
using var analyser = audioCtx.CreateAnalyser();
analyser.FftSize = 2048;

var bufferLength = analyser.FrequencyBinCount;
Console.WriteLine($"Frequency bins: {bufferLength}");

// Create a Uint8Array to hold frequency data
using var dataArray = new Uint8Array((int)bufferLength);

// Connect an audio source to the analyser
using var oscillator = audioCtx.CreateOscillator();
oscillator.Connect(analyser);
using var dest = audioCtx.Destination;
analyser.Connect(dest);
oscillator.Start();

// Read frequency data into the buffer
analyser.GetByteFrequencyData(dataArray);
byte[] freqData = dataArray.ReadBytes();
Console.WriteLine($"First frequency bin value: {freqData[0]}");

// Read time-domain (waveform) data
analyser.GetByteTimeDomainData(dataArray);
byte[] waveformData = dataArray.ReadBytes();

// Use float data for higher precision
using var floatArray = new Float32Array((int)bufferLength);
analyser.GetFloatFrequencyData(floatArray);
float[] preciseData = floatArray.ToArray();

// Customize analyser settings
analyser.MinDecibels = -90;
analyser.MaxDecibels = -10;
analyser.SmoothingTimeConstant = 0.85;

oscillator.Stop();
```

