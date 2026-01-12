using Microsoft.JSInterop;
using SpawnDev.BlazorJS.RemoteJSRuntime;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// HybridObject JsonConverter factory
    /// </summary>
    public class HybridObjectConverterFactory : JsonConverterFactory
    {
        JsonSerializerOptions Options;
        /// <summary>
        /// New instance constructor
        /// </summary>
        public HybridObjectConverterFactory(JsonSerializerOptions options)
        {
            Options = options;
        }
        /// <summary>
        /// If true the converter is disabled
        /// </summary>
        public static bool Disable { get; set; }
        /// <summary>
        /// If true, the converter will log Types it converts
        /// </summary>
        public static bool Verbose { get; set; }
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            var ret = CanConvert(typeToConvert, false);
            return ret;
        }
        Dictionary<Type, bool?> CanConvertAnswers = new Dictionary<Type, bool?>();
        bool CanConvert(Type typeToConvert, bool internalCall)
        {
            try
            {
                if (Disable) return false;
                if (CanConvertAnswers.TryGetValue(typeToConvert, out var canConvertCached))
                {
                    return canConvertCached ?? false;
                }
                CanConvertAnswers[typeToConvert] = null;
                if (typeToConvert.IsEnum) goto CanConvertFalse;
                if (typeToConvert.IsValueType) goto CanConvertFalse;
                if (!typeToConvert.IsClass) goto CanConvertFalse;
                if (typeToConvert.IsInterface) goto CanConvertFalse;
                if (typeToConvert.IsArray) goto CanConvertFalse;
                if (typeToConvert.IsAbstract) goto CanConvertFalse;
                if (typeof(JSObjectAsync).IsAssignableFrom(typeToConvert)) goto CanConvertFalse;
                if (typeof(JSObject).IsAssignableFrom(typeToConvert)) goto CanConvertFalse;
                if (typeof(Callback).IsAssignableFrom(typeToConvert)) goto CanConvertFalse;
                if (typeToConvert.IsAsync()) goto CanConvertFalse;
                if (typeToConvert.IsGenericType)
                {
                    var baseType = typeToConvert.GetGenericTypeDefinition();
                    if (baseType == typeof(List<>)) goto CanConvertFalse;
                    if (baseType == typeof(Dictionary<,>)) goto CanConvertFalse;
                }
                // Check if the class has a JsonConverterAttribute
                var jsonConverter = typeToConvert.GetCustomAttribute<JsonConverterAttribute>();
                if (jsonConverter != null && jsonConverter.ConverterType != null)
                {
                    if (jsonConverter.ConverterType == typeof(HybridObjectConverterFactory))
                    {
                        goto CanConvertTrue;
                    }
                    if (jsonConverter.ConverterType.IsGenericType)
                    {
                        var jsonConverterBaseType = jsonConverter.ConverterType.GetGenericTypeDefinition();
                        if (jsonConverterBaseType == typeof(HybridObjectConverter<>)) goto CanConvertTrue;
                    }
                    // this will not be used
                    goto CanConvertFalse;
                }
                // check properties
                var classProps = typeToConvert.GetTypeJsonProperties();// typeToConvert.GetProperties(BindingFlags.Instance);
                var propertyTypes = classProps.Select(o => o.PropertyInfo?.PropertyType ?? o.FieldInfo?.FieldType).Distinct().ToList();
                foreach (var pType in propertyTypes)
                {
                    if (pType!.IsValueType || !typeToConvert.IsClass) continue;
                    var perInstanceRequired = Options.TypeDeserializationRequiresPerInstance(pType);
                    if (perInstanceRequired)
                    {
                        goto CanConvertTrue;
                    }
                    else if (CanConvert(pType, true))
                    {
                        goto CanConvertTrue;
                    }
                }
            }
            catch
            {
                // continue
            }
        CanConvertFalse:
            CanConvertAnswers[typeToConvert] = false;
            return false;
        CanConvertTrue:
            CanConvertAnswers[typeToConvert] = true;
            if (Verbose)
            {
                Console.WriteLine($"HybridObjectConverterFactory: {typeToConvert.FullName}");
            }
            return true;
        }
        /// <summary>
        /// Creates a JsonConverter instance
        /// </summary>
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(HybridObjectConverter<>).MakeGenericType(typeToConvert);
            var converter = (JsonConverter)Activator.CreateInstance(converterType, options)!;
            return converter;
        }
    }
    /// <summary>
    /// HybridObjectConverter allows deserializing of classes that have IJSInProcessObjectReference based properties<br/>
    /// Use HybridObjectConverterFactory if using JsonConverterAttribute on a class
    /// </summary>
    public class HybridObjectConverter<T> : JSInProcessObjectReferenceConverterBase<T> where T : class
    {
        List<ClassMemberJsonInfo>? classProps = null;
        JsonSerializerOptions Options;
        ConstructorInfo? JsonConstructor => _JsonConstructor.Value;
        Lazy<ConstructorInfo?> _JsonConstructor;
        /// <summary>
        /// New instance constructor
        /// </summary>
        public HybridObjectConverter(JsonSerializerOptions options)
        {
            Options = options;
            _JsonConstructor = new Lazy<ConstructorInfo?>(() =>
            {
                var constructorMemberInfos = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                return constructorMemberInfos.FirstOrDefault(o => o.GetCustomAttribute<JsonConstructorAttribute>() != null);
            });
        }
        /// <summary>
        /// Converts an IJSInProcessObjectReference to the target type
        /// </summary>
        public override T? FromIJSInProcessObjectReference(IJSInProcessObjectReference? _ref)
        {
            if (_ref == null) return default(T);
            classProps ??= typeof(T).GetTypeJsonProperties();
            // create an instance using the json constructor (if found)
            T tmpRet;
            if (JsonConstructor != null)
            {
                tmpRet = (T)JsonConstructor.Invoke(null);
            }
            else
            {
                tmpRet = (T)Activator.CreateInstance(typeof(T), true)!;
            }
            foreach (var prop in classProps)
            {
                var propertyInfo = prop.PropertyInfo;
                var fieldInfo = prop.FieldInfo;
                var pType = propertyInfo?.PropertyType ?? fieldInfo!.FieldType;
                var propName = prop.GetJsonName(Options);
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
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
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
