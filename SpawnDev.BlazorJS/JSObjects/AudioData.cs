using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The AudioData interface of the WebCodecs API represents an audio sample.<br />
    /// AudioData is a transferable object.<br />
    /// An audio track consists of a stream of audio samples, each sample representing a captured moment of sound. An AudioData object is a representation of such a sample. Working alongside the interfaces of the Insertable Streams API, you can break a stream into individual AudioData objects with MediaStreamTrackProcessor, or construct an audio track from a stream of frames with MediaStreamTrackGenerator.<br />
    /// https://developer.mozilla.org/en-US/docs/Web/API/AudioData
    /// </summary>
    public class AudioData : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public AudioData(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
}
