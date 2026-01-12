using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class WebGLContextAttributes
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("alpha")]
        public bool? Alpha { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("desynchronized")]
        public bool? Desynchronized { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("antialias")]
        public bool? Antialias { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("depth")]
        public bool? Depth { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("failIfMajorPerformanceCaveat")]
        public bool? FailIfMajorPerformanceCaveat { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("powerPreference")]
        public string PowerPreference { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("premultipliedAlpha")]
        public bool? PremultipliedAlpha { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("preserveDrawingBuffer")]
        public bool? PreserveDrawingBuffer { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("stencil")]
        public bool? Stencil { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("xrCompatible")]
        public bool? XrCompatible { get; set; } = null;
    }
}
