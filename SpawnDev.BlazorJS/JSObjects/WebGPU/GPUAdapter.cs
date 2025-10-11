using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUAdapter interface of the WebGPU API represents a GPU adapter. 
    /// From this you can request a GPUDevice, adapter info, features, and limits.<br/>
    /// https://www.w3.org/TR/webgpu/#gpuadapter
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUAdapter
    /// </summary>
    public class GPUAdapter : GPUObjectBase
    {
        #region Constructors
        /// <inheritdoc/>
        public GPUAdapter(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// GPUSupportedFeatures is a setlike interface. Its set entries are the GPUFeatureName values of the features supported by an adapter or device. It must only contain strings from the GPUFeatureName enum.
        /// </summary>
        public GPUSupportedFeatures Features => JSRef!.Get<GPUSupportedFeatures>("features");
        /// <summary>
        /// A boolean value. Returns true if the adapter is a fallback adapter, and false if not.<br/>
        /// </summary>
        public bool IsFallbackAdapter => JSRef!.Get<bool>("isFallbackAdapter");
        /// <summary>
        /// A GPUAdapterInfo object containing identifying information about the adapter.
        /// </summary>
        public GPUAdapterInfo Info => JSRef!.Get<GPUAdapterInfo>("info");
        /// <summary>
        /// A GPUSupportedLimits object that describes the limits supported by the adapter.
        /// </summary>
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
    }
}
