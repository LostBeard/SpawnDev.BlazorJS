using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUPipelineLayout interface of the WebGPU API defines the GPUBindGroupLayouts used by a pipeline. 
    /// GPUBindGroups used with the pipeline during command encoding must have compatible GPUBindGroupLayouts.
    /// </summary>
    public class GPUPipelineLayout : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUPipelineLayout(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
