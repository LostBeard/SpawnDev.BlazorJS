using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Uint16Array>))]
    public class Uint16Array : JSObject
    {
        public Uint16Array(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
