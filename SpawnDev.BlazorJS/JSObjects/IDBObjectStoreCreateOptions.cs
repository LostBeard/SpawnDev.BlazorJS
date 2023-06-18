using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class IDBObjectStoreCreateOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<string, string[]> KeyPath { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AutoIncrement { get; set; }
    }
}
