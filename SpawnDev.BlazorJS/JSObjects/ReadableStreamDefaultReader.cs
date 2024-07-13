using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The ReadableStreamDefaultReader interface of the Streams API represents a default reader that can be used to read stream data supplied from a network (such as a fetch request).<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/ReadableStreamDefaultReader
    /// </summary>
    public class ReadableStreamDefaultReader : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public ReadableStreamDefaultReader(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a Promise that fulfills when the stream closes, or rejects if the stream throws an error or the reader's lock is released. This property enables you to write code that responds to an end to the streaming process.
        /// </summary>
        public bool Closed => JSRef!.Get<bool>("closed");
        /// <summary>
        /// Returns a Promise that resolves when the stream is canceled. Calling this method signals a loss of interest in the stream by a consumer. The supplied reason argument will be given to the underlying source, which may or may not use it.
        /// </summary>
        /// <returns></returns>
        public Task Cancel() => JSRef!.CallVoidAsync("cancel");
        /// <summary>
        /// Returns a promise providing access to the next chunk in the stream's internal queue.
        /// </summary>
        /// <returns></returns>
        public Task<ReadableStreamReaderReadResponse> Read() => JSRef!.CallAsync<ReadableStreamReaderReadResponse>("read");
        /// <summary>
        /// Releases the reader's lock on the stream.
        /// </summary>
        public void ReleaseLock() => JSRef!.CallVoid("releaseLock");
    }
}
