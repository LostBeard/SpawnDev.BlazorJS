using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Window/structuredClone#options
    /// </summary>
    public class StructuredCloneOptions
    {
        /// <summary>
        /// An array of transferable objects that will be moved rather than cloned to the returned object.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<object>? Transfer { get; set; }
    }
}
