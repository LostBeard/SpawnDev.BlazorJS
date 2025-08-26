using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUAdapter interface of the WebGPU API represents a GPU adapter. 
    /// From this you can request a GPUDevice, adapter info, features, and limits.<br/>
    /// https://www.w3.org/TR/webgpu/#gpuadapter
    /// </summary>
    public class GPUAdapter : GPUObjectBase
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
        /// This is a one-time action: if a device is returned successfully, the adapter becomes "consumed".
        /// </summary>
        /// <returns></returns>
        public Task<GPUDevice> RequestDevice() => JSRef!.CallAsync<GPUDevice>("requestDevice");
        /// <summary>
        /// Returns a Promise that fulfills with a GPUDevice object, which is the primary interface for communicating with the GPU.
        /// This is a one-time action: if a device is returned successfully, the adapter becomes "consumed".
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<GPUDevice> RequestDevice(GPUDeviceDescriptor options) => JSRef!.CallAsync<GPUDevice>("requestDevice", options);
        #endregion

        #region Events
        #endregion
    }
}
