using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop.Implementation;

namespace SpawnDev.BlazorJS.JsonConverters {
    public class JSObjectArrayConverterFactory : JsonConverterFactory {
        public override bool CanConvert(Type typeToConvert) {
            return typeToConvert.IsArray && typeToConvert.HasElementType && typeof(JSObject).IsAssignableFrom(typeToConvert.GetElementType());
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
            var elementType = typeToConvert.GetElementType();
            var covnerterType = typeof(JSObjectArrayConverter<>).MakeGenericType(new Type[] { elementType });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
            return converter;
        }
    }

    public class JSObjectArrayConverter<T> : JsonConverter<T[]>, IJSInProcessObjectReferenceConverter where T : JSObject {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public JSObjectArrayConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type typeToConvert) {
            return typeToConvert.IsArray && typeToConvert.HasElementType && typeof(JSObject).IsAssignableFrom(typeToConvert.GetElementType());
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
            foreach(var v in value) {
                JsonSerializer.Serialize(writer, v, options);
            }
            writer.WriteEndArray();
        }
    }
    public class JSObjectConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type type)
        {
            return typeof(JSObject).IsAssignableFrom(type);
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var covnerterType = typeof(JSObjectConverter<>).MakeGenericType(new Type[] { typeToConvert });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
            return converter;
        }
    }

    public class JSObjectConverter<TJSObject> : JsonConverter<TJSObject>, IJSInProcessObjectReferenceConverter where TJSObject : JSObject
    {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public JSObjectConverter(JsonSerializerOptions options)
        {
            _options = options;
        }
        public override bool CanConvert(Type type)
        {
            return typeof(TJSObject).IsAssignableFrom(type);
        }
        public override TJSObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            return _ref == null ? null :(TJSObject)Activator.CreateInstance(typeof(TJSObject), _ref);
        }
        public override void Write(Utf8JsonWriter writer, TJSObject value, JsonSerializerOptions options)
        {
            var obj = value as JSObject;
            var _ref = obj == null ? null : obj.JSRef;
            JsonSerializer.Serialize(writer, _ref, options);
        }
    }
}
