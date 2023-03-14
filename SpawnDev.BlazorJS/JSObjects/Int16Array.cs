using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    
    public class Int16Array : JSObject
    {
        public Int16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
