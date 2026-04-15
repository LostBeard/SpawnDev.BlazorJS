# GPUDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `EventTarget` -> `GPUDevice`  
**MDN Reference:** [GPUDevice](https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice)

> The `GPUDevice` class represents a logical GPU device. It is the primary interface for creating GPU resources (buffers, textures, pipelines, shaders, etc.), recording commands, and submitting work. Obtained from `GPUAdapter.RequestDevice()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPUDevice(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Queue` | `GPUQueue` | The primary command queue for this device. |
| `Features` | `GPUSupportedFeatures` | The set of features supported by this device. |
| `Limits` | `GPUSupportedLimits` | The limits of this device. |
| `Lost` | `Task<GPUDeviceLostInfo>` | A promise that resolves when the device is lost. |
| `Label` | `string?` | A label for debugging. |

## Methods

### Buffer Creation

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateBuffer(GPUBufferDescriptor descriptor)` | `GPUBuffer` | Creates a `GPUBuffer`. |

### Texture Creation

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateTexture(GPUTextureDescriptor descriptor)` | `GPUTexture` | Creates a `GPUTexture`. |
| `CreateSampler(GPUSamplerDescriptor? descriptor = null)` | `GPUSampler` | Creates a texture sampler. |
| `ImportExternalTexture(GPUExternalTextureDescriptor descriptor)` | `GPUExternalTexture` | Imports an external texture (e.g., from video). |

### Shader and Pipeline Creation

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateShaderModule(GPUShaderModuleDescriptor descriptor)` | `GPUShaderModule` | Creates a shader module from WGSL code. |
| `CreateRenderPipeline(GPURenderPipelineDescriptor descriptor)` | `GPURenderPipeline` | Creates a render pipeline. |
| `CreateRenderPipelineAsync(GPURenderPipelineDescriptor descriptor)` | `Task<GPURenderPipeline>` | Creates a render pipeline asynchronously. |
| `CreateComputePipeline(GPUComputePipelineDescriptor descriptor)` | `GPUComputePipeline` | Creates a compute pipeline. |
| `CreateComputePipelineAsync(GPUComputePipelineDescriptor descriptor)` | `Task<GPUComputePipeline>` | Creates a compute pipeline asynchronously. |

### Bind Group and Layout

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateBindGroupLayout(GPUBindGroupLayoutDescriptor descriptor)` | `GPUBindGroupLayout` | Creates a bind group layout. |
| `CreatePipelineLayout(GPUPipelineLayoutDescriptor descriptor)` | `GPUPipelineLayout` | Creates a pipeline layout from bind group layouts. |
| `CreateBindGroup(GPUBindGroupDescriptor descriptor)` | `GPUBindGroup` | Creates a bind group (binds resources to shader slots). |

### Command Encoding

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateCommandEncoder(GPUCommandEncoderDescriptor? descriptor = null)` | `GPUCommandEncoder` | Creates a command encoder for recording GPU commands. |
| `CreateRenderBundleEncoder(GPURenderBundleEncoderDescriptor descriptor)` | `GPURenderBundleEncoder` | Creates a render bundle encoder. |

### Query Sets

| Method | Return Type | Description |
|--------|-------------|-------------|
| `CreateQuerySet(GPUQuerySetDescriptor descriptor)` | `GPUQuerySet` | Creates a query set (e.g., for timestamp queries). |

### Error Handling

| Method | Return Type | Description |
|--------|-------------|-------------|
| `PushErrorScope(string filter)` | `void` | Pushes an error scope. Filter: `"validation"`, `"out-of-memory"`, `"internal"`. |
| `PopErrorScope()` | `Task<GPUError?>` | Pops the error scope and returns any captured error. |

### Lifecycle

| Method | Return Type | Description |
|--------|-------------|-------------|
| `Destroy()` | `void` | Destroys the device, releasing all resources. |

## Events

| Event | Type | Description |
|-------|------|-------------|
| `OnUncapturedError` | `ActionEvent<GPUUncapturedErrorEvent>` | Fired when an error occurs outside any error scope. |

## Example

```csharp
// Obtain a device
using var gpu = JS.Get<GPU>("navigator.gpu");
using var adapter = await gpu.RequestAdapter();
using var device = await adapter.RequestDevice();

// Create a shader module
using var shaderModule = device.CreateShaderModule(new GPUShaderModuleDescriptor
{
    Code = @"
        @vertex fn vs(@builtin(vertex_index) i: u32) -> @builtin(position) vec4f {
            var pos = array(vec2f(0, 0.5), vec2f(-0.5, -0.5), vec2f(0.5, -0.5));
            return vec4f(pos[i], 0, 1);
        }
        @fragment fn fs() -> @location(0) vec4f {
            return vec4f(1, 0, 0, 1);
        }
    "
});

// Create a render pipeline
using var pipeline = device.CreateRenderPipeline(new GPURenderPipelineDescriptor
{
    Vertex = new GPUVertexState { Module = shaderModule, EntryPoint = "vs" },
    Fragment = new GPUFragmentState
    {
        Module = shaderModule,
        EntryPoint = "fs",
        Targets = new[] { new GPUColorTargetState { Format = "bgra8unorm" } }
    }
});

// Create a buffer
using var buffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 1024,
    Usage = GPUBufferUsage.STORAGE | GPUBufferUsage.COPY_DST
});

// Record and submit commands
using var encoder = device.CreateCommandEncoder();
// ... begin render pass, set pipeline, draw, end pass ...
using var commandBuffer = encoder.Finish();
device.Queue.Submit(new[] { commandBuffer });

// Error handling
device.PushErrorScope("validation");
// ... potentially invalid operations ...
var error = await device.PopErrorScope();
if (error != null)
{
    Console.WriteLine($"GPU Error: {error.Message}");
}
```
