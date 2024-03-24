using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{

    /// <summary>
    /// The ReadableByteStreamController interface of the Streams API represents a controller for a readable byte stream. It allows control of the state and internal queue of a ReadableStream with an underlying byte source, and enables efficient zero-copy transfer of data from the underlying source to a consumer when the stream's internal queue is empty.>br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableByteStreamController
    /// </summary>
    public class ReadableByteStreamController : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReadableByteStreamController(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns the current BYOB pull request, or null if there no outstanding request.
        /// </summary>
        public ReadableStreamBYOBRequest? ByobRequest => JSRef.Get<ReadableStreamBYOBRequest?>("byobRequest");
        /// <summary>
        /// Returns the desired size required to fill the stream's internal queue.<br />
        /// Note that this can be negative if the queue is over-full.
        /// </summary>
        public int DesiredSize => JSRef.Get<int>("desiredSize");
        /// <summary>
        /// Closes the associated stream.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");
        /// <summary>
        /// Enqueues a given chunk in the associated stream.
        /// </summary>
        /// <param name="chunk"></param>
        public void Enqueue(object chunk) => JSRef.CallVoid("enqueue", chunk);
        /// <summary>
        /// Any object that you want future interactions to fail with.
        /// </summary>
        /// <param name="errorObject"></param>
        public void Error(object errorObject) => JSRef.CallVoid("error", errorObject);
    }
}
