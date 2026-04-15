# AudioDataCopyToOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/AudioDataCopyToOptions.cs`  
**MDN Reference:** [AudioDataCopyToOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioData/copyTo#options)

> Options used fpr AudioData.CopyTo() https://developer.mozilla.org/en-US/docs/Web/API/AudioData/copyTo#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AudioDataCopyToOptions` | `class` | get | Options used fpr AudioData.CopyTo() https://developer.mozilla.org/en-US/docs/Web/API/AudioData/copyTo#options |
| `FrameOffset` | `int?` | get |  |
| `FrameCount` | `int?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioDataCopyToOptions>(...)` or constructor `new AudioDataCopyToOptions(...)`

```js
AudioData.copyTo(AudioBuffer, { planeIndex: 1 });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioData/copyTo)*

