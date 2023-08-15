using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ShowNotificationsOptionAction
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Action { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Icon { get; set; }
    }
}
