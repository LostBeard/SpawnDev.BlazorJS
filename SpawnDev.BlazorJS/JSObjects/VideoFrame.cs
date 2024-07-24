using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoFrame interface of the Web Codecs API represents a frame of a video.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoFrame
    /// </summary>
    [Transferable]
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
        /// <summary>
        /// Returns the number of bytes required to hold the VideoFrame as filtered by options passed into the method.
        /// </summary>
        /// <returns></returns>
        public int AllocationSize() => JSRef!.Call<int>("allocationSize");
        /// <summary>
        /// Returns the number of bytes required to hold the VideoFrame as filtered by options passed into the method.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public int AllocationSize(AllocationSizeOptions options) => JSRef!.Call<int>("allocationSize", options);
        /// <summary>
        /// Copies the contents of the VideoFrame to an ArrayBuffer.
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public int CopyTo(Union<ArrayBuffer, TypedArray, byte[], DataView> destination) => JSRef!.Call<int>("copyTo", destination);
        /// <summary>
        /// Copies the contents of the VideoFrame to an ArrayBuffer.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public int CopyTo(Union<ArrayBuffer, TypedArray, byte[], DataView> destination, VideoFrameCopyOptions options) => JSRef!.Call<int>("copyTo", destination, options);
        /// <summary>
        /// Clears all states and releases the reference to the media resource.
        /// </summary>
        /// <returns></returns>
        public VideoFrame Clone() => JSRef!.Call<VideoFrame>("clone");
        /// <summary>
        /// Clears all states and releases the reference to the media resource.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
    }
}
