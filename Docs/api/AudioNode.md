# AudioNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `EventTarget` -> `AudioNode`  
**MDN Reference:** [AudioNode](https://developer.mozilla.org/en-US/docs/Web/API/AudioNode)

> The `AudioNode` class is the base interface for all audio processing modules in the Web Audio API. An audio node can be a source (e.g., `OscillatorNode`, `AudioBufferSourceNode`), a processing node (e.g., `GainNode`, `BiquadFilterNode`, `AnalyserNode`), or a destination (`AudioDestinationNode`). Nodes are connected together to form an audio processing graph where audio flows from sources through processors to the destination.

## Constructors

| Signature | Description |
|-----------|-------------|
| `AudioNode(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Context` | `BaseAudioContext` | The associated `BaseAudioContext` (the audio graph this node belongs to). |
| `NumberOfInputs` | `int` | The number of inputs feeding the node. Source nodes have 0 inputs. |
| `NumberOfOutputs` | `int` | The number of outputs coming out of the node. Destination nodes have 0 outputs. |
| `ChannelCount` | `int` | The number of channels used when up-mixing and down-mixing connections to any inputs. |
| `ChannelCountMode` | `string` | How channels are matched between inputs and outputs: `"max"`, `"clamped-max"`, or `"explicit"`. |
| `ChannelInterpretation` | `string` | The meaning of the channels: `"speakers"` (positional audio) or `"discrete"` (individual channels). |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Connect(AudioNode audioNode)` | `AudioNode` | Connects this node's output to another `AudioNode`'s input. Returns the destination node for chaining. |
| `Connect(AudioParam audioParam)` | `void` | Connects this node's output to an `AudioParam`, allowing the node's output to automate the parameter value. |
| `Disconnect()` | `void` | Disconnects this node from all nodes it is connected to. |
| `Disconnect(AudioNode audioNode)` | `void` | Disconnects this node from a specific `AudioNode`. |
| `Disconnect(AudioParam audioParam)` | `void` | Disconnects this node from a specific `AudioParam`. |

## AudioNode Subclasses

The Web Audio API provides many specialized nodes, all inheriting from `AudioNode`:

| Node | Category | Description |
|------|----------|-------------|
| `OscillatorNode` | Source | Generates periodic waveforms (sine, square, sawtooth, triangle). |
| `AudioBufferSourceNode` | Source | Plays audio from an `AudioBuffer`. |
| `MediaElementAudioSourceNode` | Source | Receives audio from an HTML `<audio>` or `<video>` element. |
| `MediaStreamAudioSourceNode` | Source | Receives audio from a `MediaStream` (e.g., microphone). |
| `GainNode` | Processing | Controls volume (gain). |
| `BiquadFilterNode` | Processing | Configurable filter (low-pass, high-pass, band-pass, etc.). |
| `AnalyserNode` | Processing | Provides frequency and time-domain analysis data for visualizations. |
| `DelayNode` | Processing | Delays audio by a specified time. |
| `ConvolverNode` | Processing | Applies convolution (reverb, spatial effects). |
| `DynamicsCompressorNode` | Processing | Applies dynamic range compression. |
| `WaveShaperNode` | Processing | Applies non-linear distortion. |
| `StereoPannerNode` | Processing | Stereo left/right panning. |
| `PannerNode` | Processing | 3D spatial audio panning. |
| `ChannelSplitterNode` | Processing | Splits a multi-channel stream into individual channels. |
| `ChannelMergerNode` | Processing | Merges multiple channels into one stream. |
| `AudioDestinationNode` | Destination | The final output (speakers/headphones). |
| `MediaStreamAudioDestinationNode` | Destination | Outputs to a `MediaStream`. |

## Example

```csharp
using var audioCtx = new AudioContext();

// Build an audio processing graph:
// Oscillator -> Gain -> Filter -> Analyser -> Destination

using var oscillator = audioCtx.CreateOscillator();
using var gain = audioCtx.CreateGain();
using var filter = audioCtx.CreateBiquadFilter();
using var analyser = audioCtx.CreateAnalyser();

// Connect nodes to form the graph (chaining with return value)
oscillator.Connect(gain);
gain.Connect(filter);
filter.Connect(analyser);
analyser.Connect(audioCtx.Destination);

// Inspect node properties
Console.WriteLine($"Gain inputs: {gain.NumberOfInputs}");     // 1
Console.WriteLine($"Gain outputs: {gain.NumberOfOutputs}");    // 1
Console.WriteLine($"Channel count: {gain.ChannelCount}");      // 2

// Change channel configuration
gain.ChannelCountMode = "explicit";
gain.ChannelInterpretation = "speakers";

// Connect a node's output to an AudioParam (modulation)
// This makes the oscillator's output control the gain value
using var lfo = audioCtx.CreateOscillator();
lfo.Frequency.Value = 5; // 5 Hz tremolo
lfo.Connect(gain.Gain);   // Connect to the Gain AudioParam
lfo.Start();

// Disconnect and reconnect
gain.Disconnect(filter);   // Disconnect from filter specifically
gain.Connect(analyser);    // Bypass the filter

// Disconnect everything
oscillator.Disconnect();   // Disconnects from all destinations
```
