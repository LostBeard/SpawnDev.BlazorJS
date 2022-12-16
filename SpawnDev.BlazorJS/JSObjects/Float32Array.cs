using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    [JsonConverter(typeof(JSObjectConverter<Float32Array>))]
    public class Float32Array : JSObject
    {
        public Float32Array(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Float32Array(float[] data) : base(JS.New(nameof(Float32Array), data)) { }
    }
}