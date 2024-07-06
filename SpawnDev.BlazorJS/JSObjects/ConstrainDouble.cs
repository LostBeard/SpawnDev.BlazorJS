using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainDouble constraint type is used to specify a constraint for a property whose value is a double-precision floating-point number. Its value may either be set to a number or an object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints#constraindouble
    /// </summary>
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
