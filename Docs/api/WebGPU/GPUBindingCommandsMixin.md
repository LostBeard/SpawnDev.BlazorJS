# GPUBindingCommandsMixin

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBindingCommandsMixin.cs`  

> https://www.w3.org/TR/webgpu/#gpubindingcommandsmixin

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUBindingCommandsMixin` | `interface` | get | https://www.w3.org/TR/webgpu/#gpubindingcommandsmixin |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, IEnumerable<GPUBufferDynamicOffset>? dynamicOffsets = null)` | `void` | Sets the current GPUBindGroup for the given index. |
| `SetBindGroup(GPUIndex32 index, GPUBindGroup? bindGroup, Uint32Array dynamicOffsetsData, GPUSize64 dynamicOffsetsDataStart, GPUSize32 dynamicOffsetsDataLength)` | `void` | Sets the current GPUBindGroup for the given index. |

