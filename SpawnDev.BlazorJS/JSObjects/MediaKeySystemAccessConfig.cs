using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaKeySystemAccessConfig interface of the Encrypted Media Extensions API provides a set of configurations for a given media key system access.
    /// </summary>
    public class MediaKeySystemAccessConfig
    {
        /// <summary>
        /// InitDataTypes
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? InitDataTypes { get; set; }

        /// <summary>
        /// DistinctiveIdentifier
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DistinctiveIdentifier { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Label { get; set; }

        /// <summary>
        /// PersistentState
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PersistentState { get; set; }

        /// <summary>
        /// SessionTypes
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? SessionTypes { get; set; }

        /// <summary>
        /// AudioCapabilities
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MediaKeyCapabilities[]? AudioCapabilities { get; set; }

        /// <summary>
        /// VideoCapabilities
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MediaKeyCapabilities[]? VideoCapabilities { get; set; }
    }
}
