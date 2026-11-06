# GPUBufferUsage

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUBufferUsage.cs`  

> WebGPU usage flags https://www.w3.org/TR/webgpu/#buffer-usage

## Values

| Name | JSON Value | Description |
|---|---|---|
| `MapRead` | `0x0001` | The buffer can be mapped for reading, for example when calling mapAsync() with a mode of GPUMapMode.READ. This flag may only be combined with GPUBufferUsage.COPY_DST. |
| `MapWrite` | `0x0002` | The buffer can be mapped for writing, for example when calling mapAsync() with a mode of GPUMapMode.WRITE. This flag may only be combined with GPUBufferUsage.COPY_SRC. |
| `CopySrc` | `0x0004` | The buffer can be used as the source of a copy operation, for example the source argument of a copyBufferToBuffer() call. |
| `CopyDst` | `0x0008` | The buffer can be used as the destination of a copy/write operation, for example the destination argument of a copyTextureToBuffer() call. |
| `Index` | `0x0010` | The buffer can be used as an index buffer, for example as the buffer argument passed to setIndexBuffer(). |
| `Vertex` | `0x0020` | The buffer can be used as a vertex buffer, for example as the buffer argument passed to setVertexBuffer(). |
| `Uniform` | `0x0040` | The buffer can be used as a uniform buffer, for example as a resource in a bind group entry when creating a GPUBindGroup (via createBindGroup()), which adheres to a GPUBindGroupLayout entry with a buffer binding layout type of "uniform". |
| `Storage` | `0x0080` | The buffer can be used as a storage buffer, for example as a resource in a bind group entry when creating a GPUBindGroup (via createBindGroup()), which adheres to a GPUBindGroupLayout entry with a buffer binding layout type of "storage" or "read-only-storage". |
| `Indirect` | `0x0100` | The buffer can be used to store indirect command arguments, for example as the indirectBuffer argument of a drawIndirect() or dispatchWorkgroupsIndirect() call. |
| `QueryResolve` | `0x0200` | The buffer can be used to capture query results, for example as the destination argument of a resolveQuerySet() call. |
