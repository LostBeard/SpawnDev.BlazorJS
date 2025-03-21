using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Window.Scroll() options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Window/scroll#options
    /// </summary>
    public class ScrollOptions
    {
        /// <summary>
        /// Specifies the number of pixels along the Y axis to scroll the window or element.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Top { get; set; }
        /// <summary>
        /// Specifies the number of pixels along the X axis to scroll the window or element.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Left { get; set; }
        /// <summary>
        /// Determines whether scrolling is instant or animates smoothly. This option is a string which must take one of the following values:<br/>
        /// smooth: scrolling should animate smoothly<br/>
        /// instant: scrolling should happen instantly in a single jump<br/>
        /// auto: scroll behavior is determined by the computed value of scroll-behavior
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Behavior { get; set; }
    }
}
