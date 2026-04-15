# AudioParam

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebAudio/AudioParam.cs`  
**MDN Reference:** [AudioParam on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioParam)

> The Web Audio API's AudioParam interface represents an audio-related parameter, usually a parameter of an AudioNode (such as GainNode.gain). Each AudioParam has a list of events, initially empty, that define when and how values change. When this list is not empty, changes using the AudioParam.value attributes are ignored. This list of events allows us to schedule changes that have to happen at very precise times, using arbitrary timeline-based automation curves. The time used is the one defined in AudioContext.currentTime. https://developer.mozilla.org/en-US/docs/Web/API/AudioParam

## Constructors

| Signature | Description |
|---|---|
| `AudioParam(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DefaultValue` | `float` | get | Represents the initial value of the attribute as defined by the specific AudioNode creating the AudioParam. |
| `MaxValue` | `float` | get | Represents the maximum possible value for the parameter's nominal (effective) range. |
| `MinValue` | `float` | get/set | Represents the minimum possible value for the parameter's nominal (effective) range. |
| `Value` | `float` | get | Represents the parameter's current value as of the current time; initially set to the value of defaultValue. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetValueAtTime(float value, double startTime)` | `AudioParam` | Schedules an instant change to the value at a precise time. |
| `LinearRampToValueAtTime(float value, double endTime)` | `AudioParam` | Schedules a gradual linear change to the value. |
| `ExponentialRampToValueAtTime(float value, double endTime)` | `AudioParam` | Schedules a gradual exponential change to the value. The value must be positive. |
| `SetTargetAtTime(float target, double startTime, float timeConstant)` | `AudioParam` | Schedules the start of a change to the value, following an exponential approach to a target value at a given rate. |
| `SetValueCurveAtTime(float[] values, double startTime, double duration)` | `AudioParam` | Schedules the values to follow a set of values defined by a Float32Array scaled to fit into a given interval. |
| `CancelScheduledValues(double startTime)` | `AudioParam` | Cancels all scheduled future changes to the AudioParam. |
| `CancelAndHoldAtTime(double cancelTime)` | `AudioParam` | Cancels all scheduled future changes to the AudioParam but holds its value at a given time. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioParam>(...)` or constructor `new AudioParam(...)`

```js
const audioCtx = new AudioContext();

const gainNode = audioCtx.createGain();
gainNode.gain.value = 0;
```

```js
const compressor = audioCtx.createDynamicsCompressor();
compressor.threshold.setValueAtTime(-50, audioCtx.currentTime);
compressor.knee.setValueAtTime(40, audioCtx.currentTime);
compressor.ratio.setValueAtTime(12, audioCtx.currentTime);
compressor.attack.setValueAtTime(0, audioCtx.currentTime);
compressor.release.setValueAtTime(0.25, audioCtx.currentTime);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioParam)*

