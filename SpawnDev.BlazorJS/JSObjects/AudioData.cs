using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioData interface of the WebCodecs API represents an audio sample.<br />
    /// AudioData is a transferable object.<br />
    /// An audio track consists of a stream of audio samples, each sample representing a captured moment of sound. An AudioData object is a representation of such a sample. Working alongside the interfaces of the Insertable Streams API, you can break a stream into individual AudioData objects with MediaStreamTrackProcessor, or construct an audio track from a stream of frames with MediaStreamTrackGenerator.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioData
    /// </summary>
    public class AudioData : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioData(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The AudioData() constructor creates a new AudioData object which represents an individual audio sample.
        /// </summary>
        /// <param name="options"></param>
        public AudioData(AudioDataOptions options) : base(JS.New(nameof(AudioData), options)) { }
        /// <summary>
        /// Returns the sample format of the audio.
        /// </summary>
        public string Format => JSRef.Get<string>("format");
        /// <summary>
        /// Returns the sample rate of the audio in Hz.
        /// </summary>
        public decimal SampleRate => JSRef.Get<decimal>("sampleRate");
        /// <summary>
        /// Returns the number of frames.
        /// </summary>
        public int NumberOfFrames => JSRef.Get<int>("numberOfFrames");
        /// <summary>
        /// Returns the number of audio channels.
        /// </summary>
        public int NumberOfChannels => JSRef.Get<int>("numberOfChannels");
        /// <summary>
        /// Returns the duration of the audio in microseconds.
        /// </summary>
        public double Duration => JSRef.Get<double>("duration");
        /// <summary>
        /// Returns the timestamp of the audio in microseconds.
        /// </summary>
        public long Timestamp => JSRef.Get<long>("timestamp");
        /// <summary>
        /// Returns the number of bytes required to hold the sample as filtered by options passed into the method.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public int AllocationSize(AudioDataAllocationSizeOptions options) => JSRef.Call<int>("allocationSize", options);
        /// <summary>
        /// Copies the samples from the specified plane of the AudioData object to the destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public void CopyTo(ArrayBuffer destination, AudioDataCopyToOptions options) => JSRef.CallVoid("copyTo", destination, options);
        /// <summary>
        /// Copies the samples from the specified plane of the AudioData object to the destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public void CopyTo(TypedArray destination, AudioDataCopyToOptions options) => JSRef.CallVoid("copyTo", destination, options);
        /// <summary>
        /// Copies the samples from the specified plane of the AudioData object to the destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public void CopyTo(DataView destination, AudioDataCopyToOptions options) => JSRef.CallVoid("copyTo", destination, options);
        /// <summary>
        /// Creates a new AudioData object with reference to the same media resource as the original.
        /// </summary>
        /// <returns></returns>
        public AudioData Clone() => JSRef.Call<AudioData>("clone");
        /// <summary>
        /// Clears all states and releases the reference to the media resource.
        /// </summary>
        public void Close() => JSRef.CallVoid("close");
    }
}
