# GPUCommandEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUCommandEncoder.cs`  

> The GPUCommandEncoder interface of the WebGPU API represents an encoder that collects a sequence of GPU commands to be issued to the GPU. A GPUCommandEncoder object instance is created via the GPUDevice.createCommandEncoder() property. https://www.w3.org/TR/webgpu/#gpucommandencoder

## Methods

| Method | Return Type | Description |
|---|---|---|
| `BeginRenderPass(GPURenderPassDescriptor descriptor)` | `GPURenderPassEncoder` | Begins a new render pass using the specified descriptor. The descriptor that defines the configuration and attachments for the render pass. This cannot be . A `GPURenderPassEncoder` that can be used to record rendering commands for the render pass. |
| `Finish()` | `GPUCommandBuffer` | Completes the recording of commands in the current GPU command encoder and returns a command buffer. A `GPUCommandBuffer` containing the recorded commands. The command buffer can be submitted to a GPU queue for execution. |
| `Finish(GPUCommandBufferDescriptor descriptor)` | `GPUCommandBuffer` | Completes the recording of commands in the current GPU command encoder and returns a command buffer. A `GPUCommandBuffer` containing the recorded commands. The command buffer can be submitted to a GPU queue for execution. |
| `CopyBufferToBuffer(GPUBuffer source, GPUBuffer destination, GPUSize64 size)` | `void` | The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another. The GPUBuffer to copy from. The GPUBuffer to copy to. Bytes to copy. |
| `CopyBufferToBuffer(GPUBuffer source, GPUBuffer destination)` | `void` | The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another. The GPUBuffer to copy from. The GPUBuffer to copy to. |
| `CopyBufferToBuffer(GPUBuffer source, GPUSize64 sourceOffset, GPUBuffer destination, GPUSize64 destinationOffset, GPUSize64 size)` | `void` | The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another. The GPUBuffer to copy from. Offset in bytes into source to begin copying from. The GPUBuffer to copy to. Offset in bytes into destination to place the copied data. Bytes to copy. |
| `CopyBufferToBuffer(GPUBuffer source, GPUSize64 sourceOffset, GPUBuffer destination, GPUSize64 destinationOffset)` | `void` | The copyBufferToBuffer() method of the GPUCommandEncoder interface encodes a command that copies data from one GPUBuffer to another. The GPUBuffer to copy from. Offset in bytes into source to begin copying from. The GPUBuffer to copy to. Offset in bytes into destination to place the copied data. |
| `CopyBufferToTexture(GPUTexelCopyBufferInfo source, GPUTexelCopyTextureInfo destination, Union<GPUExtent3DDict, IEnumerable<GPUIntegerCoordinate>> copySize)` | `void` | Encode a command into the GPUCommandEncoder that copies data from a sub-region of a GPUBuffer to a sub-region of one or multiple continuous texture subresources. |
| `CopyTextureToBuffer(GPUTexelCopyTextureInfo source, GPUTexelCopyBufferInfo destination, Union<GPUExtent3DDict, IEnumerable<GPUIntegerCoordinate>> copySize)` | `void` | Encode a command into the GPUCommandEncoder that copies data from a sub-region of one or multiple continuous texture subresources to a sub-region of a GPUBuffer. |
| `CopyTextureToTexture(GPUTexelCopyTextureInfo source, GPUTexelCopyTextureInfo destination, Union<GPUExtent3DDict, IEnumerable<GPUIntegerCoordinate>> copySize)` | `void` | Encode a command into the GPUCommandEncoder that copies data from a sub-region of one or multiple contiguous texture subresources to another sub-region of one or multiple continuous texture subresources. |
| `ClearBuffer(GPUBuffer buffer, GPUSize64 offset, GPUSize64 size)` | `void` | Encode a command into the GPUCommandEncoder that fills a sub-region of a GPUBuffer with zeros. |
| `ClearBuffer(GPUBuffer buffer, GPUSize64 offset)` | `void` | Encode a command into the GPUCommandEncoder that fills a sub-region of a GPUBuffer with zeros. |
| `ResolveQuerySet(GPUQuerySet querySet, GPUSize32 firstQuery, GPUSize32 queryCount, GPUBuffer destination, GPUSize64 destinationOffset)` | `void` | Resolves query results from a GPUQuerySet out into a range of a GPUBuffer. |
| `BeginComputePass(GPUComputePassDescriptor? descriptor)` | `GPUComputePassEncoder` | Begins encoding a compute pass described by descriptor. |

