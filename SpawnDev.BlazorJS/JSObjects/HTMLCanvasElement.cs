using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

    [JsonConverter(typeof(JSObjectConverter<HTMLCanvasElement>))]
    public class HTMLCanvasElement : HTMLElement
    {
        //dynamic brush1x1 = null;
        //Uint8Array brush1x1Data = null;

        public int Width { get { var tmp = JSRef.Get<int?>("width"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef.Set("width", value); } }
        public int Height { get { var tmp = JSRef.Get<int?>("height"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef.Set("height", value); } }

        //private CanvasRenderingContext2D? _Context2D = null;

        //// lazy loaded Context2D
        //public CanvasRenderingContext2D Context2D { 
        //    get { 
        //        if (_Context2D == null)
        //        {
        //            _Context2D = GetProperty<CanvasRenderingContext2D>("getContext", "2d");
        //            _Context2D._ref.Set("imageSmoothingEnabled", false);
        //        }
        //        return _Context2D; 
        //    } 
        //}

        public HTMLCanvasElement() : base(JS.DocumentCreateElement("canvas")) { }
        public HTMLCanvasElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public HTMLCanvasElement(ElementReference canvasElementReference) : base(JS.ReturnMe<IJSInProcessObjectReference>(canvasElementReference)) { }

        public static HTMLCanvasElement Create()
        {
            var jsRef = JS.DocumentCreateElement("canvas");
            var ret = new HTMLCanvasElement();
            return ret;
        }
        public static HTMLCanvasElement Create(int width, int height)
        {
            var ret = Create();
            ret.Width = width;
            ret.Height = height;
            return ret;
        }

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

        //public byte[] GetImageData(int x, int y, int width, int height)
        //{
        //    using ImageData imageData = Context2D.GetProperty<ImageData>("getImageData", x, y, width, height);
        //    using Uint8ClampedArray data = imageData.Data;
        //    return data.ReadBytes();
        //}

        //public void PutImageData(ImageData imageData)
        //{
        //    var ctx = Context2D;
        //    ctx._ref.CallVoid("putImageData", imageData, 0, 0);
        //}

        //public void PutImageData(ImageData imageData, int x, int y)
        //{
        //    var ctx = Context2D;
        //    ctx._ref.CallVoid("putImageData", imageData, x, y);
        //}

        //public void PutImageData(ImageData imageData, int x, int y, int srcX, int srcY, int srcWidth, int srcHeight)
        //{
        //    var ctx = Context2D;
        //    ctx._ref.CallVoid("putImageData", imageData, x, y, srcX, srcY, srcWidth, srcHeight);
        //}

        //public void PutImageData(byte[] imageBytes, int x, int y, int width, int height)
        //{
        //    PutImageData(imageBytes, x, y, 0, 0, width, height);
        //}

        //public void PutImageData(byte[] imageBytes)
        //{
        //    PutImageData(imageBytes, 0, 0, 0, 0, Width, Height);
        //}

        //public void PutImageData(byte[] imageBytes, int x, int y, int srcX, int srcY, int srcWidth, int srcHeight)
        //{
        //    var ctx = Context2D;
        //    using var imageData = new ImageData(imageBytes, srcWidth, srcHeight);
        //    ctx._ref.CallVoid("putImageData", imageData, x, y, srcX, srcY, srcWidth, srcHeight);
        //}

        ////public Uint8Array Data(int x, int y, int width, int height)
        ////{
        ////    dynamic ctx = Context2D;
        ////    using (dynamic imageData = ctx.getImageData<IJSObject>(x, y, width, height))
        ////    {
        ////        return imageData.data<Uint8Array>();
        ////    }
        ////}

        //public byte[] GetImageData()
        //{
        //    return GetImageData(0, 0, Width, Height);
        //}

        //public byte[] GetPixel(int x, int y)
        //{
        //    return GetImageData(x, y, 1, 1);
        //}

        public string ToDataURL(string type = "image/png") => JSRef.Call<string>(type);
        public string ToDataURL(string type, float encoderOptions) => JSRef.Call<string>(type, encoderOptions);


        // NOTE - may not work on some browsers if not added to DOM first (even if temporary)
        public void DownloadAsImage(string fileName, bool appendToBody = false)
        {
            var dataUrl = ToDataURL();
            using(var link = JS.DocumentCreateElement("a"))
            {
                link.CallVoid("setAttribute", "download", fileName);
                link.CallVoid("setAttribute", "href", dataUrl.Replace("image/png", "image/octet-stream"));
                if (appendToBody) JS.DocumentBodyAppendChild(link);
                link.CallVoid("click");
                if (appendToBody) link.CallVoid("remove");
            }
        }

        //public override void Dispose()
        //{
        //    brush1x1Data?.Dispose();
        //    brush1x1?.Dispose();
        //    //DisposeIt(_Context2D);
        //    base.Dispose();
        //}

        //public void ClearTransparent()
        //{
        //    Width = Width;
        //}

        //public void Clear(string color = "black")
        //{
        //    dynamic context = Context2D;
        //    context.clearRect(0, 0, Width, Height);
        //    context.fillStyle = color;
        //    context.fillRect(0, 0, Width, Height);
        //}

        //public void Clear(byte r, byte g, byte b, byte a = 255)
        //{
        //    Clear(Color4ToHexString(r, g, b, a));
        //}

        //public void Clear(byte[] bytes)
        //{
        //    Clear(Color4ToHexString(bytes[0], bytes[1], bytes[2], bytes.Length > 3 ? bytes[3] : (byte)255));
        //}

        //public void FillRect(int x, int y, int width, int height, string color = null)
        //{
        //    dynamic context = Context2D;
        //    if (!string.IsNullOrEmpty(color)) context.fillStyle = color;
        //    context.fillRect(x, y, width, height);
        //}

        //public void FillEllipse(int x, int y, int radius)
        //{
        //    dynamic ctx = Context2D;
        //    ctx.beginPath();
        //    ctx.ellipse(x, y, radius, radius, 0, 0, Math.PI * 2);
        //    ctx.fill();
        //}

        public static string Color4ToHexString(byte r, byte g, byte b, byte a)
        {
            var hex = "#" + BitConverter.ToString(new byte[] { r, g, b, a }).Replace("-", "");
            return hex;
        }

        //public void FillRect(int x, int y, int width, int height, byte r, byte g, byte b, byte a)
        //{
        //    FillRect(x, y, width, height, Color4ToHexString(r, g, b, a));
        //}

        //public void DrawPixel(int x, int y, byte r, byte g, byte b, byte a = 255)
        //{
        //    FillRect(x, y, 1, 1, r, g, b, a);
        //}

        //public void DrawPixel(int x, int y, byte[] bytes)
        //{
        //    FillRect(x, y, 1, 1, bytes[0], bytes[1], bytes[2], bytes.Length >= 4 ? bytes[3] : (byte)255);
        //}

        //public void Draw(byte[] bytes)
        //{
        //    //Draw(0, 0, Width, Height, bytes);
        //    //throw new Exception("DEPRECATED!");
        //    FillRect(0, 0, Width, Height, bytes[0], bytes[1], bytes[2], bytes.Length >= 4 ? bytes[3] : (byte)255);
        //}

        //public void Draw(int x, int y, int width, int height, byte[] bytes)
        //{
        //    FillRect(x, y, width, height, bytes[0], bytes[1], bytes[2], bytes.Length >= 4 ? bytes[3] : (byte)255);
        //}

        public DOMRect GetBoundingClientRect()
        {
            return JSRef.Call<DOMRect>("getBoundingClientRect");
        }

        public int OffsetWidth => JSRef.Get<int>("offsetWidth");
        public int OffsetHeight => JSRef.Get<int>("offsetHeight");

        //public void DrawPixelOld(int x, int y, byte r, byte g, byte b, byte a)
        //{
        //    dynamic context = Context2D;
        //    if (brush1x1 == null)
        //    {
        //        brush1x1 = context.createImageData<IJSObject>(1, 1);
        //        brush1x1Data = brush1x1.data<Uint8Array>();
        //    }
        //    brush1x1Data[0] = r;
        //    brush1x1Data[1] = g;
        //    brush1x1Data[2] = b;
        //    brush1x1Data[3] = a;
        //    context.putImageData(brush1x1, x, y);
        //}
    }
}
