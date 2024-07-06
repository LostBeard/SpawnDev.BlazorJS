using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaTrackConstraints dictionary is used to instruct the User Agent what sort of MediaStreamTracks to include in the MediaStream returned by getUserMedia().<br/>
    /// https://www.w3.org/TR/mediacapture-streams/#dom-mediatrackconstraints
    /// </summary>
    public class MediaTrackConstraints
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? Width { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? Height { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? AspectRatio { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? FrameRate { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? FacingMode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? ResizeMode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? SampleRate { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? SampleSize { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? EchoCancellation { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? AutoGainControl { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? NoiseSuppression { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDouble? Latency { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainULong? ChannelCount { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? DeviceId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainDOMString? GroupId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConstrainBoolean? BackgroundBlur { get; set; }
    }
}
