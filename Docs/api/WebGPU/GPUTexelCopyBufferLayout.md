# GPUTexelCopyBufferLayout

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUTexelCopyBufferLayout.cs`  

> "GPUTexelCopyBufferLayout" describes the "layout" of texels in a "buffer" of bytes (GPUBuffer or AllowSharedBufferSource) in a "texel copy" operation. https://www.w3.org/TR/webgpu/#gputexelcopybufferlayout

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUTexelCopyBufferLayout` | `class` | get | "GPUTexelCopyBufferLayout" describes the "layout" of texels in a "buffer" of bytes (GPUBuffer or AllowSharedBufferSource) in a "texel copy" operation. https://www.w3.org/TR/webgpu/#gputexelcopybufferlayout |
| `BytesPerRow` | `GPUSize32?` | get |  |
| `RowsPerImage` | `GPUSize32?` | get |  |
| `Offset` | `GPUSize64` | get/set | The offset, in bytes, from the beginning of the texel data source (such as a GPUTexelCopyBufferInfo.buffer) to the start of the texel data within that source. |

