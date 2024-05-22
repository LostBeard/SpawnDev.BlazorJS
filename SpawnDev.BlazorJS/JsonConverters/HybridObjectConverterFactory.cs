using Microsoft.JSInterop;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class HybridObjectConverterFactory : JsonConverterFactory
    {
#if DEBUG && true
        /// <summary>
        /// Types this factory has been used with
        /// </summary>
        public List<Type> Types { get; private set; } = new List<Type>();
#endif
        // this converter is for converting class types that would normally be passed as JSON but has special property types that need to be loaded individually to work
        public override bool CanConvert(Type typeToConvert)
        {
            return CanConvert(typeToConvert, false);
        }
        bool CanConvert(Type typeToConvert, bool internalCall)
        {
#if DEBUG && true
            if (!internalCall)
            {
                Console.WriteLine($"HybridObjectConverterFactory.CanConvert(typeToConvert: {typeToConvert.Name})");
                if ("SharedCancellationTokenSource" == typeToConvert.Name)
                {
                    var nmtt = true;
                }
            }
#endif
            if (!typeToConvert.IsClass) return false;
            if (typeToConvert.IsInterface) return false;
            if (typeToConvert.IsArray) return false;
            if (typeToConvert.IsAbstract) return false;
            if (typeToConvert.IsValueType) return false;
            if (typeof(JSObject).IsAssignableFrom(typeToConvert)) return false;
            if (typeof(IJSObjectProxy).IsAssignableFrom(typeToConvert)) return false;
            if (typeof(Callback).IsAssignableFrom(typeToConvert)) return false;
            if (typeToConvert.IsAsync()) return false;
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            if (baseType == typeof(List<>)) return false;
            if (baseType == typeof(Dictionary<,>)) return false;
            var classProps = typeToConvert.GetTypeJsonProperties();// typeToConvert.GetProperties(BindingFlags.Instance);
            foreach (var prop in classProps)
            {
                var propertyInfo = prop.PropertyInfo;
                var fieldInfo = prop.FieldInfo;
                var pType = propertyInfo?.PropertyType ?? fieldInfo!.FieldType;
                if (typeof(JSObject).IsAssignableFrom(pType))
                {
                    return true;
                }
                if (typeof(IJSObjectProxy).IsAssignableFrom(pType))
                {
                    return true;
                }
                if (typeof(IJSInProcessObjectReference) == pType)
                {
                    return true;
                }
                if (CanConvert(pType, true))
                {
                    return true;
                }
            }
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
#if DEBUG && true
            if (!Types.Contains(typeToConvert))
            {
                Types.Add(typeToConvert);
                if (typeToConvert == typeof(BlazorJSRuntime))
                {
                    var stopHere = true;
                }
                Console.WriteLine($"HybridObjectConverterFactory: {typeToConvert.Name} - {typeToConvert.FullName}");
            }
#endif
            var converterType = typeof(HybridObjectConverter<>).MakeGenericType(typeToConvert);
            JsonConverter converter = (JsonConverter)Activator.CreateInstance(converterType)!;
            return converter;
        }
    }
    /// <summary>
    /// HybridObjectConverter allows deserializing of classes that have IJSInProcessObjectReference based properties
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HybridObjectConverter<T> : JsonConverter<T>, IJSInProcessObjectReferenceConverter where T : class
    {
        List<ClassMemberJsonInfo>? classProps = null;
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            classProps ??= typeof(T).GetTypeJsonProperties();
            using var _ref = JsonSerializer.Deserialize<IJSInProcessObjectReference>(ref reader, options);
            if (_ref == null) return null;
            // create an instance using the json constructor
            var tmpRet = JsonSerializer.Deserialize<T>("{}")!;// (T)Activator.CreateInstance(typeof(T))!;
            foreach (var prop in classProps)
            {
                var propertyInfo = prop.PropertyInfo;
                var fieldInfo = prop.FieldInfo;
                var pType = propertyInfo?.PropertyType ?? fieldInfo!.FieldType;
                var propName = prop.GetJsonName(options);
                object? value;
                try
                {
                    value = _ref!.Get(pType, propName);
                }
                catch
                {
                    continue;
                }
                if (value == null) continue;
                if (propertyInfo != null)
                {
                    if (propertyInfo.SetMethod != null)
                    {
                        propertyInfo.SetValue(tmpRet, value);
                    }
                }
                else if (fieldInfo != null)
                {
                    fieldInfo.SetValue(tmpRet, value);
                }
            }
            return tmpRet;
        }
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            classProps ??= typeof(T).GetTypeJsonProperties();
            writer.WriteStartObject();
            foreach (var prop in classProps)
            {
                var propertyInfo = prop.PropertyInfo;
                var fieldInfo = prop.FieldInfo;
                var propName = prop.GetJsonName(options);
                object? propValue = null;
                if (propertyInfo != null)
                {
                    propValue = propertyInfo.GetValue(value);
                }
                else if (fieldInfo != null)
                {
                    propValue = fieldInfo.GetValue(value);
                }
                if (!prop.GetShouldWrite(propValue, options)) continue;
                writer.WritePropertyName(propName);
                JsonSerializer.Serialize(writer, propValue, options);
            }
            writer.WriteEndObject();
        }
    }
}
