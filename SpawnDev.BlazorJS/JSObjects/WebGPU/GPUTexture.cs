using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUTexture interface of the WebGPU API represents a container used to store 1D, 2D, 
    /// or 3D arrays of data, such as images, to use in GPU rendering operations.
    /// A GPUTexture object instance is created using the GPUDevice.createTexture() method.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUTexture
    /// </summary>
    public class GPUTexture : JSObject
    {
        /// <inheritdoc/>
        public GPUTexture(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The createView() method of the GPUTexture interface creates a GPUTextureView representing a specific view of the GPUTexture.
        /// </summary>
        /// <returns></returns>
        public GPUTextureView CreateView() => JSRef!.Call<GPUTextureView>("createView");
    }
}
