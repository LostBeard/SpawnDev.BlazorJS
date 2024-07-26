using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    /// <summary>
    /// Json class used for reading and writing Javascript BigInt
    /// </summary>
    class BigIntegerJson
    {
        /// <summary>
        /// The string representation of the BigInt
        /// </summary>
        [JsonPropertyName("$bigint")]
        public string ValueString { get; set; } = default!;
    }
    /// <summary>
    /// BigInteger JsonConverter
    /// </summary>
    public class BigIntegerConverter : JsonConverter<BigInteger>
    {
        /// <summary>
        /// Returns true if this converter can convert the specified type
        /// </summary>
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(BigInteger);
        }
        /// <summary>
        /// Reads the type value from the Json reader
        /// </summary>
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<BigIntegerJson?>(ref reader);
            if (v == null || string.IsNullOrEmpty(v.ValueString)) return default;
            return BigInteger.Parse(v.ValueString);
        }
        /// <summary>
        /// Writes value to Json stream
        /// </summary>
        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, new BigIntegerJson { ValueString = value.ToString() });
        }
    }
}
