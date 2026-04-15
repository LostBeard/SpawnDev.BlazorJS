# GPU

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebGPU`  
**Inheritance:** `JSObject` -> `GPU`  
**MDN Reference:** [GPU](https://developer.mozilla.org/en-US/docs/Web/API/GPU)

> The `GPU` class is the entry point for the WebGPU API. It provides the `RequestAdapter` method to obtain a `GPUAdapter`, which can then be used to request a `GPUDevice`. Access the `GPU` object via `navigator.gpu`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `GPU(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `WGSLLanguageFeatures` | `WGSLLanguageFeatures` | The set of WGSL language features supported by the implementation. |

## Methods

| Method | Return Type | Description |
|--------|-------------|-------------|
| `RequestAdapter()` | `Task<GPUAdapter?>` | Requests a `GPUAdapter` using default options. Returns `null` if no adapter is available. |
| `RequestAdapter(GPURequestAdapterOptions options)` | `Task<GPUAdapter?>` | Requests a `GPUAdapter` with specific options (e.g., power preference). |
| `GetPreferredCanvasFormat()` | `string` | Returns the preferred texture format for the current system. |

## Example

```csharp
@inject BlazorJSRuntime JS

// Check if WebGPU is available
if (!JS.IsUndefined("navigator.gpu"))
{
    using var gpu = JS.Get<GPU>("navigator.gpu");

    // Get the preferred canvas format
    string format = gpu.GetPreferredCanvasFormat();  // e.g., "bgra8unorm"

    // Request an adapter
    using var adapter = await gpu.RequestAdapter(new GPURequestAdapterOptions
    {
        PowerPreference = "high-performance"
    });

    if (adapter != null)
    {
        // Request a device from the adapter
        using var device = await adapter.RequestDevice();

        Console.WriteLine("WebGPU device acquired!");
    }
}
```
