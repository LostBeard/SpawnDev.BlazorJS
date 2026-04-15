# VideoColorSpace

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebCodecs/VideoColorSpace.cs`  
**MDN Reference:** [VideoColorSpace on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace/VideoColorSpace)

> The VideoColorSpace() constructor creates a new VideoColorSpace object which represents a video color space. https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace/VideoColorSpace

## Constructors

| Signature | Description |
|---|---|
| `VideoColorSpace(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `VideoColorSpace()` | The VideoColorSpace() constructor creates a new VideoColorSpace object which represents a video color space. |
| `VideoColorSpace(VideoColorSpaceOptions options)` | The VideoColorSpace() constructor creates a new VideoColorSpace object which represents a video color space. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Primaries` | `string` | get | A string containing the color primary describing the color gamut of a video sample. |
| `Transfer` | `string` | get | A string containing the transfer characteristics of video samples. |
| `Matrix` | `string` | get | A string containing the matrix coefficients describing the relationship between sample component values and color coordinates. |
| `FullRange` | `bool` | get | A Boolean. If true indicates that full-range color values are used. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `ToJSON()` | `JSObject` | Returns a JSON representation of the VideoColorSpace object. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<VideoColorSpace>(...)` or constructor `new VideoColorSpace(...)`

```js
const options = {
  primaries: "bt709",
  fullRange: true,
};

const colorSpace = new VideoColorSpace(options);
console.log(colorSpace);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace/VideoColorSpace)*

