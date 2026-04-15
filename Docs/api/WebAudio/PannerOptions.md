# PannerOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebAudio/PannerOptions.cs`  
**MDN Reference:** [PannerOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PannerNode/PannerNode#options)

> https://developer.mozilla.org/en-US/docs/Web/API/PannerNode/PannerNode#options https://webaudio.github.io/web-audio-api/#idl-def-PannerOptions

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PannerOptions` | `class` | get | https://developer.mozilla.org/en-US/docs/Web/API/PannerNode/PannerNode#options https://webaudio.github.io/web-audio-api/#idl-def-PannerOptions |
| `DistanceModel` | `string?` | get |  |
| `PositionX` | `double?` | get |  |
| `PositionY` | `double?` | get |  |
| `PositionZ` | `double?` | get |  |
| `OrientationX` | `double?` | get |  |
| `OrientationY` | `double?` | get |  |
| `OrientationZ` | `double?` | get |  |
| `RefDistance` | `double?` | get |  |
| `MaxDistance` | `double?` | get |  |
| `RolloffFactor` | `double?` | get |  |
| `ConeInnerAngle` | `double?` | get |  |
| `ConeOuterAngle` | `double?` | get |  |
| `ConeOuterGain` | `double?` | get |  |
| `ChannelCount` | `int?` | get |  |
| `ChannelCountMode` | `string?` | get |  |
| `ChannelInterpretation` | `string?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<PannerOptions>(...)` or constructor `new PannerOptions(...)`

```js
const ctx = new AudioContext();

const options = {
  positionX: 1,
  maxDistance: 5000,
};

const myPanner = new PannerNode(ctx, options);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PannerNode/PannerNode)*

