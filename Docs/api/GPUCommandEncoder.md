# GPUCommandEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPUCommandEncoder`  
**MDN Reference:** [GPUCommandEncoder](https://developer.mozilla.org/en-US/docs/Web/API/GPUCommandEncoder)

> The `GPUCommandEncoder` class records GPU commands into a `GPUCommandBuffer` for later submission. It provides methods for beginning render and compute passes, copying data between buffers and textures, and resolving query sets. Created via `GPUDevice.CreateCommandEncoder()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUCommandEncoder(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Label` | `string?` | A label for debugging. |

## Methods

### Pass Encoding

| Method | Return Type | Description |
|--------|-------------|-------------|
| `BeginRenderPass(GPURenderPassDescriptor descriptor)` | `GPURenderPassEncoder` | Begins recording a render pass. |
| `BeginComputePass(GPUComputePassDescriptor? descriptor = null)` | `GPUComputePassEncoder` | Begins recording a compute pass. |

### Copy Operations

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CopyBufferToBuffer(GPUBuffer source, long sourceOffset, GPUBuffer destination, long destinationOffset, long size)` | `void` | Copies data between buffers. |
| `CopyBufferToTexture(GPUTexelCopyBufferInfo source, GPUTexelCopyTextureInfo destination, GPUExtent3DDict copySize)` | `void` | Copies buffer data to a texture. |
| `CopyTextureToBuffer(GPUTexelCopyTextureInfo source, GPUTexelCopyBufferInfo destination, GPUExtent3DDict copySize)` | `void` | Copies texture data to a buffer. |
| `CopyTextureToTexture(GPUTexelCopyTextureInfo source, GPUTexelCopyTextureInfo destination, GPUExtent3DDict copySize)` | `void` | Copies between textures. |

### Other Commands

| Method | Return Type | Description |
|--------|-------------|-------------|
| `ClearBuffer(GPUBuffer buffer)` | `void` | Clears an entire buffer to zero. |
| `ClearBuffer(GPUBuffer buffer, long offset, long size)` | `void` | Clears a sub-range of a buffer to zero. |
| `ResolveQuerySet(GPUQuerySet querySet, int firstQuery, int queryCount, GPUBuffer destination, long destinationOffset)` | `void` | Resolves query results into a buffer. |

### Finalization

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Finish()` | `GPUCommandBuffer` | Finishes recording and returns a `GPUCommandBuffer` for submission. |
| `Finish(GPUCommandBufferDescriptor descriptor)` | `GPUCommandBuffer` | Finishes with a descriptor (label). |

### Debug Markers

| Method | Return Type | Description |
|--------|-------------|-------------|
| `PushDebugGroup(string groupLabel)` | `void` | Begins a debug group. |
| `PopDebugGroup()` | `void` | Ends the current debug group. |
| `InsertDebugMarker(string markerLabel)` | `void` | Inserts a debug marker. |

## Example

```csharp
using var encoder = device.CreateCommandEncoder(new GPUCommandEncoderDescriptor
{
    Label = "Frame Encoder"
});

// Copy data between buffers
encoder.CopyBufferToBuffer(sourceBuffer, 0, destBuffer, 0, 4096);

// Begin a render pass
using var renderPass = encoder.BeginRenderPass(new GPURenderPassDescriptor
{
    ColorAttachments = new GPURenderPassColorAttachment[]
    {
        new GPURenderPassColorAttachment
        {
            View = textureView,
            LoadOp = "clear",
            StoreOp = "store",
            ClearValue = new GPUColorDict { R = 0, G = 0, B = 0, A = 1 }
        }
    }
});
renderPass.SetPipeline(renderPipeline);
renderPass.Draw(3);
renderPass.End();

// Begin a compute pass
using var computePass = encoder.BeginComputePass();
computePass.SetPipeline(computePipeline);
computePass.SetBindGroup(0, bindGroup);
computePass.DispatchWorkgroups(256);
computePass.End();

// Finish and submit
using var commands = encoder.Finish();
device.Queue.Submit(new[] { commands });
```
