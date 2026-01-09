using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransportSendStream interface of the WebTransport API is a specialized WritableStream that is used to send outbound data in both unidirectional or bidirectional WebTransport streams.<br/>
    /// The send stream is a writable stream of Uint8Array, that can be written to in order to send data to a server. It additionally provides streaming features such as setting the send order, and getting stream statistics.<br/>
    /// Objects of this type are not constructed directly. When creating a unidirectional stream the WebTransport.createUnidirectionalStream() returns an object of this type for sending data. When creating a bidirectional stream using WebTransport.createBidirectionalStream(), the method returns a WebTransportBidirectionalStream, and the send stream object can be obtained from its writable property. When a bidirectional stream is initiated by the remote end, an object of this type can similarly be obtained using WebTransport.incomingBidirectionalStreams.<br/>
    /// WebTransportSendStream is a transferable object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebTransportSendStream
    /// </summary>
    [Transferable(TransferRequired = true)]
    public class WebTransportSendStream : WritableStream
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebTransportSendStream(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
