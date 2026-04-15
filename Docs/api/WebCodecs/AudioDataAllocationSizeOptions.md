# AudioDataAllocationSizeOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/AudioDataAllocationSizeOptions.cs`  
**MDN Reference:** [AudioDataAllocationSizeOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioData/allocationSize#options)

> Options used for AudioData.AllocationSize() https://developer.mozilla.org/en-US/docs/Web/API/AudioData/allocationSize#options

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AudioDataAllocationSizeOptions` | `class` | get | Options used for AudioData.AllocationSize() https://developer.mozilla.org/en-US/docs/Web/API/AudioData/allocationSize#options |
| `FrameOffset` | `int?` | get |  |
| `FrameCount` | `int?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<AudioDataAllocationSizeOptions>(...)` or constructor `new AudioDataAllocationSizeOptions(...)`

```js
let size = AudioData.allocationSize({ planeIndex: 1 });
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioData/allocationSize)*

