using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// DocumentPictureInPicture.RequestWindow options
    /// </summary>
    public class PIPRequestWindowOptions
    {
        /// <summary>
        /// A non-negative number representing the width to set for the Picture-in-Picture window's viewport, in pixels. If options is not specified, the default value 0 is used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int Width { get; set; }
        /// <summary>
        /// A non-negative number representing the height to set for the Picture-in-Picture window's viewport, in pixels. If options is not specified, the default value 0 is used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int Height { get; set; }
    }
}
