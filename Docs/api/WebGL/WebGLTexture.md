# WebGLTexture

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLTexture.cs`  
**MDN Reference:** [WebGLTexture on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLTexture)

> The WebGLTexture interface is part of the WebGL API and represents an opaque texture object providing storage and state for texturing operations. https://developer.mozilla.org/en-US/docs/Web/API/WebGLTexture

## Constructors

| Signature | Description |
|---|---|
| `WebGLTexture(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLTexture>(...)` or constructor `new WebGLTexture(...)`

### Creating a texture

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");
const texture = gl.createTexture();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLTexture)*

