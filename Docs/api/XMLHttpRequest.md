# XMLHttpRequest

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `XMLHttpRequestEventTarget`  
**Source:** `JSObjects/XMLHttpRequest.cs`  
**MDN Reference:** [XMLHttpRequest on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest)

> XMLHttpRequest (XHR) objects are used to interact with servers. You can retrieve data from a URL without having to do a full page refresh. This enables a Web page to update just part of a page without disrupting what the user is doing. https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest

## Constructors

| Signature | Description |
|---|---|
| `XMLHttpRequest()` | The XMLHttpRequest() constructor creates a new XMLHttpRequest |
| `XMLHttpRequest(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Upload` | `XMLHttpRequestUpload` | get | A XMLHttpRequestUpload representing the upload process. |
| `ReadyState` | `int` | get | Returns a number representing the state of the request. |
| `ResponseText` | `string?` | get | Returns a string that contains the response to the request as text, or null if the request was unsuccessful or has not yet been sent. |
| `ResponseURL` | `string` | get | Returns the serialized URL of the response or the empty string if the URL is null. |
| `ResponseXML` | `Document?` | get | Returns a Document containing the response to the request, or null if the request was unsuccessful, has not yet been sent, or cannot be parsed as XML or HTML. Not available in Web Workers. |
| `Status` | `int` | get | Returns the HTTP response status code of the request. |
| `StatusText` | `string` | get | Returns a string containing the response string returned by the HTTP server. Unlike XMLHttpRequest.status, this includes the entire text of the response message ("OK", for example). |
| `Timeout` | `double` | get | The time in milliseconds a request can take before automatically being terminated. |
| `WithCredentials` | `bool` | get | Returns true if cross-site Access-Control requests should be made using credentials such as cookies or authorization headers; otherwise false. |
| `ResponseType` | `string` | get | Specifies the type of the response. Possible values: "" - An empty responseType string is the same as "text", the default type. "arraybuffer" - The response is a JavaScript ArrayBuffer containing binary data. "blob" - The response is a Blob object containing the binary data. "document" - The response is an HTML Document or XML XMLDocument, as appropriate based on the MIME type of the received data. See HTML in XMLHttpRequest to learn more about using XHR to fetch HTML content. "json" - The response is a JavaScript object created by parsing the contents of received data as JSON. "text" - The response is a text in a string. |
| `Response` | `TResponse` | get | Get the request response as type TResponse |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `GetResponseAs()` | `TResponse?` | Get the request response as type TResponse Response type |
| `GetResponseAsBlob()` | `Blob?` | Get the request response as type Blob |
| `GetResponseAsArrayBuffer()` | `ArrayBuffer?` | Get the request response as type ArrayBuffer |
| `GetResponseAsDocument()` | `Document?` | Get the request response as type Document |
| `Abort()` | `void` | Aborts the request if it has already been sent. |
| `GetAllResponseHeaders()` | `string?` | Returns all the response headers, separated by CRLF, as a string, or null if no response has been received. |
| `GetResponseHeader(string headerName)` | `string?` | Returns all the response headers, separated by CRLF, as a string, or null if no response has been received. |
| `Open(string method, string url, bool async, string? user, string? password)` | `void` | The XMLHttpRequest method open() initializes a newly-created request, or re-initializes an existing one. The HTTP request method to use, such as "GET", "POST", "PUT", "DELETE", etc. Ignored for non-HTTP(S) URLs. A string or any other object with a stringifier - including a URL object - that provides the URL of the resource to send the request to. An optional Boolean parameter, defaulting to true, indicating whether or not to perform the operation asynchronously. If this value is false, the send() method does not return until the response is received. If true, notification of a completed transaction is provided using event listeners. This must be true if the multipart attribute is true, or an exception will be thrown. The optional user name to use for authentication purposes; by default, this is the null value. The optional password to use for authentication purposes; by default, this is the null value. |
| `OverrideMimeType(string mimeType)` | `void` | The XMLHttpRequest method overrideMimeType() specifies a MIME type other than the one provided by the server to be used instead when interpreting the data being transferred in a request. This may be used, for example, to force a stream to be treated and parsed as "text/xml", even if the server does not report it as such. This method must be called before calling send(). |
| `Send()` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `Send(Blob blob)` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `Send(ArrayBuffer arrayBuffer)` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `Send(TypedArray typedArray)` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `Send(DataView dataView)` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `Send(FormData formData)` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `Send(string text)` | `void` | Sends the request. If the request is asynchronous (which is the default), this method returns as soon as the request is sent. |
| `SetRequestHeader(string header, string value)` | `void` | Sets the value of an HTTP request header. You must call setRequestHeader() after open(), but before send(). |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAbort` | `ActionEvent<ProgressEvent>` | Fired when a request has been aborted, for example because the program called XMLHttpRequest.abort(). Also available via the onabort event handler property. |
| `OnError` | `ActionEvent<ProgressEvent>` | Fired when the request encountered an error. Also available via the onerror event handler property. |
| `OnLoad` | `ActionEvent<ProgressEvent>` | Fired when an XMLHttpRequest transaction completes successfully. Also available via the onload event handler property. |
| `OnLoadEnd` | `ActionEvent<ProgressEvent>` | Fired when a request has completed, whether successfully (after load) or unsuccessfully (after abort or error). Also available via the onloadend event handler property. |
| `OnLoadStart` | `ActionEvent<ProgressEvent>` | Fired when a request has started to load data. Also available via the onloadstart event handler property. |
| `OnProgress` | `ActionEvent<ProgressEvent>` | Fired periodically when a request receives more data. Also available via the onprogress event handler property. |
| `OnReadyStateChange` | `ActionEvent<Event>` | Fired whenever the readyState property changes. Also available via the onreadystatechange event handler property. |
| `OnTimeout` | `ActionEvent<ProgressEvent>` | Fired when progress is terminated due to preset time expiring. Also available via the ontimeout event handler property. |

