using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for the IdleDetector.start() method.
    /// </summary>
    public class IdleOptions
    {
        /// <summary>
        /// The minimum amount of time, in milliseconds, that the user must be idle before the observer is notified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? Threshold { get; set; }

        /// <summary>
        /// An AbortSignal object that can be used to abort the idle detection.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }
    }
}
