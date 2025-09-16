using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioBufferSourceNode
    /// </summary>
    public class AudioBufferSourceNode : AudioScheduledSourceNode
    {
        /// <inheritdoc/>
        public AudioBufferSourceNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The AudioBufferSourceNode() constructor creates a new AudioBufferSourceNode object instance.
        /// </summary>
        /// <param name="context">A reference to an AudioContext.</param>
        /// <param name="options">Optional</param>
        public AudioBufferSourceNode(AudioContext context, AudioBufferSourceNodeOptions? options = null) : base(options == null ? JS.New(nameof(AudioBufferSourceNode), context) : JS.New(nameof(AudioBufferSourceNode), context, options)) { }
        /// <summary>
        /// An AudioBuffer that defines the audio asset to be played, or when set to the value null, defines a single channel of silence (in which every sample is 0.0).
        /// </summary>
        public AudioBuffer? Buffer { get => JSRef!.Get<AudioBuffer?>("buffer"); set => JSRef!.Set("buffer", value); }
        /// <summary>
        /// A k-rate AudioParam representing detuning of playback in cents. This value is compounded with playbackRate to determine the speed at which the sound is played. Its default value is 0 (meaning no detuning), and its nominal range is -∞ to ∞.
        /// </summary>
        public AudioParam? Detune { get => JSRef!.Get<AudioParam?>("detune"); set => JSRef!.Set("detune", value); }
        /// <summary>
        /// A Boolean attribute indicating if the audio asset must be replayed when the end of the AudioBuffer is reached. Its default value is false.
        /// </summary>
        public bool Loop { get => JSRef!.Get<bool>("loop"); set => JSRef!.Set("loop", value); }
        /// <summary>
        /// A floating-point value indicating the time, in seconds, at which playback of the AudioBuffer must begin when loop is true. Its default value is 0 (meaning that at the beginning of each loop, playback begins at the start of the audio buffer).
        /// </summary>
        public float LoopStart { get => JSRef!.Get<float>("loopStart"); set => JSRef!.Set("loopStart", value); }
        /// <summary>
        /// A floating-point number indicating the time, in seconds, at which playback of the AudioBuffer stops and loops back to the time indicated by loopStart, if loop is true. The default value is 0.
        /// </summary>
        public float LoopEnd { get => JSRef!.Get<float>("loopEnd"); set => JSRef!.Set("loopEnd", value); }
        /// <summary>
        /// A k-rate AudioParam that defines the speed factor at which the audio asset will be played, where a value of 1.0 is the sound's natural sampling rate. Since no pitch correction is applied on the output, this can be used to change the pitch of the sample. This value is compounded with detune to determine the final playback rate.
        /// </summary>
        public AudioParam? PlaybackRate { get => JSRef!.Get<AudioParam?>("playbackRate"); set => JSRef!.Set("playbackRate", value); }
        /// <summary>
        /// The start() method of the AudioBufferSourceNode Interface is used to schedule playback of the audio data contained in the buffer, or to begin playback immediately.
        /// </summary>
        /// <param name="when">The time, in seconds, at which the sound should begin to play, in the same time coordinate system used by the AudioContext. If when is less than (AudioContext.currentTime, or if it's 0, the sound begins to play at once. The default value is 0.</param>
        /// <param name="offset">An offset, specified as the number of seconds in the same time coordinate system as the AudioContext, to the time within the audio buffer that playback should begin. For example, to start playback halfway through a 10-second audio clip, offset should be 5. The default value, 0, will begin playback at the beginning of the audio buffer, and offsets past the end of the audio which will be played (based on the audio buffer's duration and/or the loopEnd property) are silently clamped to the maximum value allowed. The computation of the offset into the sound is performed using the sound buffer's natural sample rate, rather than the current playback rate, so even if the sound is playing at twice its normal speed, the midway point through a 10-second audio buffer is still 5.</param>
        public void Start(float when, float offset) => JSRef!.CallVoid("start",  when, offset);
        /// <summary>
        /// The start() method of the AudioBufferSourceNode Interface is used to schedule playback of the audio data contained in the buffer, or to begin playback immediately.
        /// </summary>
        /// <param name="when">The time, in seconds, at which the sound should begin to play, in the same time coordinate system used by the AudioContext. If when is less than (AudioContext.currentTime, or if it's 0, the sound begins to play at once. The default value is 0.</param>
        /// <param name="offset">An offset, specified as the number of seconds in the same time coordinate system as the AudioContext, to the time within the audio buffer that playback should begin. For example, to start playback halfway through a 10-second audio clip, offset should be 5. The default value, 0, will begin playback at the beginning of the audio buffer, and offsets past the end of the audio which will be played (based on the audio buffer's duration and/or the loopEnd property) are silently clamped to the maximum value allowed. The computation of the offset into the sound is performed using the sound buffer's natural sample rate, rather than the current playback rate, so even if the sound is playing at twice its normal speed, the midway point through a 10-second audio buffer is still 5.</param>
        /// <param name="duration">The duration of the sound to be played, specified in seconds. If this parameter isn't specified, the sound plays until it reaches its natural conclusion or is stopped using the stop() method. Using this parameter is functionally identical to calling start(when, offset) and then calling stop(when+duration).</param>
        public void Start(float when, float offset, float duration) => JSRef!.CallVoid("start", when, offset, duration);
    }
}
