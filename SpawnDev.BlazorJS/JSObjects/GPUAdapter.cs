using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class GPUAdapter : JSObject
    {
        #region Constructors
        public GPUAdapter(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        public GPUSupportedFeatures Features => JSRef!.Get<GPUSupportedFeatures>("features");
        public bool IsFallbackAdapter => JSRef!.Get<bool>("isFallbackAdapter");
        public GPUSupportedLimits Limits => JSRef!.Get<GPUSupportedLimits>("limits");
        #endregion

        #region Methods
        /// <summary>
        /// Returns a Promise that fulfills with a GPUAdapterInfo object containing identifying information about an adapter.
        /// </summary>
        /// <returns></returns>
        public Task<GPUAdapterInfo> RequestAdapterInfo() => JSRef!.CallAsync<GPUAdapterInfo>("requestAdapterInfo");
        /// <summary>
        /// Returns a Promise that fulfills with a GPUDevice object, which is the primary interface for communicating with the GPU.
        /// </summary>
        /// <returns></returns>
        public Task<GPUDevice> RequestDevice() => JSRef!.CallAsync<GPUDevice>("requestDevice");
        public Task<GPUDevice> RequestDevice(GPURequestDeviceOptions options) => JSRef!.CallAsync<GPUDevice>("requestDevice", options);
        #endregion

        #region Events
        #endregion
    }
}
