using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpurenderbundle
    /// </summary>
    public class GPURenderBundle : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPURenderBundle(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
