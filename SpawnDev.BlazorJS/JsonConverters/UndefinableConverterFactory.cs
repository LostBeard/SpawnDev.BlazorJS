using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JsonConverters
{
    public class UndefinableConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Undefinable<>)) return true;
            if (typeToConvert == typeof(Undefinable)) return true;
            return false;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {

            if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Undefinable<>))
            {
                var genericTypes = typeToConvert.GetGenericArguments();
                var converterType = typeof(UndefinableConverter<>).MakeGenericType(genericTypes);
                var converter = (JsonConverter)Activator.CreateInstance(converterType, BindingFlags.Instance | BindingFlags.Public, binder: null, args: new object[] { }, culture: null)!;
                return converter;
            }
            else if (typeToConvert == typeof(Undefinable))
            {
                return new UndefinableConverter();
            }
            return null;
        }
    }

    public class UndefinableConverter<T> : JsonConverter<Undefinable<T>>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var ret = typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Undefinable<>);
            return ret;
        }
        public override Undefinable<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = JsonSerializer.Deserialize<T?>(ref reader, options);
            return new Undefinable<T>(value);
        }
        public override void Write(Utf8JsonWriter writer, Undefinable<T> value, JsonSerializerOptions options)
        {
            if (value == null || value.IsUndefined)
            {
                // gets passed as json which will allow the reviver to identify it as undefined type
                JsonSerializer.Serialize(writer, value);
            }
            else
            {
                JsonSerializer.Serialize(writer, (T)value.Value, options);
            }
        }
    }
    public class UndefinableConverter : JsonConverter<Undefinable>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(Undefinable);
        }
        public override Undefinable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new Exception("Deserialization of type Undefinable is not supported. It is designed for use as a method parameter type.");
        }
        public override void Write(Utf8JsonWriter writer, Undefinable value, JsonSerializerOptions options)
        {
            if (value == null || value.IsUndefined)
            {
                // gets passed as json which will allow the reviver to identify it as undefined type
                JsonSerializer.Serialize(writer, value);
            }
            else
            {
                JsonSerializer.Serialize(writer, value.Value, options);
            }
        }
    }
}
