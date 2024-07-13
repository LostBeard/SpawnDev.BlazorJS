using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object that sets options for the match operation<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Cache/match#options
    /// </summary>
    public class CacheMatchOptions
    {
        /// <summary>
        /// A boolean value that specifies whether the matching process should ignore the query string in the URL. For example, if set to true, the ?value=bar part of http://foo.com/?value=bar would be ignored when performing a match. It defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreSearch { get; set; }
        /// <summary>
        /// A boolean value that, when set to true, prevents matching operations from validating the Request http method (normally only GET and HEAD are allowed.) It defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreMethod { get; set; }
        /// <summary>
        /// A boolean value that, when set to true, tells the matching operation not to perform VARY header matching. In other words, if the URL matches you will get a match regardless of whether the Response object has a VARY header or not. It defaults to false.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreVary { get; set; }
        /// <summary>
        /// A string that represents a specific cache to search within.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CacheName { get; set; }
    }
}
