using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ContextAttributes2D
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Alpha { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Desynchronized { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WillReadFrequently { get; set; } = null;
    }

    public class WebGLContextAttributes
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Alpha { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Desynchronized { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Antialias { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Depth { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FailIfMajorPerformanceCaveat { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PowerPreference { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PremultipliedAlpha { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreserveDrawingBuffer { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Stencil { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? XrCompatible { get; set; } = null;
    }

    /// <summary>
    /// The HTMLCanvasElement interface provides properties and methods for manipulating the layout and presentation of &lt;canvas&gt; elements. The HTMLCanvasElement interface also inherits the properties and methods of the HTMLElement interface.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement
    /// </summary>
    public class HTMLCanvasElement : HTMLElement
    {
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
        /// <param name="canvasElementReference"></param>
        public HTMLCanvasElement(ElementReference canvasElementReference) : base(canvasElementReference) { }
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
        public int Width { get => JSRef.Get<int?>("width") ?? 0; set => JSRef.Set("width", value); }
        /// <summary>
        /// The height HTML attribute of the &lt;canvas&gt; element is a non-negative integer reflecting the number of logical pixels (or RGBA values) going down one column of the canvas. When the attribute is not specified, or if it is set to an invalid value, like a negative, the default value of 150 is used. If no [separate] CSS height is assigned to the &lt;canvas&gt;, then this value will also be used as the height of the canvas in the length-unit CSS Pixel.
        /// </summary>
        public int Height { get => JSRef.Get<int?>("height") ?? 0; set => JSRef.Set("height", value); }
        #endregion

        
        public CanvasRenderingContext2D Get2DContext(ContextAttributes2D? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<CanvasRenderingContext2D>("getContext", "2d");
            return JSRef.Call<CanvasRenderingContext2D>("getContext", "2d", contextAttributes);
        }

        public WebGLRenderingContext GetWebGLContext(WebGLContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<WebGLRenderingContext>("getContext", "webgl");
            return JSRef.Call<WebGLRenderingContext>("getContext", "webgl", contextAttributes);
        }

        public WebGL2RenderingContext GetWebGL2Context(WebGLContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<WebGL2RenderingContext>("getContext", "webgl2");
            return JSRef.Call<WebGL2RenderingContext>("getContext", "webgl2", contextAttributes);
        }


        public GPUCanvasContext GetWebGPUContext(WebGPUContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<GPUCanvasContext>("getContext", "webgpu");
            return JSRef.Call<GPUCanvasContext>("getContext", "webgpu", contextAttributes);
        }

        public ImageBitmapRenderingContext GetImageBitmapRenderingContext(ImageBitmapRenderingContextAttributes? contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<ImageBitmapRenderingContext>("getContext", "bitmaprenderer");
            return JSRef.Call<ImageBitmapRenderingContext>("getContext", "bitmaprenderer", contextAttributes);
        }




        /// <summary>
        /// Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ToDataURL(string type = "image/png") => JSRef.Call<string>("toDataURL", type);
        /// <summary>
        /// Returns a data-URL containing a representation of the image in the format specified by the type parameter (defaults to png). The returned image is in a resolution of 96dpi.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="encoderOptions"></param>
        /// <returns></returns>
        public string ToDataURL(string type, float encoderOptions) => JSRef.Call<string>("toDataURL", type, encoderOptions);


        // NOTE - may not work on some browsers if not added to DOM first (even if temporary)
        public void DownloadAsImage(string fileName, bool appendToBody = false)
        {
            var dataUrl = ToDataURL();
            using (var link = JS.DocumentCreateElement("a"))
            {
                link.CallVoid("setAttribute", "download", fileName);
                link.CallVoid("setAttribute", "href", dataUrl.Replace("image/png", "image/octet-stream"));
                if (appendToBody) JS.DocumentBodyAppendChild(link);
                link.CallVoid("click");
                if (appendToBody) link.CallVoid("remove");
            }
        }

        public static string Color4ToHexString(byte r, byte g, byte b, byte a)
        {
            var hex = "#" + BitConverter.ToString(new byte[] { r, g, b, a }).Replace("-", "");
            return hex;
        }
    }
}
