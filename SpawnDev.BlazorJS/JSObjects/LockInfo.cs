using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// LockManager lock info
    /// https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#name
    /// </summary>
    public class LockInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("mode")]
        public string Mode { get; set; }
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }
    }
}
