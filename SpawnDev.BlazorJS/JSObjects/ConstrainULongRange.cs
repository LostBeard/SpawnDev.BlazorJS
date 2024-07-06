using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/mediacapture-streams/#dom-constrainulongrange
    /// </summary>
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
}
