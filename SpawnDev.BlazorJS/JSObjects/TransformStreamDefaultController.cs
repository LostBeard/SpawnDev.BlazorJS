using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TransformStreamDefaultController interface of the Streams API provides methods to manipulate the associated ReadableStream and WritableStream.<br/>
    /// When constructing a TransformStream, the TransformStreamDefaultController is created.It therefore has no constructor.The way to get an instance of TransformStreamDefaultController is via the callback methods of TransformStream().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/TransformStreamDefaultController
    /// </summary>
    public class TransformStreamDefaultController : JSObject
    {
        /// <inheritdoc/>
        public TransformStreamDefaultController(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The desiredSize read-only property of the TransformStreamDefaultController interface returns the desired size to fill the queue of the associated ReadableStream.
        /// The internal queue of a ReadableStream contains chunks that have been enqueued, but not yet read.The browser determines the desired size to fill the stream, and it is this value returned by the desiredSize property.
        /// If the desiredSize is 0 then the queue is full.Therefore you can use this information to manually apply backpressure to manage the queue.
        /// </summary>
        public int DesiredSize => JSRef!.Get<int>("desiredSize");
        /// <summary>
        /// The enqueue() method of the TransformStreamDefaultController interface enqueues the given chunk in the readable side of the stream.<br/>
        /// For more information on readable streams and chunks see Using Readable Streams.
        /// </summary>
        /// <param name="chunk">The chunk being queued. A chunk is a single piece of data. It can be any type of data, and a stream can contain chunks of different types.</param>
        public void Enqueue(object chunk) => JSRef!.CallVoid("enqueue", chunk);
        /// <summary>
        /// The error() method of the TransformStreamDefaultController interface errors both sides of the stream. Any further interactions with it will fail with the given error message, and any chunks in the queue will be discarded.
        /// </summary>
        /// <param name="reason">A string containing the error message to be returned on any further interaction with the stream.</param>
        public void Error(string reason) => JSRef!.CallVoid("error", reason);
        /// <summary>
        /// The terminate() method of the TransformStreamDefaultController interface closes the readable side and errors the writable side of the stream.
        /// </summary>
        public void Terminate() => JSRef!.CallVoid("terminate");
    }
}
