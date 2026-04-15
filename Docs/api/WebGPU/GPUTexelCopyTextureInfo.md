# GPUTexelCopyTextureInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUTexelCopyTextureInfo.cs`  

> "GPUTexelCopyTextureInfo" describes the "info" (GPUTexture, etc.) about a "texture" source or destination of a "texel copy" operation. Together with the copySize, it describes a sub-region of a texture (spanning one or more contiguous texture subresources at the same mip-map level). https://www.w3.org/TR/webgpu/#gputexelcopytextureinfo

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUTexelCopyTextureInfo` | `class` | get | "GPUTexelCopyTextureInfo" describes the "info" (GPUTexture, etc.) about a "texture" source or destination of a "texel copy" operation. Together with the copySize, it describes a sub-region of a texture (spanning one or more contiguous texture subresources at the same mip-map level). https://www.w3.org/TR/webgpu/#gputexelcopytextureinfo |
| `MipLevel` | `GPUIntegerCoordinate?` | get |  |
| `Origin` | `GPUOrigin3D?` | get |  |
| `Aspect` | `EnumString<GPUTextureAspect>?` | get |  |

