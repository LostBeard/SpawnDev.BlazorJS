# GPU

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebGPU/GPU.cs`  
**MDN Reference:** [GPU on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GPU)

> The GPU interface of the WebGPU API is the starting point for using WebGPU. It can be used to return a GPUAdapter from which you can request devices, configure features and limits, and more. https://developer.mozilla.org/en-US/docs/Web/API/GPU

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `WGSLLanguageFeatures` | `WGSLLanguageFeatures` | get | A WGSLLanguageFeatures object that reports the WGSL language extensions supported by the WebGPU implementation. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetPreferredCanvasFormat()` | `string` | Returns the optimal canvas texture format for displaying 8-bit depth, standard dynamic range content on the current system. A string indicating a canvas texture format. The value can be rgba8unorm or bgra8unorm. |
| `RequestAdapter()` | `Task<GPUAdapter?>` | Returns a Promise that fulfills with a GPUAdapter object instance. From this you can request a GPUDevice, which is the primary interface for using WebGPU functionality. If you wish to prevent your apps from running on fallback adapters, you should check the GPUAdapter.isFallbackAdapter attribute prior to requesting a GPUDevice. A Promise that fulfills with a GPUAdapter object instance if the request is successful. requestAdapter() will resolve to null if an appropriate adapter is not available. |
| `RequestAdapter(GPURequestAdapterOptions options)` | `Task<GPUAdapter?>` | Returns a Promise that fulfills with a GPUAdapter object instance. From this you can request a GPUDevice, which is the primary interface for using WebGPU functionality. If you wish to prevent your apps from running on fallback adapters, you should check the GPUAdapter.isFallbackAdapter attribute prior to requesting a GPUDevice. A Promise that fulfills with a GPUAdapter object instance if the request is successful. requestAdapter() will resolve to null if an appropriate adapter is not available. |

## Example

```csharp
// Access the GPU interface from the navigator
using var navigator = JS.Get<Navigator>("navigator");
using var gpu = navigator.Gpu;
if (gpu == null)
{
    Console.WriteLine("WebGPU is not supported in this browser.");
    return;
}

// Get the preferred canvas texture format for this system
var preferredFormat = gpu.GetPreferredCanvasFormat();
Console.WriteLine($"Preferred format: {preferredFormat}");

// Request a GPU adapter (returns null if unavailable)
using var adapter = await gpu.RequestAdapter();
if (adapter == null)
{
    Console.WriteLine("No WebGPU adapter available.");
    return;
}

// Check adapter info
using var info = adapter.Info;
Console.WriteLine($"Adapter: {info.Description}");
Console.WriteLine($"Is fallback: {adapter.IsFallbackAdapter}");

// Request a device from the adapter
using var device = await adapter.RequestDevice();
Console.WriteLine($"Device acquired, label: {device.Label}");

// Check supported WGSL language features
using var wgslFeatures = gpu.WGSLLanguageFeatures;
Console.WriteLine("WGSL language features available.");
```

