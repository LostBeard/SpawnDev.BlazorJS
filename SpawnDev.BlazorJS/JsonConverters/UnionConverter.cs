using Microsoft.JSInterop;
using SpawnDev.BlazorJS.JSObjects;
using System.Collections;
using System.Text.Json;
using Array = SpawnDev.BlazorJS.JSObjects.Array;

namespace SpawnDev.BlazorJS.JsonConverters
{
    static class UnionConverter
    {
        public static Type[]? GetUnionTypeGenericTypes(Type unionType)
        {
            if (!typeof(Union).IsAssignableFrom(unionType)) return null;
            var testType = unionType;
            while (testType != null && testType != typeof(object))
            {
                if (testType.IsGenericType)
                {
                    var genericTypeDefinition = testType.GetGenericTypeDefinition();
                    if (SupportedGenericTypes.Contains(genericTypeDefinition))
                    {
                        return testType.GenericTypeArguments;
                    }
                }
                testType = testType.BaseType;
            }
            return null;
        }
        public static List<Type> SupportedGenericTypes { get; } = new List<Type> {
            { typeof(Union<,>) },
            { typeof(Union<,,>) },
            { typeof(Union<,,,>)},
            { typeof(Union<,,,,>)},
            { typeof(Union<,,,,,>)},
            { typeof(Union<,,,,,,>)},
            { typeof(Union<,,,,,,,>)},
            { typeof(Union<,,,,,,,,>)},
            { typeof(Union<,,,,,,,,,>)},
        };
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
                    var objectTypes = types.Where(o => o.IsClass && o != typeof(string)).ToList();
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
        public static object? ImportFromIJSInprocessObjectReference(IJSInProcessObjectReference _ref, Type[] types)
        {
            var jsObject = new JSObject(_ref);
            var jsTypeName = jsObject.JSRef!.ConstructorName()!;
            if (!string.IsNullOrEmpty(jsTypeName))
            {
                if (jsTypeName == "Uint8Array")
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
                foreach(var o in types)
                {
                    //if (o.IsValueType || !o.IsClass || o.IsInterface || o == typeof(string)) continue;
                    var name = o.Name.Split("`")[0];
                    if (jsTypeName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        var ret = jsObject.JSRef!.As(o);
                        jsObject.Dispose();
                        return ret;
                    }
                }
                // if it's a TypedArray type and TypedArray is in the Union type list, return that typed array type
                if (types.Contains(typeof(TypedArray)))
                {
                    foreach (var typedArrayType in TypedArrayTypes)
                    {
                        if (typedArrayType.Name == jsTypeName)
                        {
                            var ret = jsObject.JSRef!.As(typedArrayType);
                            jsObject.Dispose();
                            return ret;
                        }
                    }
                }
            }
            var isArray = Array.IsArray(jsObject);
            var typeOf = isArray ? "array" : jsObject.JSRef!.TypeOf();
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
                    throw new Exception($"String type not found in union: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                case "boolean":
                    // Boolean will get picked up by Type.Name checker
                    if (types.Contains(typeof(bool)))
                    {
                        var ret = jsObject.JSRef!.As<bool>();
                        jsObject.Dispose();
                        return ret;
                    }
                    jsObject.Dispose();
                    throw new Exception($"Number type not found in union: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
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
                    throw new Exception($"Number type not found in union: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
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
                        throw new Exception($"Array/IEnumerable type has too many matching types in: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                    }
                    jsObject.Dispose();
                    throw new Exception($"Array/IEnumerable type not found in union: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
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
                        throw new Exception($"Object type has too many matching types in: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
                    }
                    jsObject.Dispose();
                    throw new Exception($"Object type not found in union: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
            }
            throw new Exception($"Union type not found in union: {typeOf} - {jsTypeName} Union<{string.Join(", ", types.Select(o => o.Name))}>");
        }
    }
}
