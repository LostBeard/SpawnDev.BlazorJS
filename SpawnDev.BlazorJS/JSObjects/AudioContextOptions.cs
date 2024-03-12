using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object used to configure a new AudioContext<br />
    /// </summary>
    public class AudioContextOptions
    {
        /// <summary>
        /// Indicates the sample rate to use for the new context. The value must be a floating-point value indicating the sample rate, in samples per second, for which to configure the new context; additionally, the value must be one which is supported by AudioBuffer.sampleRate. The value will typically be between 8,000 Hz and 96,000 Hz; the default will vary depending on the output device, but the sample rate 44,100 Hz is the most common. If the sampleRate property is not included in the options, or the options are not specified when creating the audio context, the new context's output device's preferred sample rate is used by default.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? SampleRate { get; set; }
        /// <summary>
        /// The type of playback that the context will be used for, as a predefined string ("balanced", "interactive" or "playback") or a double-precision floating-point value indicating the preferred maximum latency of the context in seconds. The user agent may or may not choose to meet this request; check the value of AudioContext.baseLatency to determine the true latency after creating the context.<br />
        /// "balanced": The browser balances audio output latency and power consumption when selecting a latency value.<br />
        /// "interactive" (default value): The audio is involved in interactive elements, such as responding to user actions or needing to coincide with visual cues such as a video or game action. The browser selects the lowest possible latency that doesn't cause glitches in the audio. This is likely to require increased power consumption.<br />
        /// "playback": The browser selects a latency that will maximize playback time by minimizing power consumption at the expense of latency. Useful for non-interactive playback, such as playing music.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? LatencyHint { get; set; }
        /// <summary>
        /// Specifies the sink ID of the audio output device to use for the AudioContext. This can take one of the following value types:<br />
        /// A string representing the sink ID, retrieved for example via the deviceId property of the MediaDeviceInfo objects returned by MediaDevices.enumerateDevices().<br />
        /// An object representing different options for a sink ID. Currently, this takes a single property, type, with a value of none. Setting this parameter causes the audio to be processed without being played through any audio output device.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? SinkId { get; set; }
    }
}
