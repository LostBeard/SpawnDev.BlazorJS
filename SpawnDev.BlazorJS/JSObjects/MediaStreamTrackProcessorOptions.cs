using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// MediaStreamTrackProcessor constructor options.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackProcessor/MediaStreamTrackProcessor#options
    /// </summary>
    public class MediaStreamTrackProcessorOptions
    {
        /// <summary>
        /// The MediaStreamTrack to be processed.
        /// </summary>
        public MediaStreamTrack Track { get; set; }
        /// <summary>
        /// An integer specifying the maximum number of media frames to be buffered.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxBufferSize { get; set; }
    }
}
