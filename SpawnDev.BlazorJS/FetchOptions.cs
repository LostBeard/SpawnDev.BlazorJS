using SpawnDev.BlazorJS.JSObjects;
using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS
{
    public class FetchOptions
    {
        /// <summary>
        /// The request method, e.g., "GET", "POST". The default is "GET". Note that the Origin header is not set on Fetch requests with a method of HEAD or GET. (This behavior was corrected in Firefox 65 — see Firefox bug 1508661.) Any string which is a case-insensitive match for one of the methods in RFC 9110 will be uppercased automatically. If you want to use a custom method (like PATCH), you should uppercase it yourself.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Method { get; set; }

        /// <summary>
        /// Any body that you want to add to your request: this can be a Blob, an ArrayBuffer, a TypedArray, a DataView, a FormData, a URLSearchParams, string object or literal, or a ReadableStream object. This latest possibility is still experimental; check the compatibility information to verify you can use it. Note that a request using the GET or HEAD method cannot have a body.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Body { get; set; }

        /// <summary>
        /// The mode you want to use for the request, e.g., cors, no-cors, or same-origin.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mode { get; set; }

        /// <summary>
        /// Controls what browsers do with credentials (cookies, HTTP authentication entries, and TLS client certificates). Must be one of the following strings:<br />
        /// omit - Tells browsers to exclude credentials from the request, and ignore any credentials sent back in the response (e.g., any Set-Cookie header).<br />
        /// same-origin - Tells browsers to include credentials with requests to same-origin URLs, and use any credentials sent back in responses from same-origin URLs. This is the default value.<br />
        /// include - Tells browsers to include credentials in both same- and cross-origin requests, and always use any credentials sent back in responses.<br />
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Credentials { get; set; }

        /// <summary>
        /// A string indicating how the request will interact with the browser's HTTP cache. The possible values, default, no-store, reload, no-cache, force-cache, and only-if-cached, are documented in the article for the cache property of the Request object.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Cache { get; set; }

        /// <summary>
        /// How to handle a redirect response:<br />
        /// follow - Automatically follow redirects. Unless otherwise stated the redirect mode is set to follow<br />
        /// error -  Abort with an error if a redirect occurs<br />
        /// manual - Caller intends to process the response in another context. See WHATWG fetch standard for more information.<br />
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Redirect { get; set; }

        /// <summary>
        /// A string specifying the referrer of the request. This can be a same-origin URL, about:client, or an empty string.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Referrer { get; set; }

        /// <summary>
        /// Specifies the referrer policy to use for the request. May be one of no-referrer, no-referrer-when-downgrade, same-origin, origin, strict-origin, origin-when-cross-origin, strict-origin-when-cross-origin, or unsafe-url.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReferrerPolicy { get; set; }

        /// <summary>
        /// Contains the subresource integrity value of the request (e.g., sha256-BpfBw7ivV8q2jLiT13fxDYAe2tJllusRSZ273h2nFSE=).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Integrity { get; set; }

        /// <summary>
        /// The keepalive option can be used to allow the request to outlive the page. Fetch with the keepalive flag is a replacement for the Navigator.sendBeacon() API.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Keepalive { get; set; }

        /// <summary>
        /// An AbortSignal object instance; allows you to communicate with a fetch request and abort it if desired via an AbortController.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public AbortSignal? Signal { get; set; }

        /// <summary>
        /// Specifies the priority of the fetch request relative to other requests of the same type. Must be one of the following strings:<br />
        /// high - A high priority fetch request relative to other requests of the same type.<br />
        /// low - A low priority fetch request relative to other requests of the same type.<br />
        /// auto - Automatically determine the priority of the fetch request relative to other requests of the same type (default).<br />
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Priority { get; set; }


        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, string>? Headers { get; set; }
    }
}
