# GPURenderCommandsMixin

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPURenderCommandsMixin.cs`  

> https://www.w3.org/TR/webgpu/#gpurendercommandsmixin

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPURenderCommandsMixin` | `interface` | get | https://www.w3.org/TR/webgpu/#gpurendercommandsmixin |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetPipeline(GPURenderPipeline pipeline)` | `void` | Sets the GPU render pipeline to be used for subsequent rendering operations. https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPassEncoder/setPipeline |
| `SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset = 0)` | `void` | Sets the current index buffer. |
| `SetIndexBuffer(GPUBuffer buffer, EnumString<GPUIndexFormat> indexFormat, GPUSize64 offset, GPUSize64 size)` | `void` | Sets the current index buffer. |
| `SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset = 0)` | `void` | Sets the current vertex buffer for the given slot. |
| `SetVertexBuffer(GPUIndex32 slot, GPUBuffer? buffer, GPUSize64 offset, GPUSize64 size)` | `void` | Sets the current vertex buffer for the given slot. |
| `Draw(GPUSize32 vertexCount, GPUSize32 instanceCount = 1, GPUSize32 firstVertex = 0, GPUSize32 firstInstance = 0)` | `void` | Draws primitives. See § 23.2 Rendering for the detailed specification. |
| `DrawIndexed(GPUSize32 indexCount, GPUSize32 instanceCount = 1, GPUSize32 firstIndex = 0, GPUSignedOffset32 baseVertex = 0, GPUSize32 firstInstance = 0)` | `void` | Draws indexed primitives. See § 23.2 Rendering for the detailed specification. |
| `DrawIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` | Draws primitives using parameters read from a GPUBuffer. See § 23.2 Rendering for the detailed specification. The indirect draw parameters encoded in the buffer must be a tightly packed block of four 32-bit unsigned integer values (16 bytes total), given in the same order as the arguments for draw(). For example: |
| `DrawIndexedIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` | Draws indexed primitives using parameters read from a GPUBuffer. See § 23.2 Rendering for the detailed specification. The indirect drawIndexed parameters encoded in the buffer must be a tightly packed block of five 32-bit values (20 bytes total), given in the same order as the arguments for drawIndexed(). The value corresponding to baseVertex is a signed 32-bit integer, and all others are unsigned 32-bit integers. For example: |

