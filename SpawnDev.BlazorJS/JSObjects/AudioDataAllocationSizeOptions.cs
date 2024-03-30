using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used for AudioData.AllocationSize()<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioData/allocationSize#options
    /// </summary>
    public class AudioDataAllocationSizeOptions
    {
        /// <summary>
        /// The index of the plane to return the size of.
        /// </summary>
        public int PlaneIndex { get; set; }
        /// <summary>
        /// An integer giving an offset into the plane data indicating which plane to begin from. Defaults to 0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameOffset { get; set; }
        /// <summary>
        /// An integer giving the number of frames to return the size of. If omitted then all frames in the plane will be used, beginning with the frame specified in frameOffset.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? FrameCount { get; set; }
    }
}
