using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ColorSelectionResult dictionary of the EyeDropper API provides the result of an eye dropper selection.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/ColorSelectionResult
    /// </summary>
    public class ColorSelectionResult
    {
        /// <summary>
        /// A string representing the selected color, in hexadecimal sRGB format (#RRGGBB).
        /// </summary>
        [JsonPropertyName("sRGBHex")]
        public string SRGBHex { get; set; } = "";
    }
}
