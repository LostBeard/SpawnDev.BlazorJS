# VideoFrame

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inheritance:** `JSObject` -> `VideoFrame`  
**Attribute:** `[Transferable]`  
**MDN Reference:** [VideoFrame - MDN](https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame)

> The `VideoFrame` interface of the WebCodecs API represents a single frame of video. It can be created from various image sources and is transferable between workers without copying.

## Constructors

| Signature | Description |
|---|---|
| `VideoFrame(IJSInProcessObjectReference _ref)` | Deserialization constructor. |
| `VideoFrame(Union<SVGImageElement, HTMLVideoElement, HTMLCanvasElement, ImageBitmap, OffscreenCanvas, VideoFrame, HTMLImageElement> image)` | The VideoFrame() constructor creates a new VideoFrame object representing a frame of a video. |
| `VideoFrame(Union<SVGImageElement, HTMLVideoElement, HTMLCanvasElement, ImageBitmap, OffscreenCanvas, VideoFrame, HTMLImageElement> image, VideoFrameOptions options)` | The VideoFrame() constructor creates a new VideoFrame object representing a frame of a video. |
| `VideoFrame(Union<ArrayBuffer, TypedArray, byte[], DataView> data, VideoFrameDataOptions options)` | The VideoFrame() constructor creates a new VideoFrame object representing a frame of a video. |

## Properties

| Property | Type | Description |
|---|---|---|
| `Format` | `string?` | The pixel format (e.g., `"I420"`, `"NV12"`, `"RGBA"`, `"BGRA"`). |
| `CodedWidth` | `int` | Width of the frame including any non-visible padding. |
| `CodedHeight` | `int` | Height of the frame including any non-visible padding. |
| `DisplayWidth` | `int` | Width intended for display (after aspect ratio adjustment). |
| `DisplayHeight` | `int` | Height intended for display. |
| `Duration` | `long?` | Duration of the frame in microseconds. |
| `Timestamp` | `long` | Timestamp in microseconds. |
| `ColorSpace` | `JSObject` | The color space of the frame. |
| `CodedRect` | `DOMRectReadOnly` | Returns a DOMRectReadOnly with the width and height matching codedWidth and codedHeight. |
| `VisibleRect` | `DOMRectReadOnly` | Returns a DOMRectReadOnly describing the visible rectangle of pixels for this VideoFrame. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `CopyTo(ArrayBuffer destination)` | `Task` | Copies frame data to a buffer. |
| `Clone()` | `VideoFrame` | Creates a copy of the frame. |
| `Close()` | `void` | Releases the frame's resources. Must be called when done. |
| `AllocationSize()` | `int` | Returns the number of bytes required to hold the VideoFrame as filtered by options passed into the method. |
| `AllocationSize(AllocationSizeOptions options)` | `int` | Returns the number of bytes required to hold the VideoFrame as filtered by options passed into the method. |
| `CopyTo(Union<ArrayBuffer, TypedArray, byte[], DataView> destination)` | `Task` | Copies the contents of the VideoFrame to an ArrayBuffer. |
| `CopyTo(Union<ArrayBuffer, TypedArray, byte[], DataView> destination, VideoFrameCopyOptions options)` | `Task` | Copies the contents of the VideoFrame to an ArrayBuffer. |

## Example

```csharp
// Create a VideoFrame from an HTMLCanvasElement
using var canvas = JS.Get<HTMLCanvasElement>("document.getElementById('myCanvas')");
using var frame = new VideoFrame(canvas);

// Access frame dimensions and metadata
Console.WriteLine($"Display size: {frame.DisplayWidth}x{frame.DisplayHeight}");
Console.WriteLine($"Coded size: {frame.CodedWidth}x{frame.CodedHeight}");
Console.WriteLine($"Timestamp: {frame.Timestamp} microseconds");
Console.WriteLine($"Duration: {frame.Duration} microseconds");
Console.WriteLine($"Format: {frame.Format}");

// Get the allocation size needed to copy the frame data
int allocSize = frame.AllocationSize();
Console.WriteLine($"Allocation size: {allocSize} bytes");

// Copy frame pixel data to an ArrayBuffer
using var buffer = new ArrayBuffer(allocSize);
await frame.CopyTo(buffer);

// Clone the frame (creates a new reference to the same data)
using var clonedFrame = frame.Clone();
Console.WriteLine($"Cloned frame: {clonedFrame.DisplayWidth}x{clonedFrame.DisplayHeight}");

// Create a VideoFrame with explicit options (e.g., for setting timestamp)
using var frame2 = new VideoFrame(canvas, new VideoFrameOptions
{
    Timestamp = 33333, // 33.3ms into video
});

// Always close frames when done to release resources
frame.Close();
clonedFrame.Close();
frame2.Close();
```
