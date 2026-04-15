# GainNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `EventTarget` -> `AudioNode` -> `GainNode`  
**MDN Reference:** [GainNode](https://developer.mozilla.org/en-US/docs/Web/API/GainNode)

> The `GainNode` class represents a change in volume. It is an `AudioNode` that applies a given gain (volume multiplier) to the input audio before passing it to the output. A `GainNode` always has exactly one input and one output, both with the same number of channels. The gain is a unitless value that is multiplied to each sample of all input channels. To avoid audible clicks when changing volume, use the `AudioParam` automation methods (`LinearRampToValueAtTime`, `ExponentialRampToValueAtTime`, `SetTargetAtTime`) instead of setting `Gain.Value` directly.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GainNode(BaseAudioContext context, GainNodeOptions? options = null)` | Creates a new `GainNode` in the given audio context with optional initial gain value. |
| `GainNode(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Gain` | `AudioParam` | An a-rate `AudioParam` representing the amount of gain to apply. Default value is `1.0` (no change). A value of `0` silences the audio; `2.0` doubles the volume. |

### Inherited Properties (from AudioNode)

| Property | Type | Description |
|----------|------|-------------|
| `Context` | `BaseAudioContext` | The associated audio context. |
| `NumberOfInputs` | `int` | Always `1` for `GainNode`. |
| `NumberOfOutputs` | `int` | Always `1` for `GainNode`. |
| `ChannelCount` | `int` | Number of channels. |
| `ChannelCountMode` | `string` | Channel matching mode. |
| `ChannelInterpretation` | `string` | Channel interpretation mode. |

## AudioParam Methods (on Gain property)

The `Gain` property is an `AudioParam` with these scheduling methods:

| Method | Return Type | Description |
|--------|-------------|-------------|
| `SetValueAtTime(float value, double startTime)` | `AudioParam` | Schedules an instant change at a precise time. |
| `LinearRampToValueAtTime(float value, double endTime)` | `AudioParam` | Schedules a gradual linear change. |
| `ExponentialRampToValueAtTime(float value, double endTime)` | `AudioParam` | Schedules a gradual exponential change (value must be positive). |
| `SetTargetAtTime(float target, double startTime, float timeConstant)` | `AudioParam` | Starts an exponential approach to a target value. |
| `SetValueCurveAtTime(float[] values, double startTime, double duration)` | `AudioParam` | Follows a curve of values over a duration. |
| `CancelScheduledValues(double startTime)` | `AudioParam` | Cancels all scheduled changes from the given time onward. |
| `CancelAndHoldAtTime(double cancelTime)` | `AudioParam` | Cancels scheduled changes but holds the current computed value. |

## Example

```csharp
using var audioCtx = new AudioContext();
await audioCtx.Resume();

// Create a gain node using the factory method
using var gain = audioCtx.CreateGain();
gain.Gain.Value = 0.5f; // 50% volume

// Or create using the constructor
using var gain2 = new GainNode(audioCtx, new GainNodeOptions { Gain = 0.8f });

// Build a simple audio graph: Oscillator -> Gain -> Destination
using var oscillator = audioCtx.CreateOscillator();
oscillator.Frequency.Value = 440;

oscillator.Connect(gain);
gain.Connect(audioCtx.Destination);
oscillator.Start();

// Smooth volume fade-in over 2 seconds (avoids clicks)
gain.Gain.SetValueAtTime(0, (float)audioCtx.CurrentTime);
gain.Gain.LinearRampToValueAtTime(1.0f, (float)(audioCtx.CurrentTime + 2.0));

// Smooth fade-out over 1 second, starting 3 seconds from now
gain.Gain.SetValueAtTime(1.0f, (float)(audioCtx.CurrentTime + 3.0));
gain.Gain.ExponentialRampToValueAtTime(0.01f, (float)(audioCtx.CurrentTime + 4.0));

// Create a tremolo effect using LFO modulation
using var lfo = audioCtx.CreateOscillator();
using var lfoGain = audioCtx.CreateGain();

lfo.Frequency.Value = 5;     // 5 Hz tremolo rate
lfoGain.Gain.Value = 0.5f;   // Tremolo depth

lfo.Connect(lfoGain);
lfoGain.Connect(gain.Gain);  // Modulate the main gain
lfo.Start();

// Volume control slider
void SetVolume(float volume)
{
    // Use SetTargetAtTime for smooth transitions
    gain.Gain.SetTargetAtTime(volume, (float)audioCtx.CurrentTime, 0.05f);
}

// Mute (smooth)
SetVolume(0);

// Unmute to 75%
SetVolume(0.75f);
```
