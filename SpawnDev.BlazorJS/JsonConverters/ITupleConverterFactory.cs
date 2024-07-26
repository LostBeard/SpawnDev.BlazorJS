using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// ITuple JsonConverter factory
    /// </summary>
    public class ITupleConverterFactory : JsonConverterFactory
    {
        static List<Type> SupportedGenericTypes = new List<Type> {
            { typeof(ValueTuple<>) },
            { typeof(ValueTuple<,>) },
            { typeof(ValueTuple<,,>) },
            { typeof(ValueTuple<,,,>) },
            { typeof(ValueTuple<,,,,>) },
            { typeof(ValueTuple<,,,,,>) },
            { typeof(ValueTuple<,,,,,,>) },
            { typeof(Tuple<>) },
            { typeof(Tuple<,>) },
            { typeof(Tuple<,,>) },
            { typeof(Tuple<,,,>) },
            { typeof(Tuple<,,,,>) },
            { typeof(Tuple<,,,,,>) },
            { typeof(Tuple<,,,,,,>) },
        };
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            // ValueType is a value type and may be wrapped in Nullable<> if it is nullable(?)
            var genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            if (genericType == typeof(Nullable<>))
            {
                typeToConvert = typeToConvert.GenericTypeArguments[0];
                genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            }
            return genericType != null && SupportedGenericTypes.Contains(genericType);
        }
        /// <summary>
        /// Creates a JsonConverter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var isNullable = false;
            var genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            if (genericType == typeof(Nullable<>))
            {
                isNullable = true;
                typeToConvert = typeToConvert.GenericTypeArguments[0];
                genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            }
            return new ITupleConverter(typeToConvert, genericType!, isNullable);
        }
    }
    /// <summary>
    /// ITuple JsonConverter
    /// </summary>
    public class ITupleConverter : JSInProcessObjectReferenceConverterBase<object?>
    {
        Type ValueTupleType;
        Type ValueTupleGenericType;
        Type[] GenericTypes;
        bool IsNullable;
        object? defaultValue;
        /// <summary>
        /// Default constructor
        /// </summary>
        public ITupleConverter(Type typeToConvert, Type valueTypeGenericType, bool isNullable)
        {
            ValueTupleType = typeToConvert;
            ValueTupleGenericType = valueTypeGenericType;
            IsNullable = isNullable;
            GenericTypes = ValueTupleType.GenericTypeArguments;
            defaultValue = ValueTupleType.GetDefaultValue();
        }
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override object? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null)
            {
                return ValueTupleType.GetDefaultValue();
            }
            using var array = new JSObjects.Array(_ref);
            var list = new object?[GenericTypes.Length];
            for (var i = 0; i < GenericTypes.Length; i++)
            {
                list[i] = array.GetItem(GenericTypes[i], i);
            }
            var ret = Activator.CreateInstance(ValueTupleType, list)!;
            return ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            if (value != null && value is ITuple tuple)
            {
                writer.WriteStartArray();
                for (var i = 0; i < tuple.Length; i++)
                {
                    JsonSerializer.Serialize(writer, tuple[i], options);
                }
                writer.WriteEndArray();
            }
            else
            {
                JsonSerializer.Serialize(writer, (object?)null, options);
            }
        }
    }
}
