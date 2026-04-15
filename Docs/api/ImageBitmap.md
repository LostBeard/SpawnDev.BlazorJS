# ImageBitmap

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `ImageBitmap`  
**MDN Reference:** [ImageBitmap](https://developer.mozilla.org/en-US/docs/Web/API/ImageBitmap)  
**Transferable:** Yes (`[Transferable]`)

> The `ImageBitmap` class represents a bitmap image that can be drawn to a canvas without undue latency. It provides an asynchronous and resource-efficient pathway to prepare textures for rendering in WebGL. `ImageBitmap` is a transferable object, meaning it can be sent between workers via `postMessage` with zero-copy transfer semantics. Create instances using the global `createImageBitmap()` factory method or `OffscreenCanvas.TransferToImageBitmap()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `ImageBitmap(IJSInProcessObjectReference _ref)` | Deserialization constructor - wraps an existing JS object reference. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Width` | `uint` | The width of the bitmap in CSS pixels. |
| `Height` | `uint` | The height of the bitmap in CSS pixels. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Close()` | `void` | Disposes of all graphical resources associated with this `ImageBitmap`. After calling `Close()`, the bitmap dimensions become 0 and the image data is no longer accessible. |

## Global Factory Method

`ImageBitmap` instances are typically created using the global `createImageBitmap()` method:

```csharp
// Create from various image sources via BlazorJSRuntime
using var bitmap = await JS.CallAsync<ImageBitmap>("createImageBitmap", imageSource);
```

Supported sources include `Blob`, `ImageData`, `HTMLImageElement`, `HTMLCanvasElement`, `OffscreenCanvas`, `HTMLVideoElement`, and `SVGImageElement`.

## Example

```csharp
@inject BlazorJSRuntime JS

// Create an ImageBitmap from a Blob
using var blob = new Blob(new byte[][] { imageBytes }, new BlobOptions { Type = "image/png" });
using var bitmap = await JS.CallAsync<ImageBitmap>("createImageBitmap", blob);

Console.WriteLine($"Bitmap size: {bitmap.Width}x{bitmap.Height}");

// Draw to a canvas context
using var ctx = canvas.GetContext2D();
ctx.DrawImage(bitmap, 0, 0);

// Create from OffscreenCanvas (zero-copy transfer)
using var offscreen = new OffscreenCanvas(256, 256);
using var offCtx = offscreen.Get2DContext();
offCtx.FillStyle = "red";
offCtx.FillRect(0, 0, 256, 256);
using var transferredBitmap = offscreen.TransferToImageBitmap();

// Transfer to a worker (zero-copy, bitmap is Transferable)
worker.PostMessage(bitmap);

// Release resources when done
bitmap.Close();
```
