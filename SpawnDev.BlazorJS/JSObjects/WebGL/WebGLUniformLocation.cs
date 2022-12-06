using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebGLUniformLocation>))]
    public class WebGLUniformLocation : JSObject
    {
        public WebGLUniformLocation(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
