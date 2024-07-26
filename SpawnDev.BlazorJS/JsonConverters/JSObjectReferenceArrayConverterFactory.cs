using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// JSObject array JsonConverter factory
    /// </summary>
    public class JSObjectReferenceArrayConverterFactory : JsonConverterFactory
    {
        JsonSerializerOptions Options;
        /// <summary>
        /// Default constructor
        /// </summary>
        public JSObjectReferenceArrayConverterFactory(JsonSerializerOptions options)
        {
            Options = options;
        }
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsArray && typeToConvert.HasElementType)
            {
                var elementType = typeToConvert.GetElementType()!;
                var perInstanceRequired = Options.TypeDeserializationRequiresPerInstance(elementType);
                if (perInstanceRequired)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Creates a JsonConverter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var elementType = typeToConvert.GetElementType()!;
            var converterType = typeof(JSObjectArrayConverter<>).MakeGenericType(new Type[] { elementType });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, options)!;
            return converter;
        }
    }
    /// <summary>
    /// JSObject array JsonConverter
    /// </summary>
    public class JSObjectArrayConverter<T> : JSInProcessObjectReferenceConverterBase<T[]>
    {
        IJSInProcessObjectReferenceConverter? ElementConverter = null;
        /// <summary>
        /// Default constructor
        /// </summary>
        public JSObjectArrayConverter(JsonSerializerOptions options)
        {
            var elementType = typeof(T);
            var elementTypeConverter = options.GetConverter(elementType);
            if (elementTypeConverter is IJSInProcessObjectReferenceConverter jsRefConverter)
            {
                ElementConverter = jsRefConverter;
            }
        }
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override T[]? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            if (ElementConverter != null)
            {
                // read all IJSInProcessObjectReferences into .Net at once to give to the ElementConverter
                // not required but should be faster for types that support it
                var array = _ref.AsArray();
                var ret = new T[array.Length];
                for (var i = 0; i < ret.Length; i++)
                {
                    ret[i] = (T)ElementConverter.FromIJSInProcessObjectReference(array[i])!;
                }
                return ret;
            }
            else
            {
                using var array = new JSObjects.Array(_ref);
                var ret = new T[array.Length];
                for (var i = 0; i < ret.Length; i++)
                {
                    ret[i] = array.GetItem<T>(i);
                }
                return ret;
            }
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var v in value)
            {
                JsonSerializer.Serialize(writer, v, options);
            }
            writer.WriteEndArray();
        }
    }
}
