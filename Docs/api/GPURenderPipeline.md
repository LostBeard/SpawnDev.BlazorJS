# GPURenderPipeline

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPURenderPipeline`  
**MDN Reference:** [GPURenderPipeline](https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPipeline)

> The `GPURenderPipeline` class represents a pre-compiled render pipeline that defines the vertex processing, fragment processing, and fixed-function state (blending, depth/stencil, rasterization) for rendering operations. Created via `GPUDevice.CreateRenderPipeline()` or `GPUDevice.CreateRenderPipelineAsync()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPURenderPipeline(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Label` | `string?` | A label for debugging. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetBindGroupLayout(int index)` | `GPUBindGroupLayout` | Returns the `GPUBindGroupLayout` at the given index. Useful when using `"auto"` layout. |

## GPURenderPipelineDescriptor

The descriptor used to create a render pipeline:

| Property | Type | Description |
|----------|------|-------------|
| `Layout` | `Union<GPUPipelineLayout, string>` | The pipeline layout, or `"auto"` for automatic layout. |
| `Vertex` | `GPUVertexState` | Vertex shader configuration (module, entry point, buffer layouts). |
| `Fragment` | `GPUFragmentState?` | Fragment shader configuration (module, entry point, color targets). |
| `Primitive` | `GPUPrimitiveState?` | Primitive assembly config (topology, front face, cull mode). |
| `DepthStencil` | `GPUDepthStencilState?` | Depth/stencil configuration. |
| `Multisample` | `GPUMultisampleState?` | Multisample anti-aliasing configuration. |

## Example

```csharp
using var pipeline = device.CreateRenderPipeline(new GPURenderPipelineDescriptor
{
    Layout = "auto",
    Vertex = new GPUVertexState
    {
        Module = shaderModule,
        EntryPoint = "vertexMain",
        Buffers = new GPUVertexBufferLayout[]
        {
            new GPUVertexBufferLayout
            {
                ArrayStride = 20,  // 5 floats * 4 bytes
                StepMode = "vertex",
                Attributes = new GPUVertexAttribute[]
                {
                    new GPUVertexAttribute { Format = "float32x3", Offset = 0, ShaderLocation = 0 },
                    new GPUVertexAttribute { Format = "float32x2", Offset = 12, ShaderLocation = 1 }
                }
            }
        }
    },
    Fragment = new GPUFragmentState
    {
        Module = shaderModule,
        EntryPoint = "fragmentMain",
        Targets = new GPUColorTargetState[]
        {
            new GPUColorTargetState { Format = "bgra8unorm" }
        }
    },
    Primitive = new GPUPrimitiveState
    {
        Topology = "triangle-list",
        CullMode = "back",
        FrontFace = "ccw"
    },
    DepthStencil = new GPUDepthStencilState
    {
        Format = "depth24plus",
        DepthWriteEnabled = true,
        DepthCompare = "less"
    }
});

// Get auto-generated bind group layout
using var bindGroupLayout = pipeline.GetBindGroupLayout(0);
```
