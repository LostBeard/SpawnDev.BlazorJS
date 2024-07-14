using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaDeviceInfo interface of the Media Capture and Streams API contains information that describes a single media input or output device.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaDeviceInfo
    /// </summary>
    public class MediaDeviceInfo : JSObject
    {
        /// <summary>
        /// Used to read string properties that may not be covered by this class
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? this[string key] => JSRef!.Get<string?>(key);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaDeviceInfo(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a string that is an identifier for the represented device that is persisted across sessions. It is un-guessable by other applications and unique to the origin of the calling application. It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions).
        /// </summary>
        public string DeviceId => JSRef!.Get<string>("deviceId");
        /// <summary>
        /// Returns an enumerated value that is either "videoinput", "audioinput" or "audiooutput".
        /// </summary>
        public string Kind => JSRef!.Get<string>("kind");
        /// <summary>
        /// Returns a string describing this device (for example "External USB Webcam").<br/>
        /// Note: For security reasons, the label field is always blank unless an active media stream exists or the user has granted persistent permission for media device access. The set of device labels could otherwise be used as part of a fingerprinting mechanism to identify a user.
        /// </summary>
        public string Label => JSRef!.Get<string>("label");
        /// <summary>
        /// Returns a string that is a group identifier. Two devices have the same group identifier if they belong to the same physical device — for example a monitor with both a built-in camera and a microphone.
        /// </summary>
        public string GroupId => JSRef!.Get<string>("groupId");
        /// <summary>
        /// Returns a JSON representation of the MediaDeviceInfo object.
        /// </summary>
        /// <returns></returns>
        public MediaDeviceInfoJson ToJSON() => JSRef!.Call<MediaDeviceInfoJson>("toJSON");
    }
}
