using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;
namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/WebGLTexture
    
    public class WebGLTexture : JSObject
    {
        public WebGLTexture(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
