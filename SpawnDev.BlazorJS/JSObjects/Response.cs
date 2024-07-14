using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The Response interface of the Fetch API represents the response to a request.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/Response
    /// </summary>
    public class Response : JSObject
    {
        /// <summary>
        /// Returns a new Response object associated with a network error.
        /// </summary>
        /// <returns></returns>
        public static Response Error() => JS.Call<Response>("Response.error");
        /// <summary>
        /// Returns a new response with a different URL.
        /// </summary>
        /// <param name="url">The URL that the new response is to originate from.</param>
        /// <param name="status">An optional number indicating the status code for the response: one of 301, 302, 303, 307, or 308.<br/>If omitted, 302 (Found) is used by default.</param>
        /// <returns>A Response object.</returns>
        public static Response Redirect(string url, ushort status) => JS.Call<Response>("Response.redirect", url, status);
        /// <summary>
        /// Returns a new response with a different URL.
        /// </summary>
        /// <param name="url">The URL that the new response is to originate from.</param>
        /// <returns>A Response object.</returns>
        public static Response Redirect(string url) => JS.Call<Response>("Response.redirect", url);
        /// <summary>
        /// Returns a new Response object for returning the provided JSON encoded data.
        /// </summary>
        /// <param name="data">The JSON data to be used as the response body.</param>
        /// <param name="options">An options object containing settings for the response, including the status code, status text, and headers. This is the same as the options parameter of the Response() constructor.</param>
        /// <returns></returns>
        public static Response Json(object data, ResponseOptions? options = null) => options == null ? JS.Call<Response>("Response.redirect", data) : JS.Call<Response>("Response.redirect", data, options);
        /// <summary>
        /// The Request() constructor creates a new Request object.
        /// </summary>
        /// <param name="_ref"></param>
        public Response(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new Response object.
        /// </summary>
        public Response() : base(JS.New(nameof(Response))) { }
        /// <summary>
        /// Creates a new Response object.
        /// </summary>
        public Response(string body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        /// <summary>
        /// Creates a new Response object.
        /// </summary>
        public Response(Blob body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        /// <summary>
        /// Creates a new Response object.
        /// </summary>
        public Response(ArrayBuffer body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        /// <summary>
        /// Creates a new Response object.
        /// </summary>
        public Response(ReadableStream body, ResponseOptions? options = null) : base(JS.New(nameof(Response), body, options)) { }
        /// <summary>
        /// A ReadableStream of the body contents.
        /// </summary>
        public ReadableStream? Body => JSRef!.Get<ReadableStream?>("body");
        /// <summary>
        /// Stores a boolean value that declares whether the body has been used in a response yet.
        /// </summary>
        public bool BodyUsed => JSRef!.Get<bool>("bodyUsed");
        /// <summary>
        /// The Headers object associated with the response.
        /// </summary>
        public Headers Headers => JSRef!.Get<Headers>("headers");
        /// <summary>
        /// A boolean indicating whether the response was successful (status in the range 200 – 299) or not.
        /// </summary>
        public bool Ok => JSRef!.Get<bool>("ok");
        /// <summary>
        /// Indicates whether or not the response is the result of a redirect (that is, its URL list has more than one entry).
        /// </summary>
        public bool Redirected => JSRef!.Get<bool>("redirected");
        /// <summary>
        /// The status code of the response. (This will be 200 for a success).
        /// </summary>
        public ushort Status => JSRef!.Get<ushort>("status");
        /// <summary>
        /// The status message corresponding to the status code. (e.g., OK for 200).
        /// </summary>
        public string StatusText => JSRef!.Get<string>("statusText");
        /// <summary>
        /// The type of the response (e.g., basic, cors).
        /// </summary>
        public string Type => JSRef!.Get<string>("type");
        /// <summary>
        /// The URL of the response.
        /// </summary>
        public string Url => JSRef!.Get<string>("url");
        /// <summary>
        /// Returns a promise that resolves with an ArrayBuffer representation of the response body.
        /// </summary>
        /// <returns></returns>
        public Task<ArrayBuffer> ArrayBuffer() => JSRef!.CallAsync<ArrayBuffer>("arrayBuffer");
        /// <summary>
        /// Returns a promise that resolves with a Blob representation of the response body.
        /// </summary>
        /// <returns></returns>
        public Task<Blob> Blob() => JSRef!.CallAsync<Blob>("blob");
        /// <summary>
        /// Returns a promise that resolves with a Uint8Array representation of the response body.
        /// </summary>
        /// <returns></returns>
        public Task<Uint8Array> Bytes() => JSRef!.CallAsync<Uint8Array>("bytes");
        /// <summary>
        /// Creates a clone of a Response object.
        /// </summary>
        /// <returns></returns>
        public Task<Blob> Clone() => JSRef!.CallAsync<Blob>("clone");
        /// <summary>
        /// Returns a promise that resolves with a FormData representation of the response body.
        /// </summary>
        /// <returns></returns>
        public Task<FormData> FormData() => JSRef!.CallAsync<FormData>("formData");
        /// <summary>
        /// Returns a promise that resolves with the result of parsing the response body text as JSON.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task<T> Json<T>() => JSRef!.CallAsync<T>("json");
        /// <summary>
        /// Returns a promise that resolves with the result of parsing the response body text as JSON.
        /// </summary>
        /// <returns></returns>
        public Task Json() => JSRef!.CallAsync<JSObject>("json");
        /// <summary>
        /// Returns a promise that resolves with a text representation of the response body.
        /// </summary>
        /// <returns></returns>
        public Task<string> Text() => JSRef!.CallAsync<string>("text");
        /// <summary>
        /// Non-standard method that returns a .Net byte[]
        /// </summary>
        /// <returns></returns>
        public async Task<byte[]> ReadBytes()
        {
            using var uint8Array = await Bytes();
            return uint8Array.ReadBytes();
        }
    }
}
