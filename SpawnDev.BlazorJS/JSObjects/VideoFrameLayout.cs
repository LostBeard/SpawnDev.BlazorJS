namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Describes a video plane layout for a VideoFrame
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#layout
    /// </summary>
    public class VideoFrameLayout
    {
        /// <summary>
        /// An integer representing the offset in bytes where the given plane begins.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// An integer representing the number of bytes, including padding, used by each row of the plane. Planes may not overlap. If no layout is specified, the planes will be tightly packed.
        /// </summary>
        public int Stride { get; set; }
    }
}
