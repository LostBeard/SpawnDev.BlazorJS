using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class HybridObjectConverterFactory : JsonConverterFactory
    {
        // this converter is for converting class types that would normally be passed as JSON but has special property types that need to be loaded individually to work
        public override bool CanConvert(Type typeToConvert)
        {
            return CanConvert(typeToConvert, false);
        }
        Dictionary<Type, bool?> CanConvertAnswers = new Dictionary<Type, bool?>();
        bool CanConvert(Type typeToConvert, bool internalCall)
        {
#if DEBUG && false
            if (typeToConvert == typeof(RsaHashedKeyGenParams))
            {
                var nmtt = true;

            }
            if (!internalCall)
            {
                Console.WriteLine($"HybridObjectConverterFactory.CanConvert(typeToConvert: {typeToConvert.Name})");
                if ("SharedCancellationTokenSource" == typeToConvert.Name)
                {
                    var nmtt = true;
                }
            }
#endif
            if (CanConvertAnswers.TryGetValue(typeToConvert, out var canConvertCached))
            {
                return canConvertCached ?? false;
            }
            CanConvertAnswers[typeToConvert] = null;
            if (!typeToConvert.IsClass) goto CanConvertFalse;
            if (typeToConvert.IsInterface) goto CanConvertFalse;
            if (typeToConvert.IsArray) goto CanConvertFalse;
            if (typeToConvert.IsAbstract) goto CanConvertFalse;
            if (typeToConvert.IsValueType) goto CanConvertFalse;
            if (typeof(JSObject).IsAssignableFrom(typeToConvert)) goto CanConvertFalse;
            if (typeof(IJSObjectProxy).IsAssignableFrom(typeToConvert)) goto CanConvertFalse;
            if (typeof(Callback).IsAssignableFrom(typeToConvert)) goto CanConvertFalse;
            if (typeToConvert.IsAsync()) goto CanConvertFalse;
            var baseType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : typeToConvert;
            if (baseType == typeof(List<>)) goto CanConvertFalse;
            if (baseType == typeof(Dictionary<,>)) goto CanConvertFalse;
            var classProps = typeToConvert.GetTypeJsonProperties();// typeToConvert.GetProperties(BindingFlags.Instance);
            foreach (var prop in classProps)
            {
                var propertyInfo = prop.PropertyInfo;
                var fieldInfo = prop.FieldInfo;
                var pType = propertyInfo?.PropertyType ?? fieldInfo!.FieldType;
                if (typeof(JSObject).IsAssignableFrom(pType))
                {
                    goto CanConvertTrue;
                }
                if (typeof(IJSObjectProxy).IsAssignableFrom(pType))
                {
                    goto CanConvertTrue;
                }
                if (typeof(IJSInProcessObjectReference) == pType)
                {
                    goto CanConvertTrue;
                }
                if (typeof(byte[]) == pType)
                {
                    goto CanConvertTrue;
                }
                if (CanConvert(pType, true))
                {
                    goto CanConvertTrue;
                }
            }
        CanConvertFalse:
            CanConvertAnswers[typeToConvert] = false;
            return false;
        CanConvertTrue:
            CanConvertAnswers[typeToConvert] = true;
            return true;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
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
