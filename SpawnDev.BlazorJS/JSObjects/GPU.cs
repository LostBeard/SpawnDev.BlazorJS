using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPU interface of the WebGPU API is the starting point for using WebGPU. It can be used to return a GPUAdapter from which you can request devices, configure features and limits, and more.
    /// </summary>
    public class GPU : JSObject
    {
        #region Constructors
        public GPU(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// A WGSLLanguageFeatures object that reports the WGSL language extensions supported by the WebGPU implementation.
        /// </summary>
        public WGSLLanguageFeatures WGSLLanguageFeatures => JSRef!.Get<WGSLLanguageFeatures>("wgslLanguageFeatures");
        #endregion

        #region Methods
        /// <summary>
        /// Returns the optimal canvas texture format for displaying 8-bit depth, standard dynamic range content on the current system.
        /// </summary>
        /// <returns>A string indicating a canvas texture format. The value can be rgba8unorm or bgra8unorm.</returns>
        public string GetPreferredCanvasFormat() => JSRef!.Call<string>("getPreferredCanvasFormat");
        /// <summary>
        /// Returns a Promise that fulfills with a GPUAdapter object instance. From this you can request a GPUDevice, which is the primary interface for using WebGPU functionality.<br/>
        /// If you wish to prevent your apps from running on fallback adapters, you should check the GPUAdapter.isFallbackAdapter attribute prior to requesting a GPUDevice.
        /// </summary>
        /// <returns>A Promise that fulfills with a GPUAdapter object instance if the request is successful. requestAdapter() will resolve to null if an appropriate adapter is not available.</returns>
        public Task<GPUAdapter> RequestAdapter() => JSRef!.CallAsync<GPUAdapter>("requestAdapter");
        /// <summary>
        /// Returns a Promise that fulfills with a GPUAdapter object instance. From this you can request a GPUDevice, which is the primary interface for using WebGPU functionality.<br/>
        /// If you wish to prevent your apps from running on fallback adapters, you should check the GPUAdapter.isFallbackAdapter attribute prior to requesting a GPUDevice.
        /// </summary>
        /// <param name="options"></param>
        /// <returns>A Promise that fulfills with a GPUAdapter object instance if the request is successful. requestAdapter() will resolve to null if an appropriate adapter is not available.</returns>
        public Task<GPUAdapter> RequestAdapter(RequestAdapterOptions options) => JSRef!.CallAsync<GPUAdapter>("requestAdapter", options);
        #endregion

        #region Events
        #endregion
    }
}
