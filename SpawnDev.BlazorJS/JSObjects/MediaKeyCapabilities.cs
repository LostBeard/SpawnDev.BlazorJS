using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaKeyCapabilities
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ContentType { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? EncryptionScheme { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Robustness { get; set; }
    }
}
