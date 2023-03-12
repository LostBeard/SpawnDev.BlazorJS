using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Int8Array>))]
    public class Int8Array : JSObject
    {
        public Int8Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
