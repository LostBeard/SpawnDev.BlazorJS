using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainBoolean constraint type is used to specify a constraint for a property whose value is a Boolean value.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints#constrainboolean
    /// </summary>
    [JsonConverter(typeof(SpawnDev.BlazorJS.JsonConverters.UnionJsonConverter))]
    public class ConstrainBoolean : Union<bool, ConstrainBooleanParameters>
    {
        public static implicit operator ConstrainBoolean(bool value) => new ConstrainBoolean(value);
        public static implicit operator ConstrainBoolean?(bool? value) => value == null ? null : new ConstrainBoolean(value.Value);
        public static implicit operator ConstrainBoolean?(ConstrainBooleanParameters value) => value == null ? null : new ConstrainBoolean(value);
        public ConstrainBoolean(bool value) : base(value) { }
        public ConstrainBoolean(ConstrainBooleanParameters value) : base(value) { }
    }
}
