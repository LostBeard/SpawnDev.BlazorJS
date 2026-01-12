using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WebTransportDatagramDuplexStream interface of the WebTransport API represents a duplex stream for sending and receiving datagrams.
    /// </summary>
    public class WebTransportDatagramDuplexStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public WebTransportDatagramDuplexStream(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Returns a ReadableStream instance that can be used to read datagrams from the stream.
        /// </summary>
        public ReadableStream Readable => JSRef!.Get<ReadableStream>("readable");

        /// <summary>
        /// Returns a WritableStream instance that can be used to write datagrams to the stream.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");

        /// <summary>
        /// Returns the maximum age for incoming datagrams in milliseconds.
        /// </summary>
        public float IncomingMaxAge
        {
            get => JSRef!.Get<float>("incomingMaxAge");
            set => JSRef!.Set("incomingMaxAge", value);
        }

        /// <summary>
        /// Returns the maximum age for outgoing datagrams in milliseconds.
        /// </summary>
        public float OutgoingMaxAge
        {
            get => JSRef!.Get<float>("outgoingMaxAge");
            set => JSRef!.Set("outgoingMaxAge", value);
        }

        /// <summary>
        /// Returns the high water mark for incoming datagrams.
        /// </summary>
        public float IncomingHighWaterMark
        {
            get => JSRef!.Get<float>("incomingHighWaterMark");
            set => JSRef!.Set("incomingHighWaterMark", value);
        }

        /// <summary>
        /// Returns the high water mark for outgoing datagrams.
        /// </summary>
        public float OutgoingHighWaterMark
        {
            get => JSRef!.Get<float>("outgoingHighWaterMark");
            set => JSRef!.Set("outgoingHighWaterMark", value);
        }
    }
}
