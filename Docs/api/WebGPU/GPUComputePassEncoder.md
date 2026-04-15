# GPUComputePassEncoder

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUComputePassEncoder.cs`  

> https://www.w3.org/TR/webgpu/#gpucomputepassencoder

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetPipeline(GPUComputePipeline pipeline)` | `void` |  |
| `DispatchWorkgroups(GPUSize32 workgroupCountX, GPUSize32 workgroupCountY, GPUSize32 workgroupCountZ)` | `void` | Dispatch work to be performed with the current GPUComputePipeline. See § 23.1 Computing for the detailed specification. |
| `DispatchWorkgroupsIndirect(GPUBuffer indirectBuffer, GPUSize64 indirectOffset)` | `void` | Dispatch work to be performed with the current GPUComputePipeline using parameters read from a GPUBuffer. See § 23.1 Computing for the detailed specification. The indirect dispatch parameters encoded in the buffer must be a tightly packed block of three 32-bit unsigned integer values (12 bytes total), given in the same order as the arguments for dispatchWorkgroups(). |
| `End()` | `void` | Completes recording of the compute pass commands sequence. |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsetsData)` | `void` | Sets the current GPUBindGroup for the given index, specifying dynamic offsets as a subset of a Uint32Array. |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength)` | `void` | Sets the current GPUBindGroup for the given index. |

