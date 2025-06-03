using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStreamTrackGenerator interface of the Insertable Streams for MediaStreamTrack API creates a WritableStream that acts as a MediaStreamTrack source. The object consumes a stream of media frames as input, which can be audio or video frames.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackGenerator
    /// </summary>
    public class MediaStreamTrackGenerator : MediaStreamTrack
    {
        ///<inheritdoc/>
        public MediaStreamTrackGenerator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The MediaStreamTrackGenerator() constructor creates a new MediaStreamTrackGenerator object which consumes a stream of media frames and exposes a MediaStreamTrack.
        /// </summary>
        /// <param name="options">An object containing the property kind</param>
        public MediaStreamTrackGenerator(MediaStreamTrackGeneratorOptions options) : base(JS.New(nameof(MediaStreamTrackGenerator), options)) { }
        /// <summary>
        /// The writable property of the MediaStreamTrackGenerator interface returns a WritableStream. This allows the writing of media frames to the MediaStreamTrackGenerator. The frames will be audio or video. The type is dictated by the kind of MediaStreamTrackGenerator that was created.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");
    }
}
