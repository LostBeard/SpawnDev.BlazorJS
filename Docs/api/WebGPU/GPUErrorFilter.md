# GPUErrorFilter

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUErrorFilter.cs`  

> GPUErrorFilter defines the type of errors that should be caught when calling pushErrorScope(): https://www.w3.org/TR/webgpu/#enumdef-gpuerrorfilter

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Validation` | `"validation"` | Indicates that the error scope will catch a GPUValidationError. |
| `OutOfMemory` | `"out-of-memory"` | Indicates that the error scope will catch a GPUOutOfMemoryError. |
| `Internal` | `"internal"` | Indicates that the error scope will catch a GPUInternalError. |
