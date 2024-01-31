using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStreamAudioSourceNode interface is a type of AudioNode which operates as an audio source whose media is received from a MediaStream obtained using the WebRTC or Media Capture and Streams APIs.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamAudioSourceNode
    /// </summary>
    public class MediaStreamAudioSourceNode : AudioNode
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param
        public MediaStreamAudioSourceNode(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
