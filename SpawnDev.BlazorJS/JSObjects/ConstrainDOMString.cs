using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ConstrainDOMString constraint type is used to specify a constraint for a property whose value is a string. Its value may either be set to a string, an array of strings, or an object.
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints#constraindomstring
    /// </summary>
    [JsonConverter(typeof(SpawnDev.BlazorJS.JsonConverters.UnionJsonConverter))]
    public class ConstrainDOMString : Union<string, string[], ConstrainDOMStringParameters>
    {
        public static implicit operator ConstrainDOMString?(string[]? value) => value == null ? null : new ConstrainDOMString(value);
        public static implicit operator ConstrainDOMString?(string? value) => value == null ? null : new ConstrainDOMString(value);
        public static implicit operator ConstrainDOMString?(ConstrainDOMStringParameters value) => value == null ? null : new ConstrainDOMString(value);
        public ConstrainDOMString(string value) : base(value) { }
        public ConstrainDOMString(ConstrainDOMStringParameters value) : base(value) { }
        public ConstrainDOMString(string[] value) : base(value) { }
    }
}
