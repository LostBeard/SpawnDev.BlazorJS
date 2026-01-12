using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The OfflineAudioContext interface is an AudioContext interface representing an audio-processing graph built from linked together AudioNodes. In contrast to a standard AudioContext, an OfflineAudioContext doesn't render the audio to the device hardware; instead, it generates it, as fast as it can, and outputs the result to an AudioBuffer.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/OfflineAudioContext
    /// </summary>
    public class OfflineAudioContext : BaseAudioContext
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        public OfflineAudioContext(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Creates a new OfflineAudioContext instance.
        /// </summary>
        /// <param name="numberOfChannels">An integer specifying the number of channels for this context.</param>
        /// <param name="length">An integer specifying the length of the buffer to be created, in sample-frames.</param>
        /// <param name="sampleRate">A floating-point number specifying the sample-rate, in samples per second, of the audio data.</param>
        public OfflineAudioContext(int numberOfChannels, long length, float sampleRate) : base(JS.New(nameof(OfflineAudioContext), numberOfChannels, length, sampleRate)) { }
        /// <summary>
        /// Creates a new OfflineAudioContext instance.
        /// </summary>
        /// <param name="options">An object specifying the options for the new context.</param>
        public OfflineAudioContext(OfflineAudioContextOptions options) : base(JS.New(nameof(OfflineAudioContext), options)) { }
        /// <summary>
        /// Returns a integer representing the length of the buffer in sample-frames.
        /// </summary>
        public long Length => JSRef!.Get<long>("length");
        /// <summary>
        /// Fired when the render is complete.
        /// </summary>
        public ActionEvent<OfflineAudioCompletionEvent> OnComplete { get => new ActionEvent<OfflineAudioCompletionEvent>("complete", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Schedules a suspension of the time progression in the audio context at the specified time and returns a promise.
        /// </summary>
        /// <param name="suspendTime">A floating-point number specifying the time in seconds at which the context should be suspended.</param>
        /// <returns></returns>
        public Task Suspend(double suspendTime) => JSRef!.CallVoidAsync("suspend", suspendTime);
        /// <summary>
        /// Starts rendering the audio graph, taking into account the current connections and the current scheduled changes.
        /// </summary>
        /// <returns>A Promise that resolves with a rendered AudioBuffer.</returns>
        public Task<AudioBuffer> StartRendering() => JSRef!.CallAsync<AudioBuffer>("startRendering");
    }
}
