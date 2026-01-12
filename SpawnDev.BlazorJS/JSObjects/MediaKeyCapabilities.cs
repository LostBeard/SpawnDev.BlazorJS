using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaKeyCapabilities interface of the Encrypted Media Extensions API provides a set of capabilities for a given media key system.
    /// </summary>
    public class MediaKeyCapabilities
    {
        /// <summary>
        /// ContentType
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContentType { get; set; }

        /// <summary>
        /// EncryptionScheme
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EncryptionScheme { get; set; }

        /// <summary>
        /// Robustness
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Robustness { get; set; }
    }
}
