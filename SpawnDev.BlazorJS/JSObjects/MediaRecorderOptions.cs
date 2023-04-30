using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    public class MediaRecorderOptions
    {
        /// <summary>
        /// A MIME type specifying the format for the resulting media; you may specify the container format (the browser will select its preferred codecs for audio and/or video), or you may use the codecs parameter and/or the profiles parameter to provide detailed information about which codecs to use and how to configure them. Applications can check in advance if a mimeType is supported by the user agent by calling MediaRecorder.isTypeSupported()
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? MimeType { get; set; }
        /// <summary>
        /// The chosen bitrate for the audio component of the media.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? AudioBitsPerSecond { get; set; }
        /// <summary>
        /// The chosen bitrate for the video component of the media.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? VideoBitsPerSecond { get; set; }
        /// <summary>
        /// The chosen bitrate for the audio and video components of the media. This can be specified instead of the above two properties. If this is specified along with one or the other of the above properties, this will be used for the one that isn't specified.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? BitsPerSecond { get; set; }
    }
}
