using SpawnDev.BlazorJS.JsonConverters;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The shape of the wave produced by the node. 
    /// </summary>
    [JsonConverter(typeof(EnumStringConverterFactory))]
    public enum OscillatorType
    {
        /// <summary>
        /// sine
        /// </summary>
        [JsonPropertyName("sine")]
        Sine,
        /// <summary>
        /// square
        /// </summary>
        [JsonPropertyName("square")]
        Square,
        /// <summary>
        /// sawtooth
        /// </summary>
        [JsonPropertyName("sawtooth")]
        Sawtooth,
        /// <summary>
        /// triangle
        /// </summary>
        [JsonPropertyName("triangle")]
        Triangle,
        /// <summary>
        /// custom
        /// </summary>
        [JsonPropertyName("custom")]
        Custom,
    }
}
