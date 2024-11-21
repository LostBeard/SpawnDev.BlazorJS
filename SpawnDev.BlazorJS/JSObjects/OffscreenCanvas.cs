using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The OffscreenCanvas interface provides a canvas that can be rendered off screen, decoupling the DOM and the Canvas API so that the canvas element is no longer entirely dependent on the DOM. Rendering operations can also be run inside a worker context, allowing you to run some tasks in a separate thread and avoid heavy work on the main thread.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/OffscreenCanvas
    /// </summary>
    [Transferable(TransferRequired = true)]
    public class OffscreenCanvas : EventTarget
    {
        /// <summary>
        /// Returns true if OffscreenCanvas appears to be supported
        /// </summary>
        public static bool Supported => BlazorJSRuntime.JS?.IsUndefined("OffscreenCanvas") == false;
        #region Constructors
        /// <summary>
        /// The OffscreenCanvas() constructor returns a newly instantiated OffscreenCanvas object.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public OffscreenCanvas(int width, int height) : base(JS.New(nameof(OffscreenCanvas), width, height)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public OffscreenCanvas(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion

        #region Properties
        /// <summary>
        /// The width of the offscreen canvas.
        /// </summary>
        public int Width { get { var tmp = JSRef!.Get<int?>("width"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef!.Set("width", value); } }
        /// <summary>
        /// The height of the offscreen canvas.
        /// </summary>
        public int Height { get { var tmp = JSRef!.Get<int?>("height"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef!.Set("height", value); } }
        #endregion

        #region Methods
        /// <summary>
        /// Calls offscreenCanvas.getContext("2d"), leading to the creation of a CanvasRenderingContext2D object representing a two-dimensional rendering context.
        /// </summary>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public CanvasRenderingContext2D Get2DContext(ContextAttributes2D? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<CanvasRenderingContext2D>("getContext", "2d");
            return JSRef!.Call<CanvasRenderingContext2D>("getContext", "2d", contextAttributes);
        }
        /// <summary>
        /// Calls offscreenCanvas.getContext("webgl") which will create a WebGLRenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 1 (OpenGL ES 2.0).
        /// </summary>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public WebGLRenderingContext GetWebGLContext(WebGLContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<WebGLRenderingContext>("getContext", "webgl");
            return JSRef!.Call<WebGLRenderingContext>("getContext", "webgl", contextAttributes);
        }
        /// <summary>
        /// Calls offscreenCanvas.getContext("webgl2") which will create a WebGL2RenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 2 (OpenGL ES 3.0). 
        /// </summary>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public WebGL2RenderingContext GetWebGL2Context(WebGLContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<WebGL2RenderingContext>("getContext", "webgl2");
            return JSRef!.Call<WebGL2RenderingContext>("getContext", "webgl2", contextAttributes);
        }
        /// <summary>
        /// Calls offscreenCanvas.getContext("webgpu") which will create a GPUCanvasContext object representing a three-dimensional rendering context for WebGPU render pipelines. This context is only available on browsers that implement The WebGPU API.
        /// </summary>
        /// <returns></returns>
        public GPUCanvasContext GetWebGPUContext() => JSRef!.Call<GPUCanvasContext>("getContext", "webgpu");
        /// <summary>
        /// Calls offscreenCanvas.getContext("bitmaprenderer") which will create an ImageBitmapRenderingContext which only provides functionality to replace the content of the offscreenCanvas with a given ImageBitmap.
        /// </summary>
        /// <returns></returns>
        public ImageBitmapRenderingContext GetImageBitmapRenderingContext() => JSRef!.Call<ImageBitmapRenderingContext>("getContext", "bitmaprenderer");
        /// <summary>
        /// Creates a Blob object representing the image contained in the canvas.
        /// </summary>
        /// <returns></returns>
        public Task<Blob> ConvertToBlob() => JSRef!.CallAsync<Blob>("convertToBlob");
        /// <summary>
        /// Creates a Blob object representing the image contained in the canvas.
        /// </summary>
        /// <param name="options">An object with the following properties: type and quality</param>
        /// <returns></returns>
        public Task<Blob> ConvertToBlob(object options) => JSRef!.CallAsync<Blob>("convertToBlob", options);
        /// <summary>
        /// Creates an ImageBitmap object from the most recently rendered image of the OffscreenCanvas. See the API description for important notes on managing this ImageBitmap.
        /// </summary>
        /// <returns></returns>
        public ImageBitmap TransferToImageBitmap() => JSRef!.Call<ImageBitmap>("transferToImageBitmap");
        #endregion

        #region Events
        /// <summary>
        /// Fired if the user agent detects that the backing storage associated with a CanvasRenderingContext2D context is lost. 
        /// </summary>
        public ActionEvent<Event> OnContextLost { get => new ActionEvent<Event>("contextlost", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired if the user agent restores the backing storage for a CanvasRenderingContext2D.
        /// </summary>
        public ActionEvent<Event> OnContextRestored { get => new ActionEvent<Event>("contextrestored", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
