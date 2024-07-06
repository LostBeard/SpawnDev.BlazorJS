using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainDouble constraint type is used to specify a constraint for a property whose value is a double-precision floating-point number. Its value may either be set to a number or an object containing the following properties:
    /// </summary>
    public class ConstrainDoubleRange : DoubleRange
    {
        //public static implicit operator double?(ConstrainDouble? exactConstraint) => exactConstraint == null ? null : exactConstraint.Exact;
        //public static implicit operator ConstrainDouble(double? exactConstraint) => new ConstrainDouble { Exact = exactConstraint };
        /// <summary>
        /// A decimal number specifying the largest permissible value of the property it describes. If the value cannot remain equal to or less than this value, matching will fail.
        /// </summary>
        [JsonPropertyName("max")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Max { get; set; }
        /// <summary>
        /// A decimal number specifying the smallest permissible value of the property it describes. If the value cannot remain equal to or greater than this value, matching will fail.
        /// </summary>
        [JsonPropertyName("min")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Min { get; set; }
        /// <summary>
        /// A decimal number specifying a specific, required, value the property must have to be considered acceptable.
        /// </summary>
        [JsonPropertyName("exact")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Exact { get; set; }
        /// <summary>
        /// A decimal number specifying an ideal value for the property. If possible, this value will be used, but if it's not possible, the user agent will use the closest possible match.
        /// </summary>
        [JsonPropertyName("ideal")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Ideal { get; set; }
    }
    [JsonConverter(typeof(SpawnDev.BlazorJS.JsonConverters.UnionJsonConverter))]
    public class ConstrainDouble : Union<double, ConstrainDoubleRange>
    {
        public static implicit operator ConstrainDouble(double value) => value == null ? null : new ConstrainDouble(value);
        public static implicit operator ConstrainDouble(double? value) => value == null ? null : new ConstrainDouble(value.Value);
        public static implicit operator ConstrainDouble(ConstrainDoubleRange value) => value == null ? null : new ConstrainDouble(value);
        public ConstrainDouble(double value) : base(value) { }
        public ConstrainDouble(ConstrainDoubleRange value) : base(value) { }
    }
}
