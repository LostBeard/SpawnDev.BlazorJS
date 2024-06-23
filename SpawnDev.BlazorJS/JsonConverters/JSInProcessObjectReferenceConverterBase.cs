using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// When implemented on a JsonConverter it indicates that the converter needs an IJSInProcessObjectReference whhich can be read with<br />
    /// var _ref = JsonSerializer.Deserialize&lt;IJSInProcessObjectReference?&gt;(ref reader, options)
    /// </summary>
    public interface IJSInProcessObjectReferenceConverter
    {
        object? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref);
    }
    public abstract class JSInProcessObjectReferenceConverterBase<T> : JsonConverter<T>, IJSInProcessObjectReferenceConverter
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            if (_ref == null) return default;
            return (T)(FromIJSInProcessObjectReference(_ref) ?? default);
        }
        public abstract object? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref);
    }
}
