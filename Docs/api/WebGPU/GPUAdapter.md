# GPUAdapter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUAdapter.cs`  
**MDN Reference:** [GPUAdapter on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapter)

> The GPUAdapter interface of the WebGPU API represents a GPU adapter. From this you can request a GPUDevice, adapter info, features, and limits. https://www.w3.org/TR/webgpu/#gpuadapter https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapter

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Features` | `GPUSupportedFeatures` | get | GPUSupportedFeatures is a setlike interface. Its set entries are the GPUFeatureName values of the features supported by an adapter or device. It must only contain strings from the GPUFeatureName enum. |
| `IsFallbackAdapter` | `bool` | get | A boolean value. Returns true if the adapter is a fallback adapter, and false if not. |
| `Info` | `GPUAdapterInfo` | get | A GPUAdapterInfo object containing identifying information about the adapter. |
| `Limits` | `GPUSupportedLimits` | get | A GPUSupportedLimits object that describes the limits supported by the adapter. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RequestAdapterInfo()` | `Task<GPUAdapterInfo>` | Returns a Promise that fulfills with a GPUAdapterInfo object containing identifying information about an adapter. |
| `RequestDevice()` | `Task<GPUDevice>` | Returns a Promise that fulfills with a GPUDevice object, which is the primary interface for communicating with the GPU. This is a one-time action: if a device is returned successfully, the adapter becomes "consumed". |
| `RequestDevice(GPUDeviceDescriptor options)` | `Task<GPUDevice>` | Returns a Promise that fulfills with a GPUDevice object, which is the primary interface for communicating with the GPU. This is a one-time action: if a device is returned successfully, the adapter becomes "consumed". |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUAdapter>(...)` or constructor `new GPUAdapter(...)`

```js
async function init() {
  if (!navigator.gpu) {
    throw Error("WebGPU not supported.");
  }

  const adapter = await navigator.gpu.requestAdapter();
  if (!adapter) {
    throw Error("Couldn't request WebGPU adapter.");
  }

  const device = await adapter.requestDevice();

  // …
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapter)*

