using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used in InkPresenter.requestPresenter
    /// </summary>
    public class InkPresenterStyle
    {
        /// <summary>
        /// A String containing a valid CSS color code, indicating the color the presenter will use when rendering the ink trail.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Color { get; set; }
        /// <summary>
        /// A number representing the diameter the presenter will use when rendering the ink trail.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public float? Diameter { get; set; }
    }
}
