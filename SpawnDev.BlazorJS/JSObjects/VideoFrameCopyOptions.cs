using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// VideoFrame.CopyTo() options
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/copyTo#options
    /// </summary>
    public class VideoFrameCopyOptions
    {
        /// <summary>
        /// The rectangle of pixels to copy from the VideoFrame.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoFrameRect Rect { get; set; }
        /// <summary>
        /// A list containing the layout for each plane
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<VideoFrameLayout> Layout { get; set; }
    }
}
