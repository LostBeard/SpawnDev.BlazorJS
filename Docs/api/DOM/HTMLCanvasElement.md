# HTMLCanvasElement

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `HTMLElement`  
**Source:** `JSObjects/DOM/HTMLCanvasElement.cs`  
**MDN Reference:** [HTMLCanvasElement on MDN](https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement)

> The HTMLCanvasElement interface provides properties and methods for manipulating the layout and presentation of &lt;canvas&gt; elements. The HTMLCanvasElement interface also inherits the properties and methods of the HTMLElement interface. https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement

## Constructors

| Signature | Description |
|---|---|
| `HTMLCanvasElement(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `HTMLCanvasElement()` | Creates a new HTMLCanvasElement using Document.CreateElement |
| `HTMLCanvasElement(ElementReference elementReference)` | Creates a new HTMLCanvasElement from an ElementReference |
| `HTMLCanvasElement(int width, int height)` | Creates a new HTMLCanvasElement using Document.CreateElement and sets the initial width and height |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Width` | `int` | get | The width HTML attribute of the &lt;canvas&gt; element is a non-negative integer reflecting the number of logical pixels (or RGBA values) going across one row of the canvas. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 300 is used. If no [separate] CSS width is assigned to the &lt;canvas&gt;, then this value will also be used as the width of the canvas in the length-unit CSS Pixel. |
| `Height` | `int` | get | The height HTML attribute of the &lt;canvas&gt; element is a non-negative integer reflecting the number of logical pixels (or RGBA values) going down one column of the canvas. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 150 is used. If no [separate] CSS height is assigned to the &lt;canvas&gt;, then this value will also be used as the height of the canvas in the length-unit CSS Pixel. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetContext(string contextType, object? contextAttributes)` | `TContext?` | Returns a drawing context on the canvas, or null if the context identifier is not supported, or the canvas has already been set to a different context mode. The context type to return A string containing the context identifier defining the drawing context associated to the canvas. |
| `GetImageBitmapRenderingContext(ImageBitmapRenderingContextSettings? contextAttributes)` | `ImageBitmapRenderingContext` | Calls canvas.getContext("bitmaprenderer"), leading to the creation of a ImageBitmapRenderingContextSettings object. optional context settings |
| `Get2DContext(CanvasRenderingContext2DSettings? contextAttributes)` | `CanvasRenderingContext2D` | Calls canvas.getContext("2d"), leading to the creation of a CanvasRenderingContext2D object representing a two-dimensional rendering context. |
| `GetWebGLContext(WebGLContextAttributes? contextAttributes)` | `WebGLRenderingContext` | Calls canvas.getContext("webgl") which will create a WebGLRenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 1 (OpenGL ES 2.0). |
| `GetWebGL2Context(WebGLContextAttributes? contextAttributes)` | `WebGL2RenderingContext` | Calls canvas.getContext("webgl2") which will create a WebGL2RenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 2 (OpenGL ES 3.0). |
| `GetWebGPUContext()` | `GPUCanvasContext` | Calls canvas.getContext("webgpu") which will create a GPUCanvasContext object representing a three-dimensional rendering context for WebGPU render pipelines. This context is only available on browsers that implement The WebGPU API. |
| `GetImageBitmapRenderingContext()` | `ImageBitmapRenderingContext` | Calls canvas.getContext("bitmaprenderer") which will create an ImageBitmapRenderingContext which only provides functionality to replace the content of the canvas with a given ImageBitmap. |
| `ToDataURL(string type)` | `string` | Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi. |
| `ToDataURL(string type, float encoderOptions)` | `string` | Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi. |
| `ToBlob(ActionCallback<Blob?> callback)` | `void` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata. A callback function with the resulting Blob object as a single argument. null may be passed if the image cannot be created for any reason. |
| `ToBlob(ActionCallback<Blob?> callback, string type)` | `void` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata. A callback function with the resulting Blob object as a single argument. null may be passed if the image cannot be created for any reason. A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported. |
| `ToBlob(ActionCallback<Blob?> callback, string type, float quality)` | `void` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp. The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata. A callback function with the resulting Blob object as a single argument. null may be passed if the image cannot be created for any reason. A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported. A Number between 0 and 1 indicating the image quality to be used when creating images using file formats that support lossy compression (such as image/jpeg or image/webp). A user agent will use its default quality value if this option is not specified, or if the number is outside the allowed range. |
| `ToBlobAsync()` | `Task<Blob>` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. The resulting blob |
| `ToBlobAsync(string type)` | `Task<Blob>` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported. The resulting blob |
| `ToBlobAsync(string type, float quality)` | `Task<Blob>` | The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent. A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported. A Number between 0 and 1 indicating the image quality to be used when creating images using file formats that support lossy compression (such as image/jpeg or image/webp). A user agent will use its default quality value if this option is not specified, or if the number is outside the allowed range. The resulting blob |
| `TransferControlToOffscreen()` | `OffscreenCanvas` | The HTMLCanvasElement.transferControlToOffscreen() method transfers control to an OffscreenCanvas object, either on the main thread or on a worker. |
| `DownloadAsImage(string fileName, bool appendToBody)` | `void` | Initiates a download of the canvas content as an image file. The name of the file to download. If true, appends the link element to the body before clicking it. Useful for some browsers compatibility. |
| `Color4ToHexString(byte r, byte g, byte b, byte a)` | `string` | Converts RGBA values to a hex string. Red component (0-255) Green component (0-255) Blue component (0-255) Alpha component (0-255) Hex string representation (e.g. #RRGGBBAA) |

## Events

| Event | Type | Description |
|---|---|---|
| `OnContextLost` | `ActionEvent<Event>` | Fired if the user agent detects that the backing storage associated with a CanvasRenderingContext2D context is lost. |
| `OnContextRestored` | `ActionEvent<Event>` | Fired if the user agent restores the backing storage for a CanvasRenderingContext2D. |
| `OnWebGLContextRestored` | `ActionEvent<WebGLContextEvent>` | Fired if the user agent restores the rendering context |
| `OnWebGLContextLost` | `ActionEvent<WebGLContextEvent>` | Fired if the user agent detects that the backing rendering context is lost. |

## Example

```csharp
// Create a canvas from a Blazor ElementReference (e.g. @ref="canvasRef")
using var canvas = new HTMLCanvasElement(canvasRef);
canvas.Width = 640;
canvas.Height = 480;

// Get a 2D rendering context
using var ctx = canvas.Get2DContext();
ctx.FillStyle = "#2c3e50";
ctx.FillRect(0, 0, 640, 480);
ctx.FillStyle = "white";
ctx.Font = "32px sans-serif";
ctx.FillText("Hello from BlazorJS!", 100, 250);

// Create a canvas programmatically (no DOM reference needed)
using var offCanvas = new HTMLCanvasElement(256, 256);
using var offCtx = offCanvas.Get2DContext();
offCtx.FillStyle = "red";
offCtx.FillRect(0, 0, 256, 256);

// Export canvas content as a data URL
string dataUrl = canvas.ToDataURL("image/png");

// Export canvas content as a Blob asynchronously
using var blob = await canvas.ToBlobAsync("image/jpeg", 0.9f);

// Get a WebGL context
using var glCanvas = new HTMLCanvasElement(800, 600);
using var gl = glCanvas.GetWebGLContext();

// Get a WebGPU context
using var gpuCanvas = new HTMLCanvasElement(800, 600);
using var gpuCtx = gpuCanvas.GetWebGPUContext();

// Transfer control to an OffscreenCanvas (for worker rendering)
using var workerCanvas = new HTMLCanvasElement(canvasRef);
using var offscreen = workerCanvas.TransferControlToOffscreen();

// Listen for context loss events
canvas.OnWebGLContextLost += (e) =>
{
    Console.WriteLine("WebGL context lost");
};

// Download canvas as an image file
canvas.DownloadAsImage("screenshot.png");
```

