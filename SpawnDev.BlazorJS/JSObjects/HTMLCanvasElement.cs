using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.IJSInProcessObjectReferenceAnyKey;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLCanvasElement interface provides properties and methods for manipulating the layout and presentation of &lt;canvas&gt; elements. The HTMLCanvasElement interface also inherits the properties and methods of the HTMLElement interface.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement
    /// </summary>
    public class HTMLCanvasElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLCanvasElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLCanvasElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLCanvasElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLCanvasElement(elementReference.Value);
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLCanvasElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new HTMLCanvasElement using Document.CreateElement
        /// </summary>
        public HTMLCanvasElement() : base(JS.DocumentCreateElement("canvas")) { }
        /// <summary>
        /// Creates a new HTMLCanvasElement from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLCanvasElement(ElementReference elementReference) : base(elementReference) { }
        /// <summary>
        /// Creates a new HTMLCanvasElement using Document.CreateElement and sets the initial width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public HTMLCanvasElement(int width, int height) : base(JS.DocumentCreateElement("canvas"))
        {
            Width = width;
            Height = height;
        }
        #endregion

        #region Properties
        /// <summary>
        /// The width HTML attribute of the &lt;canvas&gt; element is a non-negative integer reflecting the number of logical pixels (or RGBA values) going across one row of the canvas. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 300 is used. If no [separate] CSS width is assigned to the &lt;canvas&gt;, then this value will also be used as the width of the canvas in the length-unit CSS Pixel.
        /// </summary>
        public int Width { get => JSRef!.Get<int?>("width") ?? 0; set => JSRef!.Set("width", value); }
        /// <summary>
        /// The height HTML attribute of the &lt;canvas&gt; element is a non-negative integer reflecting the number of logical pixels (or RGBA values) going down one column of the canvas. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 150 is used. If no [separate] CSS height is assigned to the &lt;canvas&gt;, then this value will also be used as the height of the canvas in the length-unit CSS Pixel.
        /// </summary>
        public int Height { get => JSRef!.Get<int?>("height") ?? 0; set => JSRef!.Set("height", value); }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a drawing context on the canvas, or null if the context identifier is not supported, or the canvas has already been set to a different context mode.
        /// </summary>
        /// <typeparam name="TContext">The context type to return</typeparam>
        /// <param name="contextType">A string containing the context identifier defining the drawing context associated to the canvas.</param>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public TContext? GetContext<TContext>(string contextType, object? contextAttributes = null) where TContext : JSObject =>
            contextAttributes == null ? JSRef!.Call<TContext?>("getContext", contextType) : JSRef!.Call<TContext?>("getContext", contextType, contextAttributes);
        /// <summary>
        /// Calls canvas.getContext("bitmaprenderer"), leading to the creation of a ImageBitmapRenderingContextSettings object.
        /// </summary>
        /// <param name="contextAttributes">optional context settings</param>
        /// <returns></returns>
        public ImageBitmapRenderingContext GetImageBitmapRenderingContext(ImageBitmapRenderingContextSettings? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<ImageBitmapRenderingContext>("getContext", "bitmaprenderer");
            return JSRef!.Call<ImageBitmapRenderingContext>("getContext", "bitmaprenderer", contextAttributes);
        }
        /// <summary>
        /// Calls canvas.getContext("2d"), leading to the creation of a CanvasRenderingContext2D object representing a two-dimensional rendering context.
        /// </summary>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public CanvasRenderingContext2D Get2DContext(CanvasRenderingContext2DSettings? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<CanvasRenderingContext2D>("getContext", "2d");
            return JSRef!.Call<CanvasRenderingContext2D>("getContext", "2d", contextAttributes);
        }
        /// <summary>
        /// Calls canvas.getContext("webgl") which will create a WebGLRenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 1 (OpenGL ES 2.0).
        /// </summary>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public WebGLRenderingContext GetWebGLContext(WebGLContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<WebGLRenderingContext>("getContext", "webgl");
            return JSRef!.Call<WebGLRenderingContext>("getContext", "webgl", contextAttributes);
        }
        /// <summary>
        /// Calls canvas.getContext("webgl2") which will create a WebGL2RenderingContext object representing a three-dimensional rendering context. This context is only available on browsers that implement WebGL version 2 (OpenGL ES 3.0). 
        /// </summary>
        /// <param name="contextAttributes"></param>
        /// <returns></returns>
        public WebGL2RenderingContext GetWebGL2Context(WebGLContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef!.Call<WebGL2RenderingContext>("getContext", "webgl2");
            return JSRef!.Call<WebGL2RenderingContext>("getContext", "webgl2", contextAttributes);
        }
        /// <summary>
        /// Calls canvas.getContext("webgpu") which will create a GPUCanvasContext object representing a three-dimensional rendering context for WebGPU render pipelines. This context is only available on browsers that implement The WebGPU API.
        /// </summary>
        /// <returns></returns>
        public GPUCanvasContext GetWebGPUContext() => JSRef!.Call<GPUCanvasContext>("getContext", "webgpu");
        /// <summary>
        /// Calls canvas.getContext("bitmaprenderer") which will create an ImageBitmapRenderingContext which only provides functionality to replace the content of the canvas with a given ImageBitmap.
        /// </summary>
        /// <returns></returns>
        public ImageBitmapRenderingContext GetImageBitmapRenderingContext() => JSRef!.Call<ImageBitmapRenderingContext>("getContext", "bitmaprenderer");
        /// <summary>
        /// Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ToDataURL(string type = "image/png") => JSRef!.Call<string>("toDataURL", type);
        /// <summary>
        /// Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="encoderOptions"></param>
        /// <returns></returns>
        public string ToDataURL(string type, float encoderOptions) => JSRef!.Call<string>("toDataURL", type, encoderOptions);
        /// <summary>
        /// The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent.<br/>
        /// The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp.<br/>
        /// The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata.
        /// </summary>
        /// <param name="callback">A callback function with the resulting Blob object as a single argument. null may be passed if the image cannot be created for any reason.</param>
        public void ToBlob(ActionCallback<Blob?> callback) => JSRef!.CallVoid("toBlob", callback);
        /// <summary>
        /// The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent.<br/>
        /// The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp.<br/>
        /// The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata.
        /// </summary>
        /// <param name="callback">A callback function with the resulting Blob object as a single argument. null may be passed if the image cannot be created for any reason.</param>
        /// <param name="type">A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported.</param>
        public void ToBlob(ActionCallback<Blob?> callback, string type) => JSRef!.CallVoid("toBlob", callback, type);
        /// <summary>
        /// The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent.<br/>
        /// The desired file format and image quality may be specified. If the file format is not specified, or if the given format is not supported, then the data will be exported as image/png. Browsers are required to support image/png; many will support additional formats including image/jpeg and image/webp.<br/>
        /// The created image will have a resolution of 96dpi for file formats that support encoding resolution metadata.
        /// </summary>
        /// <param name="callback">A callback function with the resulting Blob object as a single argument. null may be passed if the image cannot be created for any reason.</param>
        /// <param name="type">A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported.</param>
        /// <param name="quality">A Number between 0 and 1 indicating the image quality to be used when creating images using file formats that support lossy compression (such as image/jpeg or image/webp). A user agent will use its default quality value if this option is not specified, or if the number is outside the allowed range.</param>
        public void ToBlob(ActionCallback<Blob?> callback, string type, float quality) => JSRef!.CallVoid("toBlob", callback, type, quality);
        /// <summary>
        /// The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent.<br/>
        /// </summary>
        /// <returns>The resulting blob</returns>
        public async Task<Blob> ToBlobAsync()
        {
            var tcs = new TaskCompletionSource<Blob>();
            using var callback = new ActionCallback<Blob?>((blob) =>
            {
                if (blob == null)
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                else
                {
                    tcs.TrySetResult(blob);
                }
            });
            ToBlob(callback!);
            return await tcs.Task;
        }
        /// <summary>
        /// The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent.<br/>
        /// </summary>
        /// <param name="type">A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported.</param>
        /// <returns>The resulting blob</returns>
        public async Task<Blob> ToBlobAsync(string type)
        {
            var tcs = new TaskCompletionSource<Blob>();
            using var callback = new ActionCallback<Blob?>((blob) =>
            {
                if (blob == null)
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                else
                {
                    tcs.TrySetResult(blob);
                }
            });
            ToBlob(callback!, type);
            return await tcs.Task;
        }
        /// <summary>
        /// The HTMLCanvasElement.toBlob() method creates a Blob object representing the image contained in the canvas. This file may be cached on the disk or stored in memory at the discretion of the user agent.<br/>
        /// </summary>
        /// <param name="type">A string indicating the image format. The default type is image/png; that type is also used if the given type isn't supported.</param>
        /// <param name="quality">A Number between 0 and 1 indicating the image quality to be used when creating images using file formats that support lossy compression (such as image/jpeg or image/webp). A user agent will use its default quality value if this option is not specified, or if the number is outside the allowed range.</param>
        /// <returns>The resulting blob</returns>
        public async Task<Blob> ToBlobAsync(string type, float quality)
        {
            var tcs = new TaskCompletionSource<Blob>();
            using var callback = new ActionCallback<Blob?>((blob) =>
            {
                if (blob == null)
                {
                    tcs.TrySetException(new Exception("Failed"));
                }
                else
                {
                    tcs.TrySetResult(blob);
                }
            });
            ToBlob(callback!, type, quality);
            return await tcs.Task;
        }
        /// <summary>
        /// The HTMLCanvasElement.transferControlToOffscreen() method transfers control to an OffscreenCanvas object, either on the main thread or on a worker.
        /// </summary>
        /// <returns></returns>
        public OffscreenCanvas TransferControlToOffscreen() => JSRef!.Call<OffscreenCanvas>("transferControlToOffscreen");

        // Non-standard methods
        // NOTE - may not work on some browsers if not added to DOM first (even if temporary)
        public void DownloadAsImage(string fileName, bool appendToBody = false)
        {
            var dataUrl = ToDataURL();
            using var link = JS.DocumentCreateElement<HTMLAnchorElement>("a");
            link.SetAttribute("download", fileName);
            link.SetAttribute("href", dataUrl.Replace("image/png", "image/octet-stream"));
            if (appendToBody) JS.DocumentBodyAppendChild(link);
            link.Click();
            if (appendToBody) link.Remove();
        }

        public static string Color4ToHexString(byte r, byte g, byte b, byte a)
        {
            var hex = "#" + BitConverter.ToString(new byte[] { r, g, b, a }).Replace("-", "");
            return hex;
        }
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
