using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class GetNotificationsOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tag { get; set; }

    }
}
