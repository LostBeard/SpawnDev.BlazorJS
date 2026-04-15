# GPUCommandBuffer

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `GPUObjectBase`  
**Source:** `JSObjects/WebGPU/GPUCommandBuffer.cs`  

> Command buffers are pre-recorded lists of GPU commands (blocks of queue timeline steps) that can be submitted to a GPUQueue for execution. Each GPU command represents a task to be performed on the queue timeline, such as setting state, drawing, copying resources, etc. A GPUCommandBuffer can only be submitted once, at which point it becomes invalidated. To reuse rendering commands across multiple submissions, use GPURenderBundle. https://www.w3.org/TR/webgpu/#gpucommandbuffer

