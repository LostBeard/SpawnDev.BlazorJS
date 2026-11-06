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
| `GetContext<TContext>(string contextType, object? contextAttributes = null)` | `TContext?` | Returns a drawing context on the canvas, or null if the context identifier is not supported, or the canvas has already been set to a different context mode. |
| `GetImageBitmapRenderingContext(ImageBitmapRenderingContextSettings? contextAttributes = null)` | `ImageBitmapRenderingContext` | Calls canvas.getContext("bitmaprenderer"), leading to the creation of a ImageBitmapRenderingContextSettings object. |
| `Get2DContext(CanvasRenderingContext2DSettings? contextAttributes = null)` | `CanvasRenderingContext2D` | Calls canvas.getContext("2d"), leading to the creation of a CanvasRenderingContext2D object representing a two-dimensional rendering context. |
| `GetWebGLContext(WebGLContextAttributes? contextAttributes = null)` | `WebGLRenderingContext` | Calls canvas.getContext("webgl") which will create a WebGLRenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 1 (OpenGL ES 2.0). |
| `GetWebGL2Context(WebGLContextAttributes? contextAttributes = null)` | `WebGL2RenderingContext` | Calls canvas.getContext("webgl2") which will create a WebGL2RenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 2 (OpenGL ES 3.0). |
| `GetWebGPUContext()` | `GPUCanvasContext` | Calls canvas.getContext("webgpu") which will create a GPUCanvasContext object representing a three-dimensional rendering context for WebGPU render pipelines. This context is only available on browsers that implement The WebGPU API. |
| `GetImageBitmapRenderingContext()` | `ImageBitmapRenderingContext` | Calls canvas.getContext("bitmaprenderer") which will create an ImageBitmapRenderingContext which only provides functionality to replace the content of the canvas with a given ImageBitmap. |
| `ToDataURL(string type = "image/png")` | `string` | Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi. |
| `ToDataURL(string type, float encoderOptions)` | `string` | Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi. |
| `ToBlob(ActionCallback<Blob?> callback)` | `void` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata. |
| `ToBlob(ActionCallback<Blob?> callback, string type)` | `void` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata. |
| `ToBlob(ActionCallback<Blob?> callback, string type, float quality)` | `void` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata. |
| `ToBlobAsync()` | `Task<Blob>` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. |
| `ToBlobAsync(string type)` | `Task<Blob>` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. |
| `ToBlobAsync(string type, float quality)` | `Task<Blob>` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. |
| `CaptureStream(double? frameRate = null)` | `MediaStream` | The captureStream() method returns a MediaStream which includes a CanvasCaptureMediaStreamTrack containing a real-time video capture of the canvas's contents. |
| `DownloadAsImage(string fileName, bool appendToBody = false)` | `void` | Initiates a download of the canvas content as an image file. |

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

## Constructors

| Signature | Description |
|---|---|
| `HTMLCanvasElement()` | Creates a new HTMLCanvasElement using Document.CreateElement |
| `HTMLCanvasElement(ElementReference elementReference)` | Creates a new HTMLCanvasElement from an ElementReference |
| `HTMLCanvasElement(int width, int height)` | Creates a new HTMLCanvasElement using Document.CreateElement and sets the initial width and height |

## Static Methods

| Method | Return Type | Description |
|---|---|---|
| `Color4ToHexString(byte r, byte g, byte b, byte a)` | `string` | Converts RGBA values to a hex string. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnContextLost` | `ActionEvent<Event>` | Fired if the user agent detects that the backing storage associated with a CanvasRenderingContext2D context is lost. |
| `OnContextRestored` | `ActionEvent<Event>` | Fired if the user agent restores the backing storage for a CanvasRenderingContext2D. |
| `OnWebGLContextRestored` | `ActionEvent<WebGLContextEvent>` | Fired if the user agent restores the rendering context |
| `OnWebGLContextLost` | `ActionEvent<WebGLContextEvent>` | Fired if the user agent detects that the backing rendering context is lost. |

