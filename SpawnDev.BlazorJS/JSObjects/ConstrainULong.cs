using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainULong constraint type is used to specify a constraint for a property whose value is an integer. Its value may either be set to a number or an object containing the following properties:
    /// </summary>
    public class ConstrainULong : MediaTrackConstraint
    {
        public static implicit operator ulong?(ConstrainULong? exactConstraint) => exactConstraint == null ? null : exactConstraint.Exact;
        public static implicit operator ConstrainULong(ulong? exactConstraint) => new ConstrainULong { Exact = exactConstraint };
        /// <summary>
        /// A ulong number specifying the largest permissible value of the property it describes. If the value cannot remain equal to or less than this value, matching will fail.
        /// </summary>
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Max { get; set; }
        /// <summary>
        /// A ulong number specifying the smallest permissible value of the property it describes. If the value cannot remain equal to or greater than this value, matching will fail.
        /// </summary>
        [JsonPropertyName("min")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Min { get; set; }
        /// <summary>
        /// A ulong specifying a specific, required, value the property must have to be considered acceptable.
        /// </summary>
        [JsonPropertyName("exact")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Exact { get; set; }
        /// <summary>
        /// A ulong specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
        /// </summary>
        [JsonPropertyName("ideal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ulong? Ideal { get; set; }
    }
}
