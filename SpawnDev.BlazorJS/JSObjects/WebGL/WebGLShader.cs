using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/WebGLShader
    
    public class WebGLShader : JSObject
    {
        public WebGLShader(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
