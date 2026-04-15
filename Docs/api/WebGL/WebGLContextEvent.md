# WebGLContextEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/WebGL/WebGLContextEvent.cs`  
**MDN Reference:** [WebGLContextEvent on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLContextEvent)

> The WebGLContextEvent interface is part of the WebGL API and is an interface for an event that is generated in response to a status change to the WebGL rendering context. https://developer.mozilla.org/en-US/docs/Web/API/WebGLContextEvent

## Constructors

| Signature | Description |
|---|---|
| `WebGLContextEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `StatusMessage` | `string` | get | A read-only property containing additional information about the event. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLContextEvent>(...)` or constructor `new WebGLContextEvent(...)`

```js
const canvas = document.getElementById("canvas");
const gl = canvas.getContext("webgl");

canvas.addEventListener("webglcontextlost", (e) => {
  console.log(e);
});

gl.getExtension("WEBGL_lose_context").loseContext();

// WebGLContextEvent event with type "webglcontextlost" is logged.
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLContextEvent)*

