using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters {
    public class IJSObjectArrayConverterFactory : JsonConverterFactory {
        public override bool CanConvert(Type typeToConvert) {
            return typeToConvert.IsArray && typeToConvert.HasElementType && IJSObjectConverterFactory.CanConvertType(typeToConvert.GetElementType());
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
            var elementType = typeToConvert.GetElementType();
            var covnerterType = typeof(IJSObjectArrayConverter<>).MakeGenericType(new Type[] { elementType });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
            return converter;
        }
    }

    public class IJSObjectArrayConverter<T> : JsonConverter<T[]>, IJSInProcessObjectReferenceConverter where T : class {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public IJSObjectArrayConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type typeToConvert) {
            return typeToConvert.IsArray && typeToConvert.HasElementType && IJSObjectConverterFactory.CanConvertType(typeToConvert.GetElementType());
        }
        public override T[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            using var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            if (_ref == null) return null;
            var length = _ref.Get<int>("length");
            var tmpRet = Array.CreateInstance(typeof(T), length);
            for (var i = 0; i < length; i++) {
                object? value;
                try {
                    value = _ref.Get<T>(i);
                }
                catch {
                    continue;
                }
                if (value == null) continue;
                tmpRet.SetValue(value, i);
            }
            return (T[])tmpRet;
        }
        public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options) {
            writer.WriteStartArray();
            foreach (var v in value) {
                JsonSerializer.Serialize(writer, v, options);
            }
            writer.WriteEndArray();
        }
    }
}
