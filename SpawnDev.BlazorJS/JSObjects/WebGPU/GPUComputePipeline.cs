using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpucomputepipeline
    /// </summary>
    public class GPUComputePipeline : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUComputePipeline(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Gets a GPUBindGroupLayout that is compatible with the GPUPipelineBase’s GPUBindGroupLayout at index.
        /// </summary>
        /// <param name="index">Index into the pipeline layout’s [[bindGroupLayouts]] sequence.</param>
        /// <returns>GPUBindGroupLayout</returns>
        public GPUBindGroupLayout GetBindGroupLayout(int index) => JSRef!.Call<GPUBindGroupLayout>("getBindGroupLayout", index);
    }
}
