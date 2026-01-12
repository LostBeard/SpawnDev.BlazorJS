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

        public SpawnDev.BlazorJS.JSObjects.WebTransportReceiveStream Readable => JSRef!.Get<SpawnDev.BlazorJS.JSObjects.WebTransportReceiveStream>("readable");

        public SpawnDev.BlazorJS.JSObjects.WebTransportSendStream Writable => JSRef!.Get<SpawnDev.BlazorJS.JSObjects.WebTransportSendStream>("writable");
    }
}
