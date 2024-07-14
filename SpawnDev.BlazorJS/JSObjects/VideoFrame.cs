using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoFrame interface of the Web Codecs API represents a frame of a video.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame
    /// </summary>
    public class VideoFrame : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public VideoFrame(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The VideoFrame() constructor creates a new VideoFrame object representing a frame of a video.
        /// </summary>
        /// <param name="image"></param>
        public VideoFrame(Union<SVGImageElement, HTMLVideoElement, HTMLCanvasElement, ImageBitmap, OffscreenCanvas, VideoFrame> image) : base(JS.New(nameof(VideoFrame), image)) { }
        /// <summary>
        /// The VideoFrame() constructor creates a new VideoFrame object representing a frame of a video.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="options"></param>
        public VideoFrame(Union<SVGImageElement, HTMLVideoElement, HTMLCanvasElement, ImageBitmap, OffscreenCanvas, VideoFrame> image, VideoFrameOptions options) : base(JS.New(nameof(VideoFrame), image, options)) { }
        /// <summary>
        /// The VideoFrame() constructor creates a new VideoFrame object representing a frame of a video.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        public VideoFrame(Union<ArrayBuffer, TypedArray, byte[], DataView> data, VideoFrameDataOptions options) : base(JS.New(nameof(VideoFrame), data, options)) { }
    }
}
