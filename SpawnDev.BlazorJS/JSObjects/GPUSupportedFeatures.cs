using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUSupportedFeatures interface of the WebGPU API is a Set-like object that describes additional functionality supported by a GPUAdapter.
    /// </summary>
    public class GPUSupportedFeatures : SetReadOnly<string>
    {
        public GPUSupportedFeatures(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
