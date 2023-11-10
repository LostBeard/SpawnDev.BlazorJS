namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaCapabilitiesInfo
    {
        /// <summary>
        /// true if the media content can be decoded at all. Otherwise, it is false.
        /// </summary>
        public bool Supported { get; set; }
        /// <summary>
        /// true if playback of the media will be smooth (of high quality). Otherwise it is false.
        /// </summary>
        public bool Smooth { get; set; }
        /// <summary>
        /// true if playback of the media will be power efficient. Otherwise, it is false.
        /// </summary>
        public bool PowerEfficient { get; set; }
    }
}
