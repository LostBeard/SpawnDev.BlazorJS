using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class WebGLFramebuffer : JSObject
    {
        public WebGLFramebuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
