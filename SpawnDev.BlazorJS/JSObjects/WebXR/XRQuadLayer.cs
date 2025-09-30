using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRQuadLayer
    /// </summary>
    public class XRQuadLayer : XRCompositionLayer
    {
        /// <inheritdoc/>
        public XRQuadLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Represents the height of the layer in meters.
        /// </summary>
        public float Height { get => JSRef!.Get<float>("height"); set => JSRef!.Set("height",  value); }
        /// <summary>
        /// Represents the width of the layer in meters.
        /// </summary>
        public float Width { get => JSRef!.Get<float>("width"); set => JSRef!.Set("width", value); }
        /// <summary>
        /// An XRSpace representing the layer's spatial relationship with the user's physical environment.
        /// </summary>
        public XRSpace Space { get => JSRef!.Get<XRSpace>("space"); set => JSRef!.Set("space", value); }
        /// <summary>
        /// An XRRigidTransform representing the offset and orientation relative to space.
        /// </summary>
        public XRRigidTransform Transform { get => JSRef!.Get<XRRigidTransform>("transform"); set => JSRef!.Set("transform", value); }
        /// <summary>
        /// Sent to the XRQuadLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame.
        /// </summary>
        public ActionEvent<XRLayerEvent> OnRedraw { get => new ActionEvent<XRLayerEvent>("redraw", AddEventListener, RemoveEventListener); set { } }
    }
}
