using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUTextureView interface of the WebGPU API represents a view into 
    /// a subset of the texture resources defined by a particular GPUTexture.
    /// A GPUTextureView object instance is created using the GPUTexture.createView() method.
    /// https://www.w3.org/TR/webgpu/#gputextureview
    /// </summary>
    public class GPUTextureView : GPUObjectBase 
    {
        /// <inheritdoc/>
        public GPUTextureView(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
