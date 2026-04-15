# WebGLQuery

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `WebGLObject`  
**Source:** `JSObjects/WebGL/WebGLQuery.cs`  
**MDN Reference:** [WebGLQuery on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLQuery)

> The WebGLQuery interface is part of the WebGL 2 API and provides ways to asynchronously query for information. By default, occlusion queries and primitive queries are available. https://developer.mozilla.org/en-US/docs/Web/API/WebGLQuery

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<WebGLQuery>(...)` or constructor `new WebGLQuery(...)`

### Creating a `WebGLQuery` object

```js
const query = gl.createQuery();
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WebGLQuery)*

