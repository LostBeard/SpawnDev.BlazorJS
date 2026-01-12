using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioScheduledSourceNode interface—part of the Web Audio API—is a parent interface for several types of audio source node interfaces which share the ability to be started and stopped, optionally at specified times. Specifically, this interface defines the start() and stop() methods, as well as the ended event.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioScheduledSourceNode
    /// </summary>
    public class AudioScheduledSourceNode : AudioNode
    {
        /// <inheritdoc/>
        public AudioScheduledSourceNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Schedules the node to begin playing the constant sound at the specified time. If no time is specified, the node begins playing immediately.
        /// </summary>
        /// <param name="when">The time, in seconds, at which the sound should begin to play. This value is specified in the same time coordinate system as the AudioContext is using for its currentTime attribute. A value of 0 (or omitting the when parameter entirely) causes the sound to start playback immediately.</param>
        public void Start(float? when = null)
        {
            if (when == null) JSRef!.CallVoid("start");
            else JSRef!.CallVoid("start", when);
        }
        /// <summary>
        /// Schedules the node to stop playing at the specified time. If no time is specified, the node stops playing at once.
        /// </summary>
        /// <param name="when">The time, in seconds, at which the sound should stop playing. This value is specified in the same time coordinate system as the AudioContext is using for its currentTime attribute. Omitting this parameter, specifying a value of 0, or passing a negative value causes the sound to stop playback immediately.</param>
        public void Stop(float? when = null)
        {
            if (when == null) JSRef!.CallVoid("stop");
            else JSRef!.CallVoid("stop", when);
        }
        /// <summary>
        /// Fired when the source node has stopped playing, either because it's reached a predetermined stop time, the full duration of the audio has been performed, or because the entire buffer has been played.
        /// </summary>
        public ActionEvent<Event> OnEnded { get => new ActionEvent<Event>("ended", AddEventListener, RemoveEventListener); set { } }
    }
}
