using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoDecoder interface of the Web Codecs API decodes EncodedVideoChunks into VideoFrames.
    /// </summary>
    public class VideoDecoder : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public VideoDecoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new VideoDecoder.
        /// </summary>
        public VideoDecoder(VideoDecoderInit init) : base(JS.New(nameof(VideoDecoder), init)) { }

        /// <summary>
        /// The state of the decoder.
        /// </summary>
        public string State => JSRef!.Get<string>("state");

        /// <summary>
        /// The number of decode requests in the queue.
        /// </summary>
        public int DecodeQueueSize => JSRef!.Get<int>("decodeQueueSize");

        /// <summary>
        /// Fires when the decode queue size decreases.
        /// </summary>
        public JSEventCallback<Event> OnDequeue { get => new JSEventCallback<Event>("dequeue", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Configures the decoder.
        /// </summary>
        public void Configure(VideoDecoderConfig config) => JSRef!.CallVoid("configure", config);

        /// <summary>
        /// Enqueues a chunk to be decoded.
        /// </summary>
        public void Decode(EncodedVideoChunk chunk) => JSRef!.CallVoid("decode", chunk);

        /// <summary>
        /// Forces all pending decoded frames to be output.
        /// </summary>
        public Task Flush() => JSRef!.CallVoidAsync("flush");

        /// <summary>
        /// Resets the decoder.
        /// </summary>
        public void Reset() => JSRef!.CallVoid("reset");

        /// <summary>
        /// Closes the decoder and releases resources.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        
        /// <summary>
        /// Checks if the given config is supported.
        /// </summary>
        public static Task<VideoDecoderSupport> IsConfigSupported(VideoDecoderConfig config) => JS.CallAsync<VideoDecoderSupport>($"{nameof(VideoDecoder)}.isConfigSupported", config);
    }
}
