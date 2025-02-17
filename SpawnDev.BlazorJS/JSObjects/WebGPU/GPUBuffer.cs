using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebGPU
{
    /// <summary>
    /// The GPUBuffer interface of the WebGPU API represents a block of memory that can be used to store raw data to use in GPU operations.<br/>
    /// A GPUBuffer object instance is created using the GPUDevice.createBuffer() method.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUBuffer
    /// </summary>
    public class GPUBuffer : JSObject
    {
        /// <inheritdoc/>
        public GPUBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
