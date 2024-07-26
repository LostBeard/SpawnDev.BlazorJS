using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Undefinable JsonConverter factory
    /// </summary>
    public class UndefinableConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Returns true if the type can be converted
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(Undefinable<>)) return true;
            if (typeToConvert == typeof(Undefinable)) return true;
            return false;
        }
        /// <summary>
        /// Returns a new JsonConverter
        /// </summary>
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
    /// <summary>
    /// Undefinable JsonConverter
    /// </summary>
    public class UndefinableConverter<T> : JsonConverter<Undefinable<T>>
    {
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override Undefinable<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = JsonSerializer.Deserialize<T?>(ref reader, options);
            return new Undefinable<T>(value);
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
        public override void Write(Utf8JsonWriter writer, Undefinable<T> value, JsonSerializerOptions options)
        {
            if (value == null || value.IsUndefined)
            {
                // gets passed as json which will allow the reviver to identify it as undefined type
                JsonSerializer.Serialize(writer, value);
            }
            else
            {
                JsonSerializer.Serialize(writer, (T)value.Value!, options);
            }
        }
    }
    /// <summary>
    /// Undefinable JsonConverter
    /// </summary>
    public class UndefinableConverter : JsonConverter<Undefinable>
    {
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override Undefinable Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new Exception("Deserialization of type Undefinable is not supported. It is designed for use as a method parameter type.");
        }
        /// <summary>
        /// Writes the type value to the Json reader
        /// </summary>
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
