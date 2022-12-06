using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<WebGLBuffer>))]
    public class WebGLBuffer : JSObject
    {
        public WebGLBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
