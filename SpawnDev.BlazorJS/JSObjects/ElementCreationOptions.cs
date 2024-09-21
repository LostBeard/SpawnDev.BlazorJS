using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Document/createElement#options
    /// </summary>
    public class ElementCreationOptions
    {
        /// <summary>
        /// The tag name of a custom element previously defined via customElements.define().
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Is { get; set; }
    }
}
