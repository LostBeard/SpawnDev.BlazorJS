using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// PeriodicSync options
    /// </summary>
    public class PeriodicSyncOptions
    {
        /// <summary>
        /// The minimum interval time, in milliseconds, at which the periodic sync should occur.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MinInterval { get; set; }
    }
}
