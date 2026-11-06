# GPUShaderStageFlags

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUShaderStageFlags.cs`  

> GPUShaderStage contains the following flags, which describe which shader stages a corresponding GPUBindGroupEntry for this GPUBindGroupLayoutEntry will be visible to. https://www.w3.org/TR/webgpu/#typedefdef-gpushaderstageflags

## Values

| Name | JSON Value | Description |
|---|---|---|
| `VERTEX` | `0x1` | The bind group entry will be accessible to vertex shaders. |
| `FRAGMENT` | `0x2` | The bind group entry will be accessible to fragment shaders. |
| `COMPUTE` | `0x4` | The bind group entry will be accessible to compute shaders. |
