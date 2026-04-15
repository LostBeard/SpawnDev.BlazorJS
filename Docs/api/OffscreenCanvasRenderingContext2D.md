# OffscreenCanvasRenderingContext2D

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `CanvasRenderingContext2D`  
**Source:** `JSObjects/OffscreenCanvasRenderingContext2D.cs`  
**MDN Reference:** [OffscreenCanvasRenderingContext2D on MDN](https://developer.mozilla.org/en-US/docs/Web/API/OffscreenCanvasRenderingContext2D)

> The OffscreenCanvasRenderingContext2D interface is a CanvasRenderingContext2D rendering context for drawing to the bitmap of an OffscreenCanvas object. It is similar to the CanvasRenderingContext2D object, with the following differences: https://developer.mozilla.org/en-US/docs/Web/API/OffscreenCanvasRenderingContext2D

## Constructors

| Signature | Description |
|---|---|
| `OffscreenCanvasRenderingContext2D(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Commit()` | `void` | Pushes the rendered image to the context's OffscreenCanvas object's placeholder canvas element. ⚠ Deprecated - Not for use in new websites |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<OffscreenCanvasRenderingContext2D>(...)` or constructor `new OffscreenCanvasRenderingContext2D(...)`

```js
const canvas = document.getElementById("canvas");
const offscreen = canvas.transferControlToOffscreen();
const worker = new Worker("worker.js");
worker.postMessage({ canvas: offscreen }, [offscreen]);
```

```js
onmessage = (event) => {
  const canvas = event.data.canvas;
  const offCtx = canvas.getContext("2d");
  // draw to the offscreen canvas context
  offCtx.fillStyle = "red";
  offCtx.fillRect(0, 0, 100, 100);
};
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/OffscreenCanvasRenderingContext2D)*

