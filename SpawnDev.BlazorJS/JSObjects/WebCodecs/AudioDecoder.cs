using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioDecoder interface of the Web Codecs API decodes EncodedAudioChunks into AudioData.
    /// </summary>
    public class AudioDecoder : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public AudioDecoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new AudioDecoder.
        /// </summary>
        public AudioDecoder(AudioDecoderInit init) : base(JS.New(nameof(AudioDecoder), init)) { }

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
        public ActionEvent<Event> OnDequeue { get => new ActionEvent<Event>("dequeue", AddEventListener, RemoveEventListener); set { } }

        /// <summary>
        /// Configures the decoder.
        /// </summary>
        public void Configure(AudioDecoderConfig config) => JSRef!.CallVoid("configure", config);

        /// <summary>
        /// Enqueues a chunk to be decoded.
        /// </summary>
        public void Decode(EncodedAudioChunk chunk) => JSRef!.CallVoid("decode", chunk);

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
        public static Task<AudioDecoderSupport> IsConfigSupported(AudioDecoderConfig config) => JS.CallAsync<AudioDecoderSupport>($"{nameof(AudioDecoder)}.isConfigSupported", config);
    }
}
