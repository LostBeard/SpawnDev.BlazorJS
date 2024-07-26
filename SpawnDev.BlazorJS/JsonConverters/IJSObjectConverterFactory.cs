using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// IJSObject JsonConverter factory
    /// </summary>
    public class IJSObjectConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type type)
        {
            return typeof(IJSObject).IsAssignableFrom(type);
        }
        /// <summary>
        /// Creates a JsonConverter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(IJSObjectConverter<>).MakeGenericType(new Type[] { typeToConvert });
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
            return converter;
        }
    }
    /// <summary>
    /// IJSObject JsonConverter
    /// </summary>
    public class IJSObjectConverter<TInterface> : JSInProcessObjectReferenceConverterBase<TInterface> where TInterface : class, IJSObject
    {
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override TInterface? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            return _ref == null ? null : IJSObjectProxy.GetInterface<TInterface>(_ref);
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, TInterface value, JsonSerializerOptions options)
        {
            var obj = value as IJSObjectProxy;
            var _ref = obj == null ? null : obj.JSRef;
            JsonSerializer.Serialize(writer, _ref, options);
        }
    }
}
