using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioEncoder interface of the Web Codecs API encodes AudioData into EncodedAudioChunks.
    /// </summary>
    public class AudioEncoder : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public AudioEncoder(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new AudioEncoder.
        /// </summary>
        public AudioEncoder(AudioEncoderInit init) : base(JS.New(nameof(AudioEncoder), init)) { }

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
        public void Configure(AudioEncoderConfig config) => JSRef!.CallVoid("configure", config);

        /// <summary>
        /// Enqueues a frame to be encoded.
        /// </summary>
        public void Encode(AudioData data) => JSRef!.CallVoid("encode", data);

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
        public static Task<AudioEncoderSupport> IsConfigSupported(AudioEncoderConfig config) => JS.CallAsync<AudioEncoderSupport>($"{nameof(AudioEncoder)}.isConfigSupported", config);
    }
}
