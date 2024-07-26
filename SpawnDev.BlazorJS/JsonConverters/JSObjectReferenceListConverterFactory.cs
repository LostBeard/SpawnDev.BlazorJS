using Microsoft.JSInterop;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// JSObject List JsonConverter factory
    /// </summary>
    public class JSObjectReferenceListConverterFactory : JsonConverterFactory
    {
        JsonSerializerOptions Options;
        /// <summary>
        /// Default constructor
        /// </summary>
        public JSObjectReferenceListConverterFactory(JsonSerializerOptions options)
        {
            Options = options;
        }
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsGenericType)
            {
                var baseType = typeToConvert.GetGenericTypeDefinition();
                if (baseType == typeof(List<>))
                {
                    var elementType = typeToConvert.GetGenericArguments().First();
                    var perInstanceRequired = Options.TypeDeserializationRequiresPerInstance(elementType);
                    if (perInstanceRequired)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var elementType = typeToConvert.GetGenericArguments().First();
            var converterType = typeof(JSObjectListConverter<>).MakeGenericType(new Type[] { elementType });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, options)!;
            return converter;
        }
    }
    /// <summary>
    /// JSObject List JsonConverter
    /// </summary>
    public class JSObjectListConverter<T> : JSInProcessObjectReferenceConverterBase<List<T>>
    {
        IJSInProcessObjectReferenceConverter? ElementConverter = null;
        /// <summary>
        /// Default constructor
        /// </summary>
        public JSObjectListConverter(JsonSerializerOptions options)
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
        public override List<T>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
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
                return ret.ToList();
            }
            else
            {
                using var array = new JSObjects.Array(_ref);
                var ret = new T[array.Length];
                for (var i = 0; i < ret.Length; i++)
                {
                    ret[i] = array.GetItem<T>(i);
                }
                return ret.ToList();
            }
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
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
