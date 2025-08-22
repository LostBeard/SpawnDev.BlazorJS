using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUBindGroupLayout interface of the WebGPU API defines the structure and purpose of related GPU resources
    /// such as buffers that will be used in a pipeline, and is used as a template when creating GPUBindGroups.
    /// https://www.w3.org/TR/webgpu/#gpubindgrouplayout
    /// </summary>
    public class GPUBindGroupLayout : GPUObjectBase
    {
        /// <inheritdoc />
        public GPUBindGroupLayout(IJSInProcessObjectReference _ref) : base(_ref) { }

    }
}
