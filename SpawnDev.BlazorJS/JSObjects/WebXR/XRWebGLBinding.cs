using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The XRWebGLBinding interface is used to create layers that have a GPU backend.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XRWebGLBinding
    /// https://docs.w3cub.com/dom/xrwebglbinding
    /// </summary>
    public class XRWebGLBinding : JSObject
    {
        /// <inheritdoc/>
        public XRWebGLBinding(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The XRWebGLBinding() constructor creates and returns a new XRWebGLBinding object.
        /// </summary>
        /// <param name="session">An XRSession object specifying the WebXR session which will be rendered using the WebGL context.</param>
        /// <param name="context">A WebGLRenderingContext or WebGL2RenderingContext identifying the WebGL drawing context to use for rendering the scene for the specified WebXR session.</param>
        public XRWebGLBinding(XRSession session, WebGLRenderingContext context) : base(JS.New(nameof(XRWebGLBinding), session, context)) { }
        /// <summary>
        /// The read-only nativeProjectionScaleFactor property of the XRWebGLBinding interface represents the scaling factor by which the projection layer's resolution is multiplied by to get the native resolution of the WebXR device's frame buffer.
        /// </summary>
        public float NativeProjectionScaleFactor => JSRef!.Get<float>("nativeProjectionScaleFactor");
        /// <summary>
        /// The createCubeLayer() method of the XRWebGLBinding interface returns an XRCubeLayer object, which is a layer that renders directly from a cubemap, and projects it onto the inside faces of a cube.
        /// </summary>
        /// <returns></returns>
        public XRCubeLayer CreateCubeLayer(XRCubeLayerInit options) => JSRef!.Call<XRCubeLayer>("createCubeLayer", options);
        /// <summary>
        /// The createCylinderLayer() method of the XRWebGLBinding interface returns an XRCylinderLayer object, which is a layer that takes up a curved rectangular space in the virtual environment.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public XRCylinderLayer CreateCylinderLayer(XRCylinderLayerInit options) => JSRef!.Call<XRCylinderLayer>("createCylinderLayer", options);
        /// <summary>
        /// The createProjectionLayer() method of the XRWebGLBinding interface returns an XRProjectionLayer object which is a layer that fills the entire view of the observer and is refreshed close to the device's native frame rate.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public XRProjectionLayer CreateProjectionLayer(XRProjectionLayerInit options) => JSRef!.Call<XRProjectionLayer>("createProjectionLayer", options);
        /// <summary>
        /// The createQuadLayer() method of the XRWebGLBinding interface returns an XRQuadLayer object which is a layer that takes up a flat rectangular space in the virtual environment.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public XRQuadLayer CreateQuadLayer(XRQuadLayerInit options) => JSRef!.Call<XRQuadLayer>("createQuadLayer", options);
        /// <summary>
        /// The createEquirectLayer() method of the XRWebGLBinding interface returns an XREquirectLayer object, which is a layer that maps equirectangular coded data onto the inside of a sphere.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public XREquirectLayer CreateEquirectLayer(XREquirectLayerInit options) => JSRef!.Call<XREquirectLayer>("createEquirectLayer", options);
        /// <summary>
        /// Returns an XRWebGLDepthInformation object containing WebGL depth information.
        /// </summary>
        /// <returns></returns>
        public XRWebGLDepthInformation GetDepthInformation(XRView view) => JSRef!.Call<XRWebGLDepthInformation>("getDepthInformation", view);
        /// <summary>
        /// The getReflectionCubeMap() method of the XRWebGLBinding interface returns a WebGLTexture object containing a reflection cube map texture.<br/>
        /// The texture format is specified by the session's reflectionFormat. See the options parameter on XRSession.requestLightProbe() and XRSession.preferredReflectionFormat for more details. By default, the srgba8 format is used. When using a rgba16f format, you need to be within a WebGL 2.0 context or enable the OES_texture_half_float extension within WebGL 1.0 contexts.
        /// </summary>
        /// <param name="lightProbe"></param>
        /// <returns></returns>
        public WebGLTexture GetReflectionCubeMap(XRLightProbe lightProbe) => JSRef!.Call<WebGLTexture>("getReflectionCubeMap", lightProbe);
        /// <summary>
        /// The getSubImage() method of the XRWebGLBinding interface returns a XRWebGLSubImage object representing the WebGL texture to render.
        /// </summary>
        /// <param name="layer">The XRCompositionLayer to use for rendering (can be all types of XRCompositionLayer objects except XRProjectionLayer, see XRWebGLBinding.getViewSubImage() for rendering projection layers).</param>
        /// <param name="frame">The XRFrame frame to use for rendering.</param>
        /// <param name="eye">An optional XRView.eye indicating which view's eye to use for rendering. 'left', 'right', or 'none'. Defaults to none.</param>
        /// <returns>A XRWebGLSubImage object.</returns>
        public XRWebGLSubImage GetSubImage(XRCompositionLayer layer, XRFrame frame, string eye) => JSRef!.Call<XRWebGLSubImage>("getSubImage", layer, frame, eye);
        /// <summary>
        /// The getSubImage() method of the XRWebGLBinding interface returns a XRWebGLSubImage object representing the WebGL texture to render.
        /// </summary>
        /// <param name="layer">The XRCompositionLayer to use for rendering (can be all types of XRCompositionLayer objects except XRProjectionLayer, see XRWebGLBinding.getViewSubImage() for rendering projection layers).</param>
        /// <param name="frame">The XRFrame frame to use for rendering.</param>
        /// <returns>A XRWebGLSubImage object.</returns>
        public XRWebGLSubImage GetSubImage(XRCompositionLayer layer, XRFrame frame) => JSRef!.Call<XRWebGLSubImage>("getSubImage", layer, frame);
        /// <summary>
        /// The getViewSubImage() method of the XRWebGLBinding interface returns a XRWebGLSubImage object representing the WebGL texture to render for a view.
        /// </summary>
        /// <param name="layer">The XRProjectionLayer to use for rendering (to render other layer types, see XRWebGLBinding.getSubImage()).</param>
        /// <param name="view">The XRView to use for rendering.</param>
        /// <returns>A XRWebGLSubImage object.</returns>
        public XRWebGLSubImage GetViewSubImage(XRProjectionLayer layer, XRView view) => JSRef!.Call<XRWebGLSubImage>("getViewSubImage", layer, view);
    }
}
