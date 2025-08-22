namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// WebGPU usage flags<br/>
    /// https://www.w3.org/TR/webgpu/#buffer-usage
    /// </summary>
    [Flags]
    public enum GPUBufferUsage : GPUFlagsConstant
    {
        /// <summary>
        /// The buffer can be mapped for reading, for example when calling mapAsync() with a mode of GPUMapMode.READ. This flag may only be combined with GPUBufferUsage.COPY_DST.	
        /// </summary>
        MapRead = 0x0001,
        /// <summary>
        /// The buffer can be mapped for writing, for example when calling mapAsync() with a mode of GPUMapMode.WRITE. This flag may only be combined with GPUBufferUsage.COPY_SRC.	
        /// </summary>
        MapWrite = 0x0002,
        /// <summary>
        /// The buffer can be used as the source of a copy operation, for example the source argument of a copyBufferToBuffer() call.	
        /// </summary>
        CopySrc = 0x0004,
        /// <summary>
        /// The buffer can be used as the destination of a copy/write operation, for example the destination argument of a copyTextureToBuffer() call.	
        /// </summary>
        CopyDst = 0x0008,
        /// <summary>
        /// The buffer can be used as an index buffer, for example as the buffer argument passed to setIndexBuffer().	
        /// </summary>
        Index = 0x0010,
        /// <summary>
        /// The buffer can be used as a vertex buffer, for example as the buffer argument passed to setVertexBuffer().	
        /// </summary>
        Vertex = 0x0020,
        /// <summary>
        /// The buffer can be used as a uniform buffer, for example as a resource in a bind group entry when creating a GPUBindGroup (via createBindGroup()), which adheres to a GPUBindGroupLayout entry with a buffer binding layout type of "uniform".	
        /// </summary>
        Uniform = 0x0040,
        /// <summary>
        /// The buffer can be used as a storage buffer, for example as a resource in a bind group entry when creating a GPUBindGroup (via createBindGroup()), which adheres to a GPUBindGroupLayout entry with a buffer binding layout type of "storage" or "read-only-storage".	
        /// </summary>
        Storage = 0x0080,
        /// <summary>
        /// The buffer can be used to store indirect command arguments, for example as the indirectBuffer argument of a drawIndirect() or dispatchWorkgroupsIndirect() call.	
        /// </summary>
        Indirect = 0x0100,
        /// <summary>
        /// The buffer can be used to capture query results, for example as the destination argument of a resolveQuerySet() call.	
        /// </summary>
        QueryResolve = 0x0200,
    }
}
