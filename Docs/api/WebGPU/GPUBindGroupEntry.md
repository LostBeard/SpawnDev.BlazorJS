# GPUBindGroupEntry

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBindGroupEntry.cs`  

> A GPUBindGroupEntry describes a single resource to be bound in a GPUBindGroup https://www.w3.org/TR/webgpu/#dictdef-gpubindgroupentry

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUBindGroupEntry` | `class` | get | A GPUBindGroupEntry describes a single resource to be bound in a GPUBindGroup https://www.w3.org/TR/webgpu/#dictdef-gpubindgroupentry |
| `Resource` | `GPUBindingResource` | get |  |
| `Binding` | `GPUIndex32` | get/set | A unique identifier for a resource binding within the GPUBindGroup, corresponding to a GPUBindGroupLayoutEntry.binding and a @binding attribute in the GPUShaderModule. |

