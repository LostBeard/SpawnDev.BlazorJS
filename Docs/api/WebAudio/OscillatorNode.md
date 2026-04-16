# OscillatorNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioScheduledSourceNode`  
**Source:** `JSObjects/WebAudio/OscillatorNode.cs`  
**MDN Reference:** [OscillatorNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/OscillatorNode)

> The OscillatorNode interface represents a periodic waveform, such as a sine wave. It is an AudioScheduledSourceNode audio-processing module that causes a specified frequency of a given wave to be created-in effect, a constant tone. https://developer.mozilla.org/en-US/docs/Web/API/OscillatorNode

## Constructors

| Signature | Description |
|---|---|
| `OscillatorNode(AudioContext context, OscillatorNodeOptions? options)` | Creates a new instance of the OscillatorNode interface. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Frequency` | `AudioParam` | get | An a-rate AudioParam representing the frequency of oscillation in hertz (though the AudioParam returned is read-only, the value it represents is not). The default value is 440 Hz (a standard middle-A note). |
| `Detune` | `AudioParam` | get | An a-rate AudioParam representing detuning of oscillation in cents (though the AudioParam returned is read-only, the value it represents is not). The default value is 0. |
| `Type` | `EnumString<OscillatorType>` | get | A string which specifies the shape of waveform to play; this can be one of a number of standard values, or custom to use a PeriodicWave to describe a custom waveform. Different waves will produce different tones. Standard values are "sine", "square", "sawtooth", "triangle" and "custom". The default is "sine". |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetPeriodicWave(PeriodicWave periodicWave)` | `void` | The setPeriodicWave() method of the OscillatorNode interface is used to point to a PeriodicWave defining a periodic waveform that can be used to shape the oscillator's output, when type is custom. A PeriodicWave object representing the waveform to use as the shape of the oscillator's output. |

## Example

```csharp
using var audioCtx = new AudioContext();

// Create an oscillator via the context factory method
using var oscillator = audioCtx.CreateOscillator();

// Set the waveform type using the EnumString pattern
oscillator.Type = OscillatorType.Square;

// Set frequency to 440 Hz (A4 note)
using var freq = oscillator.Frequency;
freq.Value = 440f;

// Schedule a precise frequency change at a specific time
freq.SetValueAtTime(880f, (float)audioCtx.CurrentTime + 1.0f);

// Connect to destination (speakers) and start
using var dest = audioCtx.Destination;
oscillator.Connect(dest);
oscillator.Start();

// Schedule stop after 2 seconds
oscillator.Stop(audioCtx.CurrentTime + 2.0f);

// Listen for when the oscillator finishes playing (named method for proper cleanup)
oscillator.OnEnded += Oscillator_OnEnded;

// Clean up before disposal
oscillator.OnEnded -= Oscillator_OnEnded;

void Oscillator_OnEnded(Event e)
{
    Console.WriteLine("Oscillator finished playing");
}

// Alternative: create via constructor with options
using var osc2 = new OscillatorNode(audioCtx);
osc2.Type = OscillatorType.Sawtooth;
using var freq2 = osc2.Frequency;
freq2.Value = 220f;

// Apply detuning in cents
using var detune = osc2.Detune;
detune.Value = 50f;
```

