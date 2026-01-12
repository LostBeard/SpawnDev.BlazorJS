using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object containing a snapshot of the LockManager state.
    /// https://developer.mozilla.org/en-US/docs/Web/API/LockManager/query#return_value
    /// </summary>
    public class LockManagerState
    {
        /// <summary>
        /// An array of LockInfo objects for held locks.
        /// </summary>
        [JsonPropertyName("held")]
        public LockInfo[] Held { get; set; }
        /// <summary>
        /// An array of LockInfo objects for pending lock requests.
        /// </summary>
        [JsonPropertyName("pending")]
        public LockInfo[] Pending { get; set; }
    }
}
