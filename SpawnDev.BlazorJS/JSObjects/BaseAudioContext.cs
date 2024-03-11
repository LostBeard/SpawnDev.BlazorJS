using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The BaseAudioContext interface of the Web Audio API acts as a base definition for online and offline audio-processing graphs, as represented by AudioContext and OfflineAudioContext respectively. You wouldn't use BaseAudioContext directly — you'd use its features via one of these two inheriting interfaces.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/BaseAudioContext
    /// </summary>
    public class BaseAudioContext : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public BaseAudioContext(IJSInProcessObjectReference _ref) : base(_ref) { }


        /// <summary>
        /// Creates an AnalyserNode, which can be used to expose audio time and frequency data and for example to create data visualizations.
        /// </summary>
        public AnalyserNode CreateAnalyser() => JSRef.Call<AnalyserNode>("createAnalyser");

        /// <summary>
        /// A statechange event is fired at a BaseAudioContext object when its state member changes.
        /// </summary>
        public JSEventCallback<Event> OnStateChange { get => new JSEventCallback<Event>("statechange", AddEventListener, RemoveEventListener); set { } }
    }
}
