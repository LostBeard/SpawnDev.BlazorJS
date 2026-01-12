using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransport interface of the WebTransport API provides a modern, low-latency, bidirectional, client-server messaging transport.
    /// </summary>
    public class WebTransport : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public WebTransport(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new WebTransport object.
        /// </summary>
        public WebTransport(string url) : base(JS.New(nameof(WebTransport), url)) { }

        /// <summary>
        /// Creates a new WebTransport object.
        /// </summary>
        public WebTransport(string url, WebTransportOptions options) : base(JS.New(nameof(WebTransport), url, options)) { }

        /// <summary>
        /// Returns a Promise that resolves when the transport is ready to be used.
        /// </summary>
        public Task Ready => JSRef!.GetVoidAsync("ready");

        /// <summary>
        /// Returns a Promise that resolves when the transport is closed.
        /// </summary>
        public Task<WebTransportCloseInfo> Closed => JSRef!.GetAsync<WebTransportCloseInfo>("closed");

        /// <summary>
        /// Returns a WebTransportDatagramDuplexStream instance that can be used to send and receive datagrams.
        /// </summary>
        public WebTransportDatagramDuplexStream Datagrams => JSRef!.Get<WebTransportDatagramDuplexStream>("datagrams");

        /// <summary>
        /// Returns a ReadableStream of WebTransportBidirectionalStream objects.
        /// </summary>
        public ReadableStream IncomingBidirectionalStreams => JSRef!.Get<ReadableStream>("incomingBidirectionalStreams");

        /// <summary>
        /// Returns a ReadableStream of WebTransportReceiveStream objects.
        /// </summary>
        public ReadableStream IncomingUnidirectionalStreams => JSRef!.Get<ReadableStream>("incomingUnidirectionalStreams");

        /// <summary>
        /// Closes the WebTransport connection.
        /// </summary>
        public void Close(WebTransportCloseInfo? closeInfo = null) => JSRef!.CallVoid("close", closeInfo);

        /// <summary>
        /// Creates a bidirectional stream.
        /// </summary>
        public Task<WebTransportBidirectionalStream> CreateBidirectionalStream() => JSRef!.CallAsync<WebTransportBidirectionalStream>("createBidirectionalStream");

        /// <summary>
        /// Creates a unidirectional stream.
        /// </summary>
        public Task<WritableStream> CreateUnidirectionalStream() => JSRef!.CallAsync<WritableStream>("createUnidirectionalStream");
    }
}
