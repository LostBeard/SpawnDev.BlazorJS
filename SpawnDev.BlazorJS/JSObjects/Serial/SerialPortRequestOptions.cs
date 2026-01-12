using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class SerialPortRequestOptions
    {
        /// <summary>
        /// A list of objects containing vendor and product IDs used to search for attached devices. The USB Implementors Forum assigns IDs to specific companies. Each company assigns IDs to its products. 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("filters")]
        public IEnumerable<SerialPortRequestFilter>? Filters { get; set; }
    }
}
