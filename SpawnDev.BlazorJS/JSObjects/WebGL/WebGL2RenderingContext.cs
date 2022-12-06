using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebGL2RenderingContext>))]
    public class WebGL2RenderingContext : WebGLRenderingContext
    {
        public WebGL2RenderingContext(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
