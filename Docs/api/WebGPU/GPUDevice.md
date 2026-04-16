# GPUDevice

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebGPU/GPUDevice.cs`  
**MDN Reference:** [GPUDevice on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice)

> The GPUDevice interface of the WebGPU API represents a logical GPU device. This is the main interface through which the majority of WebGPU functionality is accessed. https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice https://www.w3.org/TR/webgpu/#gpudevice

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AdapterInfo` | `GPUAdapterInfo` | get | The adapterInfo read-only property of the GPUDevice interface returns a GPUAdapterInfo object containing identifying information about the device's originating adapter. |
| `Features` | `GPUSupportedFeatures` | get | A GPUSupportedFeatures object that describes additional functionality supported by the device. |
| `Label` | `string?` | get | A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings. |
| `Limits` | `GPUSupportedLimits` | get | A GPUSupportedLimits object that describes the limits supported by the device. |
| `Lost` | `Task<GPUDeviceLostInfo>` | get | Contains a Promise that remains pending throughout the device's lifetime and resolves with a GPUDeviceLostInfo object when the device is lost. |
| `Queue` | `GPUQueue` | get | Returns the primary GPUQueue for the device. Cached to avoid creating a new JSObject wrapper on each access. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Destroy()` | `void` | Destroys the GPUDevice. |
| `PushErrorScope(EnumString<GPUErrorFilter> filter)` | `void` | The pushErrorScope() method of the GPUDevice interface pushes a new GPU error scope onto the device's error scope stack, allowing you to capture errors of a particular type. Once you are done capturing errors, you can end capture by invoking GPUDevice.popErrorScope(). This pops the scope from the stack and returns a Promise that resolves to an object describing the first error captured in the scope, or null if no errors were captured. |
| `PopErrorScope()` | `Task<GPUError?>` | The popErrorScope() method of the GPUDevice interface pops an existing GPU error scope from the error scope stack (originally pushed using GPUDevice.pushErrorScope()) and returns a Promise that resolves to an object describing the first error captured in the scope, or null if no error occurred. |
| `CreateBuffer(GPUBufferDescriptor descriptor)` | `GPUBuffer` | The createBuffer() method of the GPUDevice interface creates a GPUBuffer in which to store raw data to use in GPU operations. |
| `CreateSampler(GPUSamplerDescriptor? descriptor)` | `GPUSampler` | Creates a GPUSampler. Description of the GPUSampler to create. |
| `ImportExternalTexture(GPUExternalTextureDescriptor descriptor)` | `GPUExternalTexture` | Creates a GPUExternalTexture wrapping the provided image source. Provides the external image source object (and any creation options). |
| `CreateRenderPipeline(GPURenderPipelineDescriptor descriptor)` | `GPURenderPipeline` | The createRenderPipeline() method of the GPUDevice interface creates a GPURenderPipeline object, which represents a collection of GPU state and shader programs that can be used to render graphics. |
| `CreateRenderPipelineAsync(GPURenderPipelineDescriptor descriptor)` | `Task<GPURenderPipeline>` | Creates a GPURenderPipeline using async pipeline creation. The returned Promise resolves when the created pipeline is ready to be used without additional delay. If pipeline creation fails, the returned Promise rejects with an GPUPipelineError. (A GPUError is not dispatched to the device.) Note: Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation. Description of the GPURenderPipeline to create. |
| `CreatePipelineLayout(GPUPipelineLayoutDescriptor descriptor)` | `GPUPipelineLayout` | The createComputePipeline() method of the GPUDevice interface creates a GPUPipelineLayout that defines the GPUBindGroupLayouts used by a pipeline. https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createPipelineLayout |
| `CreateBindGroupLayout(GPUBindGroupLayoutDescriptor descriptor)` | `GPUBindGroupLayout` | Creates a GPUBindGroupLayout that defines the structure and purpose of related GPU resources such as buffers that will be used in a pipeline, and is used as a template when creating GPUBindGroups. https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createBindGroupLayout |
| `CreateShaderModule(GPUShaderModuleDescriptor descriptor)` | `GPUShaderModule` | Creates a GPUShaderModule from a string of WGSL source code. https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createShaderModule |
| `CreateCommandEncoder(GPUCommandEncoderDescriptor? descriptor)` | `GPUCommandEncoder` | Creates a GPUCommandEncoder, which is used to encode commands to be issued to the GPU. https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createCommandEncoder |
| `CreateTexture(GPUTextureDescriptor descriptor)` | `GPUTexture` | The createTexture() method of the GPUDevice interface creates a GPUTexture in which to store 1D, 2D, or 3D arrays of data, such as images, to use in GPU rendering operations. |
| `CreateBindGroup(GPUBindGroupDescriptor descriptor)` | `GPUBindGroup` | The createBindGroup() method of the GPUDevice interface creates a GPUBindGroup based on a GPUBindGroupLayout that defines a set of resources to be bound together in a group and how those resources are used in shader stages. |
| `CreateQuerySet(GPUQuerySetDescriptor descriptor)` | `GPUQuerySet` | The createQuerySet() method of the GPUDevice interface creates a GPUQuerySet that can be used to record the results of queries on passes, such as occlusion or timestamp queries. |
| `CreateComputePipeline(GPUComputePipelineDescriptor descriptor)` | `GPUComputePipeline` | Creates a GPUComputePipeline using immediate pipeline creation. |
| `CreateComputePipelineAsync(GPUComputePipelineDescriptor descriptor)` | `Task<GPUComputePipeline>` | Creates a GPUComputePipeline using async pipeline creation. The returned Promise resolves when the created pipeline is ready to be used without additional delay. If pipeline creation fails, the returned Promise rejects with an GPUPipelineError. (A GPUError is not dispatched to the device.) Note: Use of this method is preferred whenever possible, as it prevents blocking the queue timeline work on pipeline compilation. |
| `CreateRenderBundleEncoder(GPURenderBundleEncoderDescriptor descriptor)` | `GPURenderBundleEncoder` | Creates a GPURenderBundleEncoder. Description of the GPURenderBundleEncoder to create. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnUncapturedError` | `ActionEvent<GPUUncapturedErrorEvent>` | The uncapturederror event of the GPUDevice interface is fired when an error is thrown that has not been observed by a GPU error scope, to provide a way to report unexpected errors. |

## Example

```csharp
// Acquire a device (assumes adapter already obtained - see GPU example)
using var device = await adapter.RequestDevice();

// Listen for uncaptured GPU errors (named method for proper cleanup)
device.OnUncapturedError += Device_OnUncapturedError;

// Create a GPU buffer for storing data
using var buffer = device.CreateBuffer(new GPUBufferDescriptor
{
    Size = 256,
    Usage = GPUBufferUsage.Storage | GPUBufferUsage.CopySrc,
});

// Create a shader module from WGSL source
using var shaderModule = device.CreateShaderModule(new GPUShaderModuleDescriptor
{
    Code = @"
        @compute @workgroup_size(64)
        fn main(@builtin(global_invocation_id) id: vec3<u32>) {
            // Compute shader logic here
        }
    "
});

// Create a command encoder and submit work
using var encoder = device.CreateCommandEncoder();
// ... encode render or compute passes ...
using var commandBuffer = encoder.Finish();
device.Queue.Submit(new[] { commandBuffer });

// Check device limits
using var limits = device.Limits;
Console.WriteLine($"Max buffer size: {limits.MaxBufferSize}");

// Clean up event handler before disposal
device.OnUncapturedError -= Device_OnUncapturedError;

// Destroy the device when done
device.Destroy();

void Device_OnUncapturedError(GPUUncapturedErrorEvent e)
{
    Console.WriteLine($"GPU error: {e.Error.Message}");
}
```

