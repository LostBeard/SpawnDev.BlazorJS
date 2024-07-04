namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// JSON representation of the MediaDeviceInfo object acquired from MediaDeviceInfo.ToJSON()
    /// </summary>
    public class MediaDeviceInfoJson
    {
        /// <summary>
        /// Returns a string that is an identifier for the represented device that is persisted across sessions. It is un-guessable by other applications and unique to the origin of the calling application. It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions).
        /// </summary>
        public string DeviceId { get; set; }
        /// <summary>
        /// Returns an enumerated value that is either "videoinput", "audioinput" or "audiooutput".
        /// </summary>
        public string Kind { get; set; }
        /// <summary>
        /// Returns a string describing this device (for example "External USB Webcam").<br />
        /// Note: For security reasons, the label field is always blank unless an active media stream exists or the user has granted persistent permission for media device access. The set of device labels could otherwise be used as part of a fingerprinting mechanism to identify a user.
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// Returns a string that is a group identifier. Two devices have the same group identifier if they belong to the same physical device — for example a monitor with both a built-in camera and a microphone.
        /// </summary>
        public string GroupId { get; set; }
        /// <summary>
        /// Facing mode
        /// </summary>
        public EnumString<VideoFacingModeEnum>? Facing { get; set; }
    }
}
