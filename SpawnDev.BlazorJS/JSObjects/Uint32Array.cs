using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Uint32Array>))]
    public class Uint32Array : JSObject
    {
        public Uint32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
