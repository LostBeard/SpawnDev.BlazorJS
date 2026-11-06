# GPUBufferMapState

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBufferMapState.cs`  

> A GPUBuffer represents a block of memory that can be used in GPU operations. Data is stored in linear layout, meaning that each byte of the allocation can be addressed by its offset from the start of the GPUBuffer, subject to alignment restrictions depending on the operation. Some GPUBuffers can be mapped which makes the block of memory accessible via an ArrayBuffer called its mapping. GPUBuffers are created via createBuffer(). Buffers may be mappedAtCreation. https://www.w3.org/TR/webgpu/#enumdef-gpubuffermapstate

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Unmapped` | `"unmapped"` | The buffer is not mapped for use by this.getMappedRange(). |
| `Pending` | `"pending"` | A mapping of the buffer has been requested, but is pending. It may succeed, or fail validation in mapAsync(). |
| `Mapped` | `"mapped"` | The buffer is mapped and this.getMappedRange() may be used. |
