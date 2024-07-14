using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when calling Canvas.Get2DContext or OffscreenCanvas.Get2DContext
    /// </summary>
    public class ContextAttributes2D
    {
        /// <summary>
        /// A boolean value that indicates if the canvas contains an alpha channel. If set to false, the browser now knows that the backdrop is always opaque, which can speed up drawing of transparent content and images.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Alpha { get; set; } = null;
        /// <summary>
        /// A boolean value that hints the user agent to reduce the latency by desynchronizing the canvas paint cycle from the event loop
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Desynchronized { get; set; } = null;
        /// <summary>
        /// A boolean value that indicates whether or not a lot of read-back operations are planned. This will force the use of a software (instead of hardware accelerated) 2D canvas and can save memory when calling getImageData() frequently.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WillReadFrequently { get; set; } = null;
        /// <summary>
        /// Specifies the color space of the rendering context. Possible values are:<br/>
        /// "srgb" selects the sRGB color space. This is the default value.<br/>
        /// "display-p3" selects the display-p3 color space.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ColorSpace { get; set; } = null;
    }
}
