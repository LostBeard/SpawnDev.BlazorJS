# WEBGL_lose_context

**Namespace:** `SpawnDev.BlazorJS.WebGL.Extensions`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebGL/Extensions/WEBGL_lose_context.cs`  
**MDN Reference:** [WEBGL_lose_context on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WEBGL_lose_context)

> The WEBGL_lose_context extension is part of the WebGL API and exposes functions to simulate losing and restoring the WebGL context. https://developer.mozilla.org/en-US/docs/Web/API/WEBGL_lose_context

## Methods

| Method | Return Type | Description |
|---|---|---|
| `LoseContext()` | `void` | Simulates the losing of the context. |
| `RestoreContext()` | `void` | Simulates the restoring of the context. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WEBGL_lose_context>(...)` or constructor `new WEBGL_lose_context(...)`

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");

canvas.addEventListener("webglcontextlost", (event) => {
  console.log(event);
});

gl.getExtension("WEBGL_lose_context").loseContext();

// WebGLContextEvent event with type "webglcontextlost" is logged.
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WEBGL_lose_context)*

