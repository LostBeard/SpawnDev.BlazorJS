using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class TaskConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))
            {
                return true;
            }
            if (type == typeof(Task))
            {
                return true;
            }
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var genericTypes = typeToConvert.GetGenericArguments();
            if (genericTypes.Length > 0)
            {
                var covnerterType = typeof(TaskConverter<>).MakeGenericType(genericTypes);
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            else if (typeToConvert == typeof(Task))
            {
                var covnerterType = typeof(TaskConverter);
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(covnerterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            return null;
        }
    }
    public class TaskConverter : JSInProcessObjectReferenceConverterBase<Task>
    {
        public override bool CanConvert(Type type)
        {
            return type == typeof(Task);
        }
        public override Task? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var promise = new Promise(_ref);
            var ret = (Task)promise.ThenAsync();
            //ret.ContinueWith((t) => {
            //    promise?.Dispose();
            //});
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Task value, JsonSerializerOptions options)
        {
            var promise = new Promise(value);
            JsonSerializer.Serialize(writer, promise, options);
            //value.ContinueWith((t) => {
            //    promise?.Dispose();
            //});
        }
    }
    public class TaskConverter<TResult> : JSInProcessObjectReferenceConverterBase<Task<TResult>>
    {
        public override bool CanConvert(Type type)
        {
            return type.GetGenericTypeDefinition() == typeof(Task<>);
        }
        public override Task<TResult>? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var promise = new Promise<TResult>(_ref);
            var ret = (Task<TResult>)promise.ThenAsync();
            //ret.ContinueWith((t) => {
            //    promise?.Dispose();
            //});
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Task<TResult> value, JsonSerializerOptions options)
        {
            //var promise = value.PromiseGet(true);
            var completed = value.IsCompleted;
            var promise = new Promise<TResult>(value);
            JsonSerializer.Serialize(writer, promise, options);
            //value.ContinueWith((t) => {
            //    promise?.Dispose();
            //});
        }
    }
}
