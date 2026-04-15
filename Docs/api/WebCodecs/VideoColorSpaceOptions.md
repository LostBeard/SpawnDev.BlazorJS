# VideoColorSpaceOptions

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebCodecs/VideoColorSpaceOptions.cs`  
**MDN Reference:** [VideoColorSpaceOptions on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace)

> An object representing the color space of the VideoFrame https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#colorspace

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `VideoColorSpaceOptions` | `class` | get | An object representing the color space of the VideoFrame https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#colorspace |
| `Transfer` | `string?` | get |  |
| `Matrix` | `string?` | get |  |
| `FullRange` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoColorSpaceOptions>(...)` or constructor `new VideoColorSpaceOptions(...)`

```js
let colorSpace = VideoFrame.colorSpace;
console.log(colorSpace);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace)*

