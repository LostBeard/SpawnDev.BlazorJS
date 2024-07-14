using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Settings used when creating an ImageData instance
    /// https://developer.mozilla.org/en-US/docs/Web/API/ImageData/ImageData#settings
    /// </summary>
    public class ImageDataSettings
    {
        /// <summary>
        /// colorSpace: Specifies the color space of the image data. Can be set to "srgb" for the sRGB color space or "display-p3" for the display-p3 color space.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ColorSpace { get; set; }
    }
}
