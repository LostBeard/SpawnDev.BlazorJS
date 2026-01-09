using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The TextTrackCue interface of the WebVTT API is the abstract base class for the various derived cue types, such as VTTCue; you will work with these derived types rather than the base class.<br/>
    /// These cues represent strings of text presented for some duration of time during the performance of a TextTrack. The cue includes the start time (the time at which the text will be displayed) and the end time (the time at which it will be removed from the display), as well as other information.
    /// https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCue
    /// </summary>
    public class TextTrackCue : EventTarget
    {
        /// <inheritdoc/>
        public TextTrackCue(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The TextTrack that this cue belongs to, or null if it doesn't belong to any.
        /// </summary>
        public TextTrack? Track => JSRef!.Get<TextTrack?>("track");
        /// <summary>
        /// A string that identifies the cue.
        /// </summary>
        public string Id { get => JSRef!.Get<string>("id"); set => JSRef!.Set("id", value); }
        /// <summary>
        /// A double that represents the video time that the cue will start being displayed, in seconds.
        /// </summary>
        public double StartTime { get => JSRef!.Get<double>("startTime"); set => JSRef!.Set("startTime", value); }
        /// <summary>
        /// A double that represents the video time that the cue will stop being displayed, in seconds.
        /// </summary>
        public double EndTime { get => JSRef!.Get<double>("endTime"); set => JSRef!.Set("endTime", value); }
        /// <summary>
        /// A boolean for whether the video will pause when this cue stops being displayed.
        /// </summary>
        public bool PauseOnExit { get => JSRef!.Get<bool>("pauseOnExit"); set => JSRef!.Set("pauseOnExit", value); }
        /// <summary>
        /// Fired when a cue becomes active.
        /// </summary>
        public ActionEvent<Event> OnEnter { get => new ActionEvent<Event>("enter", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the cue has stopped being active.
        /// </summary>
        public ActionEvent<Event> OnExit { get => new ActionEvent<Event>("exit", AddEventListener, RemoveEventListener); set { } }
    }
}