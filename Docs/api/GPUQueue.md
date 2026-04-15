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
