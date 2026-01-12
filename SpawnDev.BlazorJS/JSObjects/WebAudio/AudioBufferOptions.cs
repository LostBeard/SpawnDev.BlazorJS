using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioBuffer/AudioBuffer#options
    /// </summary>
    public class AudioBufferOptions
    {
        /// <summary>
        /// The size of the audio buffer in sample-frames. To determine the length to use for a specific number of seconds of audio, use numSeconds * sampleRate.
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// The number of channels for the buffer. The default is 1, and all user agents are required to support at least 32 channels.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? NumberOfChannels{ get; set; }
        /// <summary>
        /// The sample rate in Hz for the buffer. The default is the sample rate of the context used in constructing this object. User agents are required to support sample rates from 8,000 Hz to 96,000 Hz (but are allowed to go farther outside this range).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? SampleRate { get; set; }
    }
}
