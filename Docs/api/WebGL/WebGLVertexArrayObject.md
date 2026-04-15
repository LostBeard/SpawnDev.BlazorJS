# WebGLVertexArrayObject

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLVertexArrayObject.cs`  
**MDN Reference:** [WebGLVertexArrayObject on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLVertexArrayObject)

> TThe WebGLVertexArrayObject interface is part of the WebGL 2 API, represents vertex array objects (VAOs) pointing to vertex array data, and provides names for different sets of vertex data. https://developer.mozilla.org/en-US/docs/Web/API/WebGLVertexArrayObject

## Constructors

| Signature | Description |
|---|---|
| `WebGLVertexArrayObject(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLVertexArrayObject>(...)` or constructor `new WebGLVertexArrayObject(...)`

```js
const vao = gl.createVertexArray();
gl.bindVertexArray(vao);

// …

// calls to bindBuffer or vertexAttribPointer
// which will be "recorded" in the VAO

// …
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLVertexArrayObject)*

