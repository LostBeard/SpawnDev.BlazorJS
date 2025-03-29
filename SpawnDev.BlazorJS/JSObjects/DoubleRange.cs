using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/mediacapture-streams/#dom-doublerange
    /// </summary>
    public class DoubleRange
    {
        /// <summary>
        /// The maximum valid value of this property.
        /// </summary>
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Max { get; set; }
        /// <summary>
        /// The minimum value of this property.
        /// </summary>
        [JsonPropertyName("min")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Min { get; set; }
        /// <summary>
        /// The step value for this property.
        /// </summary>
        [JsonPropertyName("step")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Step { get; set; }
    }
}
