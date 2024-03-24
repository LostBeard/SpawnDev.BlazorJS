namespace SpawnDev.BlazorJS.JSObjects
{
    public class VideoFrameDataOptions
    {
        /// <summary>
        /// A string representing the video pixel format. One of the following strings, which are fully described on the page for the format property:<br />
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
    }
}
