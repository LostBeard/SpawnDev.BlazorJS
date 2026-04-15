# WebGLShader

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLShader.cs`  
**MDN Reference:** [WebGLShader on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLShader)

> The WebGLShader is part of the WebGL API and can either be a vertex or a fragment shader. A WebGLProgram requires both types of shaders. https://developer.mozilla.org/en-US/docs/Web/API/WebGLShader

## Constructors

| Signature | Description |
|---|---|
| `WebGLShader(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLShader>(...)` or constructor `new WebGLShader(...)`

### Creating a vertex shader

```js
const vertexShaderSource =
  "attribute vec4 position;\n" +
  "void main() {\n" +
  "  gl_Position = position;\n" +
  "}\n";

// Use the createShader function from the example above
const vertexShader = createShader(gl, vertexShaderSource, gl.VERTEX_SHADER);
```

### Creating a fragment shader

```js
const fragmentShaderSource = `void main() {
  gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0);
}
`;

// Use the createShader function from the example above
const fragmentShader = createShader(
  gl,
  fragmentShaderSource,
  gl.FRAGMENT_SHADER,
);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLShader)*

