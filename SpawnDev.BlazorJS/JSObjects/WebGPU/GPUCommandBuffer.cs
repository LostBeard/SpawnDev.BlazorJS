using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUCommandBuffer interface of the WebGPU API represents a pre-recorded list of GPU commands
    /// that can be submitted to a GPUQueue for execution. A GPUCommandBuffer is created via the 
    /// GPUCommandEncoder.finish() method; the GPU commands recorded within are submitted
    /// for execution by passing the GPUCommandBuffer into the parameter of a GPUQueue.submit() call.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUCommandBuffer
    /// </summary>
    public class GPUCommandBuffer : JSObject
    {

        /// <inheritdoc/>
        public GPUCommandBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string Label { get; set; }
    }
}
