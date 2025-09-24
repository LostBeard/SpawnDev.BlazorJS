using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRProjectionLayer interface of the WebXR Device API is a layer that fills the entire view of the observer and is refreshed close to the device's native frame rate.<br/>
    /// XRProjectionLayer is supported by all XRSession objects (no layers feature descriptor is needed).<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRProjectionLayer
    /// </summary>
    public class XRProjectionLayer : XRCompositionLayer
    {
        /// <inheritdoc/>
        public XRProjectionLayer(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
}
