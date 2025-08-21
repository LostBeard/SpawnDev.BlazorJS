using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUTextureView interface of the WebGPU API represents a view into 
    /// a subset of the texture resources defined by a particular GPUTexture.
    /// A GPUTextureView object instance is created using the GPUTexture.createView() method.
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUTextureView
    /// </summary>
    public class GPUTextureView : JSObject
    {
        /// <inheritdoc/>
        public GPUTextureView(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// A string providing a label that can be used to identify the object, for example in GPUError messages or console warnings.
        /// </summary>
        public string Label { get; set; }
    }
}
