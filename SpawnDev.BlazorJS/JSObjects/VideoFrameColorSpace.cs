namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object representing the color space of the VideoFrame<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame/VideoFrame#colorspace
    /// </summary>
    public class VideoFrameColorSpace
    {
        /// <summary>
        /// A string representing the video color primaries, described on the page for the VideoColorSpace.primaries property.
        /// </summary>
        public string Primaries { get; set; }
        /// <summary>
        /// A string representing the video color transfer function, described on the page for the VideoColorSpace.transfer property.
        /// </summary>
        public string Transfer { get; set; }
        /// <summary>
        /// A string representing the video color matrix, described on the page for the VideoColorSpace.matrix property.
        /// </summary>
        public string Matrix { get; set; }
        /// <summary>
        /// A Boolean. If true, indicates that full-range color values are used.
        /// </summary>
        public bool FullRange { get; set; }
    }
}
