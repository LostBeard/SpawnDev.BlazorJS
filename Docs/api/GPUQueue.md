# GPUQueue

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPUQueue`  
**MDN Reference:** [GPUQueue](https://developer.mozilla.org/en-US/docs/Web/API/GPUQueue)

> The `GPUQueue` class represents a command submission queue on the GPU. It provides methods for submitting recorded command buffers, writing data to buffers and textures, and tracking work completion. Each `GPUDevice` has exactly one queue, accessible via `device.Queue`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUQueue(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Label` | `string?` | A label for debugging. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Submit(GPUCommandBuffer[] commandBuffers)` | `void` | Submits one or more command buffers for execution on the GPU. |
| `WriteBuffer(GPUBuffer buffer, long bufferOffset, TypedArray data)` | `void` | Writes data from a `TypedArray` into a GPU buffer. |
| `WriteBuffer(GPUBuffer buffer, long bufferOffset, ArrayBuffer data)` | `void` | Writes data from an `ArrayBuffer` into a GPU buffer. |
| `WriteBuffer(GPUBuffer buffer, long bufferOffset, TypedArray data, long dataOffset, long size)` | `void` | Writes a sub-range of data into a GPU buffer. |
| `WriteTexture(GPUTexelCopyTextureInfo destination, TypedArray data, GPUTexelCopyBufferLayout dataLayout, GPUExtent3DDict size)` | `void` | Writes pixel data into a GPU texture. |
| `CopyExternalImageToTexture(GPUCopyExternalImageSourceInfo source, GPUCopyExternalImageDestInfo destination, GPUExtent3DDict copySize)` | `void` | Copies from an external image source (canvas, image, video) to a texture. |
| `OnSubmittedWorkDone()` | `Task` | Returns a promise that resolves when all previously submitted work has completed. |
| `WriteBuffer(GPUBuffer gpuBuffer, GPUSize64 bufferOffset, AllowSharedBufferSource data, int? dataOffset = 0, GPUSize64? size = null)` | `void` | The writeBuffer() method of the GPUQueue interface writes a provided data source into a given GPUBuffer. This is a convenience function, which provides an alternative to setting buffer data via buffer mapping and buffer-to-buffer copies. It lets the user agent determine the most efficient way to copy the data over. |
| `WriteBuffer(GPUBuffer gpuBuffer, long bufferOffset, AllowSharedBufferSource data, int? dataOffset = 0, long? size = null)` | `void` | The writeBuffer() method of the GPUQueue interface writes a provided data source into a given GPUBuffer. This is a convenience function, which provides an alternative to setting buffer data via buffer mapping and buffer-to-buffer copies. It lets the user agent determine the most efficient way to copy the data over. |
| `WriteTexture(GPUTexelCopyTextureInfo destination, AllowSharedBufferSource data, GPUTexelCopyBufferLayout dataLayout, GPUExtent3D size)` | `void` | Issues a write operation of the provided data into a GPUTexture. |
| `CopyExternalImageToTexture(GPUCopyExternalImageSourceInfo source, GPUCopyExternalImageDestInfo destination, GPUExtent3D copySize)` | `void` | Issues a copy operation of the contents of a platform image/canvas into the destination texture. This operation performs color encoding into the destination encoding according to the parameters of GPUCopyExternalImageDestInfo. Copying into a -srgb texture results in the same texture bytes, not the same decoded values, as copying into the corresponding non--srgb format. Thus, after a copy operation, sampling the destination texture has different results depending on whether its format is -srgb, all else unchanged. |

## Example

```csharp
using var device = await adapter.RequestDevice();
var queue = device.Queue;

// Write data to a buffer
float[] data = { 1.0f, 2.0f, 3.0f, 4.0f };
using var floatArray = new Float32Array(data);
queue.WriteBuffer(myBuffer, 0, floatArray);

// Submit command buffers
using var encoder = device.CreateCommandEncoder();
// ... record commands ...
using var commandBuffer = encoder.Finish();
queue.Submit(new[] { commandBuffer });

// Wait for GPU work to complete
await queue.OnSubmittedWorkDone();
Console.WriteLine("GPU work finished!");

// Write texture data
byte[] pixels = new byte[256 * 256 * 4];
using var pixelData = new Uint8Array(pixels);
queue.WriteTexture(
    new GPUTexelCopyTextureInfo { Texture = myTexture },
    pixelData,
    new GPUTexelCopyBufferLayout { BytesPerRow = 256 * 4, RowsPerImage = 256 },
    new GPUExtent3DDict { Width = 256, Height = 256 }
);
```
