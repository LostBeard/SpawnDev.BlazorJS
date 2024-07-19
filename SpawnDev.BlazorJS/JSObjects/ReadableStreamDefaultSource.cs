using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // References:
    // A readable stream with an underlying push source and backpressure support
    // https://streams.spec.whatwg.org/#example-rs-push-backpressure
    // https://streams.spec.whatwg.org/#underlying-source-api
    public class ReadableStreamDefaultSource : ReadableStreamUnderlyingSource, IDisposable
    {
        /// <summary>
        /// This property controls what type of readable stream is being dealt with. If it is included with a value set to "bytes", the passed controller object will be a ReadableStreamDefaultController capable of handling a BYOB (bring your own buffer)/byte stream. If it is not included, the passed controller will be a ReadableStreamDefaultController.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; } = null;
        /// <summary>
        /// For byte streams, the developer can set the autoAllocateChunkSize with a positive integer value to turn on the stream's auto-allocation feature. With this is set, the stream implementation will automatically allocate a view buffer of the specified size in ReadableStreamDefaultController.byobRequest when required.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AutoAllocateChunkSize { get; set; } = null;
        /// <summary>
        /// This method, also defined by the developer, will be called repeatedly when the stream's internal queue of chunks is not full, up until it reaches its high water mark. If pull() returns a promise, then it won't be called again until that promise fulfills; if the promise rejects, the stream will become errored. The controller parameter passed to this method is a ReadableStreamDefaultController or a ReadableStreamDefaultController, depending on the value of the type property. This can be used by the developer to control the stream as more chunks are fetched.
        /// A function that is called whenever the stream’s internal queue of chunks becomes not full, i.e. whenever the queue’s desired size becomes positive. Generally, it will be called repeatedly until the queue reaches its high water mark (i.e. until the desired size becomes non-positive).
        /// For push sources, this can be used to resume a paused flow, as in § 10.2 A readable stream with an underlying push source and backpressure support.For pull sources, it is used to acquire new chunks to enqueue into the stream, as in § 10.4 A readable stream with an underlying pull source.
        /// This function will not be called until start() successfully completes.Additionally, it will only be called repeatedly if it enqueues at least one chunk or fulfills a BYOB request; a no-op pull() implementation will not be continually called.
        /// If the function returns a promise, then it will not be called again until that promise fulfills. (If the promise rejects, the stream will become errored.) This is mainly used in the case of pull sources, where the promise returned represents the process of acquiring a new chunk.Throwing an exception is treated the same as returning a rejected promise.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FuncCallback<ReadableStreamDefaultController, Task>? Pull { get; set; }
        /// <summary>
        /// This is a method, called immediately when the object is constructed. The contents of this method are defined by the developer, and should aim to get access to the stream source, and do anything else required to set up the stream functionality. If this process is to be done asynchronously, it can return a promise to signal success or failure. The controller parameter passed to this method is a ReadableStreamDefaultController or a ReadableStreamDefaultController, depending on the value of the type property. This can be used by the developer to control the stream during set up.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FuncCallback<ReadableStreamDefaultController, Task>? Start { get; set; }
        /// <summary>
        /// This method, also defined by the developer, will be called if the app signals that the stream is to be cancelled (e.g. if ReadableStream.cancel() is called). The contents should do whatever is necessary to release access to the stream source. If this process is asynchronous, it can return a promise to signal success or failure. The reason parameter contains a string describing why the stream was cancelled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<string?>? Cancel { get; set; }
        public ReadableStreamDefaultSource(Func<ReadableStreamDefaultController, Task>? start = null, Func<ReadableStreamDefaultController, Task>? pull = null, Action<string?>? cancel = null)
        {
            if (start != null) Start = start;
            if (pull != null) Pull = pull;
            if (cancel != null) Cancel = cancel;
        }
        public void Dispose()
        {
            Pull?.Dispose();
            Start?.Dispose();
            Cancel?.Dispose();
        }
    }
}
