namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for IDBDatabase.Transaction
    /// </summary>
    public enum IDBTransactionMode
    {
        /// <summary>
        /// Read only mode
        /// </summary>
        @readonly,
        /// <summary>
        /// Read and write mode
        /// </summary>
        readwrite,
        /// <summary>
        /// Read, write, and flush mode (non-standard, Firefox-only)
        /// </summary>
        readwriteflush,
    }
}
