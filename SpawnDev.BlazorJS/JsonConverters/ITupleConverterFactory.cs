using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
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
        public override bool CanConvert(Type typeToConvert)
        {
            // ValueType is a value type and may be wrapped in Nullable<> if it is nullable(?)
            var genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            if (genericType == typeof(Nullable<>))
            {
                typeToConvert = typeToConvert.GenericTypeArguments[0];
                genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            }
            var ret = SupportedGenericTypes.Contains(genericType);
            return ret;
        }
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
    public class ITupleConverter : JSInProcessObjectReferenceConverterBase<object?>
    {
        Type ValueTupleType;
        Type ValueTupleGenericType;
        Type[] GenericTypes;
        bool IsNullable;
        object? defaultValue;
        public ITupleConverter(Type typeToConvert, Type valueTypeGenericType, bool isNullable)
        {
            ValueTupleType = typeToConvert;
            ValueTupleGenericType = valueTypeGenericType;
            IsNullable = isNullable;
            GenericTypes = ValueTupleType.GenericTypeArguments;
            defaultValue = ValueTupleType.GetDefaultValue();
        }
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
                JsonSerializer.Serialize(writer, null, options);
            }
        }
    }
}
