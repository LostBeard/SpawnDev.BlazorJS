using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRLayer interface of the WebXR Device API is the base class for WebXR layer types. It inherits methods from EventTarget.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRLayer
    /// </summary>
    public class XRLayer : EventTarget
    {
        /// <inheritdoc/>
        public XRLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
