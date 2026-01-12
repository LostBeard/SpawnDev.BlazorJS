using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VTTCue interface of the WebVTT API represents a cue that can be added to the text track associated with a particular video (or other media).<br/>
    /// A cue defines the text to display in a particular timeslice of a video or audio track, along with display properties such as its size, alignment, and position.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VTTCue
    /// </summary>
    public class VTTCue : TextTrackCue
    {
        /// <summary>
        /// Creates a new VTTCue object.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="text"></param>
        public VTTCue(double startTime, double endTime, string text) : base(JS.New("VTTCue", startTime, endTime, text)) { }
        /// <inheritdoc/>
        public VTTCue(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The VTTRegion to which the cue belongs, or null if it doesn't belong to any.
        /// </summary>
        public VTTRegion? Region { get => JSRef!.Get<VTTRegion?>("region"); set => JSRef!.Set("region", value); }
        /// <summary>
        /// A string that represents the vertical setting of the cue.
        /// </summary>
        public string Vertical { get => JSRef!.Get<string>("vertical"); set => JSRef!.Set("vertical", value); }
        /// <summary>
        /// A boolean for whether the line is relative to the video or is an absolute line number.
        /// </summary>
        public bool SnapToLines { get => JSRef!.Get<bool>("snapToLines"); set => JSRef!.Set("snapToLines", value); }
        /// <summary>
        /// A double that represents the line number or the percentage of the video height.
        /// </summary>
        public Union<double, string> Line { get => JSRef!.Get<Union<double, string>>("line"); set => JSRef!.Set("line", value); }
        /// <summary>
        /// A string that represents the line alignment of the cue.
        /// </summary>
        public string LineAlign { get => JSRef!.Get<string>("lineAlign"); set => JSRef!.Set("lineAlign", value); }
        /// <summary>
        /// A double that represents the position of the cue as a percentage of the video width (or height if vertical).
        /// </summary>
        public Union<double, string> Position { get => JSRef!.Get<Union<double, string>>("position"); set => JSRef!.Set("position", value); }
        /// <summary>
        /// A string that represents the position alignment of the cue.
        /// </summary>
        public string PositionAlign { get => JSRef!.Get<string>("positionAlign"); set => JSRef!.Set("positionAlign", value); }
        /// <summary>
        /// A double that represents the size of the cue as a percentage of the video width (or height if vertical).
        /// </summary>
        public double Size { get => JSRef!.Get<double>("size"); set => JSRef!.Set("size", value); }
        /// <summary>
        /// A string that represents the alignment of the cue.
        /// </summary>
        public string Align { get => JSRef!.Get<string>("align"); set => JSRef!.Set("align", value); }
        /// <summary>
        /// A string that represents the text of the cue.
        /// </summary>
        public string Text { get => JSRef!.Get<string>("text"); set => JSRef!.Set("text", value); }
        /// <summary>
        /// Returns the cue text as an HTML DocumentFragment.
        /// </summary>
        /// <returns></returns>
        public DocumentFragment GetCueAsHTML() => JSRef!.Call<DocumentFragment>("getCueAsHTML");

    }
}