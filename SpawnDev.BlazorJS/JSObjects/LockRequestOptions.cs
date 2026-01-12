using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object describing characteristics of the lock you want to create.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/LockManager/request#options
    /// </summary>
    public class LockRequestOptions
    {
        /// <summary>
        /// Either "exclusive" or "shared". The default value is "exclusive".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("mode")]
        public string? Mode { get; set; }
        /// <summary>
        /// If true, the lock request will only be granted if it is not already held.<br/>
        /// If it cannot be granted, the callback will be invoked with null instead of a Lock instance. The default value is false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("ifAvailable")]
        public bool? IfAvailable { get; set; }
        /// <summary>
        /// If true, then any held locks with the same name will be released, and the request will be granted, preempting any queued requests for it. The default value is false.<br/>
        /// ⚠ Warning: Use with care! Code that was previously running inside the lock continues to run, and may clash with the code that now holds the lock.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("steal")]
        public bool? Steal { get; set; }
        /// <summary>
        /// An AbortSignal (the signal property of an AbortController); if specified and the AbortController is aborted, the lock request is dropped if it was not already granted.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("signal")]
        public AbortSignal? Signal { get; set; }
    }
}
