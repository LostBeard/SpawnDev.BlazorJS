using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Power preference options for GPUAdapter request.
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum GPUPowerPreference
    {
        /// <summary>
        /// Low power usage is preferred.
        /// </summary>
        [JsonPropertyName("low-power")]
        LowPower,
        /// <summary>
        /// High performance is preferred.
        /// </summary>
        [JsonPropertyName("high-performance")]
        HighPerformance,
    }
}
