namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options for the MediaStreamTrackProcessor constructor.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator/MediaStreamTrackGenerator#options
    /// </summary>
    public class MediaStreamTrackGeneratorOptions
    {
        /// <summary>
        /// The kind of media frames that the MediaStreamTrackGenerator will produce.<br/>
        /// This can be:<br/>
        /// "audio"<br/>
        /// "video"
        /// </summary>
        public string Kind { get; set; }
    }
}
