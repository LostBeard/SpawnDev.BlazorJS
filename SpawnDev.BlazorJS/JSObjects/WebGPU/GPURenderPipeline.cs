using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPURenderPipeline interface of the WebGPU API represents a pipeline that controls the vertex and fragment 
    /// shader stages and can be used in a GPURenderPassEncoder or GPURenderBundleEncoder.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPURenderPipeline
    /// </summary>
    public class GPURenderPipeline : JSObject
    {
        /// <inheritdoc/>
        public GPURenderPipeline(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
