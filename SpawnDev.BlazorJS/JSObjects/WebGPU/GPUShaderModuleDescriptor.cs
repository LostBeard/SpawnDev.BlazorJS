namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes the parameters for creating a GPUShaderModule, which is used to compile and manage shader code in WebGPU.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice/createShaderModule#descriptor
    /// </summary>
    public class GPUShaderModuleDescriptor
    {
        /// <summary>
        /// A string representing the WGSL source code for the shader module.
        /// </summary>
        public string Code { get; set; }
    }
}
