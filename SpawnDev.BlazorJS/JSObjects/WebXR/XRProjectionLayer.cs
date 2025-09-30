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
        /// <summary>
        /// A number indicating the amount of foveation used by the XR compositor for the layer. Fixed Foveated Rendering (FFR) renders the edges of the eye textures at a lower resolution than the center and reduces the GPU load.
        /// </summary>
        public float FixedFoveation { get => JSRef!.Get<float>("fixedFoveation"); set => JSRef!.Set("fixedFoveation", value); }
        /// <summary>
        /// A boolean indicating that the XR compositor is not making use of depth buffer values when rendering the layer.
        /// </summary>
        public bool IgnoreDepthValues => JSRef!.Get<bool>("ignoreDepthValues");
        /// <summary>
        /// The layer's layer count for array textures when using texture-array as the textureType.
        /// </summary>
        public int TextureArrayLength => JSRef!.Get<int>("textureArrayLength");
        /// <summary>
        /// The height in pixels of the color textures of this layer.
        /// </summary>
        public int TextureHeight => JSRef!.Get<int>("textureHeight");
        /// <summary>
        /// The width in pixels of the color textures of this layer.
        /// </summary>
        public int TextureWidth => JSRef!.Get<int>("textureWidth");
    }
}
