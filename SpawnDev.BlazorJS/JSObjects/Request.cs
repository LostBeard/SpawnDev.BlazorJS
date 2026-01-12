using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Request interface of the Fetch API represents a resource request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Request
    /// </summary>
    public class Request : JSObject
    {
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="input"></param>
        public Request(string input) : base(JS.New(nameof(Request), input)) { }
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="options"></param>
        public Request(string input, RequestOptions options) : base(JS.New(nameof(Request), input, options)) { }
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="input"></param>
        public Request(Request input) : base(JS.New(nameof(Request), input)) { }
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="options"></param>
        public Request(Request input, RequestOptions options) : base(JS.New(nameof(Request), input, options)) { }
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="_ref"></param>
        public Request(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A ReadableStream of the body contents.
        /// </summary>
        public ReadableStream Body => JSRef!.Get<ReadableStream>("body");
        /// <summary>
        /// Stores true or false to indicate whether or not the body has been used in a request yet.
        /// </summary>
        public bool BodyUsed => JSRef!.Get<bool>("bodyUsed");
        /// <summary>
        /// Contains the cache mode of the request (e.g., default, reload, no-cache).
        /// </summary>
        public string Cache => JSRef!.Get<string>("cache");
        /// <summary>
        /// Contains the credentials of the request (e.g., omit, same-origin, include). The default is same-origin.
        /// </summary>
        public string Credentials => JSRef!.Get<string>("credentials");
        /// <summary>
        /// A string describing the type of content being requested
        /// </summary>
        public string Destination => JSRef!.Get<string>("destination");
        /// <summary>
        /// Contains the associated Headers object of the request.
        /// </summary>
        public Headers Headers => JSRef!.Get<Headers>("headers");
        /// <summary>
        /// Contains the subresource integrity value of the request (e.g., sha256-BpfBw7ivV8q2jLiT13fxDYAe2tJllusRSZ273h2nFSE=)
        /// </summary>
        public string Integrity => JSRef!.Get<string>("integrity");
        /// <summary>
        /// Contains the request's method (GET, POST, etc.)
        /// </summary>
        public string Method => JSRef!.Get<string>("method");
        /// <summary>
        /// Contains the mode of the request (e.g., cors, no-cors, same-origin, navigate.)
        /// </summary>
        public string Mode => JSRef!.Get<string>("mode");
        /// <summary>
        /// Contains the mode for how redirects are handled. It may be one of follow, error, or manual.
        /// </summary>
        public string Redirect => JSRef!.Get<string>("redirect");
        /// <summary>
        /// Contains the referrer of the request (e.g., client)
        /// </summary>
        public string Referrer => JSRef!.Get<string>("referrer");
        /// <summary>
        /// Contains the referrer policy of the request (e.g., no-referrer).
        /// </summary>
        public string ReferrerPolicy => JSRef!.Get<string>("referrerPolicy");
        /// <summary>
        /// Returns the AbortSignal associated with the request
        /// </summary>
        public AbortSignal Signal => JSRef!.Get<AbortSignal>("signal");
        /// <summary>
        /// Contains the URL of the request.
        /// </summary>
        public string Url => JSRef!.Get<string>("url");
        /// <summary>
        /// Returns a promise that resolves with an ArrayBuffer representation of the request body.
        /// </summary>
        /// <returns></returns>
        public Task<ArrayBuffer> ArrayBuffer() => JSRef!.CallAsync<ArrayBuffer>("arrayBuffer");
        /// <summary>
        /// Returns a promise that resolves with a Blob representation of the request body.
        /// </summary>
        /// <returns></returns>
        public Task<Blob> Blob() => JSRef!.CallAsync<Blob>("blob");
        /// <summary>
        /// Creates a copy of the current Request object.
        /// </summary>
        /// <returns></returns>
        public Request Clone() => JSRef!.Call<Request>("clone");
        /// <summary>
        /// Returns a promise that resolves with a FormData representation of the request body.
        /// </summary>
        /// <returns></returns>
        public Task<FormData> FormData() => JSRef!.CallAsync<FormData>("formData");
        /// <summary>
        /// Returns a promise that resolves with the result of parsing the request body as JSON.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Json<T>() => JSRef!.Call<T>("json");
        /// <summary>
        /// Returns a promise that resolves with a text representation of the request body.
        /// </summary>
        /// <returns></returns>
        public Task<string> Text() => JSRef!.CallAsync<string>("text");
    }
}
