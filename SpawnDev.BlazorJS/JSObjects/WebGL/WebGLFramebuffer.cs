using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebGLFramebuffer>))]
    public class WebGLFramebuffer : JSObject
    {
        public WebGLFramebuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
