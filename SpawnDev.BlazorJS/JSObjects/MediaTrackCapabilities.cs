using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Object which specifies the value or range of values which are supported for each of the user agent's supported constrainable properties<br/>
    /// https://www.w3.org/TR/mediacapture-streams/#media-track-capabilities<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrack/getCapabilities#return_value<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/InputDeviceInfo/getCapabilities#return_value<br/>
    /// Example: <br/>
    ///    aspectRatio: {max: 1280, min: 0.001388888888888889},<br/>
    ///    deviceId: "a5b30cd91182cbd9ab169188e4f3508bc627922980f2e665dec7bcb2f092252b",<br/>
    ///    facingMode: [],<br/>
    ///    frameRate: { max: 60.000240325927734, min: 1},<br/>
    ///    groupId: "c6bef31820797c3cabe2b45b135ae2a8eb8f0b564d214942b6ca70bc45e2fdc4",<br/>
    ///    height: { max: 720, min: 1},<br/>
    ///    resizeMode: ['none', 'crop-and-scale'],<br/>
    ///    width: { max: 1280, min: 1},<br/>
    /// </summary>
    public class MediaTrackCapabilities
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<WhiteBalanceModeEnum>[]? WhiteBalanceMode { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? Sharpness { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? Saturation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? ExposureCompensation { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? Contrast { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? ColorTemperature { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? Brightness { get; set; }
        /// <summary>
        /// The width, in pixels. As a capability, its valid range should span the video source's pre-set width values with min being equal to 1 and max being the largest width. The User Agent MUST support downsampling to any value between the min width range value and the native resolution width.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ULongRange? Width { get; set; }
        /// <summary>
        /// The height, in pixels. As a capability, its valid range should span the video source's pre-set height values with min being equal to 1 and max being the largest height. The User Agent MUST support downsampling to any value between the min height range value and the native resolution height.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ULongRange? Height { get; set; }
        /// <summary>
        /// The exact aspect ratio (width in pixels divided by height in pixels, represented as a double rounded to the tenth decimal place) or aspect ratio range.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? AspectRatio { get; set; }
        /// <summary>
        /// The frame rate (frames per second). If video source's pre-set can determine frame rates, then, as a capability, its valid range should span the video source's pre-set frame rate values with min being equal to 0 and max being the largest frame rate. The User Agent MUST support frame rates obtained from integral decimation of the native resolution frame rate. If frame rate cannot be determined (e.g. the source does not natively provide a frame rate, or the frame rate cannot be determined from the source stream), then the capability values MUST refer to the User Agent's vsync display rate.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? FrameRate { get; set; }
        /// <summary>
        /// A camera can report multiple facing modes. For example, in a high-end telepresence solution with several cameras facing the user, a camera to the left of the user can report both "left" and "user". See facingMode for additional details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<VideoFacingModeEnum>[]? FacingMode { get; set; }
        /// <summary>
        /// The User Agent MAY use cropping and downscaling to offer more resolution choices than this camera naturally produces. The reported sequence MUST list all the means the UA may employ to derive resolution choices for this camera. The value "none" MUST be present, indicating the ability to constrain the UA from cropping and downscaling. See resizeMode for additional details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<VideoResizeModeEnum>[]? ResizeMode { get; set; }
        /// <summary>
        /// The sample rate in samples per second for the audio data.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ULongRange? SampleRate { get; set; }
        /// <summary>
        /// The linear sample size in bits. As a constraint, it can only be satisfied for audio devices that produce linear samples.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ULongRange? SampleSize { get; set; }
        /// <summary>
        /// If the source cannot do echo cancellation a single false is reported. If echo cancellation cannot be turned off, a single true is reported. If the script can control the feature, the source reports a list with both true and false as possible values. See echoCancellation for additional details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool[]? EchoCancellation { get; set; }
        /// <summary>
        /// If the source cannot do auto gain control a single false is reported. If auto gain control cannot be turned off, a single true is reported. If the script can control the feature, the source reports a list with both true and false as possible values. See autoGainControl for additional details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool[]? AutoGainControl { get; set; }
        /// <summary>
        /// If the source cannot do noise suppression a single false is reported. If noise suppression cannot be turned off, a single true is reported. If the script can control the feature, the source reports a list with both true and false as possible values. See noiseSuppression for additional details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool[]? NoiseSuppression { get; set; }
        /// <summary>
        /// The latency or latency range, in seconds. The latency is the time between start of processing (for instance, when sound occurs in the real world) to the data being available to the next step in the process. Low latency is critical for some applications; high latency may be acceptable for other applications because it helps with power constraints. The number is expected to be the target latency of the configuration; the actual latency may show some variation from that.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DoubleRange? Latency { get; set; }
        /// <summary>
        /// The number of independent channels of sound that the audio data contains, i.e. the number of audio samples per sample frame.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ULongRange? ChannelCount { get; set; }
        /// <summary>
        /// The identifier of the device generating the content of the MediaStreamTrack. It conforms with the definition of MediaDeviceInfo.deviceId. Note that the setting of this property is uniquely determined by the source that is attached to the MediaStreamTrack. In particular, getCapabilities() will return only a single value for deviceId. This property can therefore be used for initial media selection with getUserMedia(). However, it is not useful for subsequent media control with applyConstraints(), since any attempt to set a different value will result in an unsatisfiable ConstraintSet. If a string of length 0 is used as a deviceId value constraint with getUserMedia(), it MAY be interpreted as if the constraint is not specified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? DeviceId { get; set; }
        /// <summary>
        /// The document-unique group identifier for the device generating the content of the MediaStreamTrack. It conforms with the definition of MediaDeviceInfo.groupId. Note that the setting of this property is uniquely determined by the source that is attached to the MediaStreamTrack. In particular, getCapabilities() will return only a single value for groupId. Since this property is not stable between browsing sessions, its usefulness for initial media selection with getUserMedia() is limited. It is not useful for subsequent media control with applyConstraints(), since any attempt to set a different value will result in an unsatisfiable ConstraintSet.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? GroupId { get; set; }
        /// <summary>
        /// If the source does not have built-in background blurring, a single false is reported. If background blurring cannot be turned off, a single true is reported. If the script can control the feature, the source reports a list with both true and false as possible values. See backgroundBlur for details.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool[]? BackgroundBlur { get; set; }
    }
}
