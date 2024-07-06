using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ConstrainULongRange : ULongRange
    {
        /// <summary>
        /// The exact required value for this property.
        /// </summary>
        [JsonPropertyName("exact")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Exact { get; set; }
        /// <summary>
        /// The ideal (target) value for this property.
        /// </summary>
        [JsonPropertyName("ideal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Ideal { get; set; }
    }
    [JsonConverter(typeof(SpawnDev.BlazorJS.JsonConverters.UnionJsonConverter))]
    public class ConstrainULong : Union<uint, ConstrainULongRange>
    {
        public static implicit operator ConstrainULong(uint value) => value == null ? null : new ConstrainULong(value);
        public static implicit operator ConstrainULong(uint? value) => value == null ? null : new ConstrainULong(value.Value);
        public static implicit operator ConstrainULong(ConstrainULongRange value) => value == null ? null : new ConstrainULong(value);
        public ConstrainULong(uint value) : base(value) { }
        public ConstrainULong(ConstrainULongRange value) : base(value) { }
    }
}
