using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The EncodedAudioChunk interface of the Web Codecs API represents a chunk of encoded audio.
    /// </summary>
    public class EncodedAudioChunk : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public EncodedAudioChunk(IJSInProcessObjectReference _ref) : base(_ref) { }

        /// <summary>
        /// Creates a new EncodedAudioChunk.
        /// </summary>
        public EncodedAudioChunk(EncodedAudioChunkInit init) : base(JS.New(nameof(EncodedAudioChunk), init)) { }

        /// <summary>
        /// Returns a string indicating whether this chunk is a key chunk or a delta chunk.
        /// </summary>
        public EncodedAudioChunkType Type => JSRef!.Get<EncodedAudioChunkType>("type");

        /// <summary>
        /// Returns an integer indicating the timestamp of the audio in microseconds.
        /// </summary>
        public long Timestamp => JSRef!.Get<long>("timestamp");

        /// <summary>
        /// Returns an integer indicating the duration of the audio in microseconds.
        /// </summary>
        public long? Duration => JSRef!.Get<long?>("duration");

        /// <summary>
        /// Returns the size in bytes of the encoded audio data.
        /// </summary>
        public long ByteLength => JSRef!.Get<long>("byteLength");

        /// <summary>
        /// Copies the encoded audio data to the destination buffer.
        /// </summary>
        public void CopyTo(ArrayBuffer destination) => JSRef!.CallVoid("copyTo", destination);
    }
}
