# AudioContextOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebAudio/AudioContextOptions.cs`  
**MDN Reference:** [AudioContextOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/AudioContext#options)

> An object used to configure a new AudioContext https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/AudioContext#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AudioContextOptions` | `class` | get | An object used to configure a new AudioContext https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/AudioContext#options |
| `LatencyHint` | `string?` | get |  |
| `SinkId` | `object?` | get |  |
| `SampleRate` | `float?` | get/set | Indicates the sample rate to use for the new context. The value must be a floating-point value indicating the sample rate, in samples per second, for which to configure the new context; additionally, the value must be one which is supported by AudioBuffer.sampleRate. The value will typically be between 8,000 Hz and 96,000 Hz; the default will vary depending on the output device, but the sample rate 44,100 Hz is the most common. If the sampleRate property is not included in the options, or the options are not specified when creating the audio context, the new context's output device's preferred sample rate is used by default. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioContextOptions>(...)` or constructor `new AudioContextOptions(...)`

```js
const audioCtx = new AudioContext({
  latencyHint: "interactive",
  sampleRate: 44100,
  sinkId: "bb04fea9a8318c96de0bd...", // truncated for brevity
});
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioContext/AudioContext)*

