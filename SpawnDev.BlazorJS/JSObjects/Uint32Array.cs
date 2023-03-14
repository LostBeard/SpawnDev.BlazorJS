using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class Uint32Array : JSObject
    {
        public Uint32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
