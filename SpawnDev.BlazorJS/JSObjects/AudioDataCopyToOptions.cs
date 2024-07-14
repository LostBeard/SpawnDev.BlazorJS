using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used fpr AudioData.CopyTo()<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioData/copyTo#options
    /// </summary>
    public class AudioDataCopyToOptions
    {
        /// <summary>
        /// The index of the plane to copy from.
        /// </summary>
        public int PlaneIndex { get; set; }
        /// <summary>
        /// An integer giving an offset into the plane data indicating which plane to begin copying from. Defaults to 0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameOffset { get; set; }
        /// <summary>
        /// An integer giving the number of frames to copy. If omitted then all frames in the plane will be copied, beginning with the frame specified in frameOffset.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameCount { get; set; }
    }
}
