using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUTexture interface of the WebGPU API represents a container used to store 1D, 2D, 
    /// or 3D arrays of data, such as images, to use in GPU rendering operations.
    /// A GPUTexture object instance is created using the GPUDevice.createTexture() method.
    /// https://www.w3.org/TR/webgpu/#gputexture
    /// </summary>
    public class GPUTexture : GPUObjectBase, IGPUBindingResource, IGPUTextureOrTextureView
    {
        /// <inheritdoc/>
        public GPUTexture(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

        public GPUIntegerCoordinateOut Width => JSRef!.Get<GPUIntegerCoordinateOut>("width");
        public GPUIntegerCoordinateOut Height => JSRef!.Get<GPUIntegerCoordinateOut>("height");
        public GPUIntegerCoordinateOut DepthOrArrayLayers => JSRef!.Get<GPUIntegerCoordinateOut>("depthOrArrayLayers");
        public GPUIntegerCoordinateOut MipLevelCount => JSRef!.Get<GPUIntegerCoordinateOut>("mipLevelCount");
        public GPUSize32Out SampleCount => JSRef!.Get<GPUSize32Out>("sampleCount");
        public string Dimension => JSRef!.Get<string>("dimension");
        public string Format => JSRef!.Get<string>("format");
        public GPUFlagsConstant Usage => JSRef!.Get<GPUFlagsConstant>("usage");

#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        #endregion

        /// <summary>
        /// The createView() method of the GPUTexture interface creates a GPUTextureView representing a specific view of the GPUTexture.
        /// </summary>
        /// <returns></returns>
        public GPUTextureView CreateView() => JSRef!.Call<GPUTextureView>("createView");

        /// <summary>
        /// Destroys the GPUTexture.
        /// </summary>
        public void Destroy() => JSRef!.CallVoid("destroy");
    }
}
