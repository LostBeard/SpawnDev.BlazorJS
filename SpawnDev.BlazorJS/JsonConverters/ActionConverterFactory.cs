using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// A JsonConverter that can handle Action and its typed variants
    /// </summary>
    public class ActionConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Action), typeof(ActionConverter) },
            { typeof(Action<>), typeof(ActionConverter<>) },
            { typeof(Action<,>), typeof(ActionConverter<,>) },
            { typeof(Action<,,>), typeof(ActionConverter<,,>) },
            { typeof(Action<,,,>), typeof(ActionConverter<,,,>) },
            { typeof(Action<,,,,>), typeof(ActionConverter<,,,,>) },
            { typeof(Action<,,,,,>), typeof(ActionConverter<,,,,,>) },
            { typeof(Action<,,,,,,>), typeof(ActionConverter<,,,,,,>) },
        };
        /// <summary>
        /// Returns true if this converter can convert the specified type
        /// </summary>
        public override bool CanConvert(Type type)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            return SupportedGenericTypes.ContainsKey(baseType);
        }
        /// <summary>
        /// Returns a new converter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type type, JsonSerializerOptions options)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            var genericTypes = type.GetGenericArguments();
            if (SupportedGenericTypes.TryGetValue(baseType, out var converterBaseType))
            {
                var converterType = type.IsGenericType ? converterBaseType.MakeGenericType(genericTypes) : converterBaseType;
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            return null;
        }
    }
}
