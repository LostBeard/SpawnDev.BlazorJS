# GPUBindGroupLayoutEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBindGroupLayoutEntry.cs`  

> Describes a single shader resource binding to be included in the GPUBindGroupLayout https://www.w3.org/TR/webgpu/#dictdef-gpubindgrouplayoutentry

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUBindGroupLayoutEntry` | `class` | get/set | Describes a single shader resource binding to be included in the GPUBindGroupLayout https://www.w3.org/TR/webgpu/#dictdef-gpubindgrouplayoutentry |
| `Visibility` | `GPUShaderStageFlags` | get/set |  |
| `Buffer` | `GPUBufferBindingLayout?` | get/set |  |
| `Sampler` | `GPUSamplerBindingLayout?` | get/set |  |
| `Texture` | `GPUTextureBindingLayout?` | get/set |  |
| `StorageTexture` | `GPUStorageTextureBindingLayout?` | get/set |  |
| `ExternalTexture` | `GPUExternalTextureBindingLayout?` | get |  |
| `Binding` | `GPUSize32` | get/set | A number representing a unique identifier for this particular entry, which matches the binding value of a corresponding GPUBindGroup entry. In addition, it matches the n index value of the corresponding @binding(n) attribute in the shader (GPUShaderModule) used in the related pipeline. |

