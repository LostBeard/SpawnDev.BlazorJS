using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Similar methods to Activator
    /// </summary>
    internal static class ActivatorExt
    {
        /// <summary>
        /// Creates a new instance using the specified arguments<br/>
        /// Will use a private constructor if no public constructor is found
        /// </summary>
        public static object CreateInstance(Type type, object?[]? args = null)
        {
            var argTypes = args?.Select(o => o == null ? typeof(object) : o.GetType()).ToArray() ?? new Type[0];
            var constructor = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, argTypes, null);
            var ret = constructor!.Invoke(args);
            return ret;
        }
        /// <summary>
        /// Creates a new instance using the specified arguments<br/>
        /// Will use a private constructor if no public constructor is found
        /// </summary>
        public static T CreateInstance<T>(object?[]? args = null) => (T)CreateInstance(typeof(T), args);
    }
    /// <summary>
    /// Union JsonConverter
    /// </summary>
    public class UnionJSRuntimeConverter : JSInProcessObjectReferenceConverterBase<Union>
    {
        Type TypeToConvert;
        Type[] UnionTypes;
        /// <summary>
        /// Default constructor
        /// </summary>
        public UnionJSRuntimeConverter(Type typeToConvert)
        {
            TypeToConvert = typeToConvert;
            UnionTypes = UnionConverter.GetUnionTypeGenericTypes(TypeToConvert)!;
        }
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override Union? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return null;
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(_ref, UnionTypes);
            if (value == null) return null;
            var constructor = TypeToConvert.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { value.GetType() }, null);
            var ret = constructor!.Invoke(new object?[] { value });
            return (Union)ret;
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Union value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}
