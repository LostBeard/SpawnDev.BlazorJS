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
        /// <inheritdoc/>
        public VTTCue(IJSInProcessObjectReference _ref) : base(_ref) { }
        // TODO
    }
}