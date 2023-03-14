using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

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

    public class IJSObjectConverterFactory : JsonConverterFactory {
        static List<Type> IgnoreInterfaces = new List<Type> {
            typeof(IJSInProcessObjectReference),
            typeof(IJSObjectReference),
            typeof(IJSStreamReference),
        };

        public override bool CanConvert(Type type) {
            return CanConvertType(type);
        }

        public static bool CanConvertType(Type type) {
            var ignored = IgnoreInterfaces.Contains(type);
            if (ignored) return false;
            var isIJSObject = typeof(IJSObject).IsAssignableFrom(type);
            if (isIJSObject) return true;
            var isInterface = type.IsInterface;
            return isInterface;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
            var covnerterType = typeof(IJSObjectConverter<>).MakeGenericType(new Type[] { typeToConvert });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                covnerterType,
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: new object[] { options }, culture: null)!;

            return converter;
        }
    }

    // https://github.com/dotnet/aspnetcore/blob/ccb861b89f62c445f175f6a3ca2142f93e7ce5db/src/Components/WebAssembly/JSInterop/src/WebAssemblyJSObjectReferenceJsonConverter.cs#L10
    // WebAssemblyJSObjectReferenceJsonConverter.cs
    public class IJSObjectConverter<TInterface> : JsonConverter<TInterface>, IJSInProcessObjectReferenceConverter where TInterface : class {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public IJSObjectConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type type) {
            return typeof(TInterface).IsAssignableFrom(type);
        }
        public override TInterface Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            return _ref == null ? null : IJSObject.GetInterface<TInterface>(_ref);
        }
        public override void Write(Utf8JsonWriter writer, TInterface value, JsonSerializerOptions options) {
            var obj = value as IJSObject;
            var _ref = obj == null ? null : obj.JSRef;
            JsonSerializer.Serialize(writer, _ref, options);
        }
    }
}
