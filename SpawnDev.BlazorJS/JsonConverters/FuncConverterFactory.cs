using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Func JsonConverter factory
    /// </summary>
    public class FuncConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Func<>), typeof(FuncConverter<>) },
            { typeof(Func<,>), typeof(FuncConverter<,>) },
            { typeof(Func<,,>), typeof(FuncConverter<,,>) },
            { typeof(Func<,,,>), typeof(FuncConverter<,,,>) },
            { typeof(Func<,,,,>), typeof(FuncConverter<,,,,>) },
            { typeof(Func<,,,,,>), typeof(FuncConverter<,,,,,>) },
            { typeof(Func<,,,,,,>), typeof(FuncConverter<,,,,,,>) },
            { typeof(Func<,,,,,,,>), typeof(FuncConverter<,,,,,,,>) },
        };
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type type)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            return SupportedGenericTypes.ContainsKey(baseType);
        }
        /// <summary>
        /// Creates a JsonConverter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type type, JsonSerializerOptions options)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            var genericTypes = type.GetGenericArguments();
            SupportedGenericTypes.TryGetValue(baseType, out var converterBaseType);
            var converterType = type.IsGenericType ? converterBaseType!.MakeGenericType(genericTypes) : converterBaseType;
            return (JsonConverter)Activator.CreateInstance(converterType!, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
        }
    }
}
