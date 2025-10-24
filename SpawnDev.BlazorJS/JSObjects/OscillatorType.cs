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
        [JsonPropertyName("sine")]
        Sine,
        [JsonPropertyName("square")]
        Square,
        [JsonPropertyName("sawtooth")]
        Sawtooth,
        [JsonPropertyName("triangle")]
        Triangle,
        [JsonPropertyName("custom")]
        Custom,
    }
}
