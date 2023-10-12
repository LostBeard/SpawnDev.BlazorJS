using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class FileSystemCreateWritableOptions
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? KeepExistingData { get;set; }
    }
}
