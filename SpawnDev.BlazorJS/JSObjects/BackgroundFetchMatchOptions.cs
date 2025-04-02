using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Options used with BackgroundFetchRegistration.Match()<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BackgroundFetchRegistration/match#options
    /// </summary>
    public class BackgroundFetchMatchOptions
    {
        /// <summary>
        /// A boolean value that specifies whether to ignore the query string in the URL. For example, if set to true the ?value=bar part of http://foo.com/?value=bar would be ignored when performing a match. It defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreSearch { get; set; }
        /// <summary>
        /// A boolean value. When true, prevents matching operations from validating the Request http method. If false (the default) only GET and HEAD are allowed.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreMethod { get; set; }
        /// <summary>
        /// A boolean value. When true indicates that the Vary header should be ignored. It defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreVary { get; set; }
    }
}
