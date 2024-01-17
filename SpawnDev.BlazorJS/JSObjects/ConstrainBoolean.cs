using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainBoolean constraint type is used to specify a constraint for a property whose value is a Boolean value. Its value may either be set to a Boolean (true or false) or an object containing the following properties:
    /// </summary>
    public class ConstrainBoolean : MediaTrackConstraint
    {
        public static implicit operator bool?(ConstrainBoolean? exactConstraint) => exactConstraint == null ? null : exactConstraint.Exact;
        public static implicit operator ConstrainBoolean(bool? exactConstraint) => new ConstrainBoolean { Exact = exactConstraint };
        /// <summary>
        /// A boolean specifying a specific, required, value the property must have to be considered acceptable.
        /// </summary>
        [JsonPropertyName("exact")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Exact { get; set; }
        /// <summary>
        /// A boolean specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
        /// </summary>
        [JsonPropertyName("ideal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Ideal { get; set; }
    }
}
