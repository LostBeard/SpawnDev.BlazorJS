using Microsoft.JSInterop;
using SpawnDev.BlazorJS.RemoteJSRuntime;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// 
    /// </summary>
    public interface IJSObjectAsyncConverter { }
    /// <summary>
    /// 
    /// </summary>
    public class JSObjectAsyncConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <returns></returns>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(JSObjectAsync).IsAssignableFrom(typeToConvert);
        }
        /// <summary>
        /// Creates a new converter instance
        /// </summary>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(JSObjectAsyncConverter<>).MakeGenericType(new Type[] { typeToConvert });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
            return converter;
        }
    }
    /// <summary>
    /// JSObjectAsync JsonConverter
    /// </summary>
    public class JSObjectAsyncConverter<TJSObject> : JsonConverter<TJSObject>, IJSObjectAsyncConverter where TJSObject : JSObjectAsync
    {
        public override void Write(Utf8JsonWriter writer, TJSObject value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value?.JSRef, options);
        }
        public override TJSObject? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var _ref = JsonSerializer.Deserialize<IJSObjectReference?>(ref reader, options);
            if (_ref == null) return default!;
            var ret = (TJSObject)Activator.CreateInstance(typeToConvert, _ref)!;
            return ret;
        }
        public override TJSObject ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return base.ReadAsPropertyName(ref reader, typeToConvert, options);
        }
        public override void WriteAsPropertyName(Utf8JsonWriter writer, [DisallowNull] TJSObject value, JsonSerializerOptions options)
        {
            base.WriteAsPropertyName(writer, value, options);
        }
    }
}
