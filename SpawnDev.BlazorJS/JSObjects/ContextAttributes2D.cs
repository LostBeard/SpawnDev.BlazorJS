using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class ContextAttributes2D
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Alpha { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Desynchronized { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WillReadFrequently { get; set; } = null;
    }
}
