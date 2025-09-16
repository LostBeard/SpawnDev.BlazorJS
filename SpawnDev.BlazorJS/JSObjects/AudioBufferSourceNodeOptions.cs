using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioBufferSourceNode/AudioBufferSourceNode#options
    /// </summary>
    public class AudioBufferSourceNodeOptions
    {
        /// <summary>
        /// An instance of AudioBuffer to be played.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AudioBuffer? Buffer { get; set; }
        /// <summary>
        /// A value in cents to modulate the speed of audio stream rendering. Its nominal range is (-∞ to +∞). The default is 0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Detune { get; set; }
        /// <summary>
        /// A boolean indicating whether the audio should play in a loop. The default is false. If the loop is dynamically modified during playback, the new value will take effect on the next processing block of audio.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Loop { get; set; }
        /// <summary>
        /// An optional value, in seconds, where looping should end if the loop attribute is true. The default is 0. Its value is exclusive to the content of the loop. The sample frames, comprising the loop, run from the values loopStart to loopEnd-(1/sampleRate). It's sensible to set this to a value between 0 and the duration of the buffer. If loopEnd is less than 0, looping will end at 0. If loopEnd is greater than the duration of the buffer, looping will end at the end of the buffer. This attribute is converted to an exact sample frame offset within the buffer, by multiplying by the buffer's sample rate and rounding to the nearest integer value. Thus, its behavior is independent of the value of the playbackRate parameter.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? LoopEnd { get; set; }
        /// <summary>
        /// An optional value in seconds, where looping should begin if the loop attribute is true. The default is 0. It's sensible to set this to a value between 0 and the duration of the buffer. If loopStart is less than 0, looping will begin at 0. If loopStart is greater than the duration of the buffer, looping will begin at the end of the buffer. This attribute is converted to an exact sample frame offset within the buffer, by multiplying by the buffer's sample rate and rounding to the nearest integer value. Thus, its behavior is independent of the value of the playbackRate parameter.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? LoopStart { get; set; }
        /// <summary>
        /// The speed at which to render the audio stream. Its default value is 1. This parameter is k-rate. This is a compound parameter with detune. Its nominal range is (-∞ to +∞).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? PlaybackRate { get; set; }
        /// <summary>
        /// Represents an integer used to determine how many channels are used when up-mixing and down-mixing connections to any inputs to the node. (See AudioNode.channelCount for more information.) Its usage and precise definition depend on the value of channelCountMode.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ChannelCount{ get; set; }
        /// <summary>
        /// Represents an enumerated value describing the way channels must be matched between the node's inputs and outputs. (See AudioNode.channelCountMode for more information including default values.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChannelCountMode { get; set; }
        /// <summary>
        /// Represents an enumerated value describing the meaning of the channels. This interpretation will define how audio up-mixing and down-mixing will happen. The possible values are "speakers" or "discrete". (See AudioNode.channelCountMode for more information including default values.)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ChannelInterpretation { get; set; }
    }
}
