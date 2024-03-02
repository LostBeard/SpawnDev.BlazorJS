using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Element.checkVisibility options
    /// </summary>
    public class CheckVisibilityOptions
    {
        /// <summary>
        /// true to check if the element content-visibility property has (or inherits) the value auto, and it is currently skipping its rendering. false by default.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ContentVisibilityAuto { get; set; }
        /// <summary>
        /// true to check if the element opacity property has (or inherits) a value of 0. false by default.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? OpacityProperty { get; set; }
        /// <summary>
        /// true to check if the element is invisible due to the value of its visibility property. false by default.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? VisibilityProperty { get; set; }
    }
}