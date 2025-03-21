using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object that sets options for the image's extraction when using Window.CreateImageBitmap<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Window/createImageBitmap#options
    /// </summary>
    public class ImageBitmapOptions
    {
        /// <summary>
        /// Specifies how the bitmap image should be oriented.<br/>
        /// "from-image" - Image oriented according to EXIF orientation metadata, if present (default).<br/>
        /// "flipY" - Image oriented according to EXIF orientation metadata, if present, and then flipped vertically.<br/>
        /// "none" - Image oriented according to image encoding, ignoring any metadata about the orientation (such as EXIF metadata, that might be added to an image to indicate that the camera was turned sideways to capture the image in portrait mode).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ImageOrientation { get; set; }
        /// <summary>
        /// Specifies whether the bitmap's color channels should be premultiplied by the alpha channel. One of none, premultiply, or default (default).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? PremultiplyAlpha { get; set; }
        /// <summary>
        /// Specifies whether the image should be decoded using color space conversion. Either none or default (default). The value default indicates that implementation-specific behavior is used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ColorSpaceConversion { get; set; }
        /// <summary>
        /// A long integer that indicates the output width.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ResizeWidth { get; set; }
        /// <summary>
        /// A long integer that indicates the output height.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ResizeHeight { get; set; }
        /// <summary>
        /// Specifies the algorithm to be used for resizing the input to match the output dimensions. One of pixelated, low (default), medium, or high.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResizeQuality { get; set; }
    }
}
