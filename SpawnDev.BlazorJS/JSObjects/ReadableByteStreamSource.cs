using System.Text.Json.Serialization;

namespace SpawnDev.BlazorJS.JSObjects
{
    // TODO - verify the json converter serializes this correctly
    /// <summary>
    /// The ReadableByteStreamSource interface represents an underlying source for a ReadableStream of bytes.
    /// </summary>
    public class ReadableByteStreamSource : ReadableStreamUnderlyingSource, IDisposable
    {
        /// <summary>
        /// This property controls what type of readable stream is being dealt with. If it is included with a value set to "bytes", the passed controller object will be a ReadableByteStreamController capable of handling a BYOB (bring your own buffer)/byte stream. If it is not included, the passed controller will be a ReadableStreamDefaultController.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Type { get; } = "bytes";
        /// <summary>
        /// For byte streams, the developer can set the autoAllocateChunkSize with a positive integer value to turn on the stream's auto-allocation feature. With this is set, the stream implementation will automatically allocate a view buffer of the specified size in ReadableByteStreamController.byobRequest when required.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? AutoAllocateChunkSize { get; set; } = null;
        /// <summary>
        /// This method, also defined by the developer, will be called repeatedly when the stream's internal queue of chunks is not full, up until it reaches its high water mark. If pull() returns a promise, then it won't be called again until that promise fulfills; if the promise rejects, the stream will become errored. The controller parameter passed to this method is a ReadableStreamDefaultController or a ReadableByteStreamController, depending on the value of the type property. This can be used by the developer to control the stream as more chunks are fetched.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<ReadableByteStreamController>? Pull { get; set; }
        /// <summary>
        /// This is a method, called immediately when the object is constructed. The contents of this method are defined by the developer, and should aim to get access to the stream source, and do anything else required to set up the stream functionality. If this process is to be done asynchronously, it can return a promise to signal success or failure. The controller parameter passed to this method is a ReadableStreamDefaultController or a ReadableByteStreamController, depending on the value of the type property. This can be used by the developer to control the stream during set up.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<ReadableByteStreamController>? Start { get; set; }
        /// <summary>
        /// This method, also defined by the developer, will be called if the app signals that the stream is to be cancelled (e.g. if ReadableStream.cancel() is called). The contents should do whatever is necessary to release access to the stream source. If this process is asynchronous, it can return a promise to signal success or failure. The reason parameter contains a string describing why the stream was cancelled.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ActionCallback<string?>? Cancel { get; set; }
        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="pull"></param>
        /// <param name="start"></param>
        /// <param name="cancel"></param>
        public ReadableByteStreamSource(Action<ReadableByteStreamController>? pull = null, Action<ReadableByteStreamController>? start = null, Action<string?>? cancel = null)
        {
            if (pull != null) Pull = pull;
            if (start != null) Start = start;
            if (cancel != null) Cancel = cancel;
        }
        /// <summary>
        /// Disposes of the instance
        /// </summary>
        public void Dispose()
        {
            Pull?.Dispose();
            Start?.Dispose();
            Cancel?.Dispose();
        }
    }
}
