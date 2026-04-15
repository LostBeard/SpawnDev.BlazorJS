# GPUDeviceLostInfo

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUDeviceLostInfo.cs`  
**MDN Reference:** [GPUDeviceLostInfo on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUDeviceLostInfo)

> The GPUDeviceLostInfo interface of the WebGPU API represents the object returned when the GPUDevice.lost Promise resolves. This provides information as to why a device has been lost. https://developer.mozilla.org/en-US/docs/Web/API/GPUDeviceLostInfo

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUDeviceLostInfo` | `class` | get/set | The GPUDeviceLostInfo interface of the WebGPU API represents the object returned when the GPUDevice.lost Promise resolves. This provides information as to why a device has been lost. https://developer.mozilla.org/en-US/docs/Web/API/GPUDeviceLostInfo |
| `Reason` | `string` | get | An enumerated value that defines the reason the device was lost in a machine-readable way. |

## Examples

> **SpawnDev.BlazorJS Mapping Note:** The JavaScript examples below show the standard Web API usage.
> In SpawnDev.BlazorJS, the same API is available with C# conventions:
> - Properties and methods use **PascalCase** (e.g., `readyState` becomes `ReadyState`)
> - Events use **ActionEvent** with `+=`/`-=` (e.g., `addEventListener("click", fn)` becomes `OnClick += handler`)
> - Async methods return `Task<T>` instead of `Promise<T>`
> - Objects should be disposed with `using` statements
> - Access via `JS.Get<GPUDeviceLostInfo>(...)` or constructor `new GPUDeviceLostInfo(...)`

```js
async function init() {
  if (!navigator.gpu) {
    throw Error("WebGPU not supported.");
  }
  const adapter = await navigator.gpu.requestAdapter();
  if (!adapter) {
    throw Error("Couldn't request WebGPU adapter.");
  }

  // Create a GPUDevice
  let device = await adapter.requestDevice(descriptor);

  // Use lost to handle lost devices
  device.lost.then((info) => {
    console.error(`WebGPU device was lost: ${info.message}`);
    device = null;
    if (info.reason !== "destroyed") {
      init();
    }
  });
  // …
}
```

*[See full example on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPUDeviceLostInfo)*

