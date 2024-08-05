using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// When implemented on a JsonConverter it indicates that the converter needs an IJSInProcessObjectReference which can be read with<br />
    /// var _ref = JsonSerializer.Deserialize&lt;IJSInProcessObjectReference?&gt;(ref reader, options)
    /// </summary>
    public interface IJSInProcessObjectReferenceConverter
    {
        /// <summary>
        /// Method that converts an IJSInProcessObjectReference to the target type
        /// </summary>
        object? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref);
    }
    /// <summary>
    /// JsonConverter base class for converters that require a IJSInProcessObjectReference handle
    /// </summary>
    public abstract class JSInProcessObjectReferenceConverterBase<T> : JsonConverter<T>, IJSInProcessObjectReferenceConverter
    {
        /// <summary>
        /// Reads the target type from the Json reader
        /// </summary>
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            if (_ref == null) return default!;
            return (T)(FromIJSInProcessObjectReference(_ref) ?? default(T))!;
        }
        /// <summary>
        /// If the IJSInProcessObjectReference may be null, use this method instead of FromIJSInProcessObjectReference
        /// </summary>
        public T? FromIJSInProcessObjectReferenceSafe(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default!;
            return (T)(FromIJSInProcessObjectReference(_ref) ?? default(T))!;
        }
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type<br/>
        /// _ref should not be null
        /// </summary>
        public abstract object? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref);
    }
}
