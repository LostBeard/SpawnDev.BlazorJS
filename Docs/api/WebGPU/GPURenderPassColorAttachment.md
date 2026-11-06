# GPURenderPassColorAttachment

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPURenderPassColorAttachment.cs`  

> Defines the color attachments that will be output to when executing a render pass. https://www.w3.org/TR/webgpu/#dictdef-gpurenderpasscolorattachment

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPURenderPassColorAttachment` | `class` | get | Defines the color attachments that will be output to when executing a render pass. https://www.w3.org/TR/webgpu/#dictdef-gpurenderpasscolorattachment |
| `StoreOp` | `EnumString<GPUStoreOp>` | get |  |
| `View` | `Union<GPUTexture, GPUTextureView>` | get |  |
| `ResolveTarget` | `Union<GPUTexture, GPUTextureView>` | get |  |
| `DepthSlice` | `GPUIntegerCoordinate?` | get/set |  |
| `ClearValue` | `GPUColor?` | get |  |
| `LoadOp` | `EnumString<GPULoadOp>` | get/set | An enumerated value indicating the load operation to perform on view prior to executing the render pass. Possible values are: "clear": Loads the clearValue for this attachment into the render pass. "load": Loads the existing value for this attachment into the render pass. |

