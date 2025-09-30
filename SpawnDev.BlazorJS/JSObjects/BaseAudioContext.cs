using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BaseAudioContext interface of the Web Audio API acts as a base definition for online and offline audio-processing graphs, as represented by AudioContext and OfflineAudioContext respectively. You wouldn't use BaseAudioContext directly — you'd use its features via one of these two inheriting interfaces.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext
    /// </summary>
    public class BaseAudioContext : EventTarget
    {
        /// <inheritdoc/>
        public BaseAudioContext(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Returns a double representing an ever-increasing hardware time in seconds used for scheduling. It starts at 0.
        /// </summary>
        public double CurrentTime => JSRef!.Get<double>("currentTime");
        /// <summary>
        /// Returns an AudioDestinationNode representing the final destination of all audio in the context. It can be thought of as the audio-rendering device.
        /// </summary>
        public AudioDestinationNode Destination => JSRef!.Get<AudioDestinationNode>("destination");
        /// <summary>
        /// Returns the AudioListener object, used for 3D spatialization.
        /// </summary>
        public AudioListener Listener => JSRef!.Get<AudioListener>("listener");
        /// <summary>
        /// Returns a float representing the sample rate (in samples per second) used by all nodes in this context. The sample-rate of an AudioContext cannot be changed.
        /// </summary>
        public float SampleRate => JSRef!.Get<float>("sampleRate");
        /// <summary>
        /// Returns the current state of the AudioContext.
        /// </summary>
        public string State => JSRef!.Get<string>("state");
        /// <summary>
        /// Creates an AnalyserNode, which can be used to expose audio time and frequency data and for example to create data visualizations.
        /// </summary>
        public AnalyserNode CreateAnalyser() => JSRef!.Call<AnalyserNode>("createAnalyser");
        /// <summary>
        /// Creates a BiquadFilterNode, which represents a second order filter configurable as several different common filter types: high-pass, low-pass, band-pass, etc
        /// </summary>
        /// <returns></returns>
        public BiquadFilterNode CreateBiquadFilter() => JSRef!.Call<BiquadFilterNode>("createBiquadFilter");
        /// <summary>
        /// Creates a new, empty AudioBuffer object, which can then be populated by data and played via an AudioBufferSourceNode.
        /// </summary>
        /// <param name="numOfChannels">An integer representing the number of channels this buffer should have. The default value is 1, and all user agents must support at least 32 channels.</param>
        /// <param name="length">An integer representing the size of the buffer in sample-frames (where each sample-frame is the size of a sample in bytes multiplied by numOfChannels). To determine the length to use for a specific number of seconds of audio, use numSeconds * sampleRate.</param>
        /// <param name="sampleRate">The sample rate of the linear audio data in sample-frames per second. All browsers must support sample rates in at least the range 8,000 Hz to 96,000 Hz.</param>
        /// <returns>An AudioBuffer configured based on the specified options.</returns>
        public AudioBuffer CreateBuffer(int numOfChannels, long length, float sampleRate) => JSRef!.Call<AudioBuffer>("createBuffer", numOfChannels, length, sampleRate);
        /// <summary>
        /// Creates an AudioBufferSourceNode, which can be used to play and manipulate audio data contained within an AudioBuffer object. AudioBuffers are created using AudioContext.createBuffer() or returned by AudioContext.decodeAudioData() when it successfully decodes an audio track.
        /// </summary>
        /// <returns></returns>
        public AudioBufferSourceNode CreateBufferSource() => JSRef!.Call<AudioBufferSourceNode>("createBufferSource");
        /// <summary>
        /// The createPanner() method of the BaseAudioContext Interface is used to create a new PannerNode, which is used to spatialize an incoming audio stream in 3D space.<br/>
        /// The panner node is spatialized in relation to the AudioContext's AudioListener (defined by the AudioContext.listener attribute), which represents the position and orientation of the person listening to the audio.
        /// </summary>
        /// <returns></returns>
        public PannerNode CreatePanner() => JSRef!.Call<PannerNode>("createPanner");
        /// <summary>
        /// The createGain() method of the BaseAudioContext interface creates a GainNode, which can be used to control the overall gain (or volume) of the audio graph.
        /// </summary>
        /// <returns></returns>
        public GainNode CreateGain() => JSRef!.Call<GainNode>("createGain");
        /// <summary>
        /// Creates a DelayNode, which is used to delay the incoming audio signal by a certain amount. This node is also useful to create feedback loops in a Web Audio API graph.
        /// </summary>
        /// <returns></returns>
        public DelayNode CreateDelay(float? maxDelayTime = null)
            => maxDelayTime == null ? JSRef!.Call<DelayNode>("createDelay") : JSRef!.Call<DelayNode>("createDelay", maxDelayTime);
        /// <summary>
        /// The createConvolver() method of the BaseAudioContext interface creates a ConvolverNode, which is commonly used to apply reverb effects to your audio. See the spec definition of Convolution for more information
        /// </summary>
        /// <returns></returns>
        public ConvolverNode CreateConvolver() => JSRef!.Call<ConvolverNode>("createConvolver");

        // TODO - finish methods

        /// <summary>
        /// A statechange event is fired at a BaseAudioContext object when its state member changes.
        /// </summary>
        public ActionEvent<Event> OnStateChange { get => new ActionEvent<Event>("statechange", AddEventListener, RemoveEventListener); set { } }
    }
}
