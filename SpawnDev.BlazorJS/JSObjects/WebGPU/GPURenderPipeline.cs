using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPURenderPipeline interface of the WebGPU API represents a pipeline that controls the vertex and fragment 
    /// shader stages and can be used in a GPURenderPassEncoder or GPURenderBundleEncoder.
    /// https://www.w3.org/TR/webgpu/#gpurenderpipeline
    /// </summary>
    public class GPURenderPipeline : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPURenderPipeline(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Gets a GPUBindGroupLayout that is compatible with the GPUPipelineBase’s GPUBindGroupLayout at index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public GPUBindGroupLayout GetBindGroupLayout(ulong index) => JSRef!.Call<GPUBindGroupLayout>("getBindGroupLayout", index);
    }
}
