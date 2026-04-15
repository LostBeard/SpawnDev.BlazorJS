# WebGLUniformLocation

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebGL/WebGLUniformLocation.cs`  
**MDN Reference:** [WebGLUniformLocation on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLUniformLocation)

> The WebGLUniformLocation interface is part of the WebGL API and represents the location of a uniform variable in a shader program. https://developer.mozilla.org/en-US/docs/Web/API/WebGLUniformLocation

## Constructors

| Signature | Description |
|---|---|
| `WebGLUniformLocation(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLUniformLocation>(...)` or constructor `new WebGLUniformLocation(...)`

### Getting an uniform location

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");

const location = gl.getUniformLocation(WebGLProgram, "uniformName");
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLUniformLocation)*

