# GPUAdapterInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebGPU/GPUAdapterInfo.cs`  
**MDN Reference:** [GPUAdapterInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapterInfo)

> The GPUAdapterInfo interface of the WebGPU API contains identifying information about a GPUAdapter. https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapterInfo

## Constructors

| Signature | Description |
|---|---|
| `GPUAdapterInfo(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Architecture` | `string` | get | The name of the family or class of GPUs the adapter belongs to. Returns an empty string if it is not available. |
| `Description` | `string` | get | A human-readable string describing the adapter. Returns an empty string if it is not available. |
| `Device` | `string` | get | A vendor-specific identifier for the adapter. Returns an empty string if it is not available. |
| `Vendor` | `string` | get | The name of the adapter vendor. Returns an empty string if it is not available. |
| `SubgroupMaxSize` | `int` | get | The maximum supported subgroup size for the GPUAdapter. |
| `SubgroupMinSize` | `int` | get | The minimum supported subgroup size for the GPUAdapter. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUAdapterInfo>(...)` or constructor `new GPUAdapterInfo(...)`

### Access GPUAdapterInfo via GPUAdapter.info

```js
const adapter = await navigator.gpu.requestAdapter();
if (!adapter) {
  throw Error("Couldn't request WebGPU adapter.");
}

const adapterInfo = adapter.info;
console.log(adapterInfo.vendor);
console.log(adapterInfo.architecture);
```

### Access GPUAdapterInfo via GPUDevice.adapterInfo

```js
const adapter = await navigator.gpu.requestAdapter();
if (!adapter) {
  throw Error("Couldn't request WebGPU adapter.");
}

const myDevice = await adapter.requestDevice();

function optimizeForGpuDevice(device) {
  if (device.adapterInfo.vendor === "amd") {
    // Use AMD-specific optimizations
  } else if (device.adapterInfo.architecture.includes("turing")) {
    // Optimize for NVIDIA Turing architecture
  }
}

optimizeForGpuDevice(myDevice);
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapterInfo)*

