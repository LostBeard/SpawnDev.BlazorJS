using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRCylinderLayer
    /// </summary>
    public class XRCylinderLayer : XRCompositionLayer
    {
        /// <inheritdoc/>
        public XRCylinderLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A number indicating the ratio of the visible cylinder section. It is the ratio of the width of the visible section of the cylinder divided by its height. The width is calculated by multiplying the radius with the centralAngle.
        /// </summary>
        public float AspectRatio { get => JSRef!.Get<float>("aspectRatio"); set => JSRef!.Set("aspectRatio", value); }
        /// <summary>
        /// A number indicating the angle in radians of the visible section of the cylinder.
        /// </summary>
        public float CentralAngle { get => JSRef!.Get<float>("centralAngle"); set => JSRef!.Set("centralAngle", value); }
        /// <summary>
        /// A number indicating the radius of the cylinder.
        /// </summary>
        public float Radius { get => JSRef!.Get<float>("radius"); set => JSRef!.Set("radius", value); }
        /// <summary>
        /// An XRSpace representing the layer's spatial relationship with the user's physical environment.
        /// </summary>
        public XRSpace Space { get => JSRef!.Get<XRSpace>("space"); set => JSRef!.Set("space", value); }
        /// <summary>
        /// An XRRigidTransform representing the offset and orientation relative to space.
        /// </summary>
        public XRRigidTransform Transform { get => JSRef!.Get<XRRigidTransform>("transform"); set => JSRef!.Set("transform", value); }
        /// <summary>
        /// Sent to the XRCylinderLayer object when the underlying resources of the layer are lost or when the XR Compositor can no longer reproject the layer. If this event is sent, authors should redraw the content of the layer in the next XR animation frame.
        /// </summary>
        public ActionEvent<XRLayerEvent> OnRedraw { get => new ActionEvent<XRLayerEvent>("redraw", AddEventListener, RemoveEventListener); set { } }
    }
}
