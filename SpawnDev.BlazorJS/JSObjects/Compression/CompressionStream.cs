using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The CompressionStream interface of the Compression Streams API is an API for compressing a stream of data.
    /// </summary>
    public class CompressionStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public CompressionStream(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new CompressionStream.
        /// </summary>
        /// <param name="format">The compression format. One of: "gzip", "deflate", "deflate-raw".</param>
        public CompressionStream(string format) : base(JS.New(nameof(CompressionStream), format)) { }

        /// <summary>
        /// Returns a ReadableStream instance that can be used to read compressed data from the stream.
        /// </summary>
        public ReadableStream Readable => JSRef!.Get<ReadableStream>("readable");

        /// <summary>
        /// Returns a WritableStream instance that can be used to write data to be compressed to the stream.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");
    }
}
