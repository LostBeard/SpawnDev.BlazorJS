using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUDevice interface of the WebGPU API represents a logical GPU device. This is the main interface through which the majority of WebGPU functionality is accessed.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice
    /// </summary>
    public class GPUDevice : EventTarget
    {
        #region Constructors
        /// <inheritdoc/>
        public GPUDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        /// <summary>
        /// The createBuffer() method of the GPUDevice interface creates a GPUBuffer in which to store raw data to use in GPU operations.
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public GPUBuffer CreateBuffer(GPUBufferDescriptor descriptor) => JSRef!.Call<GPUBuffer>("createBuffer", descriptor);
        // TODO
    }
}
