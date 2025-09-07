using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://www.w3.org/TR/webxr/#enumdef-xrsessionmode
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum XRSessionMode
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("inline")]
        Inline,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("immersive-vr")]
        ImmersiveVR,
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("immersive-ar")]
        ImmersiveAR,
    }
}
