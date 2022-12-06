using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebGLRenderbuffer>))]
    public class WebGLRenderbuffer : JSObject
    {
        public WebGLRenderbuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
