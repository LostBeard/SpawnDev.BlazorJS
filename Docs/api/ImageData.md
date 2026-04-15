# ImageData

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/ImageData.cs`  
**MDN Reference:** [ImageData on MDN](https://developer.mozilla.org/en-US/docs/Web/API/ImageData)

> The ImageData interface represents the underlying pixel data of an area of a canvas element. It is created using the ImageData() constructor or creator methods on the CanvasRenderingContext2D object associated with a canvas: createImageData() and getImageData(). It can also be used to set a part of the canvas by using putImageData(). https://developer.mozilla.org/en-US/docs/Web/API/ImageData

## Constructors

| Signature | Description |
|---|---|
| `ImageData(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `ImageData(double width, double height)` | The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height. This constructor is the preferred way of creating such an object in a Worker. An unsigned long representing the width of the image. An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width. |
| `ImageData(double width, double height, ImageDataSettings settings)` | The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height. This constructor is the preferred way of creating such an object in a Worker. An unsigned long representing the width of the image. An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width. ImageDataSettings object |
| `ImageData(Uint8ClampedArray dataArray, double width)` | The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height. This constructor is the preferred way of creating such an object in a Worker. A Uint8ClampedArray containing the underlying pixel representation of the image. If no such array is given, an image with a transparent black rectangle of the specified width and height will be created. An unsigned long representing the width of the image. |
| `ImageData(Uint8ClampedArray dataArray, double width, double height)` | The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height. This constructor is the preferred way of creating such an object in a Worker. A Uint8ClampedArray containing the underlying pixel representation of the image. If no such array is given, an image with a transparent black rectangle of the specified width and height will be created. An unsigned long representing the width of the image. An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width. |
| `ImageData(Uint8ClampedArray dataArray, double width, double height, ImageDataSettings settings)` | The ImageData() constructor returns a newly instantiated ImageData object built from the typed array given and having the specified width and height. This constructor is the preferred way of creating such an object in a Worker. A Uint8ClampedArray containing the underlying pixel representation of the image. If no such array is given, an image with a transparent black rectangle of the specified width and height will be created. An unsigned long representing the width of the image. An unsigned long representing the height of the image. This value is optional if an array is given: the height will be inferred from the array's size and the given width. ImageDataSettings object |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Data` | `Uint8ClampedArray` | get | A Uint8ClampedArray representing a one-dimensional array containing the data in the RGBA order, with integer values between 0 and 255 (inclusive). The order goes by rows from the top-left pixel to the bottom-right. |
| `ColorSpace` | `string` | get | A string indicating the color space of the image data. |
| `PixelFormat` | `string` | get | A string indicating the format to use for the ImageData. |
| `Height` | `int` | get | An unsigned long representing the actual height, in pixels, of the ImageData. |
| `Width` | `int` | get | An unsigned long representing the actual width, in pixels, of the ImageData. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `FromUint8Array(Uint8Array rgbaUint8Array, double width, double height)` | `ImageData` | Creates an ImageData from a Uint8Array's view on its underlying ArrayBuffer. This is a zero-copy operation. The ImageData.Data property, a Uint8ClampedArray, will point to the same section of the same ArrayBuffer as the source. |
| `FromBytes(byte[] rgbaBytes, double width, double height)` | `ImageData` | Creates an ImageData from a byte[] |

## Example

```csharp
// Create an empty ImageData with given dimensions
using var imageData = new ImageData(256, 256);
int width = imageData.Width;   // 256
int height = imageData.Height; // 256

// Access the pixel data (Uint8ClampedArray, RGBA order)
using var pixelData = imageData.Data;

// Create ImageData from a .NET byte array
byte[] rgbaBytes = new byte[100 * 100 * 4]; // 100x100 pixels, RGBA
// Fill with red pixels
for (int i = 0; i < rgbaBytes.Length; i += 4)
{
    rgbaBytes[i] = 255;     // R
    rgbaBytes[i + 1] = 0;   // G
    rgbaBytes[i + 2] = 0;   // B
    rgbaBytes[i + 3] = 255; // A
}
using var redImage = ImageData.FromBytes(rgbaBytes, 100, 100);

// Create ImageData from a Uint8Array (zero-copy)
using var uint8Arr = new Uint8Array(rgbaBytes);
using var zeroCopyImage = ImageData.FromUint8Array(uint8Arr, 100, 100);

// Use with CanvasRenderingContext2D
using var canvas = new HTMLCanvasElement(100, 100);
using var ctx = canvas.Get2DContext();
ctx.PutImageData(redImage, 0, 0);

// Read pixel data back from a canvas
using var readBack = ctx.GetImageData(0, 0, 100, 100);
string colorSpace = readBack.ColorSpace;
```

