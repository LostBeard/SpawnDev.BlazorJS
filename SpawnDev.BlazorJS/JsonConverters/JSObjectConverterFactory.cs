using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// JSObject JsonConverter factory
    /// </summary>
    public class JSObjectConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type type)
        {
            return typeof(JSObject).IsAssignableFrom(type);
        }
        /// <summary>
        /// Creates a JsonConverter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(JSObjectConverter<>).MakeGenericType(new Type[] { typeToConvert });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
            return converter;
        }
    }
    /// <summary>
    /// JSObject JsonConverter
    /// </summary>
    public class JSObjectConverter<TJSObject> : JSInProcessObjectReferenceConverterBase<TJSObject> where TJSObject : JSObject
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override TJSObject? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            return (TJSObject?)(_ref == null ? null : Activator.CreateInstance(typeof(TJSObject), _ref));
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, TJSObject value, JsonSerializerOptions options)
        {
            var obj = value as JSObject;
            if (value.IsJSRefUndefined)
            {
                // cast to JSInProcessObjectReferenceUndefined so it gets picked up by the JSInProcessObjectReferenceUndefinedConverter
                JsonSerializer.Serialize(writer, (JSInProcessObjectReferenceUndefined)value.JSRef!, options);
            }
            else
            {
                var _ref = obj == null ? null : obj.JSRef;
                JsonSerializer.Serialize(writer, _ref, options);
            }
        }
    }
}
