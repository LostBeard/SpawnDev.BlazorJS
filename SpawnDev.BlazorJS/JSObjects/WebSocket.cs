using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebSocket object provides the API for creating and managing a WebSocket connection to a server, as well as for sending and receiving data on the connection.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebSocket
    /// </summary>
    public class WebSocket : EventTarget
    {
        #region Constructors
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebSocket(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The WebSocket() constructor returns a new WebSocket object.
        /// </summary>
        /// <param name="url"></param>
        public WebSocket(string url) : base(JS.New(nameof(WebSocket), url)) { }
        /// <summary>
        /// The WebSocket() constructor returns a new WebSocket object.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="protocols"></param>
        public WebSocket(string url, string[] protocols) : base(JS.New(nameof(WebSocket), url, protocols)) { }
        /// <summary>
        /// The WebSocket() constructor returns a new WebSocket object.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="protocols"></param>
        public WebSocket(string url, string protocols) : base(JS.New(nameof(WebSocket), url, protocols)) { }
        #endregion
        #region Properties
        /// <summary>
        /// The binary data type used by the connection.<br/>
        /// "blob" - Use Blob objects for binary data. This is the default value.<br/>
        /// "arraybuffer" - Use ArrayBuffer objects for binary data.
        /// </summary>
        public string BinaryType { get => JSRef!.Get<string>("binaryType"); set => JSRef!.Set("binaryType", value); }
        /// <summary>
        /// The number of bytes of queued data.
        /// </summary>
        public int BufferedAmount => JSRef!.Get<int>("bufferedAmount");
        /// <summary>
        /// The current state of the connection.<br/>
        /// 0 - CONNECTING - Socket has been created. The connection is not yet open.<br/>
        /// 1 - OPEN - The connection is open and ready to communicate.<br/>
        /// 2 - CLOSING - The connection is in the process of closing.<br/>
        /// 3 - CLOSED - The connection is closed or couldn't be opened.<br/>
        /// </summary>
        public int ReadyState => JSRef!.Get<int>("readyState");
        /// <summary>
        /// The sub-protocol selected by the server.
        /// </summary>
        public string Protocol => JSRef!.Get<string>("protocol");
        public string Url => JSRef!.Get<string>("url");
        #endregion
        #region Methods
        /// <summary>
        /// Closes the WebSocket connection or connection attempt, if any. If the connection is already CLOSED, this method does nothing.
        /// </summary>
        /// <param name="code">
        /// An integer WebSocket connection close code value indicating a reason for closure:<br/>
        /// - If unspecified, a close code for the connection is automatically set: to 1000 for a normal closure, or otherwise to another standard value in the range 1001-1015 that indicates the actual reason the connection was closed.<br/>
        /// - If specified, the value of this code parameter overrides the automatic setting of the close code for the connection, and instead sets a custom code. The value must be an integer: either 1000, or else a custom code of your choosing in the range 3000-4999. If you specify a code value, you should also specify a reason value.<br/>
        /// </param>
        /// <param name="reason">A string providing a custom WebSocket connection close reason (a concise human-readable prose explanation for the closure). The value must be no longer than 123 bytes (encoded in UTF-8).</param>
        public void Close(int code, string reason) => JSRef!.CallVoid("close", code ,reason);
        /// <summary>
        /// Closes the WebSocket connection or connection attempt, if any. If the connection is already CLOSED, this method does nothing.
        /// </summary>
        /// <param name="code">
        /// An integer WebSocket connection close code value indicating a reason for closure:<br/>
        /// - If unspecified, a close code for the connection is automatically set: to 1000 for a normal closure, or otherwise to another standard value in the range 1001-1015 that indicates the actual reason the connection was closed.<br/>
        /// - If specified, the value of this code parameter overrides the automatic setting of the close code for the connection, and instead sets a custom code. The value must be an integer: either 1000, or else a custom code of your choosing in the range 3000-4999. If you specify a code value, you should also specify a reason value.<br/>
        /// </param>
        public void Close(int code) => JSRef!.CallVoid("close", code);
        /// <summary>
        /// Closes the WebSocket connection or connection attempt, if any. If the connection is already CLOSED, this method does nothing.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// Enqueues data to be transmitted.
        /// </summary>
        /// <param name="data"></param>
        public void Send(string data) => JSRef!.CallVoid("send", data);
        /// <summary>
        /// Enqueues data to be transmitted.
        /// </summary>
        /// <param name="data"></param>
        public void Send(ArrayBuffer data) => JSRef!.CallVoid("send", data);
        /// <summary>
        /// Enqueues data to be transmitted.
        /// </summary>
        /// <param name="data"></param>
        public void Send(TypedArray data) => JSRef!.CallVoid("send", data);
        /// <summary>
        /// Enqueues data to be transmitted.
        /// </summary>
        /// <param name="data"></param>
        public void Send(byte[] data) => JSRef!.CallVoid("send", data);
        /// <summary>
        /// Enqueues data to be transmitted.
        /// </summary>
        /// <param name="data"></param>
        public void Send(DataView data) => JSRef!.CallVoid("send", data);
        /// <summary>
        /// Enqueues data to be transmitted.
        /// </summary>
        /// <param name="data"></param>
        public void Send(Blob data) => JSRef!.CallVoid("send", data);
        #endregion
        #region Events
        /// <summary>
        /// Fired when a connection with a WebSocket is closed. Also available via the onclose property
        /// </summary>
        public ActionEvent<CloseEvent> OnClose { get => new ActionEvent<CloseEvent>("close", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a connection with a WebSocket has been closed because of an error, such as when some data couldn't be sent. Also available via the onerror property.
        /// </summary>
        public ActionEvent<Event> OnError { get => new ActionEvent<Event>("error", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when data is received through a WebSocket. Also available via the onmessage property.
        /// </summary>
        public ActionEvent<MessageEvent> OnMessage { get => new ActionEvent<MessageEvent>("message", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when a connection with a WebSocket is opened. Also available via the onopen property.
        /// </summary>
        public ActionEvent<Event> OnOpen { get => new ActionEvent<Event>("open", AddEventListener, RemoveEventListener); set { } }
        #endregion
    }
}
