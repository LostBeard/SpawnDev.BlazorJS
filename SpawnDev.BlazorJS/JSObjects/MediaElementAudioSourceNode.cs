using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{

    /// <summary>
    /// The MediaElementAudioSourceNode interface represents an audio source consisting of an HTML audio or video element. It is an AudioNode that acts as an audio source.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaElementAudioSourceNode
    /// </summary>
    public class MediaElementAudioSourceNode : AudioNode
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public MediaElementAudioSourceNode(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The MediaElementAudioSourceNode() constructor creates a new MediaElementAudioSourceNode object instance.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="options"></param>
        public MediaElementAudioSourceNode(AudioContext context, MediaElementAudioSourceNodeOptions options) : base(JS.New(nameof(MediaElementAudioSourceNode), context, options)) { }
        /// <summary>
        /// The HTMLMediaElement used when constructing this MediaStreamAudioSourceNode.
        /// </summary>
        public HTMLMediaElement MediaElement => JSRef.Get<HTMLMediaElement>("mediaElement");
    }
}
