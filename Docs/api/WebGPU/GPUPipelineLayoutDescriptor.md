# GPUPipelineLayoutDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectDescriptorBase`  
**Source:** `JSObjects/WebGPU/GPUPipelineLayoutDescriptor.cs`  

> Describes the layout of a pipeline, which is used to create a GPUPipelineLayout object. https://www.w3.org/TR/webgpu/#dictdef-gpupipelinelayoutdescriptor

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `BindGroupLayouts` | `IEnumerable<GPUBindGroupLayout>` | get | An array of GPUBindGroupLayout objects (which are in turn created via calls to GPUDevice.createBindGroupLayout()). Each one corresponds to a @group attribute in the shader code contained in the GPUShaderModule used in a related pipeline. |

