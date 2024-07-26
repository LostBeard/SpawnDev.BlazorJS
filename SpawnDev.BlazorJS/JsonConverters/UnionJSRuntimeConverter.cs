using Microsoft.JSInterop;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Union JsonConverter
    /// </summary>
    public class UnionJSRuntimeConverter : JSInProcessObjectReferenceConverterBase<Union>
    {
        Type TypeToConvert;
        Type[] UnionTypes;
        /// <summary>
        /// Default constructor
        /// </summary>
        public UnionJSRuntimeConverter(Type typeToConvert)
        {
            TypeToConvert = typeToConvert;
            UnionTypes = UnionConverter.GetUnionTypeGenericTypes(TypeToConvert)!;
        }
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Union? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(_ref, UnionTypes);
            if (value == null) return null;
            var ret = Activator.CreateInstance(TypeToConvert, value)!;
            return (Union)ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Union value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}
