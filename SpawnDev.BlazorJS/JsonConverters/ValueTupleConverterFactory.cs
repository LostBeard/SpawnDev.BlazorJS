using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class ValueTupleConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(ValueTuple<>), typeof(ValueTupleConverter<>) },
            { typeof(ValueTuple<,>), typeof(ValueTupleConverter<,>) },
            { typeof(ValueTuple<,,>), typeof(ValueTupleConverter<,,>)  },
            { typeof(ValueTuple<,,,>), typeof(ValueTupleConverter<,,,>)   },
            { typeof(ValueTuple<,,,,>), typeof(ValueTupleConverter<,,,,>)  },
            { typeof(ValueTuple<,,,,,>), typeof(ValueTupleConverter<,,,,,>)  },
            { typeof(ValueTuple<,,,,,,>), typeof(ValueTupleConverter<,,,,,,>)  },
        };
        public override bool CanConvert(Type typeToConvert)
        {
            var genericType = typeToConvert.IsGenericType ? typeToConvert.GetGenericTypeDefinition() : null;
            if (genericType != null && SupportedGenericTypes.TryGetValue(genericType, out var converterType))
            {
                return true;
            }
            return false;
        }
        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var genericType = typeToConvert.GetGenericTypeDefinition();
            var genericTypes = typeToConvert.GenericTypeArguments;
            SupportedGenericTypes.TryGetValue(genericType, out var converterGenericType);
            var converterType = converterGenericType!.MakeGenericType(genericTypes);
            var converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
            return converter;
        }
    }
    public class ValueTupleConverter<T1> : JsonConverter<ValueTuple<T1>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for (var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            writer.WriteEndArray();
        }
    }
    public class ValueTupleConverter<T1, T2> : JsonConverter<ValueTuple<T1, T2>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for(var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1, T2>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            writer.WriteEndArray();
        }
    }
    public class ValueTupleConverter<T1, T2, T3> : JsonConverter<ValueTuple<T1, T2, T3>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for (var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1, T2, T3>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2, T3> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            writer.WriteEndArray();
        }
    }
    public class ValueTupleConverter<T1, T2, T3, T4> : JsonConverter<ValueTuple<T1, T2, T3, T4>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1, T2, T3, T4> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for (var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1, T2, T3, T4>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            writer.WriteEndArray();
        }
    }
    public class ValueTupleConverter<T1, T2, T3, T4, T5> : JsonConverter<ValueTuple<T1, T2, T3, T4, T5>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1, T2, T3, T4, T5> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for (var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1, T2, T3, T4, T5>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            writer.WriteEndArray();
        }
    }
    public class ValueTupleConverter<T1, T2, T3, T4, T5, T6> : JsonConverter<ValueTuple<T1, T2, T3, T4, T5, T6>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1, T2, T3, T4, T5, T6> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for (var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1, T2, T3, T4, T5, T6>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            JsonSerializer.Serialize(writer, value.Item6, options);
            writer.WriteEndArray();
        }
    }
    public class ValueTupleConverter<T1, T2, T3, T4, T5, T6, T7> : JsonConverter<ValueTuple<T1, T2, T3, T4, T5, T6, T7>>, IJSInProcessObjectReferenceConverter
    {
        public override ValueTuple<T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using var array = JsonSerializer.Deserialize<JSObjects.Array>(ref reader, options)!;
            var genericTypes = typeToConvert.GenericTypeArguments;
            var list = new object?[genericTypes.Length];
            for (var i = 0; i < genericTypes.Length; i++)
            {
                list[i] = array.GetItem(genericTypes[i], i);
            }
            var ret = (ValueTuple<T1, T2, T3, T4, T5, T6, T7>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, ValueTuple<T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            JsonSerializer.Serialize(writer, value.Item5, options);
            JsonSerializer.Serialize(writer, value.Item6, options);
            JsonSerializer.Serialize(writer, value.Item7, options);
            writer.WriteEndArray();
        }
    }
}
