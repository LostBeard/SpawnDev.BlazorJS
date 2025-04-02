using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Notification direction
    /// </summary>
    public enum NotificationDirection
    {
        /// <summary>
        /// Auto
        /// </summary>
        [JsonPropertyName("auto")]
        Auto,
        /// <summary>
        /// Left to right
        /// </summary>
        [JsonPropertyName("ltr")]
        LeftToRight,
        /// <summary>
        /// Right to left
        /// </summary>
        [JsonPropertyName("rtl")]
        RightToLeft,
    }
    /// <summary>
    /// Notification creation options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Notification/Notification#options<br/>
    /// https://www.w3.org/TR/2015/REC-notifications-20151022/#api
    /// </summary>
    public class NotificationOptions
    {
        /// <summary>
        /// The direction in which to display the notification. It defaults to auto, which just adopts the browser's language setting behavior, but you can override that behavior by setting values of ltr and rtl (although most browsers seem to ignore these settings.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<NotificationDirection>? Dir { get; set; } = null;
        /// <summary>
        /// The notification's language, as specified using a string representing a language tag according to RFC 5646: Tags for Identifying Languages (also known as BCP 47). See the Sitepoint ISO 2 letter language codes page for a simple reference.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Lang { get; set; } = null;
        /// <summary>
        /// A string containing the URL of the image used to represent the notification when there isn't enough space to display the notification itself.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Badge { get; set; } = null;
        /// <summary>
        /// A string representing the body text of the notification, which is displayed below the title.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Body { get; set; } = null;
        /// <summary>
        /// A string representing an identifying tag for the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tag { get; set; } = null;
        /// <summary>
        /// A string containing the URL of an icon to be displayed in the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Icon { get; set; } = null;
        /// <summary>
        /// a string containing the URL of an image to be displayed in the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Image { get; set; } = null;
        /// <summary>
        /// Arbitrary data that you want associated with the notification. This can be of any data type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Data { get; set; } = null;
        /// <summary>
        /// A vibration pattern for the device's vibration hardware to emit with the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Vibrate { get; set; } = null;
        /// <summary>
        /// A boolean value specifying whether the user should be notified after a new notification replaces an old one. The default is false, which means they won't be notified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Remotify { get; set; } = null;
        /// <summary>
        /// Indicates that a notification should remain active until the user clicks or dismisses it, rather than closing automatically. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequireInteraction { get; set; } = null;
        /// <summary>
        /// An array of actions to display in the notification. Each element in the array is an object with the following members:
        /// action: A string identifying a user action to be displayed on the notification.
        /// title: A string containing action text to be shown to the user.
        /// icon: A string containing the URL of an icon to display with the action.
        /// Appropriate responses are built using event.action within the notificationclick event.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<NotificationAction>? Actions { get; set; } = null;
        /// <summary>
        /// A boolean value specifying whether the notification is silent (no sounds or vibrations issued), regardless of the device settings. The default is false, which means it won't be silent.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Silent { get; set; } = null;
        /// <summary>
        /// A timestamp, given as Unix time in milliseconds, representing the time associated with the notification. This could be in the past when a notification is used for a message that couldn't immediately be delivered because the device was offline, or in the future for a meeting that is about to start.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EpochDateTime? Timestamp { get; set; } = null;
    }
}
