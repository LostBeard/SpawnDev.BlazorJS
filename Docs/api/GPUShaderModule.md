# GPUShaderModule

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPUShaderModule`  
**MDN Reference:** [GPUShaderModule](https://developer.mozilla.org/en-US/docs/Web/API/GPUShaderModule)

> The `GPUShaderModule` class represents a compiled WGSL shader module. Created via `GPUDevice.CreateShaderModule()` with a WGSL source code string. The shader module is referenced by pipeline descriptors to specify vertex, fragment, and compute entry points.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUShaderModule(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Label` | `string?` | A label for debugging. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetCompilationInfo()` | `Task<GPUCompilationInfo>` | Returns compilation messages (warnings, errors, info). |

## Example

```csharp
using var shaderModule = device.CreateShaderModule(new GPUShaderModuleDescriptor
{
    Label = "Triangle Shader",
    Code = @"
        struct VertexOutput {
            @builtin(position) position: vec4f,
            @location(0) color: vec4f,
        };

        @vertex
        fn vertexMain(@builtin(vertex_index) idx: u32) -> VertexOutput {
            var positions = array(
                vec2f( 0.0,  0.5),
                vec2f(-0.5, -0.5),
                vec2f( 0.5, -0.5)
            );
            var colors = array(
                vec4f(1, 0, 0, 1),
                vec4f(0, 1, 0, 1),
                vec4f(0, 0, 1, 1)
            );
            var output: VertexOutput;
            output.position = vec4f(positions[idx], 0, 1);
            output.color = colors[idx];
            return output;
        }

        @fragment
        fn fragmentMain(input: VertexOutput) -> @location(0) vec4f {
            return input.color;
        }
    "
});

// Check for compilation errors
using var info = await shaderModule.GetCompilationInfo();
```
