using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WritableStream interface of the Streams API provides a standard abstraction for writing streaming data to a destination, known as a sink. This object comes with built-in backpressure and queuing.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WritableStream
    /// </summary>
    public class WritableStream : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WritableStream(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A boolean indicating whether the WritableStream is locked to a writer.
        /// </summary>
        public bool Locked => JSRef!.Get<bool>("locked");
        /// <summary>
        /// Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");
        /// <summary>
        /// Closes the stream.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// Returns a new instance of WritableStreamDefaultWriter and locks the stream to that instance. While the stream is locked, no other writer can be acquired until this one is released.
        /// </summary>
        /// <returns></returns>
        public WritableStreamDefaultWriter GetWriter() => JSRef!.Call<WritableStreamDefaultWriter>("getWriter");
    }
}
