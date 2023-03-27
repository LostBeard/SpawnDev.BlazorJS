using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters {
    public class FuncConverterFactory : JsonConverterFactory {

        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Func<>), typeof(FuncConverter<>) },
            { typeof(Func<,>), typeof(FuncConverter<,>) },
            { typeof(Func<,,>), typeof(FuncConverter<,,>) },
            { typeof(Func<,,,>), typeof(FuncConverter<,,,>) },
            { typeof(Func<,,,,>), typeof(FuncConverter<,,,,>) },
        };
        public override bool CanConvert(Type type) {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            if (SupportedGenericTypes.ContainsKey(baseType)) return true;
            return false;
        }

        public override JsonConverter? CreateConverter(Type type, JsonSerializerOptions options) {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            var genericTypes = type.GetGenericArguments();
            if (SupportedGenericTypes.TryGetValue(baseType, out var converterBaseType)) {
                var converterType = type.IsGenericType ? converterBaseType.MakeGenericType(genericTypes) : converterBaseType;
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            return null;
        }
    }
    public class FuncConverter<TResult> : JsonConverter<Func<TResult>>, IJSInProcessObjectReferenceConverter {
        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Func<>);
        }
        public override Func<TResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = fn.ToFunc<TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<TResult> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, TResult> : JsonConverter<Func<T0, TResult>>, IJSInProcessObjectReferenceConverter {

        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Func<,>);
        }
        public override Func<T0, TResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, TResult> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, TResult> : JsonConverter<Func<T0, T1, TResult>>, IJSInProcessObjectReferenceConverter {
        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Func<,,>);
        }
        public override Func<T0, T1, TResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, TResult> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, TResult> : JsonConverter<Func<T0, T1, T2, TResult>>, IJSInProcessObjectReferenceConverter {

        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Func<,,,>);
        }
        public override Func<T0, T1, T2, TResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, TResult> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class FuncConverter<T0, T1, T2, T3, TResult> : JsonConverter<Func<T0, T1, T2, T3, TResult>>, IJSInProcessObjectReferenceConverter {

        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Func<,,,,>);
        }
        public override Func<T0, T1, T2, T3, TResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = fn.ToFunc<T0, T1, T2, T3, TResult>();
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Func<T0, T1, T2, T3, TResult> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet(true);
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
}
