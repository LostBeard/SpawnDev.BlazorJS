using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaTrackConstraints dictionary is used to instruct the User Agent what sort of MediaStreamTracks to include in the MediaStream returned by getUserMedia().<br/>
    /// https://www.w3.org/TR/mediacapture-streams/#dom-mediatrackconstraints<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints
    /// </summary>
    public class MediaTrackConstraints
    {
        /// <summary>
        /// WhiteBalanceMode
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EnumString<WhiteBalanceModeEnum>[]? WhiteBalanceMode { get; set; }

        /// <summary>
        /// Sharpness
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? Sharpness { get; set; }

        /// <summary>
        /// Saturation
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? Saturation { get; set; }

        /// <summary>
        /// ExposureCompensation
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? ExposureCompensation { get; set; }

        /// <summary>
        /// Contrast
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? Contrast { get; set; }

        /// <summary>
        /// ColorTemperature
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? ColorTemperature { get; set; }

        /// <summary>
        /// Brightness
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? Brightness { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? Width { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? Height { get; set; }

        /// <summary>
        /// AspectRatio
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? AspectRatio { get; set; }

        /// <summary>
        /// FrameRate
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? FrameRate { get; set; }

        /// <summary>
        /// FacingMode
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? FacingMode { get; set; }

        /// <summary>
        /// ResizeMode
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? ResizeMode { get; set; }

        /// <summary>
        /// SampleRate
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? SampleRate { get; set; }

        /// <summary>
        /// SampleSize
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? SampleSize { get; set; }

        /// <summary>
        /// EchoCancellation
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? EchoCancellation { get; set; }

        /// <summary>
        /// AutoGainControl
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? AutoGainControl { get; set; }

        /// <summary>
        /// NoiseSuppression
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? NoiseSuppression { get; set; }

        /// <summary>
        /// Latency
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? Latency { get; set; }

        /// <summary>
        /// ChannelCount
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? ChannelCount { get; set; }

        /// <summary>
        /// DeviceId
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? DeviceId { get; set; }

        /// <summary>
        /// GroupId
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? GroupId { get; set; }

        /// <summary>
        /// BackgroundBlur
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? BackgroundBlur { get; set; }
    }
}
