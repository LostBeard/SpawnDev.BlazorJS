﻿using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class TupleConverterFactory : JsonConverterFactory
    {
        static Dictionary<Type, Type> SupportedGenericTypes = new Dictionary<Type, Type> {
            { typeof(Tuple<>), typeof(TupleConverter<>) },
            { typeof(Tuple<,>), typeof(TupleConverter<,>) },
            { typeof(Tuple<,,>), typeof(TupleConverter<,,>)  },
            { typeof(Tuple<,,,>), typeof(TupleConverter<,,,>)   },
            { typeof(Tuple<,,,,>), typeof(TupleConverter<,,,,>)  },
            { typeof(Tuple<,,,,,>), typeof(TupleConverter<,,,,,>)  },
            { typeof(Tuple<,,,,,,>), typeof(TupleConverter<,,,,,,>)  },
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
    public class TupleConverter<T1> : JsonConverter<Tuple<T1>>
    {
        public override Tuple<T1> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            writer.WriteEndArray();
        }
    }
    public class TupleConverter<T1, T2> : JsonConverter<Tuple<T1, T2>>
    {
        public override Tuple<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1, T2>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            writer.WriteEndArray();
        }
    }
    public class TupleConverter<T1, T2, T3> : JsonConverter<Tuple<T1, T2, T3>>
    {
        public override Tuple<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1, T2, T3>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            writer.WriteEndArray();
        }
    }
    public class TupleConverter<T1, T2, T3, T4> : JsonConverter<Tuple<T1, T2, T3, T4>>
    {
        public override Tuple<T1, T2, T3, T4> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1, T2, T3, T4>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            JsonSerializer.Serialize(writer, value.Item1, options);
            JsonSerializer.Serialize(writer, value.Item2, options);
            JsonSerializer.Serialize(writer, value.Item3, options);
            JsonSerializer.Serialize(writer, value.Item4, options);
            writer.WriteEndArray();
        }
    }
    public class TupleConverter<T1, T2, T3, T4, T5> : JsonConverter<Tuple<T1, T2, T3, T4, T5>>
    {
        public override Tuple<T1, T2, T3, T4, T5> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1, T2, T3, T4, T5>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
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
    public class TupleConverter<T1, T2, T3, T4, T5, T6> : JsonConverter<Tuple<T1, T2, T3, T4, T5, T6>>
    {
        public override Tuple<T1, T2, T3, T4, T5, T6> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1, T2, T3, T4, T5, T6>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
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
    public class TupleConverter<T1, T2, T3, T4, T5, T6, T7> : JsonConverter<Tuple<T1, T2, T3, T4, T5, T6, T7>>
    {
        public override Tuple<T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }
            else if (reader.TokenType != JsonTokenType.StartArray)
            {
                throw new Exception("Non-nullable Tuple cannot be deserialized from non-array types");
            }
            var genericTypes = typeToConvert.GenericTypeArguments;
            var genericIndex = 0;
            var list = new object?[genericTypes.Length];
            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (genericIndex < genericTypes.Length)
                {
                    var itemType = genericTypes[genericIndex];
                    list[genericIndex] = JsonSerializer.Deserialize(ref reader, itemType, options);
                    genericIndex++;
                }
            }
            var ret = (Tuple<T1, T2, T3, T4, T5, T6, T7>)Activator.CreateInstance(typeToConvert, list)!;
            return ret;
        }
        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options)
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
