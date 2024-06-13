using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JsonConverters
{
    class BigIntegerJson
    {
        [JsonPropertyName("$bigint")]
        public string ValueString { get; set; }
    }
    public class BigIntegerConverter : JsonConverter<BigInteger>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(BigInteger);
        }
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var v = JsonSerializer.Deserialize<BigIntegerJson?>(ref reader);
            if (v == null || string.IsNullOrEmpty(v.ValueString)) return default;
            return BigInteger.Parse(v.ValueString);
        }
        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, new BigIntegerJson { ValueString = value.ToString() });
        }
    }
}
