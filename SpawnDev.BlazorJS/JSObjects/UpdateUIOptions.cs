using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchUpdateUIEvent/updateUI#options
    /// </summary>
    public class UpdateUIOptions
    {
        /// <summary>
        /// A list of one or more image resources, containing icons for use in the user interface.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<IconInfo>? Icons { get; set; }
        /// <summary>
        /// A string containing the new title of the user interface.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
    }
}
