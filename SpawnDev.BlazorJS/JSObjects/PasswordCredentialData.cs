using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class PasswordCredentialData
    {
        public string Id { get; set; } = "";
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? IconURL { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Name { get; set; }
        public string Password { get; set; } = "";
    }
}
