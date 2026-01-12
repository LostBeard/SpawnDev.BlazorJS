using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoEncoder interface of the Web Codecs API encodes VideoFrames into EncodedVideoChunks.
    /// </summary>
    public class VideoEncoder : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public VideoEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new VideoEncoder.
        /// </summary>
        public VideoEncoder(VideoEncoderInit init) : base(JS.New(nameof(VideoEncoder), init)) { }

        /// <summary>
        /// The state of the encoder.
        /// </summary>
        public string State => JSRef!.Get<string>("state");

        /// <summary>
        /// The number of encode requests in the queue.
        /// </summary>
        public int EncodeQueueSize => JSRef!.Get<int>("encodeQueueSize");

        /// <summary>
        /// Fires when the encode queue size decreases.
        /// </summary>
        public ActionEvent<Event> OnDequeue { get => new ActionEvent<Event>("dequeue", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Configures the encoder.
        /// </summary>
        public void Configure(VideoEncoderConfig config) => JSRef!.CallVoid("configure", config);

        /// <summary>
        /// Enqueues a frame to be encoded.
        /// </summary>
        public void Encode(VideoFrame frame, VideoEncoderEncodeOptions? options = null) => JSRef!.CallVoid("encode", frame, options);

        /// <summary>
        /// Forces all pending encoded chunks to be output.
        /// </summary>
        public Task Flush() => JSRef!.CallVoidAsync("flush");

        /// <summary>
        /// Resets the encoder.
        /// </summary>
        public void Reset() => JSRef!.CallVoid("reset");

        /// <summary>
        /// Closes the encoder and releases resources.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        
        /// <summary>
        /// Checks if the given config is supported.
        /// </summary>
        public static Task<VideoEncoderSupport> IsConfigSupported(VideoEncoderConfig config) => JS.CallAsync<VideoEncoderSupport>($"{nameof(VideoEncoder)}.isConfigSupported", config);
    }
}
