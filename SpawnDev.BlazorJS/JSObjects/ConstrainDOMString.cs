using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainDOMString constraint type is used to specify a constraint for a property whose value is a string. Its value may either be set to a string, an array of strings, or an object containing the following properties:
    /// </summary>
    public class ConstrainDOMString : MediaTrackConstraint
    {
        public static implicit operator string?(ConstrainDOMString? exactConstraint) => exactConstraint == null ? null : exactConstraint.Exact;
        public static implicit operator ConstrainDOMString(string? exactConstraint) => new ConstrainDOMString { Exact = exactConstraint };
        /// <summary>
        /// A string specifying a specific, required, value the property must have to be considered acceptable.
        /// </summary>
        [JsonPropertyName("exact")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Exact { get; set; }
        /// <summary>
        /// A string specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
        /// </summary>
        [JsonPropertyName("ideal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Ideal { get; set; }
    }
}
