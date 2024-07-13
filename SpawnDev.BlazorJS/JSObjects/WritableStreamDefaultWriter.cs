using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The WritableStreamDefaultWriter interface of the Streams API is the object returned by WritableStream.getWriter() and once created locks the writer to the WritableStream ensuring that no other streams can write to the underlying sink.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/WritableStreamDefaultWriter
    /// </summary>
    public class WritableStreamDefaultWriter : JSObject
    {
        /// <summary>
        /// The WritableStreamDefaultWriter() constructor creates a new WritableStreamDefaultWriter object instance.
        /// </summary>
        /// <param name="writableStream"></param>
        public WritableStreamDefaultWriter(WritableStream writableStream) : base(JS.New(nameof(WritableStreamDefaultWriter), writableStream)) { }
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public WritableStreamDefaultWriter(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Allows you to write code that responds to an end to the streaming process. Returns a promise that fulfills if the stream becomes closed, or rejects if the stream errors or the writer's lock is released.
        /// </summary>
        public bool Closed => JSRef!.Get<bool>("closed");
        /// <summary>
        /// Returns the desired size required to fill the stream's internal queue.
        /// </summary>
        public int DesiredSize => JSRef!.Get<int>("desiredSize");
        /// <summary>
        /// Returns a Promise that resolves when the desired size of the stream's internal queue transitions from non-positive to positive, signaling that it is no longer applying backpressure.
        /// </summary>
        public Task Ready => JSRef!.Get<Task>("ready");
        /// <summary>
        /// Aborts the stream, signaling that the producer can no longer successfully write to the stream and it is to be immediately moved to an error state, with any queued writes discarded.
        /// </summary>
        public void Abort() => JSRef!.CallVoid("abort");
        /// <summary>
        /// Closes the associated writable stream.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// Releases the writer's lock on the corresponding stream. After the lock is released, the writer is no longer active. If the associated stream is errored when the lock is released, the writer will appear errored in the same way from now on; otherwise, the writer will appear closed.
        /// </summary>
        public void ReleaseLock() => JSRef!.CallVoid("releaseLock");
        /// <summary>
        /// Writes a passed chunk of data to a WritableStream and its underlying sink, then returns a Promise that resolves to indicate the success or failure of the write operation.
        /// </summary>
        /// <param name="chunk">A block of binary data to pass to the WritableStream.</param>
        /// <returns></returns>
        public Task Write(object chunk) => JSRef!.CallVoidAsync("write", chunk);
    }
}
