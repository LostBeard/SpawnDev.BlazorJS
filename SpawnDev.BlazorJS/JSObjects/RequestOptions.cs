using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// An object containing any custom settings that you want to apply to the request.
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        /// The request method, e.g., GET, POST. The default is GET
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Method { get; set; }
        /// <summary>
        /// Any headers you want to add to your request, contained within a Headers object or an object literal with String values
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Headers? Headers { get; set; }
        /// <summary>
        /// Any body that you want to add to your request: this can be a Blob, an ArrayBuffer, a TypedArray, a DataView, a FormData, a URLSearchParams, a string, or a ReadableStream object. Note that a request using the GET or HEAD method cannot have a body
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Union<Blob, ArrayBuffer, TypedArray, DataView, FormData, URLSearchParams, string, ReadableStream, byte[]>? Body { get; set; }
        /// <summary>
        /// The mode you want to use for the request, e.g., cors, no-cors, same-origin, or navigate. The default is cors.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }
        /// <summary>
        /// The request credentials you want to use for the request: omit, same-origin, or include. The default is same-origin
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Credentials { get; set; }
        /// <summary>
        /// The cache mode you want to use for the request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Cache { get; set; }
        /// <summary>
        /// The redirect mode to use: follow, error, or manual. The default is follow.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Redirect { get; set; }
        /// <summary>
        /// A string specifying no-referrer, client, or a URL. The default is about:client
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Referrer { get; set; }
        /// <summary>
        /// A string that changes how the referrer header is populated during certain actions (e.g., fetching subresources, prefetching, performing navigations).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReferrerPolicy { get; set; }
        /// <summary>
        /// Contains the subresource integrity value of the request (e.g., sha256-BpfBw7ivV8q2jLiT13fxDYAe2tJllusRSZ273h2nFSE=).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Integrity { get; set; }
        /// <summary>
        /// A boolean that indicates whether to make a persistent connection for multiple requests/responses.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? KeepAlive { get; set; }
        /// <summary>
        /// An AbortSignal object which can be used to communicate with/abort a request.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }
        /// <summary>
        /// Specifies the priority of the fetch request relative to other requests of the same type. Must be one of the following strings:<br/>
        /// high - A high priority fetch request relative to other requests of the same type.<br/>
        /// low  - A low priority fetch request relative to other requests of the same type.<br/>
        /// auto - Automatically determine the priority of the fetch request relative to other requests of the same type (default).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Priority { get; set; }
    }
}
