# GPUBufferBindingLayout

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBufferBindingLayout.cs`  

> https://www.w3.org/TR/webgpu/#dictdef-gpubufferbindinglayout

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUBufferBindingLayout` | `class` | get/set | https://www.w3.org/TR/webgpu/#dictdef-gpubufferbindinglayout |
| `HasDynamicOffset` | `bool` | get | Indicates whether this binding requires a dynamic offset. |
| `MinBindingSize` | `GPUSize64` | get | Indicates the minimum size of a buffer binding used with this bind point. Bindings are always validated against this size in createBindGroup(). If this is not 0, pipeline creation additionally validates that this value ≥ the minimum buffer binding size of the variable. If this is 0, it is ignored by pipeline creation, and instead draw/dispatch commands validate that each binding in the GPUBindGroup satisfies the minimum buffer binding size of the variable. |

