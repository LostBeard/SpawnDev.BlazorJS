# WebGLContextAttributes

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGL/WebGLContextAttributes.cs`  
**MDN Reference:** [WebGLContextAttributes on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement/getContext)

> The WebGLContextAttributes dictionary contains attributes used to configure the WebGL context when creating it. https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement/getContext

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `WebGLContextAttributes` | `class` | get | The WebGLContextAttributes dictionary contains attributes used to configure the WebGL context when creating it. https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement/getContext |
| `Desynchronized` | `bool?` | get |  |
| `Antialias` | `bool?` | get |  |
| `Depth` | `bool?` | get |  |
| `FailIfMajorPerformanceCaveat` | `bool?` | get |  |
| `PowerPreference` | `string?` | get |  |
| `PremultipliedAlpha` | `bool?` | get |  |
| `PreserveDrawingBuffer` | `bool?` | get |  |
| `Stencil` | `bool?` | get |  |
| `XrCompatible` | `bool?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLContextAttributes>(...)` or constructor `new WebGLContextAttributes(...)`

```js
const canvas = document.getElementById("canvas");
const ctx = canvas.getContext("2d");
console.log(ctx); // CanvasRenderingContext2D { /* … */ }
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement/getContext)*

