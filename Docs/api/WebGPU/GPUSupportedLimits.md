# GPUSupportedLimits

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebGPU/GPUSupportedLimits.cs`  
**MDN Reference:** [GPUSupportedLimits on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUSupportedLimits)

> The GPUSupportedLimits interface of the WebGPU API describes the limits supported by a GPUAdapter. https://www.w3.org/TR/webgpu/#gpusupportedlimits https://developer.mozilla.org/en-US/docs/Web/API/GPUSupportedLimits

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MaxTextureDimension1D` | `int?` | get |  |
| `MaxTextureDimension2D` | `int?` | get |  |
| `MaxTextureDimension3D` | `int?` | get |  |
| `MaxTextureArrayLayers` | `int?` | get |  |
| `MaxBindGroups` | `int?` | get |  |
| `MaxBindingsPerBindGroup` | `int?` | get |  |
| `MaxDynamicUniformBuffersPerPipelineLayout` | `int?` | get |  |
| `MaxDynamicStorageBuffersPerPipelineLayout` | `int?` | get |  |
| `MaxSampledTexturesPerShaderStage` | `int?` | get |  |
| `MaxSamplersPerShaderStage` | `int?` | get |  |
| `MaxStorageBuffersPerShaderStage` | `int?` | get |  |
| `MaxStorageTexturesPerShaderStage` | `int?` | get |  |
| `MaxUniformBuffersPerShaderStage` | `int?` | get |  |
| `MaxUniformBufferBindingSize` | `long?` | get |  |
| `MaxStorageBufferBindingSize` | `long?` | get |  |
| `MinUniformBufferOffsetAlignment` | `int?` | get |  |
| `MinStorageBufferOffsetAlignment` | `int?` | get |  |
| `MaxVertexBuffers` | `int?` | get |  |
| `MaxBufferSize` | `long?` | get |  |
| `MaxVertexAttributes` | `int?` | get |  |
| `MaxVertexBufferArrayStride` | `int?` | get |  |
| `MaxInterStageShaderComponents` | `int?` | get |  |
| `MaxInterStageShaderVariables` | `int?` | get |  |
| `MaxColorAttachments` | `int?` | get |  |
| `MaxColorAttachmentBytesPerSample` | `int?` | get |  |
| `MaxComputeWorkgroupStorageSize` | `int?` | get |  |
| `MaxComputeInvocationsPerWorkgroup` | `int?` | get |  |
| `MaxComputeWorkgroupSizeX` | `int?` | get |  |
| `MaxComputeWorkgroupSizeY` | `int?` | get |  |
| `MaxComputeWorkgroupSizeZ` | `int?` | get |  |
| `MaxComputeWorkgroupsPerDimension` | `int?` | get |  |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUSupportedLimits>(...)` or constructor `new GPUSupportedLimits(...)`

```js
async function init() {
  if (!navigator.gpu) {
    throw Error("WebGPU not supported.");
  }

  const adapter = await navigator.gpu.requestAdapter();
  if (!adapter) {
    throw Error("Couldn't request WebGPU adapter.");
  }

  const requiredLimits = {};

  // App ideally needs 6 bind groups, so we'll try to request what the app needs
  if (adapter.limits.maxBindGroups >= 6) {
    requiredLimits.maxBindGroups = 6;
  }

  const device = await adapter.requestDevice({
    requiredLimits,
  });

  // …
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUSupportedLimits)*

