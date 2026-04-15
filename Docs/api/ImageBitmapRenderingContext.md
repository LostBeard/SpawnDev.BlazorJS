# ImageBitmapRenderingContext

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ImageBitmapRenderingContext.cs`  
**MDN Reference:** [ImageBitmapRenderingContext on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ImageBitmapRenderingContext)

> The ImageBitmapRenderingContext interface is a canvas rendering context that provides variables and methods for replacing the canvas's contents with a given ImageBitmap. Its context id (the first argument to HTMLCanvasElement.getContext() or OffscreenCanvas.getContext()) is "bitmaprenderer". https://developer.mozilla.org/en-US/docs/Web/API/ImageBitmapRenderingContext

## Constructors

| Signature | Description |
|---|---|
| `ImageBitmapRenderingContext(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Canvas` | `HTMLCanvasElement` | get | Returns the CanvasElement that the context is bound to. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `TransferFromImageBitmap(ImageBitmap bitmap)` | `void` | Transfers the underlying bitmap data from an ImageBitmap to the canvas, so that the canvas displays the image. The ImageBitmap is consumed and can no longer be used. An ImageBitmap object to transfer. |

