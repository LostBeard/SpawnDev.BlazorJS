using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Object that controls how the element is defined.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/CustomElementRegistry/define#options
    /// </summary>
    public class CustomElementOptions
    {
        /// <summary>
        /// String specifying the name of a built-in element to extend. Used to create a customized built-in element.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Extends { get; set; }
    }
}
