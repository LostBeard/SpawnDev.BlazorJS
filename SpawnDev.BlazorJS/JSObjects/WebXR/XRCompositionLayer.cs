using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRCompositionLayer interface of the WebXR Device API is a base class that defines a set of common properties and behaviors for WebXR layer types. It is not constructable on its own.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRCompositionLayer
    /// </summary>
    public class XRCompositionLayer : XRLayer
    {
        /// <inheritdoc/>
        public XRCompositionLayer(IJSInProcessObjectReference _ref) : base(_ref) { }

        // TODO
    }
}
