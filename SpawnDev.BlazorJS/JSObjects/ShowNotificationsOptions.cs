using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ShowNotificationsOptions
    {
        /// <summary>
        /// An array of actions to display in the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ShowNotificationsOptionAction[]? Actions { get; set; }

        /// <summary>
        /// a string containing the URL of an image to represent the notification when there is not enough space to display the notification itself such as for example, the Android Notification Bar. On Android devices, the badge should accommodate devices up to 4x resolution, about 96 by 96 px, and the image will be automatically masked.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Badge { get; set; }

        /// <summary>
        /// A string representing an extra content to display within the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Body { get; set; }

        /// <summary>
        /// Arbitrary data that you want to be associated with the notification. This can be of any data type.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Data { get; set; }

        /// <summary>
        /// The direction of the notification; it can be auto, ltr or rtl
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Dir { get; set; }

        /// <summary>
        /// a string containing the URL of an image to be used as an icon by the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Icon { get; set; }

        /// <summary>
        /// a string containing the URL of an image to be displayed in the notification.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Image { get; set; }

        /// <summary>
        /// Specify the lang used within the notification. This string must be a valid language tag according to RFC 5646: Tags for Identifying Languages (also known as BCP 47).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Lang { get; set; }

        /// <summary>
        /// A boolean that indicates whether to suppress vibrations and audible alerts when reusing a tag value. If options's renotify is true and options's tag is the empty string a TypeError will be thrown. The default is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Renotify { get; set; }

        /// <summary>
        /// Indicates that on devices with sufficiently large screens, a notification should remain active until the user clicks or dismisses it. If this value is absent or false, the desktop version of Chrome will auto-minimize notifications after approximately twenty seconds. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RequireInteraction { get; set; }

        /// <summary>
        /// When set indicates that no sounds or vibrations should be made. If options's silent is true and options's vibrate is present a TypeError exception will be thrown. The default value is false
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Silent { get; set; }

        /// <summary>
        /// An ID for a given notification that allows you to find, replace, or remove the notification using a script if necessary.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Tag { get; set; }

        /// <summary>
        /// A timestamp, given as Unix time in milliseconds, representing the time associated with the notification. This could be in the past when a notification is used for a message that couldn't immediately be delivered because the device was offline, or in the future for a meeting that is about to start.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Timestamp { get; set; }

        /// <summary>
        /// A vibration pattern to run with the display of the notification. A vibration pattern can be an array with as few as one member. The values are times in milliseconds where the even indices (0, 2, 4, etc.) indicate how long to vibrate and the odd indices indicate how long to pause. For example, [300, 100, 400] would vibrate 300ms, pause 100ms, then vibrate 400ms.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double[]? Vibrate{ get; set; }
    }
}
