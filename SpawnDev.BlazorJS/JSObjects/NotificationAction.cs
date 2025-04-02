using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Represents a Notification action
    /// </summary>
    public class NotificationAction
    {
        /// <summary>
        /// A string identifying a user action to be displayed on the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Action { get; set; } = null;
        /// <summary>
        /// A string containing action text to be shown to the user.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; } = null;
        /// <summary>
        /// A string containing the URL of an icon to display with the action.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Icon { get; set; } = null;
    }
}
