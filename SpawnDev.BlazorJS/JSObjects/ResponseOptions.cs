using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An options object containing settings for the response, including the status code, status text, and headers.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Response/Response#options<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Response/json_static#options
    /// </summary>
    public class ResponseOptions
    {
        /// <summary>
        /// The status code for the response, such as 200.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Status { get; set; }
        /// <summary>
        /// The status message associated with the status code. For a status of 200 this might be OK.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StatusText { get; set; }
        /// <summary>
        /// Any headers you want to add to your response, contained within a Headers object or object literal of String key/value pairs (see HTTP headers for a reference).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Headers? Headers { get; set; }
    }
}
