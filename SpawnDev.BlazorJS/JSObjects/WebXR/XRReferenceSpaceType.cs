using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#enumdef-xrreferencespacetype
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum XRReferenceSpaceType
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("viewer")]
        Viewer,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("local")]
        Local,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("local-floor")]
        LocalFloor,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("bounded-floor")]
        BoundedFloor,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("unbounded")]
        Unbounded,
    }
}
