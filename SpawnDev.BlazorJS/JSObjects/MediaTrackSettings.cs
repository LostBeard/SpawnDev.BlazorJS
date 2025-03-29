using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// MediaTrackSettings represents the Settings of a MediaStreamTrack object. Future specifications can extend the MediaTrackSettings dictionary by defining a partial dictionary with dictionary members of appropriate type.<br/>
    /// https://www.w3.org/TR/mediacapture-streams/#media-track-settings<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings
    /// </summary>
    public class MediaTrackSettings
    {
        // Instance properties of all media tracks
        // https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings#instance_properties_of_all_media_tracks
        /// <summary>
        /// A string indicating the current value of the deviceId property. The device ID is an origin-unique string identifying the source of the track; this is usually a GUID. This value is specific to the source of the track's data and is not usable for setting constraints; it can, however, be used for initially selecting media when calling MediaDevices.getUserMedia().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DeviceId { get; set; }
        /// <summary>
        /// A string indicating the current value of the groupId property. The group ID is a browsing session-unique string identifying the source group of the track. Two devices (as identified by the deviceId) are considered part of the same group if they are from the same physical device. For instance, the audio input and output devices for the speaker and microphone built into a phone would share the same group ID, since they're part of the same physical device. The microphone on a headset would have a different ID, though. This value is specific to the source of the track's data and is not usable for setting constraints; it can, however, be used for initially selecting media when calling MediaDevices.getUserMedia().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string GroupId { get; set; }

        // Instance properties of audio tracks
        // https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings#instance_properties_of_audio_tracks

        /// <summary>
        /// A Boolean which indicates the current value of the autoGainControl property, which is true if automatic gain control is enabled and is false otherwise.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoGainControl { get; set; }
        /// <summary>
        /// A long integer value indicating the current value of the channelCount property, specifying the number of audio channels present on the track (therefore indicating how many audio samples exist in each audio frame). This is 1 for mono, 2 for stereo, and so forth.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ChannelCount { get; set; }
        /// <summary>
        /// A Boolean indicating the current value of the echoCancellation property, specifying true if echo cancellation is enabled, otherwise false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? EchoCancellation { get; set; }
        /// <summary>
        /// A double-precision floating point value indicating the current value of the latency property, specifying the audio latency, in seconds. Latency is the amount of time which elapses between the start of processing the audio and the data being available to the next stop in the audio utilization process. This value is a target value; actual latency may vary to some extent for various reasons.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Latency { get; set; }
        /// <summary>
        /// A Boolean which indicates the current value of the noiseSuppression property, which is true if noise suppression is enabled and is false otherwise.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? NoiseSuppression { get; set; }
        /// <summary>
        /// A long integer value indicating the current value of the sampleRate property, specifying the sample rate in samples per second of the audio data. Standard CD-quality audio, for example, has a sample rate of 41,000 samples per second.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? SampleRate { get; set; }
        /// <summary>
        /// A long integer value indicating the current value of the sampleSize property, specifying the linear size, in bits, of each audio sample. CD-quality audio, for example, is 16-bit, so this value would be 16 in that case.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? SampleSize { get; set; }

        // Instance properties of video tracks
        // https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings#instance_properties_of_video_tracks

        /// <summary>
        /// A double-precision floating point value indicating the current value of the aspectRatio property, specified precisely to 10 decimal places. This is the width of the image in pixels divided by its height in pixels. Common values include 1.3333333333 (for the classic television 4:3 "standard" aspect ratio, also used on tablets such as Apple's iPad), 1.7777777778 (for the 16:9 high-definition widescreen aspect ratio), and 1.6 (for the 16:10 aspect ratio common among widescreen computers and tablets).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? AspectRatio { get; set; }
        /// <summary>
        /// A string indicating the current value of the facingMode property, specifying the direction the camera is facing. The value will be one of:<br/>
        /// "user" - A camera facing the user (commonly known as a "selfie cam"), used for self-portraiture and video calling.<br/>
        /// "environment" - A camera facing away from the user (when the user is looking at the screen). This is typically the highest quality camera on the device, used for general photography.<br/>
        /// "left" - A camera facing toward the environment to the user's left.<br/>
        /// "right" - A camera facing toward the environment to the user's right.<br/>
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FacingMode { get; set; }
        /// <summary>
        /// A double-precision floating point value indicating the current value of the frameRate property, specifying how many frames of video per second the track includes. If the value can't be determined for any reason, the value will match the vertical sync rate of the device the user agent is running on.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FrameRate { get; set; }
        /// <summary>
        /// A long integer value indicating the current value of the height property, specifying the height of the track's video data in pixels.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Height { get; set; }
        /// <summary>
        /// A long integer value indicating the current value of the width property, specifying the width of the track's video data in pixels.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public uint? Width { get; set; }
        /// <summary>
        /// A string indicating the current value of the resizeMode property, specifying the mode used by the user agent to derive the resolution of the track. The value will be one of:<br/>
        /// "none" - The track has the resolution offered by the camera, its driver or the OS.<br/>
        /// "crop-and-scale" - The track's resolution might be the result of the user agent using cropping or downscaling from a higher camera resolution.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResizeMode { get; set; }

        // Instance properties of shared screen tracks
        // https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackSettings#instance_properties_of_shared_screen_tracks
        /// <summary>
        /// A string which indicates whether or not the mouse cursor is being included in the generated stream and under what conditions. Possible values are:<br/>
        /// "always" - The mouse is always visible in the video content of the {domxref("MediaStream"), unless the mouse has moved outside the area of the content.<br/>
        /// "motion" - The mouse cursor is always included in the video if it's moving, and for a short time after it stops moving.<br/>
        /// "never" - The mouse cursor is never included in the shared video.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Cursor { get; set; }
        /// <summary>
        /// A string which specifies the type of source the track contains; one of:<br/>
        /// "application" - The stream contains all of the windows of the application chosen by the user rendered into the one video track.<br/>
        /// "browser" - The stream contains the contents of a single browser tab selected by the user.<br/>
        /// "monitor" - The stream's video track contains the entire contents of one or more of the user's screens.<br/>
        /// "window" - The stream contains a single window selected by the user for sharing.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DisplaySurface { get; set; }
        /// <summary>
        /// A Boolean value which, if true, indicates that the video contained in the stream's video track contains a background rendering context, rather than a user-visible one. This is false if the video being captured is coming from a foreground (user-visible) source.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LogicalSurface { get; set; }

        // ************** Not listed on w3.org

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? BackgroundBlur { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Brightness { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ColorTemperature { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Contrast { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ExposureCompensation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ExposureTime { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Saturation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Sharpness { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<WhiteBalanceModeEnum>? WhiteBalanceMode { get; set; }
    }
}
