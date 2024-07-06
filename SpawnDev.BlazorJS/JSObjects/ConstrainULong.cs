using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainULong constraint type is used to specify a constraint for a property whose value is an integer. Its value may either be set to a number or an object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints#constrainulong
    /// </summary>
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
