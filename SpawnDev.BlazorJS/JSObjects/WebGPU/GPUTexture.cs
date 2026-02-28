using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUTexture interface of the WebGPU API represents a container used to store 1D, 2D, 
    /// or 3D arrays of data, such as images, to use in GPU rendering operations.
    /// A GPUTexture object instance is created using the GPUDevice.createTexture() method.
    /// https://www.w3.org/TR/webgpu/#gputexture
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUTexture
    /// </summary>
    public class GPUTexture : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUTexture(IJSInProcessObjectReference _ref) : base(_ref) { }

        #region Properties

        /// <summary>
        /// A number representing the width of the GPUTexture in pixels.
        /// </summary>
        public GPUIntegerCoordinateOut Width => JSRef!.Get<GPUIntegerCoordinateOut>("width");
        /// <summary>
        /// A number representing the height of the GPUTexture in pixels.
        /// </summary>
        public GPUIntegerCoordinateOut Height => JSRef!.Get<GPUIntegerCoordinateOut>("height");
        /// <summary>
        /// A number representing the depth or layer count of the GPUTexture (pixels, or number of layers).
        /// </summary>
        public GPUIntegerCoordinateOut DepthOrArrayLayers => JSRef!.Get<GPUIntegerCoordinateOut>("depthOrArrayLayers");
        /// <summary>
        /// A number representing the number of mip levels of the GPUTexture.
        /// </summary>
        public GPUIntegerCoordinateOut MipLevelCount => JSRef!.Get<GPUIntegerCoordinateOut>("mipLevelCount");
        /// <summary>
        /// A number representing the sample count of the GPUTexture.
        /// </summary>
        public GPUSize32Out SampleCount => JSRef!.Get<GPUSize32Out>("sampleCount");
        /// <summary>
        /// An enumerated value representing the dimension of the set of texels for each GPUTexture subresource.
        /// </summary>
        public string Dimension => JSRef!.Get<string>("dimension");
        /// <summary>
        /// An enumerated value representing the format of the GPUTexture. See the Texture formats section of the specification for all the possible values.
        /// </summary>
        public string Format => JSRef!.Get<string>("format");
        /// <summary>
        /// The bitwise flags representing the allowed usages of the GPUTexture.
        /// </summary>
        public GPUFlagsConstant Usage => JSRef!.Get<GPUFlagsConstant>("usage");
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
