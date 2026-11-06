# GPUDeviceDescriptor

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUDeviceDescriptor.cs`  

> RequestDevice options https://www.w3.org/TR/webgpu/#gpudevicedescriptor

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `GPUDeviceDescriptor` | `class` | get | RequestDevice options https://www.w3.org/TR/webgpu/#gpudevicedescriptor |
| `Label` | `string?` | get |  |
| `RequiredFeatures` | `List<string>?` | get |  |
| `RequiredLimits` | `object?` | get |  |
| `DefaultQueue` | `GPUQueue?` | get/set | An object that provides information for the device's default GPUQueue (as returned by GPUDevice.queue). This object has a single property — label — which provides the default queue with a label value. If no value is provided, this defaults to an empty object, and the default queue's label will be an empty string. |

