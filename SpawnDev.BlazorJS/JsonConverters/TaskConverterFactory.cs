using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Task JsonConverter factory
    /// </summary>
    public class TaskConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
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
        /// <summary>
        /// Returns a new JsonConverter
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var genericTypes = typeToConvert.GetGenericArguments();
            if (genericTypes.Length > 0)
            {
                var converterType = typeof(TaskConverter<>).MakeGenericType(genericTypes);
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            else if (typeToConvert == typeof(Task))
            {
                var converterType = typeof(TaskConverter);
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            return null;
        }
    }
    /// <summary>
    /// Task JsonConverter
    /// </summary>
    public class TaskConverter : JSInProcessObjectReferenceConverterBase<Task>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
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
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Task value, JsonSerializerOptions options)
        {
            var promise = new Promise(value);
            JsonSerializer.Serialize(writer, promise, options);
            //value.ContinueWith((t) => {
            //    promise?.Dispose();
            //});
        }
    }
    /// <summary>
    /// Task&lt;TResult> JsonConverter
    /// </summary>
    public class TaskConverter<TResult> : JSInProcessObjectReferenceConverterBase<Task<TResult>>
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
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
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Task<TResult> value, JsonSerializerOptions options)
        {
            var promise = new Promise<TResult>(value);
            JsonSerializer.Serialize(writer, promise, options);
            //value.ContinueWith((t) => {
            //    promise?.Dispose();
            //});
        }
    }
}
