using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The GPUDevice interface of the WebGPU API represents a logical GPU device. This is the main interface through which the majority of WebGPU functionality is accessed.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/GPUDevice
    /// </summary>
    public class GPUDevice : JSObject
    {
        #region Constructors
        public GPUDevice(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        // TODO finish
    }
}
