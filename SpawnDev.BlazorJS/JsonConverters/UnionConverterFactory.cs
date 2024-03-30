using SpawnDev.BlazorJS.JSObjects;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.JsonConverters
{
    static class UnionConverter
    {
        public static List<Type> StringParsers = new List<Type>
        {
             typeof(string),
             typeof(DateTime),
        };
        public static List<Type> NumberTypes = new List<Type>
        { typeof(byte),
             typeof(byte),
            typeof(sbyte),
             typeof(short),
             typeof(ushort),
             typeof(int),
             typeof(uint),
             typeof(long),
             typeof(ulong),
             typeof(float),
             typeof(double),
             typeof(decimal),
        };
        public delegate bool TryParse(ref Utf8JsonReader reader, out object? result);
        public static object? ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options, Type[] types)
        {
            var jsObject = JsonSerializer.Deserialize<JSObject>(ref reader, options);
            if (jsObject == null) return null;
            var isArray = Array.IsArray(jsObject);
            var typeOf = isArray ? "array" : jsObject.JSRef!.PropertyType();
            var instanceOf = jsObject.JSRef!.PropertyIsUndefined("constructor") ? "" : jsObject.JSRef!.GetConstructorName()!;
            if (!string.IsNullOrEmpty(instanceOf))
            {
                var matchType = types.Where(o => o.Name.Equals(instanceOf, StringComparison.OrdinalIgnoreCase)).ToList();
                if (matchType.Count == 1)
                {
                    var ret = jsObject.JSRef!.As(matchType[0]);
                    jsObject.Dispose();
                    return ret;
                }
            }
            switch (typeOf)
            {
                case "string":
                    foreach (var type in types)
                    {
                        if (UnionConverter.StringParsers.Contains(type))
                        {
                            var ret = jsObject.JSRef!.As(type);
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                    break;
                case "number":
                    foreach (var type in types)
                    {
                        if (UnionConverter.NumberTypes.Contains(type))
                        {
                            var ret = jsObject.JSRef!.As(type);
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                    break;
                case "array":
                    var enumerableTypes = types.Where(o => typeof(IEnumerable).IsAssignableFrom(o) && o != typeof(string)).ToList();
                    if (enumerableTypes.Count == 1)
                    {
                        var ret = jsObject.JSRef!.As(enumerableTypes[0]);
                        jsObject.Dispose();
                        return ret;
                    }
                    break;
                case "function":
                case "object":
                    var objectTypes = types.Where(o => o.IsClass && o != typeof(string)).ToList();
                    if (objectTypes.Count == 1)
                    {
                        var ret = jsObject.JSRef!.As(objectTypes[0]);
                        jsObject.Dispose();
                        return ret;
                    }
                    break;
            }
            return jsObject;
        }
    }
    public class UnionConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Union<,>), typeof(UnionConverter<,>) },
            { typeof(Union<,,>), typeof(UnionConverter<,,>) },
            { typeof(Union<,,,>), typeof(UnionConverter<,,,>) },
            { typeof(Union<,,,,>), typeof(UnionConverter<,,,,>) },
            { typeof(Union<,,,,,>), typeof(UnionConverter<,,,,,>) },
            { typeof(Union<,,,,,,>), typeof(UnionConverter<,,,,,,>) },
            { typeof(Union<,,,,,,,>), typeof(UnionConverter<,,,,,,,>) },
            { typeof(Union<,,,,,,,,>), typeof(UnionConverter<,,,,,,,,>) },
            { typeof(Union<,,,,,,,,,>), typeof(UnionConverter<,,,,,,,,,>) },
        };
        public override bool CanConvert(Type type)
        {
            var baseType = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            if (SupportedGenericTypes.ContainsKey(baseType)) return true;
            return false;
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
    public class UnionConverter<T1, T2> : JsonConverter<Union<T1, T2>>, IJSInProcessObjectReferenceConverter
    {
        List<Type> types = new List<Type> { typeof(T1), typeof(T2) };
        public override Union<T1, T2>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3> : JsonConverter<Union<T1, T2, T3>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4> : JsonConverter<Union<T1, T2, T3, T4>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5> : JsonConverter<Union<T1, T2, T3, T4, T5>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4, T5>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4, T5>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6> : JsonConverter<Union<T1, T2, T3, T4, T5, T6>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4, T5, T6>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4, T5, T6>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4, T5, T6, T7>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7, T8> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7, T8>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7, T8>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4, T5, T6, T7, T8>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7, T8> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>, IJSInProcessObjectReferenceConverter
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ExtractValue(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return (Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>?)ret;
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}
