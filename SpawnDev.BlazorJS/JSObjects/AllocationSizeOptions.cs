using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// VideoFrame.AllocationSize() options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/allocationSize#options
    /// </summary>
    public class AllocationSizeOptions
    {
        /// <summary>
        /// The rectangle of pixels to copy from the VideoFrame. If unspecified the visibleRect will be used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoFrameRect? Rect { get; set; }
        /// <summary>
        /// A list containing the following values for each plane in the VideoFrame.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<VideoFrameLayout>? Layout { get; set; }

    }
}
