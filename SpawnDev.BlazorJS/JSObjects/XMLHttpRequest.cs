using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// XMLHttpRequest (XHR) objects are used to interact with servers. You can retrieve data from a URL without having to do a full page refresh. This enables a Web page to update just part of a page without disrupting what the user is doing.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest
    /// </summary>
    public class XMLHttpRequest : XMLHttpRequestEventTarget
    {
        #region Constructors
        /// <summary>
        /// The XMLHttpRequest() constructor creates a new XMLHttpRequest
        /// </summary>
        public XMLHttpRequest() : base(JS.New("XMLHttpRequest")) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public XMLHttpRequest(IJSInProcessObjectReference _ref) : base(_ref) { }
        #endregion
        #region Property get/set
        /// <summary>
        /// A XMLHttpRequestUpload representing the upload process.
        /// </summary>
        public XMLHttpRequestUpload Upload => JSRef!.Get<XMLHttpRequestUpload>("upload");
        /// <summary>
        /// Returns a number representing the state of the request.
        /// </summary>
        public int ReadyState => JSRef!.Get<int>("readyState");
        /// <summary>
        /// Get the request response as type TResponse
        /// </summary>
        /// <typeparam name="TResponse">Response type</typeparam>
        public TResponse? GetResponseAs<TResponse>() => JSRef!.Get<TResponse>("response");
        /// <summary>
        /// Get the request response as type Blob
        /// </summary>
        public Blob? GetResponseAsBlob() => JSRef!.Get<Blob?>("response");
        /// <summary>
        /// Get the request response as type ArrayBuffer
        /// </summary>
        public ArrayBuffer? GetResponseAsArrayBuffer() => JSRef!.Get<ArrayBuffer?>("response");
        /// <summary>
        /// Get the request response as type Document
        /// </summary>
        public Document? GetResponseAsDocument() => JSRef!.Get<Document?>("response");
        /// <summary>
        /// Returns a string that contains the response to the request as text, or null if the request was unsuccessful or has not yet been sent.
        /// </summary>
        public string? ResponseText => JSRef!.Get<string?>("responseText");
        /// <summary>
        /// Returns the serialized URL of the response or the empty string if the URL is null.
        /// </summary>
        public string ResponseURL => JSRef!.Get<string>("responseURL");
        /// <summary>
        /// Returns a Document containing the response to the request, or null if the request was unsuccessful, has not yet been sent, or cannot be parsed as XML or HTML. Not available in Web Workers.
        /// </summary>
        public Document? ResponseXML => JSRef!.Get<Document?>("responseXML");
        /// <summary>
        /// Returns the HTTP response status code of the request.
        /// </summary>
        public int Status => JSRef!.Get<int>("status");
        /// <summary>
        /// Returns a string containing the response string returned by the HTTP server. Unlike XMLHttpRequest.status, this includes the entire text of the response message ("OK", for example).
        /// </summary>
        public string StatusText => JSRef!.Get<string>("statusText");
        /// <summary>
        /// The time in milliseconds a request can take before automatically being terminated.
        /// </summary>
        public double Timeout { get => JSRef!.Get<double>("timeout"); set => JSRef!.Set("timeout", value); }
        /// <summary>
        /// Returns true if cross-site Access-Control requests should be made using credentials such as cookies or authorization headers; otherwise false.
        /// </summary>
        public bool WithCredentials { get => JSRef!.Get<bool>("withCredentials"); set => JSRef!.Set("withCredentials", value); }
        /// <summary>
        /// Specifies the type of the response. Possible values: <br/>
        /// "" - An empty responseType string is the same as "text", the default type.<br/>
        /// "arraybuffer" - The response is a JavaScript ArrayBuffer containing binary data.<br/>
        /// "blob" - The response is a Blob object containing the binary data.<br/>
        /// "document" - The response is an HTML Document or XML XMLDocument, as appropriate based on the MIME type of the received data. See HTML in XMLHttpRequest to learn more about using XHR to fetch HTML content.<br/>
        /// "json"  - The response is a JavaScript object created by parsing the contents of received data as JSON.<br/>
        /// "text" - The response is a text in a string.<br/>
        /// </summary>
        public string ResponseType { get => JSRef!.Get<string>("responseType"); set => JSRef!.Set("responseType", value); }
        #endregion
        #region Methods
        /// <summary>
        /// Aborts the request if it has already been sent.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");
        /// <summary>
        /// Returns all the response headers, separated by CRLF, as a string, or null if no response has been received.
        /// </summary>
        /// <returns></returns>
        public string? GetAllResponseHeaders() => JSRef!.Call<string?>("getAllResponseHeaders");
        /// <summary>
        /// Returns all the response headers, separated by CRLF, as a string, or null if no response has been received.
        /// </summary>
        /// <param name="headerName"></param>
        /// <returns></returns>
        public string? GetResponseHeader(string headerName) => JSRef!.Call<string?>("getResponseHeader", headerName);
        /// <summary>
        /// The XMLHttpRequest method open() initializes a newly-created request, or re-initializes an existing one.
        /// </summary>
        /// <param name="method">The HTTP request method to use, such as "GET", "POST", "PUT", "DELETE", etc. Ignored for non-HTTP(S) URLs.</param>
        /// <param name="url">A string or any other object with a stringifier — including a URL object — that provides the URL of the resource to send the request to.</param>
        /// <param name="async">An optional Boolean parameter, defaulting to true, indicating whether or not to perform the operation asynchronously. If this value is false, the send() method does not return until the response is received. If true, notification of a completed transaction is provided using event listeners. This must be true if the multipart attribute is true, or an exception will be thrown.</param>
        /// <param name="user">The optional user name to use for authentication purposes; by default, this is the null value.</param>
        /// <param name="password">The optional password to use for authentication purposes; by default, this is the null value.</param>
        public void Open(string method, string url, bool async = true, string? user = null, string? password = null) => JSRef!.CallVoid("open", method, url, async, user, password);
        /// <summary>
        /// The XMLHttpRequest method overrideMimeType() specifies a MIME type other than the one provided by the server to be used instead when interpreting the data being transferred in a request. <br/>
        /// This may be used, for example, to force a stream to be treated and parsed as "text/xml", even if the server does not report it as such.<br/>
        /// This method must be called before calling send().
        /// </summary>
        /// <param name="mimeType"></param>
        public void OverrideMimeType(string mimeType) => JSRef!.CallVoid("overrideMimeType", mimeType);
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        public void Send() => JSRef!.CallVoid("send");
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        /// <param name="blob"></param>
        public void Send(Blob blob) => JSRef!.CallVoid("send", blob);
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        /// <param name="arrayBuffer"></param>
        public void Send(ArrayBuffer arrayBuffer) => JSRef!.CallVoid("send", arrayBuffer);
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        /// <param name="typedArray"></param>
        public void Send(TypedArray typedArray) => JSRef!.CallVoid("send", typedArray);
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        /// <param name="dataView"></param>
        public void Send(DataView dataView) => JSRef!.CallVoid("send", dataView);
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        /// <param name="formData"></param>
        public void Send(FormData formData) => JSRef!.CallVoid("send", formData);
        /// <summary>
        /// Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent.
        /// </summary>
        /// <param name="text"></param>
        public void Send(string text) => JSRef!.CallVoid("send", text);
        /// <summary>
        /// Sets the value of an HTTP request header. You must call setRequestHeader() after open(), but before send().
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        public void SetRequestHeader(string header, string value) => JSRef!.CallVoid("setRequestHeader", header, value);
        #endregion
        #region Events
        /// <summary>
        /// Fired when a request has been aborted, for example because the program called XMLHttpRequest.abort(). Also available via the onabort event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnAbort { get => new ActionEvent<ProgressEvent>("abort", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the request encountered an error. Also available via the onerror event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnError { get => new ActionEvent<ProgressEvent>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when an XMLHttpRequest transaction completes successfully. Also available via the onload event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnLoad { get => new ActionEvent<ProgressEvent>("load", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request has completed, whether successfully (after load) or unsuccessfully (after abort or error). Also available via the onloadend event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnLoadEnd { get => new ActionEvent<ProgressEvent>("loadend", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a request has started to load data. Also available via the onloadstart event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnLoadStart { get => new ActionEvent<ProgressEvent>("loadstart", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired periodically when a request receives more data. Also available via the onprogress event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnProgress { get => new ActionEvent<ProgressEvent>("progress", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired whenever the readyState property changes. Also available via the onreadystatechange event handler property.
        /// </summary>
        public ActionEvent<Event> OnReadyStateChange { get => new ActionEvent<Event>("readystatechange", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when progress is terminated due to preset time expiring. Also available via the ontimeout event handler property.
        /// </summary>
        public ActionEvent<ProgressEvent> OnTimeout { get => new ActionEvent<ProgressEvent>("timeout", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
    /// <summary>
    /// XMLHttpRequest (XHR) objects are used to interact with servers. You can retrieve data from a URL without having to do a full page refresh. This enables a Web page to update just part of a page without disrupting what the user is doing.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest
    /// </summary>
    public class XMLHttpRequest<TResponse> : XMLHttpRequest
    {
        /// <summary>
        /// Get the request response as type TResponse
        /// </summary>
        public TResponse Response => JSRef!.Get<TResponse>("response");
    }
}
