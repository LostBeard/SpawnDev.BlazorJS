using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaSource interface of the Media Source Extensions API represents a source of media data for an HTMLMediaElement object. A MediaSource object can be attached to a HTMLMediaElement to be played in the user agent.
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaSource
    /// </summary>
    public class MediaSource : EventTarget
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaSource(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The MediaSource() constructor of the MediaSource interface constructs and returns a new MediaSource object with no associated source buffers.
        /// </summary>
        public MediaSource() : base(JS.New(nameof(MediaSource))) { }
    }
}