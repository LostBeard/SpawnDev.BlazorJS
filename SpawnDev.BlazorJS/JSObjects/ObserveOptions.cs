using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An options object allowing you to set options for the observation.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ResizeObserver/observe#options
    /// </summary>
    public class ObserveOptions
    {
        /// <summary>
        /// Sets which box model the observer will observe changes to. Possible values are:<br/>
        /// "content-box" - Size of the content area as defined in CSS. (default)<br/>
        /// "border-box" - Size of the box border area as defined in CSS.<br/>
        /// "device-pixel-content-box" - The size of the content area as defined in CSS, in device pixels, before applying any CSS transforms on the element or its ancestors.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Box { get; set; }
    }
}
