using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The SourceBuffer interface represents a chunk of media to be passed into an HTMLMediaElement and played, via a MediaSource object. This can be made up of one or several media segments.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/SourceBuffer
    /// </summary>
    public class SourceBuffer : EventTarget
    {
        /// <inheritdoc/>
        public SourceBuffer(IJSInProcessObjectReference _ref) : base(_ref) { }
        // TODO
    }
}