using System.Text.Json.Serialization;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Int32Array>))]
    public class Int32Array : JSObject
    {
        public Int32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
