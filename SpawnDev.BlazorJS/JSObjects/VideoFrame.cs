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
        /// <summary>
        /// Returns the pixel format of the VideoFrame.
        /// </summary>
        public string Format => JSRef!.Get<string>("format");
        /// <summary>
        /// Returns the width of the VideoFrame in pixels, potentially including non-visible padding, and prior to considering potential ratio adjustments.
        /// </summary>
        public int CodedWidth => JSRef!.Get<int>("codedWidth");
        /// <summary>
        /// Returns the height of the VideoFrame in pixels, potentially including non-visible padding, and prior to considering potential ratio adjustments.
        /// </summary>
        public int CodedHeight => JSRef!.Get<int>("codedHeight");
        /// <summary>
        /// Returns a DOMRectReadOnly with the width and height matching codedWidth and codedHeight.
        /// </summary>
        public DOMRectReadOnly CodedRect => JSRef!.Get<DOMRectReadOnly>("codedRect");
        /// <summary>
        /// Returns a DOMRectReadOnly describing the visible rectangle of pixels for this VideoFrame.
        /// </summary>
        public DOMRectReadOnly VisibleRect => JSRef!.Get<DOMRectReadOnly>("visibleRect");
        /// <summary>
        /// Returns the width of the VideoFrame when displayed after applying aspect ratio adjustments.
        /// </summary>
        public int DisplayWidth => JSRef!.Get<int>("displayWidth");
        /// <summary>
        /// Returns the height of the VideoFrame when displayed after applying aspect ratio adjustments.
        /// </summary>
        public int DisplayHeight => JSRef!.Get<int>("displayHeight");
        /// <summary>
        /// Returns an integer indicating the duration of the video in microseconds.
        /// </summary>
        public int Duration => JSRef!.Get<int>("duration");
        /// <summary>
        /// Returns an integer indicating the timestamp of the video in microseconds.
        /// </summary>
        public int Timestamp => JSRef!.Get<int>("timestamp");
        /// <summary>
        /// Returns a VideoColorSpace object.
        /// </summary>
        public VideoColorSpace ColorSpace => JSRef!.Get<VideoColorSpace>("colorSpace");
    }
}
