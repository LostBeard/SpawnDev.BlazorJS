using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Base type for AudioTrack, VideoTrack, and TextTrack (non-spec, used to group MediaTrack types)
    /// </summary>
    public class MediaTrack : EventTarget
    {
        /// <inheritdoc/>
        public MediaTrack(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}