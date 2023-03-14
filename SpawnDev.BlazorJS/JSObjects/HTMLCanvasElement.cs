using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System;
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

    
    public class HTMLCanvasElement : HTMLElement
    {
        public int Width { get { var tmp = JSRef.Get<int?>("width"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef.Set("width", value); } }
        public int Height { get { var tmp = JSRef.Get<int?>("height"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef.Set("height", value); } }
        //public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        //public int OffsetHeight => JSRef.Get<int>("offsetHeight");

        public HTMLCanvasElement() : base(JS.DocumentCreateElement("canvas")) { }
        public HTMLCanvasElement(ElementReference canvasElementReference) : base(JS.ReturnMe<IJSInProcessObjectReference>(canvasElementReference)) { }

        public HTMLCanvasElement(int width, int height) : base(JS.DocumentCreateElement("canvas"))
        {
            Width = width;
            Height = height;
        }
        public HTMLCanvasElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        //public static HTMLCanvasElement Create()
        //{
        //    var ret = new HTMLCanvasElement(JS.DocumentCreateElement("canvas"));
        //    return ret;
        //}
        //public static HTMLCanvasElement Create(int width, int height)
        //{
        //    var ret = Create();
        //    ret.Width = width;
        //    ret.Height = height;
        //    return ret;
        //}

        public CanvasRenderingContext2D Get2DContext(ContextAttributes2D contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<CanvasRenderingContext2D>("getContext", "2d");
            return JSRef.Call<CanvasRenderingContext2D>("getContext", "2d", contextAttributes);
        }

        public WebGLRenderingContext GetWebGLContext(WebGLContextAttributes contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<WebGLRenderingContext>("getContext", "webgl");
            return JSRef.Call<WebGLRenderingContext>("getContext", "webgl", contextAttributes);
        }

        public WebGL2RenderingContext GetWebGL2Context(WebGLContextAttributes contextAttributes = null)
        {
            if (contextAttributes == null) return JSRef.Call<WebGL2RenderingContext>("getContext", "webgl2");
            return JSRef.Call<WebGL2RenderingContext>("getContext", "webgl2", contextAttributes);
        }

        public string ToDataURL(string type = "image/png") => JSRef.Call<string>(type);
        public string ToDataURL(string type, float encoderOptions) => JSRef.Call<string>(type, encoderOptions);


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
