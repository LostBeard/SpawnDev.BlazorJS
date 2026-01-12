using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options utilized when creating a new IntersectionObserver.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/IntersectionObserver/IntersectionObserver#options
    /// </summary>
    public class IntersectionObserverInit
    {
        /// <summary>
        /// An Element or Document object which is an ancestor of the intended target, whose bounding rectangle will be considered the viewport. Any part of the target not visible in the visible area of the root is not considered visible.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Element? Root { get; set; }
        /// <summary>
        /// A string which specifies a set of offsets to add to the root's bounding_box when calculating intersections, effectively shrinking or growing the root for calculation purposes. The syntax is approximately the same as that for the CSS margin property; see The root intersection rectangle for more information. The default is "0px 0px 0px 0px".
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RootMargin { get; set; }
        /// <summary>
        /// Either a single number or an array of numbers between 0.0 and 1.0, specifying a ratio of intersection area to total bounding box area for the observed target. A value of 0.0 means that even a single visible pixel counts as the target being visible. 1.0 means that the entire target element is visible. See Thresholds for a more in-depth description of how thresholds are used. The default is a threshold of 0.0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<double, double[]>? Threshold { get; set; }
    }
}
