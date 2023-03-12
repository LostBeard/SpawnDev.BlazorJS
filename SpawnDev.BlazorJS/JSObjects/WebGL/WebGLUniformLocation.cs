using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebGLUniformLocation>))]
    public class WebGLUniformLocation : JSObject
    {
        public WebGLUniformLocation(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
