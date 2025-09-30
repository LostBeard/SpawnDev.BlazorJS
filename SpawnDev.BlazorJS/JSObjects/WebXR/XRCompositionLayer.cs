using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRCompositionLayer interface of the WebXR Device API is a base class that defines a set of common properties and behaviors for WebXR layer types. It is not constructable on its own.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRCompositionLayer
    /// https://www.w3.org/TR/webxrlayers-1/#xrcompositionlayertype
    /// </summary>
    public class XRCompositionLayer : XRLayer
    {
        /// <inheritdoc/>
        public XRCompositionLayer(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean enabling the layer's texture alpha channel.
        /// </summary>
        public bool BlendTextureSourceAlpha { get => JSRef!.Get<bool>("blendTextureSourceAlpha"); set => JSRef!.Set("blendTextureSourceAlpha", value); }
        /// <summary>
        /// The read-only layout property of the XRCompositionLayer interface is the layout type of the layer.<br/>
        /// default<br/>
        /// The layer accommodates all views of the session.It is recommended to use the texture-array texture type for default layouts.<br/>
        /// mono<br/>
        /// A single XRSubImage is allocated and presented to both eyes.<br/>
        /// stereo<br/>
        /// The user agent decides how it allocates the XRSubImage (one or two) and the layout(top/bottom or left/right). It is recommended to use the texture-array texture type for stereo layouts.<br/>
        /// stereo-left-right<br/>
        /// A single XRSubImage is allocated.Left eye gets the left area of the texture, right eye the right. This layout is designed to minimize draw calls for content that is already in stereo (for example stereo videos or images).<br/>
        /// stereo-top-bottom<br/>
        /// A single XRSubImage is allocated.Left eye gets the top area of the texture, right eye the bottom.This layout is designed to minimize draw calls for content that is already in stereo (for example stereo videos or images).
        /// </summary>
        public string Layout => JSRef!.Get<string>("layout");
        /// <summary>
        /// The number of mip levels in the color and texture data for the layer.
        /// </summary>
        public int MipLevels => JSRef!.Get<int>("mipLevels");
        /// <summary>
        /// A boolean signaling that the layer should be re-rendered in the next frame.
        /// </summary>
        public int NeedsRedraw => JSRef!.Get<int>("needsRedraw");
        /// <summary>
        /// Deletes the underlying layer attachments.
        /// </summary>
        public void Destroy() => JSRef!.CallVoid("destroy");
    }
}
