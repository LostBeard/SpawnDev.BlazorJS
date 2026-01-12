namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaCapabilitiesInfo interface of the Media Capabilities API is returned when MediaCapabilities.decodingInfo() or MediaCapabilities.encodingInfo() is called. It contains information about whether the media configuration is supported, and if so, whether decoding/encoding will be smooth and power efficient.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaCapabilitiesInfo
    /// </summary>
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
