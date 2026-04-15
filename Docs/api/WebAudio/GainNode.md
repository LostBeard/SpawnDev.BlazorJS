# GainNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/GainNode.cs`  
**MDN Reference:** [GainNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GainNode)

> The GainNode interface represents a change in volume. It is an AudioNode audio-processing module that causes a given gain to be applied to the input data before its propagation to the output. A GainNode always has exactly one input and one output, both with the same number of channels. The gain is a unitless value, changing with time, that is multiplied to each corresponding sample of all input channels. If modified, the new gain is instantly applied, causing unaesthetic 'clicks' in the resulting audio. To prevent this from happening, never change the value directly but use the exponential interpolation methods on the AudioParam interface. https://developer.mozilla.org/en-US/docs/Web/API/GainNode

## Constructors

| Signature | Description |
|---|---|
| `GainNode(BaseAudioContext context, GainNodeOptions? options)` | The GainNode() constructor of the Web Audio API creates a new GainNode object which is an AudioNode that represents a change in volume. A reference to a BaseAudioContext, e.g., an AudioContext. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Gain` | `AudioParam` | get | An a-rate AudioParam representing the amount of gain to apply. You have to set AudioParam.value or use the methods of AudioParam to change the effect of gain. |

## Example

```csharp
using var audioCtx = new AudioContext();

// Create a gain node via the constructor (pass context)
using var gainNode = new GainNode(audioCtx);

// Set gain to 75% volume
using var gain = gainNode.Gain;
gain.Value = 0.75f;

// Create a source and connect through the gain node
using var oscillator = audioCtx.CreateOscillator();
using var dest = audioCtx.Destination;
oscillator.Connect(gainNode);
gainNode.Connect(dest);

// Use AudioParam methods for smooth volume transitions
// Fade from current volume to 0 over 1 second (avoids clicks)
gain.LinearRampToValueAtTime(0f, (float)audioCtx.CurrentTime + 1.0f);

// Or use exponential ramp (value must be positive, not zero)
gain.ExponentialRampToValueAtTime(0.01f, (float)audioCtx.CurrentTime + 2.0f);

// Or create via BaseAudioContext.CreateGain()
using var gainNode2 = audioCtx.CreateGain();
using var gain2 = gainNode2.Gain;
gain2.Value = 0.5f;
```

