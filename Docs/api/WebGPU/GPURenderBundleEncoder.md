# GPURenderBundleEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`, `GPUCommandsMixin`, `GPUDebugCommandsMixin`, `GPUBindingCommandsMixin`, `GPURenderCommandsMixin`  
**Source:** `JSObjects/WebGPU/GPURenderBundleEncoder.cs`  

> https://www.w3.org/TR/webgpu/#gpurenderbundleencoder

## Methods

| Method | Return Type | Description |
|---|---|---|
| `PushDebugGroup(string groupLabel)` | `void` |  |
| `PopDebugGroup()` | `void` |  |
| `InsertDebugMarker(string markerLabel)` | `void` |  |
| `SetPipeline(GPURenderPipeline pipeline)` | `void` |  |
| `SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset)` | `void` |  |
| `SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset, GPUSize64 size)` | `void` |  |
| `SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset)` | `void` |  |
| `SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset, GPUSize64 size)` | `void` |  |
| `Draw(GPUSize32 vertexCount, GPUSize32 instanceCount, GPUSize32 firstVertex, GPUSize32 firstInstance)` | `void` |  |
| `DrawIndexed(GPUSize32 indexCount, GPUSize32 instanceCount, GPUSize32 firstIndex, GPUSignedOffset32 baseVertex, GPUSize32 firstInstance)` | `void` |  |
| `DrawIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` |  |
| `DrawIndexedIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` |  |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsets)` | `void` |  |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength)` | `void` |  |
| `Finish(GPURenderBundleDescriptor? descriptor)` | `GPURenderBundle` | Completes recording of the render bundle commands sequence. optional options |

