namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for IDBDatabase.Transaction
    /// </summary>
    public enum IDBTransactionDurability
    {
        /// <summary>
        /// Default
        /// </summary>
        @default,
        /// <summary>
        /// Use in cases where reducing the risk of data loss outweighs the impact to performance and power.
        /// </summary>
        strict,
        /// <summary>
        /// provides better performance, but with fewer guarantees. <br />
        /// Web applications are encouraged to use "relaxed" for ephemeral data such as caches or quickly changing records,
        /// </summary>
        relaxed,
    }
}
