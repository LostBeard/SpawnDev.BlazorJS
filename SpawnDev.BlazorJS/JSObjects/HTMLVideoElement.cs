using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement
    public class HTMLVideoElement : HTMLMediaElement
    {
        public HTMLVideoElement(ElementReference elRef) : base(JS.ToJSRef(elRef)) { }
        public HTMLVideoElement() : base(JS.DocumentCreateElement("video")) { }
        public HTMLVideoElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        public int VideoWidth => JSRef.Get<int>("videoWidth");
        public int VideoHeight => JSRef.Get<int>("videoHeight");
        public bool SupportsRequestVideoFrameCallback => !JSRef.PropertyIsUndefined("requestVideoFrameCallback");
        public void RequestVideoFrameCallback(Callback callback) => JSRef.CallVoid("requestVideoFrameCallback", callback);
        /// <summary>
        /// This enumerated attribute is intended to provide a hint to the browser about what the author thinks will lead to the best user experience regarding what content is loaded before the video is played. It may have one of the following values:<br />
        /// none: Indicates that the video should not be preloaded.<br />
        /// metadata: Indicates that only video metadata (e.g. length) is fetched.<br />
        /// auto: Indicates that the whole video file can be downloaded, even if the user is not expected to use it.<br />
        /// empty string: Synonym of the auto value.
        /// </summary>
        public string Preload { get => JSRef.Get<string>("preload"); set => JSRef.Set("preload", value); }
        /// <summary>
        /// A Boolean attribute indicating that the video is to be played "inline", that is within the element's playback area. Note that the absence of this attribute does not imply that the video will always be played in fullscreen.
        /// </summary>
        public bool PlaysInline { get => JSRef.Get<bool>("playsInline"); set => JSRef.Set("playsInline", value); }
        /// <summary>
        /// A URL for an image to be shown while the video is downloading. If this attribute isn't specified, nothing is displayed until the first frame is available, then the first frame is shown as the poster frame.
        /// </summary>
        public string Poster { get => JSRef.Get<string>("poster"); set => JSRef.Set("poster", value); }
    }
}