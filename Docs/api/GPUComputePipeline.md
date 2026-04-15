# GPUComputePipeline

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPUComputePipeline`  
**MDN Reference:** [GPUComputePipeline](https://developer.mozilla.org/en-US/docs/Web/API/GPUComputePipeline)

> The `GPUComputePipeline` class represents a pre-compiled compute pipeline for running GPGPU compute shaders. Created via `GPUDevice.CreateComputePipeline()` or `GPUDevice.CreateComputePipelineAsync()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUComputePipeline(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Label` | `string?` | A label for debugging. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `GetBindGroupLayout(int index)` | `GPUBindGroupLayout` | Returns the bind group layout at the given index. |

## Example

```csharp
using var computeShader = device.CreateShaderModule(new GPUShaderModuleDescriptor
{
    Code = @"
        @group(0) @binding(0) var<storage, read_write> data: array<f32>;
        @compute @workgroup_size(64)
        fn main(@builtin(global_invocation_id) id: vec3u) {
            data[id.x] = data[id.x] * 2.0;
        }
    "
});

using var computePipeline = device.CreateComputePipeline(new GPUComputePipelineDescriptor
{
    Layout = "auto",
    Compute = new GPUProgrammableStage
    {
        Module = computeShader,
        EntryPoint = "main"
    }
});

using var bindGroupLayout = computePipeline.GetBindGroupLayout(0);
using var bindGroup = device.CreateBindGroup(new GPUBindGroupDescriptor
{
    Layout = bindGroupLayout,
    Entries = new GPUBindGroupEntry[]
    {
        new GPUBindGroupEntry { Binding = 0, Resource = new GPUBufferBinding { Buffer = dataBuffer } }
    }
});

using var encoder = device.CreateCommandEncoder();
using var pass = encoder.BeginComputePass();
pass.SetPipeline(computePipeline);
pass.SetBindGroup(0, bindGroup);
pass.DispatchWorkgroups(1024 / 64);
pass.End();
using var commands = encoder.Finish();
device.Queue.Submit(new[] { commands });
```
