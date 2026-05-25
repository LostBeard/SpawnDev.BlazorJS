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
        public double IncomingMaxAge
        {
            get => JSRef!.Get<double>("incomingMaxAge");
            set => JSRef!.Set("incomingMaxAge", value);
        }

        /// <summary>
        /// Returns the maximum age for outgoing datagrams in milliseconds.
        /// </summary>
        public double OutgoingMaxAge
        {
            get => JSRef!.Get<double>("outgoingMaxAge");
            set => JSRef!.Set("outgoingMaxAge", value);
        }

        /// <summary>
        /// Returns the high water mark for incoming datagrams.
        /// </summary>
        public double IncomingHighWaterMark
        {
            get => JSRef!.Get<double>("incomingHighWaterMark");
            set => JSRef!.Set("incomingHighWaterMark", value);
        }

        /// <summary>
        /// Returns the high water mark for outgoing datagrams.
        /// </summary>
        public double OutgoingHighWaterMark
        {
            get => JSRef!.Get<double>("outgoingHighWaterMark");
            set => JSRef!.Set("outgoingHighWaterMark", value);
        }
    }
}
