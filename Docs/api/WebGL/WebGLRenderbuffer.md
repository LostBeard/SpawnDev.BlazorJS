# WebGLRenderbuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLRenderbuffer.cs`  
**MDN Reference:** [WebGLRenderbuffer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderbuffer)

> The WebGLRenderbuffer interface is part of the WebGL API and represents a buffer that can contain an image, or that can be a source or target of a rendering operation. https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderbuffer

## Constructors

| Signature | Description |
|---|---|
| `WebGLRenderbuffer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLRenderbuffer>(...)` or constructor `new WebGLRenderbuffer(...)`

### Creating a render buffer

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");
const buffer = gl.createRenderbuffer();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLRenderbuffer)*

