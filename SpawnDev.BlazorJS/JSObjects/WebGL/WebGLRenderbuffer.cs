using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class WebGLRenderbuffer : JSObject
    {
        public WebGLRenderbuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
