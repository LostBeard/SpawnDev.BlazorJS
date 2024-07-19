using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
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
        public override bool CanConvert(Type type)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            return SupportedGenericTypes.ContainsKey(baseType);
        }
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
