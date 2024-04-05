using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class JSObjectArrayConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsArray && typeToConvert.HasElementType && typeof(JSObject).IsAssignableFrom(typeToConvert.GetElementType());
        }
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var elementType = typeToConvert.GetElementType();
            var covnerterType = typeof(JSObjectArrayConverter<>).MakeGenericType(new Type[] { elementType });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
            return converter;
        }
    }
    public class JSObjectArrayConverter<T> : JsonConverter<T[]>, IJSInProcessObjectReferenceConverter where T : JSObject
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsArray && typeToConvert.HasElementType && typeof(JSObject).IsAssignableFrom(typeToConvert.GetElementType());
        }
        public override T[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            if (_ref == null) return null;
            var tmpRet = _ref.AsArray<T>();
            return tmpRet;
        }
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
