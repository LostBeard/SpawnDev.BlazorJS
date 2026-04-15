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

