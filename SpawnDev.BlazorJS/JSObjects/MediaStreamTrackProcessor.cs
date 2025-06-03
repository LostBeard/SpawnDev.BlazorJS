using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The MediaStreamTrackProcessor interface of the Insertable Streams for MediaStreamTrack API consumes a video MediaStreamTrack object's source and generates a stream of VideoFrame objects.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/MediaStreamTrackProcessor
    /// </summary>
    public class MediaStreamTrackProcessor : JSObject
    {
        ///<inheritdoc/>
        public MediaStreamTrackProcessor(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The MediaStreamTrackProcessor() constructor creates a new MediaStreamTrackProcessor object which consumes a video MediaStreamTrack object's source and generates a stream of VideoFrames.
        /// </summary>
        /// <param name="options"></param>
        public MediaStreamTrackProcessor(MediaStreamTrackProcessorOptions options) : base(JS.New(nameof(MediaStreamTrackProcessor), options)) { }
        /// <summary>
        /// The readable property of the MediaStreamTrackProcessor interface returns a ReadableStream of VideoFrames.
        /// </summary>
        public ReadableStream Readable => JSRef!.Get<ReadableStream>("readable");
    }
}
