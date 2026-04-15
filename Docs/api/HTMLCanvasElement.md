# HTMLCanvasElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** JSObject -> EventTarget -> Node -> Element -> HTMLElement -> HTMLCanvasElement  
**MDN Reference:** [HTMLCanvasElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement)  
**Source:** `SpawnDev.BlazorJS/JSObjects/DOM/HTMLCanvasElement.cs`

> The HTMLCanvasElement interface provides properties and methods for manipulating the layout and presentation of canvas elements. It is used to obtain 2D, WebGL, WebGL2, and WebGPU rendering contexts. In SpawnDev.BlazorJS projects, HTMLCanvasElement is the gateway to GPU-accelerated rendering via WebGPU and WebGL contexts.

## Constructor

```csharp
// From existing reference
public HTMLCanvasElement(IJSInProcessObjectReference _ref)

// Create a new canvas element
public HTMLCanvasElement() // creates via document.createElement("canvas")
```

## Properties

| Property | Type | Description |
|---|---|---|
| `Width` | `int` | Get/set the width of the canvas in pixels. |
| `Height` | `int` | Get/set the height of the canvas in pixels. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetContext(string contextId)` | `JSObject?` | Get a rendering context. contextId: "2d", "webgl", "webgl2", "webgpu". |
| `GetContext<T>(string contextId)` | `T?` | Get a typed rendering context. |
| `GetContext2D()` | `CanvasRenderingContext2D?` | Shortcut for GetContext<CanvasRenderingContext2D>("2d"). |
| `GetContextWebGL()` | `WebGLRenderingContext?` | Shortcut for GetContext<WebGLRenderingContext>("webgl"). |
| `GetContextWebGL2()` | `WebGL2RenderingContext?` | Shortcut for GetContext<WebGL2RenderingContext>("webgl2"). |
| `ToBlob(Callback callback, string type, double quality)` | `void` | Create a Blob from the canvas content. |
| `ToBlobAsync(string type, double quality)` | `Task<Blob>` | Async version of ToBlob. |
| `ToDataURL(string type, double quality)` | `string` | Get a data URI of the canvas content. |
| `ToDataURL()` | `string` | Get a data URI (default PNG). |
| `TransferControlToOffscreen()` | `OffscreenCanvas` | Transfer control to an OffscreenCanvas for worker rendering. |

## Example - 2D Context

```csharp
using var canvas = doc.CreateElement<HTMLCanvasElement>("canvas");
canvas.Width = 800;
canvas.Height = 600;
doc.Body.AppendChild(canvas);

using var ctx = canvas.GetContext2D();
ctx!.FillStyle = "red";
ctx.FillRect(10, 10, 100, 100);
ctx.StrokeStyle = "blue";
ctx.StrokeRect(50, 50, 200, 150);
```

## Example - WebGPU Context (AubsCraft Pattern)

```csharp
// Getting a WebGPU context for GPU rendering
using var canvas = doc.QuerySelector<HTMLCanvasElement>("#renderCanvas");
using var gpuContext = canvas!.GetContext<GPUCanvasContext>("webgpu");

// Configure the context
gpuContext!.Configure(new GPUCanvasConfiguration
{
    Device = gpuDevice,
    Format = navigator.GPU.GetPreferredCanvasFormat()
});

// Render loop
using var texture = gpuContext.GetCurrentTexture();
// ... submit GPU commands ...
```

## Example - Offscreen Canvas for Workers

```csharp
using var canvas = doc.QuerySelector<HTMLCanvasElement>("#workerCanvas");
using var offscreen = canvas!.TransferControlToOffscreen();
// Transfer offscreen to a worker for rendering
worker.PostMessage(offscreen, new[] { offscreen });
```

## Example - Export as Image

```csharp
using var canvas = doc.QuerySelector<HTMLCanvasElement>("#myCanvas");

// As data URL
string dataUrl = canvas!.ToDataURL("image/png", 1.0);

// As Blob
using var blob = await canvas.ToBlobAsync("image/jpeg", 0.95);
```
