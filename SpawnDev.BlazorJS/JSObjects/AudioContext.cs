using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioContext interface represents an audio-processing graph built from audio modules linked together, each represented by an AudioNode.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioContext
    /// </summary>
    public class AudioContext : BaseAudioContext
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioContext(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The AudioContext() constructor creates a new AudioContext object which represents an audio-processing graph, built from audio modules linked together, each represented by an AudioNode.
        /// </summary>
        public AudioContext() : base(JS.New(nameof(AudioContext))) { }
        /// <summary>
        /// The AudioContext() constructor creates a new AudioContext object which represents an audio-processing graph, built from audio modules linked together, each represented by an AudioNode.
        /// </summary>
        /// <param name="options"></param>
        public AudioContext(AudioContextOptions options) : base(JS.New(nameof(AudioContext), options)) { }
        /// <summary>
        /// Creates a MediaStreamAudioSourceNode associated with a MediaStream representing an audio stream which may come from the local computer microphone or other sources.
        /// </summary>
        /// <param name="mediaStream"></param>
        /// <returns></returns>
        public MediaStreamAudioSourceNode CreateMediaStreamSource(MediaStream mediaStream) => JSRef!.Call<MediaStreamAudioSourceNode>("createMediaStreamSource", mediaStream);
        /// <summary>
        /// The close() method of the AudioContext Interface closes the audio context, releasing any system audio resources that it uses.<br/>
        /// This function does not automatically release all AudioContext-created objects, unless other references have been released as well; however, it will forcibly release any system audio resources that might prevent additional AudioContexts from being created and used, suspend the progression of audio time in the audio context, and stop processing audio data. The returned Promise resolves when all AudioContext-creation-blocking resources have been released. This method throws an INVALID_STATE_ERR exception if called on an OfflineAudioContext.
        /// </summary>
        /// <returns></returns>
        public Task Close() => JSRef!.CallVoidAsync("close");
        /// <summary>
        /// The createMediaElementSource() method of the AudioContext Interface is used to create a new MediaElementAudioSourceNode object, given an existing HTML <audio> or <video> element, the audio from which can then be played and manipulated.
        /// </summary>
        /// <param name="mediaElement"></param>
        /// <returns></returns>
        public MediaElementAudioSourceNode CreateMediaElementSource(HTMLMediaElement mediaElement) => JSRef!.Call<MediaElementAudioSourceNode>("createMediaElementSource", mediaElement);
        /// <summary>
        /// The createMediaStreamTrackSource() method of the AudioContext interface creates and returns a MediaStreamTrackAudioSourceNode which represents an audio source whose data comes from the specified MediaStreamTrack.
        /// </summary>
        /// <param name="track"></param>
        /// <returns></returns>
        public MediaStreamTrackAudioSourceNode CreateMediaStreamTrackSource(MediaStreamTrack track) => JSRef!.Call<MediaStreamTrackAudioSourceNode>("createMediaStreamTrackSource", track);
        /// <summary>
        /// Returns a new AudioTimestamp object containing two audio timestamp values relating to the current audio context.
        /// </summary>
        /// <returns></returns>
        public AudioTimestamp GetOutputTimestamp() => JSRef!.Call<AudioTimestamp>("getOutputTimestamp");
        /// <summary>
        /// Resumes the progression of time in an audio context that has previously been suspended/paused.
        /// </summary>
        /// <returns></returns>
        public Task Resume() => JSRef!.CallVoidAsync("resume");
        /// <summary>
        /// The setSinkId() method of the AudioContext interface sets the output audio device for the AudioContext. If a sink ID is not explicitly set, the default system audio output device will be used.
        /// </summary>
        /// <param name="sinkId">A string representing the sink ID, retrieved for example via the deviceId property of the MediaDeviceInfo objects returned by MediaDevices.enumerateDevices().</param>
        /// <returns></returns>
        public Task SetSinkId(string sinkId) => JSRef!.CallVoidAsync("setSinkId", sinkId);
        /// <summary>
        /// The setSinkId() method of the AudioContext interface sets the output audio device for the AudioContext. If a sink ID is not explicitly set, the default system audio output device will be used.
        /// </summary>
        /// <param name="options">An object representing different options for a sink ID. Currently this takes a single property, type, with a value of none. Setting this parameter causes the audio to be processed without being played through any audio output device. This is a useful option to minimize power consumption when you don't need playback along with processing.</param>
        /// <returns></returns>
        public Task SetSinkId(AudioSinkOptions options) => JSRef!.CallVoidAsync("setSinkId", options);
        /// <summary>
        /// Suspends the progression of time in the audio context, temporarily halting audio hardware access and reducing CPU/battery usage in the process.
        /// </summary>
        /// <returns></returns>
        public Task Suspend() => JSRef!.CallVoidAsync("suspend");
    }
}
