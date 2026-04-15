# OffscreenCanvas

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `EventTarget` -> `OffscreenCanvas`  
**MDN Reference:** [OffscreenCanvas](https://developer.mozilla.org/en-US/docs/Web/API/OffscreenCanvas)  
**Transferable:** Yes (`[Transferable(TransferRequired = true)]`)

> The `OffscreenCanvas` class provides a canvas that can be rendered off-screen, decoupling the DOM and the Canvas API so that the `<canvas>` element is no longer entirely dependent on the DOM. Rendering operations can run inside a Web Worker context, enabling offloading of heavy rendering work from the main thread. Supports 2D, WebGL, WebGL2, WebGPU, and ImageBitmapRendering contexts. Marked as `[Transferable]` with `TransferRequired = true`, meaning it must be transferred (not cloned) when sent between contexts via `postMessage`.

## Static Properties

| Property | Type | Description |
|----------|------|-------------|
| `Supported` | `bool` | Returns `true` if `OffscreenCanvas` is available in the current browser context. |

## Constructors

| Signature | Description |
|-----------|-------------|
| `OffscreenCanvas(int width, int height)` | Creates a new `OffscreenCanvas` with the specified dimensions. |
| `OffscreenCanvas(IJSInProcessObjectReference _ref)` | Deserialization constructor - wraps an existing JS object reference. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Width` | `int` | The width of the offscreen canvas in pixels (read/write). |
| `Height` | `int` | The height of the offscreen canvas in pixels (read/write). |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Get2DContext(CanvasRenderingContext2DSettings? contextAttributes = null)` | `CanvasRenderingContext2D` | Gets a 2D rendering context. |
| `GetWebGLContext(WebGLContextAttributes? contextAttributes = null)` | `WebGLRenderingContext` | Gets a WebGL 1.0 context (OpenGL ES 2.0). |
| `GetWebGL2Context(WebGLContextAttributes? contextAttributes = null)` | `WebGL2RenderingContext` | Gets a WebGL 2.0 context (OpenGL ES 3.0). |
| `GetWebGPUContext()` | `GPUCanvasContext` | Gets a WebGPU context for render pipelines. |
| `GetImageBitmapRenderingContext()` | `ImageBitmapRenderingContext` | Gets an `ImageBitmapRendering` context for displaying `ImageBitmap`s. |
| `ConvertToBlob()` | `Task<Blob>` | Creates a `Blob` representing the image on the canvas. |
| `ConvertToBlob(ConvertToBlobOptions options)` | `Task<Blob>` | Creates a `Blob` with specified type and quality options. |
| `TransferToImageBitmap()` | `ImageBitmap` | Creates an `ImageBitmap` from the most recently rendered image. This is a zero-copy operation - the canvas is cleared after transfer. |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `OnContextLost` | `ActionEvent<Event>` | Fired when the 2D context backing storage is lost. |
| `OnContextRestored` | `ActionEvent<Event>` | Fired when the 2D context backing storage is restored. |
| `OnWebGLContextLost` | `ActionEvent<WebGLContextEvent>` | Fired when the WebGL context is lost. |
| `OnWebGLContextRestored` | `ActionEvent<WebGLContextEvent>` | Fired when the WebGL context is restored. |

## Example

```csharp
// Create an offscreen canvas for rendering
using var offscreen = new OffscreenCanvas(800, 600);

// Get a 2D context and draw
using var ctx = offscreen.Get2DContext();
ctx.FillStyle = "#3498db";
ctx.FillRect(0, 0, 800, 600);
ctx.Font = "48px Arial";
ctx.FillStyle = "white";
ctx.FillText("Rendered Offscreen", 100, 300);

// Convert to a Blob for download or storage
using var blob = await offscreen.ConvertToBlob(new ConvertToBlobOptions
{
    Type = "image/png",
    Quality = 1.0
});

// Transfer to ImageBitmap for display on a visible canvas
using var bitmap = offscreen.TransferToImageBitmap();

// Transfer to a worker for GPU rendering (real AubsCraft pattern)
// OffscreenCanvas is Transferable - it MUST be transferred, not cloned
using var worker = new Worker("worker.js");
worker.PostMessage(offscreen);  // Transfers ownership to the worker

// In the worker: receive and use for WebGPU rendering
// using var ctx = offscreenCanvas.GetWebGPUContext();

// Check support before using
if (OffscreenCanvas.Supported)
{
    using var canvas = new OffscreenCanvas(1024, 768);
    // ... use canvas
}
```
