using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Serial port flow control options<br/>
    /// https://wicg.github.io/serial/#flowcontroltype-enum
    /// </summary>
    public enum FlowControlType
    {
        /// <summary>
        /// No flow control is used. This is the default value.
        /// </summary>
        [JsonPropertyName("none")]
        None,
        /// <summary>
        /// Hardware flow control using the RTS and CTS signals is enabled.
        /// </summary>
        [JsonPropertyName("hardware")]
        Hardware,
    }
}
