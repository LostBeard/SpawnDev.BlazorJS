using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webgpu/#gpuqueryset
    /// </summary>
    public class GPUQuerySet : GPUObjectBase
    {
        /// <inheritdoc/>
        public GPUQuerySet(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The type of the queries managed by this GPUQuerySet.
        /// </summary>
        public GPUQueryType Type => JSRef!.Get<GPUQueryType>("type");

        /// <summary>
        /// The number of queries managed by this GPUQuerySet.
        /// </summary>
        public GPUSize32Out Count => JSRef!.Get<GPUSize32Out>("count");

        /// <summary>
        /// Destroys the GPUQuerySet.
        /// </summary>
        public void Destroy() => JSRef!.CallVoid("destroy");
    }


}
