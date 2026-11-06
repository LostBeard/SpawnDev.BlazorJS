# GPUVertexStepMode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebGPU/GPUVertexStepMode.cs`  

> The step mode configures how an address for vertex buffer data is computed, based on the current vertex or instance index: https://www.w3.org/TR/webgpu/#enumdef-gpuvertexstepmode

## Values

| Name | JSON Value | Description |
|---|---|---|
| `Vertex` | `"vertex"` | The address is advanced by arrayStride for each vertex, and reset between instances. |
| `Instance` | `"instance"` | The address is advanced by arrayStride for each instance. |
