using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object that sets options for getting the root node. The available options are:
    /// </summary>
    public class GetRootNodeOptions
    {
        /// <summary>
        /// composed: A boolean value that indicates whether the shadow root should be returned (false, the default), or a root node beyond shadow root (true).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("composed")]
        public bool? Composed { get; set; }
    }
}
