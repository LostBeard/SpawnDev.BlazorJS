using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for Element.RequestFullscreen()
    /// </summary>
    public class RequestFullscreenOptions {
        /// <summary>
        /// Options hide, show, auto (default)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? NavigationUI { get; set; }
    }
}