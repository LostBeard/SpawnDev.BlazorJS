# OscillatorNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `EventTarget` -> `AudioNode` -> `AudioScheduledSourceNode` -> `OscillatorNode`  
**MDN Reference:** [OscillatorNode](https://developer.mozilla.org/en-US/docs/Web/API/OscillatorNode)

> The `OscillatorNode` class represents a periodic waveform - a tone generator. It produces a constant tone at a specified frequency using one of several waveform types (sine, square, sawtooth, triangle) or a custom waveform defined by a `PeriodicWave`. Oscillators are commonly used for synthesizer tones, test signals, sound effects, and as low-frequency oscillators (LFOs) for modulation effects like tremolo and vibrato. Created via `AudioContext.CreateOscillator()` or the constructor.

## Constructors

| Signature | Description |
|-----------|-------------|
| `OscillatorNode(AudioContext context, OscillatorNodeOptions? options = null)` | Creates a new oscillator in the given audio context with optional initial settings. |
| `OscillatorNode(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Frequency` | `AudioParam` | The frequency of oscillation in Hz. Default is `440` (concert A4). Supports automation via `AudioParam` scheduling methods. |
| `Detune` | `AudioParam` | Detuning of oscillation in cents (1/100 of a semitone). Default is `0`. Allows fine pitch adjustments. |
| `Type` | `EnumString<OscillatorType>` | The waveform shape: `"sine"`, `"square"`, `"sawtooth"`, `"triangle"`, or `"custom"` (when using `SetPeriodicWave`). Default is `"sine"`. |

### OscillatorType Enum Values

| Value | Description |
|-------|-------------|
| `Sine` | A smooth sine wave. The fundamental, purest tone. |
| `Square` | A square wave with sharp transitions. Rich in odd harmonics, sounds buzzy. |
| `Sawtooth` | A sawtooth wave. Contains all harmonics, sounds bright and brassy. |
| `Triangle` | A triangle wave. Contains odd harmonics at lower amplitudes than square, sounds mellow. |
| `Custom` | A custom waveform defined by `SetPeriodicWave()`. Set automatically when `SetPeriodicWave` is called. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Start(float? when = null)` | `void` | Starts the oscillator. `when` is the time in seconds (from `AudioContext.CurrentTime`) to start. Omit or pass `null` to start immediately. |
| `Stop(float? when = null)` | `void` | Stops the oscillator. `when` is the time in seconds to stop. Omit or pass `null` to stop immediately. Once stopped, an oscillator cannot be restarted - create a new one. |
| `SetPeriodicWave(PeriodicWave wave)` | `void` | Sets a custom waveform. The `Type` property automatically changes to `"custom"`. |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `OnEnded` | `ActionEvent<Event>` | Fired when the oscillator stops playing (after `Stop()` time is reached). |

## Example

```csharp
using var audioCtx = new AudioContext();
await audioCtx.Resume();

// Simple tone: 440 Hz sine wave
using var osc = audioCtx.CreateOscillator();
osc.Type = OscillatorType.Sine;
osc.Frequency.Value = 440;
osc.Connect(audioCtx.Destination);
osc.Start();
osc.Stop((float)(audioCtx.CurrentTime + 1.0)); // Play for 1 second

// Using the constructor with options
using var osc2 = new OscillatorNode(audioCtx, new OscillatorNodeOptions
{
    Type = OscillatorType.Square,
    Frequency = 880
});
using var gain = audioCtx.CreateGain();
gain.Gain.Value = 0.3f; // Lower volume for square wave
osc2.Connect(gain);
gain.Connect(audioCtx.Destination);
osc2.Start();

// Play a melody by scheduling frequency changes
using var melody = audioCtx.CreateOscillator();
melody.Type = OscillatorType.Triangle;
melody.Connect(audioCtx.Destination);

float now = (float)audioCtx.CurrentTime;
float[] notes = { 261.63f, 293.66f, 329.63f, 349.23f, 392.00f }; // C D E F G
for (int i = 0; i < notes.Length; i++)
{
    melody.Frequency.SetValueAtTime(notes[i], now + i * 0.5f);
}
melody.Start();
melody.Stop(now + notes.Length * 0.5f);

// Vibrato effect using a second oscillator as LFO
using var tone = audioCtx.CreateOscillator();
using var lfo = audioCtx.CreateOscillator();
using var lfoGain = audioCtx.CreateGain();

tone.Frequency.Value = 440;
lfo.Frequency.Value = 6;      // 6 Hz vibrato rate
lfoGain.Gain.Value = 10;      // 10 Hz vibrato depth

lfo.Connect(lfoGain);
lfoGain.Connect(tone.Frequency); // Modulate the tone's frequency
tone.Connect(audioCtx.Destination);

tone.Start();
lfo.Start();

// Custom waveform using PeriodicWave
float[] real = new float[] { 0, 0, 1, 0, 1 };   // Cosine terms
float[] imag = new float[] { 0, 1, 0, 0.5f, 0 }; // Sine terms
using var realArr = new Float32Array(real);
using var imagArr = new Float32Array(imag);
using var customWave = audioCtx.CreatePeriodicWave(realArr, imagArr);

using var customOsc = audioCtx.CreateOscillator();
customOsc.SetPeriodicWave(customWave);
Console.WriteLine($"Type: {customOsc.Type}"); // "custom"
customOsc.Frequency.Value = 220;
customOsc.Connect(audioCtx.Destination);
customOsc.Start();

// Detune for slight pitch variation
customOsc.Detune.Value = 50; // 50 cents sharp (half a semitone)

// Handle the ended event
osc.OnEnded += (evt) =>
{
    Console.WriteLine("Oscillator finished playing");
    evt.Dispose();
};
```
