using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;

namespace SpawnDev.BlazorJS.JsonConverters {
    public class ActionConverterFactory : JsonConverterFactory {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Action), typeof(ActionConverter) },
            { typeof(Action<>), typeof(ActionConverter<>) },
            { typeof(Action<,>), typeof(ActionConverter<,>) },
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
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
                return converter;
            }
            return null;
        }
    }
    public class ActionConverter : JsonConverter<Action>, IJSInProcessObjectReferenceConverter {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public ActionConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Action);
        }
        public override Action Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = new Action(() => fn.CallVoid());
            ret.FunctionSet(fn);
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Action value, JsonSerializerOptions options) {
            // wrap in a new promise and send that
            var ret = value.CallbackGet();
            if (ret == null) {
                ret = Callback.Create(value);
                value.CallbackSet(ret);
            }
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class ActionConverter<T0> : JsonConverter<Action<T0>>, IJSInProcessObjectReferenceConverter {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public ActionConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Action<>);
        }
        public override Action<T0> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = new Action<T0>((arg0) => fn.CallVoid(arg0));
            ret.FunctionSet(fn);
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Action<T0> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet();
            if (ret == null) {
                ret = Callback.Create(value);
                value.CallbackSet(ret);
            }
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
    public class ActionConverter<T0, T1> : JsonConverter<Action<T0, T1>>, IJSInProcessObjectReferenceConverter {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public ActionConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Action<,>);
        }
        public override Action<T0, T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            var fn = new Function(_ref);
            var ret = new Action<T0, T1>((arg0, arg1) => fn.CallVoid(arg0, arg1));
            ret.FunctionSet(fn);
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Action<T0, T1> value, JsonSerializerOptions options) {
            var ret = value.CallbackGet();
            if (ret == null) {
                ret = Callback.Create(value);
                value.CallbackSet(ret);
            }
            JsonSerializer.Serialize(writer, ret, options);
        }
    }
}
