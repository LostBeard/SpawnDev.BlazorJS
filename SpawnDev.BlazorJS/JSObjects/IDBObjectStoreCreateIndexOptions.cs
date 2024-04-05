using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for IDBObjectStore.CreateIndex<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/IDBObjectStore/createIndex#options
    /// </summary>
    public class IDBObjectStoreCreateIndexOptions
    {
        /// <summary>
        /// If true, the index will not allow duplicate values for a single key. Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Unique { get; set; }
        /// <summary>
        /// If true, the index will add an entry in the index for each array element when the keyPath resolves to an array. If false, it will add one single entry containing the array. Defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MultiEntry { get; set; }
    }
}
