using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUAdapterInfo interface of the WebGPU API contains identifying information about a GPUAdapter.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapterInfo
    /// </summary>
    public class GPUAdapterInfo : JSObject
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public GPUAdapterInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// The name of the family or class of GPUs the adapter belongs to. Returns an empty string if it is not available.
        /// </summary>
        public string Architecture => JSRef!.Get<string>("architecture");
        /// <summary>
        /// A human-readable string describing the adapter. Returns an empty string if it is not available.
        /// </summary>
        public string Description => JSRef!.Get<string>("description");
        /// <summary>
        /// A vendor-specific identifier for the adapter. Returns an empty string if it is not available.
        /// </summary>
        public string Device => JSRef!.Get<string>("device");
        /// <summary>
        /// The name of the adapter vendor. Returns an empty string if it is not available.
        /// </summary>
        public string Vendor => JSRef!.Get<string>("vendor");
        /// <summary>
        /// The maximum supported subgroup size for the GPUAdapter.
        /// </summary>
        public int SubgroupMaxSize => JSRef!.Get<int>("subgroupMaxSize");
        /// <summary>
        /// The minimum supported subgroup size for the GPUAdapter.
        /// </summary>
        public int SubgroupMinSize => JSRef!.Get<int>("subgroupMinSize");
        #endregion
    }
}
