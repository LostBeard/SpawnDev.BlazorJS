using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUSupportedFeatures interface of the WebGPU API is a Set-like object that describes additional functionality supported by a GPUAdapter.
    /// https://www.w3.org/TR/webgpu/#gpusupportedfeatures
    /// </summary>
    public class GPUSupportedFeatures : SetReadOnly<string>
    {
        /// <inheritdoc />
        public GPUSupportedFeatures(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
