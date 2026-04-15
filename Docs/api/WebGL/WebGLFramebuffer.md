# WebGLFramebuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLFramebuffer.cs`  
**MDN Reference:** [WebGLFramebuffer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLFramebuffer)

> The WebGLFramebuffer interface is part of the WebGL API and represents a collection of buffers that serve as a rendering destination. https://developer.mozilla.org/en-US/docs/Web/API/WebGLFramebuffer

## Constructors

| Signature | Description |
|---|---|
| `WebGLFramebuffer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLFramebuffer>(...)` or constructor `new WebGLFramebuffer(...)`

### Creating a frame buffer

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");
const buffer = gl.createFramebuffer();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLFramebuffer)*

