using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://html.spec.whatwg.org/multipage/canvas.html#predefinedcolorspace
    /// </summary>
    [JsonConverter(typeof(JsonConverters.EnumStringConverterFactory))]
    public enum PredefinedColorSpace
    {
        /// <summary>
        /// srgb
        /// </summary>
        [JsonPropertyName("srgb")]
        Srgb,
        /// <summary>
        /// display-p3
        /// </summary>
        [JsonPropertyName("display-p3")]
        DisplayP3,
    }
}
