using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for IDBDatabase.CreateObjectStore
    /// </summary>
    public class IDBObjectStoreCreateOptions
    {
        /// <summary>
        /// The key path to be used by the new object store. If empty or not specified, the object store is created without a key path and uses out-of-line keys. You can also pass in an array as a keyPath.<br/>
        /// A valid key path can include one of the following: an empty string, a JavaScript identifier, or multiple JavaScript identifiers separated by periods or an array containing any of those. It cannot include spaces.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<string, string[]>? KeyPath { get; set; }
        /// <summary>
        /// If true, the object store has a key generator. Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoIncrement { get; set; }
    }
}
