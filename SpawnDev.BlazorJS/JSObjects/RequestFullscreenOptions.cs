using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class RequestFullscreenOptions {
        /// <summary>
        /// Options hide, show, auto (default)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NavigationUI { get; set; }
    }
}