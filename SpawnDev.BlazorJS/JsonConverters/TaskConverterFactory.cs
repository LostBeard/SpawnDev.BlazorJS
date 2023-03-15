using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters {
    public class TaskConverterFactory : JsonConverterFactory {
        public override bool CanConvert(Type type) {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>)) {
                return true;
            }
            if (type == typeof(Task)) {
                return true;
            }
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options) {
            var genericTypes = typeToConvert.GetGenericArguments();
            if (genericTypes.Length > 0) {
                var covnerterType = typeof(TaskConverter<>).MakeGenericType(genericTypes);
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
                return converter;
            }
            else if (typeToConvert == typeof(Task)) {
                var covnerterType = typeof(TaskConverter);
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { options }, culture: null)!;
                return converter;
            }
            return null;
        }
    }
    public class TaskConverter : JsonConverter<Task>, IJSInProcessObjectReferenceConverter {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public TaskConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type type) {
            return type == typeof(Task);
        }
        public override Task Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            using var promise = new Promise(_ref);
            return promise.ThenAsync();
        }
        public override void Write(Utf8JsonWriter writer, Task value, JsonSerializerOptions options) {
            var promise = value.PromiseGet(true);
            JsonSerializer.Serialize(writer, promise, options);
        }
    }
    public class TaskConverter<TResult> : JsonConverter<Task<TResult>>, IJSInProcessObjectReferenceConverter {
        public JSCallResultType JSCallResultType { get; } = JSCallResultType.JSObjectReference;
        public bool OverrideResultType => true;
        JsonSerializerOptions _options;
        public TaskConverter(JsonSerializerOptions options) {
            _options = options;
        }
        public override bool CanConvert(Type type) {
            return type.GetGenericTypeDefinition() == typeof(Task<>);
        }
        public override Task<TResult> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            using var promise = new Promise<TResult>(_ref);
            return promise.ThenAsync();
        }
        public override void Write(Utf8JsonWriter writer, Task<TResult> value, JsonSerializerOptions options) {
            var promise = value.PromiseGet(true);
            JsonSerializer.Serialize(writer, promise, options);
        }
    }
}
