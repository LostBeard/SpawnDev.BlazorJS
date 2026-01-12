using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStreamAudioDestinationNode interface represents an audio destination consisting of a WebRTC MediaStream with a single AudioMediaStreamTrack, which can be used in a similar way to a MediaStream obtained from getUserMedia().<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamAudioDestinationNode
    /// </summary>
    public class MediaStreamAudioDestinationNode : AudioNode
    {
        /// <inheritdoc/>
        public MediaStreamAudioDestinationNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// A MediaStream containing a single AudioMediaStreamTrack with the same number of channels as the node itself.
        /// </summary>
        public MediaStream Stream => JSRef!.Get<MediaStream>("stream");
    }
}
