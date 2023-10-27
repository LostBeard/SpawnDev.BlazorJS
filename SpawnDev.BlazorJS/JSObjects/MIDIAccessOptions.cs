using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Otpions for RequestMIDIAccess
    /// </summary>
    public class MIDIAccessOptions
    {
        /// <summary>
        /// A Boolean value that, if set to true, allows the ability to send and receive system exclusive (sysex) messages. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Sysex { get; set; }
        /// <summary>
        /// A Boolean value that, if set to true, allows the system to utilize any installed software synthesizers. The default value is false
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Software { get; set; }
    }
}
