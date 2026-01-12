using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransportBidirectionalStream interface of the WebTransport API represents a bidirectional stream created by a WebTransport.
    /// </summary>
    public class WebTransportBidirectionalStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public WebTransportBidirectionalStream(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// The readable property of the WebTransportBidirectionalStream interface returns a WebTransportReceiveStream instance that can be used to read data from the bidirectional stream.
        /// </summary>
        public SpawnDev.BlazorJS.JSObjects.WebTransportReceiveStream Readable => JSRef!.Get<SpawnDev.BlazorJS.JSObjects.WebTransportReceiveStream>("readable");
        /// <summary>
        /// The writable property of the WebTransportBidirectionalStream interface returns a WebTransportSendStream instance that can be used to write data to the bidirectional stream.
        /// </summary>
        public SpawnDev.BlazorJS.JSObjects.WebTransportSendStream Writable => JSRef!.Get<SpawnDev.BlazorJS.JSObjects.WebTransportSendStream>("writable");
    }
}
