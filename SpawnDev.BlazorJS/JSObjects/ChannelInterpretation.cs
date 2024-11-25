using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// ChannelInterpretation
    /// https://www.w3.org/TR/webaudio/#enumdef-channelinterpretation
    /// </summary>
    [JsonConverter(typeof(JsonConverters.EnumStringConverterFactory))]
    public enum ChannelInterpretation
    {
        /// <summary>
        /// use up-mix equations or down-mix equations. In cases where the number of channels do not match any of these basic speaker layouts, revert to "discrete".
        /// </summary>
        [JsonPropertyName("speakers")]
        Speakers,
        /// <summary>
        /// Up-mix by filling channels until they run out then zero out remaining channels. Down-mix by filling as many channels as possible, then dropping remaining channels.
        /// </summary>
        [JsonPropertyName("discrete")]
        Discrete,
    }
}
