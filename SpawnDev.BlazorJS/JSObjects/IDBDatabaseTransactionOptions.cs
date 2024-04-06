using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for IDBDatabase.Transaction
    /// </summary>
    public class IDBDatabaseTransactionOptions
    {
        /// <summary>
        /// "default", "strict", or "relaxed". The default is "default". Using "relaxed" provides better performance, but with fewer guarantees. Web applications are encouraged to use "relaxed" for ephemeral data such as caches or quickly changing records, and "strict" in cases where reducing the risk of data loss outweighs the impact to performance and power.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Durability { get; set; }
    }
}
