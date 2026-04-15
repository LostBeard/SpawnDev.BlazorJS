# WebGLSync

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLSync.cs`  
**MDN Reference:** [WebGLSync on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLSync)

> The WebGLSync interface is part of the WebGL 2 API and is used to synchronize activities between the GPU and the application. https://developer.mozilla.org/en-US/docs/Web/API/WebGLSync

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLSync>(...)` or constructor `new WebGLSync(...)`

### Creating a `WebGLSync` object

```js
const sync = gl.fenceSync(gl.SYNC_GPU_COMMANDS_COMPLETE, 0);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLSync)*

