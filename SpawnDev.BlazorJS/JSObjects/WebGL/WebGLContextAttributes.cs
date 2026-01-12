using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebGLContextAttributes dictionary contains attributes used to configure the WebGL context when creating it.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLCanvasElement/getContext
    /// </summary>
    public class WebGLContextAttributes
    {
        /// <summary>
        /// Boolean that indicates if the canvas contains an alpha buffer.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("alpha")]
        public bool? Alpha { get; set; } = null;
        /// <summary>
        /// Boolean that indicates the user agent may reduce the latency by desynchronizing the canvas paint cycle from the event loop.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("desynchronized")]
        public bool? Desynchronized { get; set; } = null;
        /// <summary>
        /// Boolean that indicates whether or not to perform anti-aliasing.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("antialias")]
        public bool? Antialias { get; set; } = null;
        /// <summary>
        /// Boolean that indicates that the drawing buffer has a depth buffer of at least 16 bits.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("depth")]
        public bool? Depth { get; set; } = null;
        /// <summary>
        /// Boolean that indicates if a context will be created if the system performance is low or if no hardware GPU is available.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("failIfMajorPerformanceCaveat")]
        public bool? FailIfMajorPerformanceCaveat { get; set; } = null;
        /// <summary>
        /// A hint to the user agent indicating what configuration of GPU is suitable for this WebGL context.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("powerPreference")]
        public string? PowerPreference { get; set; } = null;
        /// <summary>
        /// Boolean that indicates that the page compositor will assume the drawing buffer contains colors with pre-multiplied alpha.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("premultipliedAlpha")]
        public bool? PremultipliedAlpha { get; set; } = null;
        /// <summary>
        /// Boolean that indicates that the buffers will not be cleared and will preserve their values until the next authoring by the page compositor.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("preserveDrawingBuffer")]
        public bool? PreserveDrawingBuffer { get; set; } = null;
        /// <summary>
        /// Boolean that indicates that the drawing buffer has a stencil buffer of at least 8 bits.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("stencil")]
        public bool? Stencil { get; set; } = null;
        /// <summary>
        /// Boolean that indicates the context is compatible with the WebXR Device API.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("xrCompatible")]
        public bool? XrCompatible { get; set; } = null;
    }
}
