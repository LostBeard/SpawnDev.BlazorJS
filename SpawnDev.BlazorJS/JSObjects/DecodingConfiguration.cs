using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object with a property type and either a video or audio property containing a configuration of the appropriate type
    /// </summary>
    public class DecodingConfiguration
    {
        /// <summary>
        /// The type of media being tested. This takes one of three values:<br />
        /// file - Represents a configuration that is meant to be used for a plain file playback.<br />
        /// media-source - Represents a configuration that is meant to be used for playback of a MediaSource.<br />
        /// webrtc - Represents a configuration that is meant to be received using RTCPeerConnection.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; set; }
        /// <summary>
        /// Configuration object for a audio media source.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EncodingConfigurationAudio? Audio { get; set; }
        /// <summary>
        /// Configuration object for a video media source.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EncodingConfigurationVideo? Video { get; set; }
    }
}
