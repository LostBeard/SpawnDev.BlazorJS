using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used when creating a new VideoFrame using ArrayBuffer, TypedArray, or DataView data<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#options_2
    /// </summary>
    public class VideoFrameDataOptions
    {
        /// <summary>
        /// A string representing the video pixel format. One of the following strings, which are fully described on the page for the format property:<br/>
        /// I420, I420A, I422, I444, NV12, RGBA, RGBX, BGRA, BGRX
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Width of the VideoFrame in pixels, potentially including non-visible padding, and prior to considering potential ratio adjustments.
        /// </summary>
        public int CodedWidth { get; set; }
        /// <summary>
        /// Height of the VideoFrame in pixels, potentially including non-visible padding, and prior to considering potential ratio adjustments.
        /// </summary>
        public int CodedHeight { get; set; }
        /// <summary>
        /// An integer representing the timestamp of the frame in microseconds.
        /// </summary>
        public double Timestamp { get; set; }
        /// <summary>
        /// An integer representing the duration of the frame in microseconds.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Duration { get; set; }
        /// <summary>
        /// A list containing the layout for each plane
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<VideoFrameLayout>? Layout { get; set; }
        /// <summary>
        /// An object representing the visible rectangle of the VideoFrame
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoFrameRect? VisibleRect { get; set; }
        /// <summary>
        /// The width of the VideoFrame when displayed after applying aspect-ratio adjustments.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayWidth { get; set; }
        /// <summary>
        /// The height of the VideoFrame when displayed after applying aspect-ratio adjustments.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? DisplayHeight { get; set; }
        /// <summary>
        /// An object representing the color space of the VideoFrame
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideoColorSpaceOptions? ColorSpace { get; set; }
        /// <summary>
        /// An array of ArrayBuffers that VideoFrame will detach and take ownership of. If the array contains the ArrayBuffer backing data, VideoFrame will use that buffer directly instead of copying from it.
        /// </summary>
        public ArrayBuffer[]? Transfer { get; set; }
    }
}
