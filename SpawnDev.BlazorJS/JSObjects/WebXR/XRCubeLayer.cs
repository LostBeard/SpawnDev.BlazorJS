using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRCubeLayer interface of the WebXR Device API is a layer that renders directly from a cubemap and projects it onto the inside faces of a cube.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRCubeLayer
    /// </summary>
    public class XRCubeLayer : XRCompositionLayer
    {
        /// <inheritdoc/>
        public XRCubeLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// An XRSpace representing the layer's spatial relationship with the user's physical environment.
        /// </summary>
        public XRSpace Space => JSRef!.Get<XRSpace>("space");
        /// <summary>
        /// A DOMPointReadOnly representing the orientation relative to the space property.
        /// </summary>
        public DOMPointReadOnly Orientation => JSRef!.Get<DOMPointReadOnly>("orientation");
        /// <summary>
        /// The redraw event is sent to the XRCubeLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame.
        /// </summary>
        public ActionEvent<XRLayerEvent> OnRedraw { get => new ActionEvent<XRLayerEvent>("redraw", AddEventListener, RemoveEventListener); set { } }
    }
}
