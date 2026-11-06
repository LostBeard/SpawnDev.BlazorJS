# XRGPUProjectionLayerInit

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebXR/XRGPUBinding.cs`  

> Configuration options for XRGPUBinding.createProjectionLayer().

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ColorFormat` | `string?` | get/set | The GPUTextureFormat to use for the color texture. Defaults to the binding's preferred format. |
| `DepthStencilFormat` | `string?` | get/set | The GPUTextureFormat for the depth/stencil texture, or null for no depth. |
| `ScaleFactor` | `float?` | get/set | A scaling factor for the projection layer resolution. Default 1.0. |
