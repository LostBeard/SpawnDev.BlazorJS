using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object with a property type and either a video or audio property containing a configuration of the appropriate type
    /// </summary>
    public class EncodingConfiguration
    {
        /// <summary>
        /// The type of media being tested. This takes one of two values:<br />
        /// record - Represents a configuration for recording of media, e.g. using MediaRecorder.<br />
        /// webrtc - Represents a configuration meant to be transmitted over electronic means(e.g. using RTCPeerConnection). Note: Firefox uses transmission for this type, and webrtc does not work.<br />
        /// transmission - Non-standard. The synonym of webrtc to be used in Firefox.
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
