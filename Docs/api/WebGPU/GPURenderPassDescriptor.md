# GPURenderPassDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectDescriptorBase`  
**Source:** `JSObjects/WebGPU/GPURenderPassDescriptor.cs`  

> Represents a descriptor for configuring a GPU render pass. https://www.w3.org/TR/webgpu/#dictdef-gpurenderpassdescriptor

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ColorAttachments` | `GPURenderPassColorAttachment[]` | get |  |
| `DepthStencilAttachment` | `GPURenderPassDepthStencilAttachment?` | get |  |
| `MaxDrawCount` | `GPUSize64?` | get |  |
| `OcclusionQuerySet` | `GPUQuerySet?` | get |  |
| `TimestampWrites` | `GPURenderPassTimestampWrites?` | get |  |
| `GPURenderPassTimestampWrites` | `class` | get/set | Defines timestamp write operations for a render pass. https://www.w3.org/TR/webgpu/#dictdef-gpurenderpasstimestampwrites |
| `BeginningOfPassWriteIndex` | `int?` | get/set |  |
| `EndOfPassWriteIndex` | `int?` | get |  |

