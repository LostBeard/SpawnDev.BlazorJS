using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Used to customize the BackgroundFetchManager fetch progress dialog that the browser shows to the user.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchManager/fetch#options
    /// </summary>
    public class BackgroundFetchOptions
    {
        /// <summary>
        /// A string that will be used as the title for the progress dialog.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public IEnumerable<IconInfo>? Icons { get; set; }
        /// <summary>
        /// A number representing the estimated total download size, in bytes, for the fetch operation. This is used to show the user how big the download is and to show the user download progress.<br/>
        /// As soon as the total download size exceeds downloadTotal, then the fetch is aborted.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public long? DownloadTotal { get; set; }
    }
}
