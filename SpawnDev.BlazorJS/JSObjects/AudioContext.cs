using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioContext interface represents an audio-processing graph built from audio modules linked together, each represented by an AudioNode.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioContext
    /// </summary>
    public class AudioContext : BaseAudioContext
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioContext(IJSInProcessObjectReference _ref) : base(_ref) { }

        public AudioContext() : base(JS.New(nameof(AudioContext))) { }


        public MediaStreamAudioSourceNode CreateMediaStreamSource(MediaStream mediaStream) => JSRef.Call<MediaStreamAudioSourceNode>("createMediaStreamSource", mediaStream);
    }
}
