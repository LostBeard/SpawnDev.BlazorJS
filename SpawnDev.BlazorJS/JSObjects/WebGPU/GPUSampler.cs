using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// A GPUSampler encodes transformations and filtering information that can be used in a shader to interpret texture resource data.
    /// https://www.w3.org/TR/webgpu/#gpusampler
    /// </summary>
    public class GPUSampler : GPUObjectBase, IGPUBindingResource
    {
        /// <inheritdoc />
        public GPUSampler(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
