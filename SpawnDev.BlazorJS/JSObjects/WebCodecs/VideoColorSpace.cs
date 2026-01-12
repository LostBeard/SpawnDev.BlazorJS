using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The VideoColorSpace() constructor creates a new VideoColorSpace object which represents a video color space.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/VideoColorSpace/VideoColorSpace
    /// </summary>
    public class VideoColorSpace : JSObject
    {
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public VideoColorSpace(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The VideoColorSpace() constructor creates a new VideoColorSpace object which represents a video color space.
        /// </summary>
        public VideoColorSpace() : base(JS.New(nameof(VideoColorSpace))) { }
        /// <summary>
        /// The VideoColorSpace() constructor creates a new VideoColorSpace object which represents a video color space.
        /// </summary>
        /// <param name="options"></param>
        public VideoColorSpace(VideoColorSpaceOptions options) : base(JS.New(nameof(VideoColorSpace), options)) { }
        /// <summary>
        /// A string containing the color primary describing the color gamut of a video sample.
        /// </summary>
        public string Primaries => JSRef!.Get<string>("primaries");
        /// <summary>
        /// A string containing the transfer characteristics of video samples.
        /// </summary>
        public string Transfer { get => JSRef!.Get<string>("transfer"); set => JSRef!.Set("transfer", value); }
        /// <summary>
        /// A string containing the matrix coefficients describing the relationship between sample component values and color coordinates.
        /// </summary>
        public string Matrix { get => JSRef!.Get<string>("matrix"); set => JSRef!.Set("matrix", value); }
        /// <summary>
        /// A Boolean. If true indicates that full-range color values are used.
        /// </summary>
        public bool FullRange { get => JSRef!.Get<bool>("fullRange"); set => JSRef!.Set("fullRange", value); }
        /// <summary>
        /// Returns a JSON representation of the VideoColorSpace object.
        /// </summary>
        /// <returns></returns>
        public JSObject ToJSON() => JSRef!.Call<JSObject>("toJSON");
    }
}
