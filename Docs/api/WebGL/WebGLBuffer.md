# WebGLBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLBuffer.cs`  
**MDN Reference:** [WebGLBuffer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLBuffer)

> The WebGLBuffer interface is part of the WebGL API and represents an opaque buffer object storing data such as vertices or colors. https://developer.mozilla.org/en-US/docs/Web/API/WebGLBuffer

## Constructors

| Signature | Description |
|---|---|
| `WebGLBuffer(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLBuffer>(...)` or constructor `new WebGLBuffer(...)`

### Creating a buffer

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");
const buffer = gl.createBuffer();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLBuffer)*

