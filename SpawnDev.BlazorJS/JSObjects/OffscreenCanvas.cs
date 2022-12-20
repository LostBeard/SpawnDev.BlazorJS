using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<OffscreenCanvas>))]
    public class OffscreenCanvas : JSObject
    {
        public OffscreenCanvas(int width, int height) : base(JS.New(nameof(OffscreenCanvas), width, height)) { }
        public OffscreenCanvas(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int Width { get { var tmp = JSRef.Get<int?>("width"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef.Set("width", value); } }
        public int Height { get { var tmp = JSRef.Get<int?>("height"); return tmp.HasValue ? tmp.Value : 0; } set { JSRef.Set("height", value); } }

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
    }
}
