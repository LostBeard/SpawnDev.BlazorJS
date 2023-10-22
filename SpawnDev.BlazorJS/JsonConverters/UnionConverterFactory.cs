using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JsonConverters
{
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
    public class UnionConverter<T1, T2> : JsonConverter<Union<T1, T2>>
    {
        public override Union<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3> : JsonConverter<Union<T1, T2, T3>>
    {
        public override Union<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4> : JsonConverter<Union<T1, T2, T3, T4>>
    {
        public override Union<T1, T2, T3, T4> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5> : JsonConverter<Union<T1, T2, T3, T4, T5>>
    {
        public override Union<T1, T2, T3, T4, T5> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
                case 5:
                    JsonSerializer.Serialize(writer, value.ValueT5, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6> : JsonConverter<Union<T1, T2, T3, T4, T5, T6>>
    {
        public override Union<T1, T2, T3, T4, T5, T6> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
                case 5:
                    JsonSerializer.Serialize(writer, value.ValueT5, options);
                    break;
                case 6:
                    JsonSerializer.Serialize(writer, value.ValueT6, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7>>
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
                case 5:
                    JsonSerializer.Serialize(writer, value.ValueT5, options);
                    break;
                case 6:
                    JsonSerializer.Serialize(writer, value.ValueT6, options);
                    break;
                case 7:
                    JsonSerializer.Serialize(writer, value.ValueT7, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7, T8> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7, T8>>
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7, T8> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7, T8> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
                case 5:
                    JsonSerializer.Serialize(writer, value.ValueT5, options);
                    break;
                case 6:
                    JsonSerializer.Serialize(writer, value.ValueT6, options);
                    break;
                case 7:
                    JsonSerializer.Serialize(writer, value.ValueT7, options);
                    break;
                case 8:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9>>
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
                case 5:
                    JsonSerializer.Serialize(writer, value.ValueT5, options);
                    break;
                case 6:
                    JsonSerializer.Serialize(writer, value.ValueT6, options);
                    break;
                case 7:
                    JsonSerializer.Serialize(writer, value.ValueT7, options);
                    break;
                case 8:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
                case 9:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
                case 10:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
            }
        }
    }
    public class UnionConverter<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : JsonConverter<Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>
    {
        public override Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
        public override void Write(Utf8JsonWriter writer, Union<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> value, JsonSerializerOptions options)
        {
            switch (value.TIndex)
            {
                case 1:
                    JsonSerializer.Serialize(writer, value.ValueT1, options);
                    break;
                case 2:
                    JsonSerializer.Serialize(writer, value.ValueT2, options);
                    break;
                case 3:
                    JsonSerializer.Serialize(writer, value.ValueT3, options);
                    break;
                case 4:
                    JsonSerializer.Serialize(writer, value.ValueT4, options);
                    break;
                case 5:
                    JsonSerializer.Serialize(writer, value.ValueT5, options);
                    break;
                case 6:
                    JsonSerializer.Serialize(writer, value.ValueT6, options);
                    break;
                case 7:
                    JsonSerializer.Serialize(writer, value.ValueT7, options);
                    break;
                case 8:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
                case 9:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
                case 10:
                    JsonSerializer.Serialize(writer, value.ValueT8, options);
                    break;
            }
        }
    }
}
