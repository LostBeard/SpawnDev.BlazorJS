using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Int16Array>))]
    public class Int16Array : JSObject
    {
        public Int16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
