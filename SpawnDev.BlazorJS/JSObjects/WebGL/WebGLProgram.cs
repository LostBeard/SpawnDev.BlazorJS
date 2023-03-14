using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class WebGLProgram : JSObject
    {
        public WebGLProgram(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
