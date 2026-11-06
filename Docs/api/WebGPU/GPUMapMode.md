# GPUMapMode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUMapMode.cs`  

> The GPUMapMode flags determine how a GPUBuffer is mapped when calling mapAsync(): https://www.w3.org/TR/webgpu/#typedefdef-gpumapmodeflags

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Read` | `1` | Only valid with buffers created with the MAP_READ usage. Once the buffer is mapped, calls to getMappedRange() will return an ArrayBuffer containing the buffer’s current values. Changes to the returned ArrayBuffer will be discarded after unmap() is called. |
| `Write` | `2` | Only valid with buffers created with the MAP_WRITE usage. Once the buffer is mapped, calls to getMappedRange() will return an ArrayBuffer containing the buffer’s current values. Changes to the returned ArrayBuffer will be stored in the GPUBuffer after unmap() is called. Note: Since the MAP_WRITE buffer usage may only be combined with the COPY_SRC buffer usage, mapping for writing can never return values produced by the GPU, and the returned ArrayBuffer will only ever contain the default initialized data (zeros) or data written by the webpage during a previous mapping. |
