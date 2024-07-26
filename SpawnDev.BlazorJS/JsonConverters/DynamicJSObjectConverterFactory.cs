using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// DynamicJSObject JsonConverter factory
    /// </summary>
    public class DynamicJSObjectConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if this converter can convert the specified type
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(DynamicJSObject);
        }
        /// <summary>
        /// Returns a new JsonConverter
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new DynamicJSObjectConverter();
        }
    }
    /// <summary>
    /// DynamicJSObject JsonConverter
    /// </summary>
    public class DynamicJSObjectConverter : JSInProcessObjectReferenceConverterBase<DynamicJSObject>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override DynamicJSObject? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            return _ref == null ? null : new DynamicJSObject(_ref);
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DynamicJSObject value, JsonSerializerOptions options)
        {
            var obj = value.JSObjectRef;
            if (obj.IsJSRefUndefined)
            {
                // cast to JSInProcessObjectReferenceUndefined so it gets picked up by the JSInProcessObjectReferenceUndefinedConverter
                JsonSerializer.Serialize(writer, (JSInProcessObjectReferenceUndefined)obj.JSRef!, options);
            }
            else
            {
                var _ref = obj == null ? null : obj.JSRef;
                JsonSerializer.Serialize(writer, _ref, options);
            }
        }
    }
}
