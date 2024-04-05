using SpawnDev.BlazorJS.JSObjects;
using System.Collections;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// This converter is designed to allow converting Union types to and from JSON<br />
    /// When being serialized/deserialized by the Blazor JSRuntime UnionConverterFactory overrides this converter and is used<br />
    /// This allows handling serialization based on the environment the result will be used in<br />
    /// Ex. JSObjects nad IJSInProcessObjectReferences are only valid in the Javascript scope
    /// </summary>
    public class UnionJsonConverter : JsonConverter<object?>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(Union).IsAssignableFrom(typeToConvert);
        }

        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = UnionConverter.ImportFromJson(ref reader, options, typeToConvert.GenericTypeArguments);
            if (value == null) return null;
            var ret = Activator.CreateInstance(typeToConvert, value);
            return ret;
        }

        public override void Write(Utf8JsonWriter writer, object? value, JsonSerializerOptions options)
        {
            var u = (Union?)value;
            if (u != null && u.Value != null)
            {
                var vType = u.Value.GetType();
                var uType = u.ValueType;
                if (u.Value is TypedArray t)
                {
                    var bytes = t.ReadBytes();
                    JsonSerializer.Serialize(writer, bytes, options);
                    return;
                }
                else if (u.Value is ArrayBuffer r)
                {
                    var bytes = r.ReadBytes();
                    JsonSerializer.Serialize(writer, bytes, options);
                    return;
                }
                else if (typeof(JSObject).IsAssignableFrom(vType))
                {
                    // Could be problem, JSObjects are not serializable outside of JS interop
                    var nmt = true;
                }
            }
            JsonSerializer.Serialize(writer, u == null ? null : u.Value, options);
        }
    }
    static class UnionConverter
    {
        static Lazy<List<string>> TypedArrayTypeNames = new Lazy<List<string>>(() => TypedArrayTypes!.Select(o => o.Name).ToList());
        public static List<Type> TypedArrayTypes = new List<Type>
        {
            typeof(Int8Array),
            typeof(Uint8Array),
            typeof(Uint8ClampedArray),
            typeof(Int16Array),
            typeof(Uint16Array),
            typeof(Int16Array),
            typeof(Int32Array),
            typeof(Uint32Array),
            typeof(Float32Array),
            typeof(Float64Array),
            typeof(BigInt64Array),
            typeof(BigUint64Array),
        };
        public static List<Type> Uint8ArrayTypes = new List<Type>
        {
            typeof(byte[]),
            typeof(TypedArray),
        };
        public static List<Type> StringTypes = new List<Type>
        {
            typeof(string),
            typeof(DateTime),
        };
        public static List<Type> NumberTypes = new List<Type>
        {
            typeof(byte),
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
        public static object? ImportFromJson(ref Utf8JsonReader reader, JsonSerializerOptions options, Type[] types)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:

                    foreach (var type in types)
                    {
                        if (type == typeof(DateTime) && reader.TryGetDateTime(out var date))
                        {
                            return date;
                        }
                        else if (type == typeof(string))
                        {
                            return reader.GetString();
                        }
                        else if (type == typeof(byte[]))
                        {
                            var ret1 = JsonSerializer.Deserialize(ref reader, type);
                            return ret1;
                        }
                    }
                    break;
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    foreach (var type in types)
                    {
                        if (NumberTypes.Contains(type))
                        {
                            var ret1 = JsonSerializer.Deserialize(ref reader, type);
                            return ret1;
                        }
                    }
                    break;
                case JsonTokenType.StartObject:
                    var objectTypes = types.Where(o => o.IsClass && o != typeof(string) && !typeof(JSObject).IsAssignableFrom(o)).ToList();
                    if (objectTypes.Count == 1)
                    {
                        var type = objectTypes[0];
                        var ret1 = JsonSerializer.Deserialize(ref reader, type, options);
                        return ret1;
                    }
                    break;
                case JsonTokenType.StartArray:
                    var enumerableTypes = types.Where(o => typeof(IEnumerable).IsAssignableFrom(o) && o != typeof(string)).ToList();
                    if (enumerableTypes.Count == 1)
                    {
                        var type = enumerableTypes[0];
                        var ret1 = JsonSerializer.Deserialize(ref reader, type, options);
                        return ret1;
                    }
                    break;
            }
            throw new Exception($"(Json) Union type not found in union: Union<{string.Join(", ", types.Select(o => o.Name))}>");
        }
        public static object? ImportFromIJSInprocessObjectReference(ref Utf8JsonReader reader, JsonSerializerOptions options, Type[] types)
        {
            var jsObject = JsonSerializer.Deserialize<JSObject>(ref reader, options);
            if (jsObject == null) return null;
            var isArray = Array.IsArray(jsObject);
            var typeOf = isArray ? "array" : jsObject.JSRef!.PropertyType();
            var instanceOf = jsObject.JSRef!.PropertyIsUndefined("constructor") ? "" : jsObject.JSRef!.GetConstructorName()!;
            if (!string.IsNullOrEmpty(instanceOf))
            {
                if (instanceOf == "Uint8Array")
                {
                    foreach (var type in types)
                    {
                        // if the .Net native type is in the lsit, use that
                        if (type == typeof(byte[]))
                        {
                            var ret = jsObject.JSRef!.As(type);
                            jsObject.Dispose();
                            return ret;
                        }
                        // Uint8Array can be returned for TypedArray and Uint8Array types
                        else if (type == typeof(Uint8Array))
                        {
                            var ret = jsObject.JSRef!.As(type);
                            jsObject.Dispose();
                            return ret;
                        }
                        // Uint8Array can be returned for TypedArray and Uint8Array types
                        else if (type == typeof(TypedArray))
                        {
                            var ret = jsObject.JSRef!.As<Uint8Array>();
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                }
                // look for exact match
                //var typeNames = types.Select(o =>o.Name).ToArray();
                var matchType = types.Where(o => o.Name.Equals(instanceOf, StringComparison.OrdinalIgnoreCase)).ToList();
                if (matchType.Count == 1)
                {
                    var ret = jsObject.JSRef!.As(matchType[0]);
                    jsObject.Dispose();
                    return ret;
                }
                // if it's a TypedArray type and TypedArray is in the Union type list, return that typed array type
                if (types.Contains(typeof(TypedArray)))
                {
                    foreach (var typedArrayType in TypedArrayTypes)
                    {
                        if (typedArrayType.Name == instanceOf)
                        {
                            var ret = jsObject.JSRef!.As(typedArrayType);
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                }
            }
            switch (typeOf)
            {
                case "string":
                    foreach (var type in types)
                    {
                        if (StringTypes.Contains(type))
                        {
                            var ret = jsObject.JSRef!.As(type);
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                    jsObject.Dispose();
                    throw new Exception($"String type not found in union: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                case "number":
                    foreach (var type in types)
                    {
                        if (NumberTypes.Contains(type))
                        {
                            var ret = jsObject.JSRef!.As(type);
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                    jsObject.Dispose();
                    throw new Exception($"Number type not found in union: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                case "array":
                    var enumerableTypes = types.Where(o => typeof(IEnumerable).IsAssignableFrom(o) && o != typeof(string)).ToList();
                    if (enumerableTypes.Count == 1)
                    {
                        var ret = jsObject.JSRef!.As(enumerableTypes[0]);
                        jsObject.Dispose();
                        return ret;
                    }
                    else if (enumerableTypes.Count > 1)
                    {
                        jsObject.Dispose();
                        throw new Exception($"Array/IEnumerable type has too many matching types in: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                    }
                    jsObject.Dispose();
                    throw new Exception($"Array/IEnumerable type not found in union: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                case "function":
                case "object":
                    var objectTypes = types.Where(o => o.IsClass && o != typeof(string)).ToList();
                    if (objectTypes.Count == 1)
                    {
                        var ret = jsObject.JSRef!.As(objectTypes[0]);
                        jsObject.Dispose();
                        return ret;
                    }
                    else if (objectTypes.Count > 1)
                    {
                        jsObject.Dispose();
                        throw new Exception($"Object type has too many matching types in: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                    }
                    jsObject.Dispose();
                    throw new Exception($"Object type not found in union: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
            }
            throw new Exception($"Union type not found in union: {typeOf} - {instanceOf} Union<{string.Join(", ", types.Select(o => o.Name))}>");
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
            var value = UnionConverter.ImportFromIJSInprocessObjectReference(ref reader, options, typeToConvert.GenericTypeArguments);
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
