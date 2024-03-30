using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when creating a new AudioData
    /// </summary>
    public class AudioDataOptions
    {
        /// <summary>
        /// One of:<br />
        /// "u8"<br />
        /// "s16"<br />
        /// "s32"<br />
        /// "f32"<br />
        /// "u8-planar"<br />
        /// "s16-planar"<br />
        /// "s32-planar"<br />
        /// "f32-planar"
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// A decimal containing the sample rate in Hz.
        /// </summary>
        public decimal SampleRate { get; set; }
        /// <summary>
        /// An integer containing the number of frames in this sample.
        /// </summary>
        public int NumberOfFrames { get; set; }
        /// <summary>
        /// An integer containing the number of channels in this sample.
        /// </summary>
        public int NumberOfChannels { get; set; }
        /// <summary>
        /// An integer indicating the data's time in microseconds.
        /// </summary>
        public long Timestamp { get; set; }
        /// <summary>
        /// A typed array of the audio data for this sample.
        /// </summary>
        public TypedArray Data { get; set; }
        /// <summary>
        /// An array of ArrayBuffers that AudioData will detach and take ownership of. If the array contains the ArrayBuffer backing data, AudioData will use that buffer directly instead of copying from it.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<ArrayBuffer>? Transfer { get; set; }
    }
}
