using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransportReceiveStream interface of the WebTransport API is a ReadableStream that can be used to read from an incoming unidirectional or bidirectional WebTransport stream.<br/>
    /// The stream is a readable byte stream of Uint8Array, and can be consumed using either a BYOB reader (ReadableStreamBYOBReader) or the default reader (ReadableStreamDefaultReader).<br/>
    /// Objects of this type are not constructed directly. Instead they are obtained using the WebTransport.incomingUnidirectionalStream property.<br/>
    /// WebTransportReceiveStream is a transferable object.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/WebTransportReceiveStream
    /// </summary>
    [Transferable(TransferRequired = true)]
    public class WebTransportReceiveStream : ReadableStream
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WebTransportReceiveStream(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
