# PeriodicWaveOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNodeOptions`  
**Source:** `JSObjects/WebAudio/PeriodicWaveOptions.cs`  
**MDN Reference:** [PeriodicWaveOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PeriodicWave/PeriodicWave#options)

> https://developer.mozilla.org/en-US/docs/Web/API/PeriodicWave/PeriodicWave#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Real` | `Float32Array` | get | An array containing the cosine terms of the Fourier series defining the periodic waveform. The first element (index 0) represents the DC offset, the second element (index 1) represents the fundamental frequency, the third element (index 2) represents the second harmonic, and so on. |
| `Imag` | `Float32Array` | get | An array containing the sine terms of the Fourier series defining the periodic waveform. The first element (index 0) is ignored, the second element (index 1) represents the fundamental frequency, the third element (index 2) represents the second harmonic, and so on. |
| `DisableNormalization` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PeriodicWaveOptions>(...)` or constructor `new PeriodicWaveOptions(...)`

```js
const real = new Float32Array(2);
const imag = new Float32Array(2);
const ac = new AudioContext();

real[0] = 0;
imag[0] = 0;
real[1] = 1;
imag[1] = 0;

const wave = new PeriodicWave(ac, {
  real,
  imag,
  disableNormalization: false,
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PeriodicWave/PeriodicWave)*

