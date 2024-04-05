namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Returned as elements in an array from the Promise returned by IDBFactory.databases() 
    /// </summary>
    public class IDBDatabaseInfo
    {
        /// <summary>
        /// The database name.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// The database version.
        /// </summary>
        public long Version { get; set; }
    }
}
