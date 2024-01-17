using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    //public class InputDeviceInfo : MediaDeviceInfo
    //{
    //    public InputDeviceInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
    //}
    public class UserMediaDeviceInfo : JSObject
    {
        public UserMediaDeviceInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string that is an identifier for the represented device that is persisted across sessions. It is un-guessable by other applications and unique to the origin of the calling application. It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions).
        /// </summary>
        public string DeviceId => JSRef.Get<string>("deviceId");
        /// <summary>
        /// Returns an enumerated value that is either "videoinput", "audioinput" or "audiooutput".
        /// </summary>
        public string Kind => JSRef.Get<string>("kind");
        /// <summary>
        /// Returns a string describing this device (for example "External USB Webcam").<br />
        /// Note: For security reasons, the label field is always blank unless an active media stream exists or the user has granted persistent permission for media device access. The set of device labels could otherwise be used as part of a fingerprinting mechanism to identify a user.
        /// </summary>
        public string Label => JSRef.Get<string>("label");
        /// <summary>
        /// Returns a string that is a group identifier. Two devices have the same group identifier if they belong to the same physical device — for example a monitor with both a built-in camera and a microphone.
        /// </summary>
        public string GroupId => JSRef.Get<string>("groupId");
    }

    public class MediaDeviceInfo
    {
        //public static explicit operator MediaDeviceInfoDTO?(MediaDeviceInfo? mediaDeviceInfo) => mediaDeviceInfo == null ? null : new MediaDeviceInfoDTO
        //{
        //    DeviceId = mediaDeviceInfo.DeviceId,
        //    GroupId = mediaDeviceInfo.GroupId,
        //    Kind = mediaDeviceInfo.Kind,
        //    Label = mediaDeviceInfo.Label,
        //};
        /// <summary>
        /// Returns a string that is an identifier for the represented device that is persisted across sessions. It is un-guessable by other applications and unique to the origin of the calling application. It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions).
        /// </summary>
        public string DeviceId { get; set; } = "";
        /// <summary>
        /// Returns an enumerated value that is either "videoinput", "audioinput" or "audiooutput".
        /// </summary>
        public string Kind { get; set; } = "";
        /// <summary>
        /// Returns a string describing this device (for example "External USB Webcam").<br />
        /// Note: For security reasons, the label field is always blank unless an active media stream exists or the user has granted persistent permission for media device access. The set of device labels could otherwise be used as part of a fingerprinting mechanism to identify a user.
        /// </summary>
        public string Label { get; set; } = "";
        /// <summary>
        /// Returns a string that is a group identifier. Two devices have the same group identifier if they belong to the same physical device — for example a monitor with both a built-in camera and a microphone.
        /// </summary>
        public string GroupId { get; set; } = "";

        public string Facing { get; set; } = "";
    }
}
