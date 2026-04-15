# GPUTexelCopyBufferInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUTexelCopyBufferLayout`  
**Source:** `JSObjects/WebGPU/GPUTexelCopyBufferInfo.cs`  

> "GPUTexelCopyBufferInfo" describes the "info" (GPUBuffer and GPUTexelCopyBufferLayout) about a "buffer" source or destination of a "texel copy" operation. Together with the copySize, it describes the footprint of a region of texels in a GPUBuffer. https://www.w3.org/TR/webgpu/#gputexelcopybufferinfo

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Buffer` | `GPUBuffer` | get | A buffer which either contains texel data to be copied or will store the texel data being copied, depending on the method it is being passed to. |

