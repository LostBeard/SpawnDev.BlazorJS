using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoTrackGenerator interface of the Insertable Streams for MediaStreamTrack API has a WritableStream property that acts as a MediaStreamTrack source, by consuming a stream of VideoFrames as input.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoTrackGenerator
    /// </summary>
    public class VideoTrackGenerator : JSObject
    {
        ///<inheritdoc/>
        public VideoTrackGenerator(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The VideoTrackGenerator() constructor creates a new VideoTrackGenerator object which consumes a stream of media frames and exposes a MediaStreamTrack.
        /// </summary>
        public VideoTrackGenerator() : base(JS.New(nameof(VideoTrackGenerator))) { }
        /// <summary>
        /// A Boolean property to temporarily halt or resume the generation of video frames in the output track.
        /// </summary>
        public bool Muted
        {
            get => JSRef!.Get<bool>("muted");
            set => JSRef!.Set("muted", value);
        }
        /// <summary>
        /// The output MediaStreamTrack.
        /// </summary>
        public MediaStreamTrack MediaStreamTrack => JSRef!.Get<MediaStreamTrack>("mediaStreamTrack");
        /// <summary>
        /// The input WritableStream.
        /// </summary>
        public WritableStream Writable => JSRef!.Get<WritableStream>("writable");
    }
}
