using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// LockManager lock info
    /// https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#name
    /// </summary>
    public class LockInfo
    {
        /// <summary>
        /// The name of the lock.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        /// <summary>
        /// The mode of the lock, either "exclusive" (the default) or "shared".
        /// </summary>
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
        /// <summary>
        /// The unique ID of the client holding the lock.
        /// </summary>
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
    }
}
