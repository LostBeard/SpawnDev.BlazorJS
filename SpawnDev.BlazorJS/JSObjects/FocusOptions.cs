using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Optional parameter of HTMLElement.focus() for controlling aspects of the focusing process. 
    /// </summary>
    public class FocusOptions
    {
        /// <summary>
        /// A boolean value indicating whether or not the browser should scroll the document to bring the newly-focused element into view. A value of false for preventScroll (the default) means that the browser will scroll the element into view after focusing it. If preventScroll is set to true, no scrolling will occur.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PreventScroll { get; set; }
        /// <summary>
        /// A boolean value that should be set to true to force visible indication that the element is focused. By default, or if the property is not true, a browser may still provide visible indication if it determines that this would improve accessibility for users.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FocusVisible { get; set; }
    }
}