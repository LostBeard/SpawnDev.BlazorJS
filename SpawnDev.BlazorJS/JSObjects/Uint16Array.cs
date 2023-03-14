using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class Uint16Array : JSObject
    {
        public Uint16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
