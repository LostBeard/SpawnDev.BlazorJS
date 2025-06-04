using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// Implemented by the video element, the HTMLVideoElement interface provides special properties and methods for manipulating video objects. It also inherits properties and methods of HTMLMediaElement and HTMLElement.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLVideoElement
    /// </summary>
    public class HTMLVideoElement : HTMLMediaElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLVideoElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLVideoElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLVideoElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLVideoElement(elementReference.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLVideoElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLVideoElement(ElementReference elementReference) : base(elementReference) { }
        /// <summary>
        /// Create a new instance of HTMLVideoElement
        /// </summary>
        public HTMLVideoElement() : base(JS.DocumentCreateElement("video")) { }
        /// <summary>
        /// Returns an unsigned integer value indicating the intrinsic height of the resource in CSS pixels, or 0 if no media is available yet.
        /// </summary>
        public int VideoWidth => JSRef!.Get<int>("videoWidth");
        /// <summary>
        /// Returns an unsigned integer value indicating the intrinsic width of the resource in CSS pixels, or 0 if no media is available yet.
        /// </summary>
        public int VideoHeight => JSRef!.Get<int>("videoHeight");
        /// <summary>
        /// Returns true if RequestVideoFrameCallback is defined
        /// </summary>
        public bool SupportsRequestVideoFrameCallback => !JSRef!.IsUndefined("requestVideoFrameCallback");
        /// <summary>
        /// The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources.
        /// </summary>
        /// <param name="callback"></param>
        public void RequestVideoFrameCallback(ActionCallback callback) => JSRef!.CallVoid("requestVideoFrameCallback", callback);
        /// <summary>
        /// The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources.
        /// </summary>
        /// <param name="callback"></param>
        public void RequestVideoFrameCallback(ActionCallback<double> callback) => JSRef!.CallVoid("requestVideoFrameCallback", callback);
        /// <summary>
        /// The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources.
        /// </summary>
        /// <param name="callback"></param>
        public void RequestVideoFrameCallback(ActionCallback<double, VideoFrameMetadata> callback) => JSRef!.CallVoid("requestVideoFrameCallback", callback);
        /// <summary>
        /// The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources.
        /// </summary>
        /// <param name="callback"></param>
        public void RequestVideoFrameCallback(Action callback) => RequestVideoFrameCallback(Callback.CreateOne(callback));
        /// <summary>
        /// The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources.
        /// </summary>
        /// <param name="callback"></param>
        public void RequestVideoFrameCallback(Action<double> callback) => RequestVideoFrameCallback(Callback.CreateOne(callback));
        /// <summary>
        /// The HTMLVideoElement.requestVideoFrameCallback() method allows web authors to register a callback that runs in the rendering steps when a new video frame is sent to the compositor. This allows developers to perform efficient per-video-frame operations on video, such as video processing and painting to a canvas, video analysis, or synchronization with external audio sources.
        /// </summary>
        /// <param name="callback"></param>
        public void RequestVideoFrameCallback(Action<double, VideoFrameMetadata> callback) => RequestVideoFrameCallback(Callback.CreateOne(callback));
        /// <summary>
        /// This enumerated attribute is intended to provide a hint to the browser about what the author thinks will lead to the best user experience regarding what content is loaded before the video is played. It may have one of the following values:<br/>
        /// none: Indicates that the video should not be preloaded.<br/>
        /// metadata: Indicates that only video metadata (e.g. length) is fetched.<br/>
        /// auto: Indicates that the whole video file can be downloaded, even if the user is not expected to use it.<br/>
        /// empty string: Synonym of the auto value.
        /// </summary>
        public string Preload { get => JSRef!.Get<string>("preload"); set => JSRef!.Set("preload", value); }
        /// <summary>
        /// A Boolean attribute indicating that the video is to be played "inline", that is within the element's playback area. Note that the absence of this attribute does not imply that the video will always be played in fullscreen.
        /// </summary>
        public bool PlaysInline { get => JSRef!.Get<bool>("playsInline"); set => JSRef!.Set("playsInline", value); }
        /// <summary>
        /// A URL for an image to be shown while the video is downloading. If this attribute isn't specified, nothing is displayed until the first frame is available, then the first frame is shown as the poster frame.
        /// </summary>
        public string Poster { get => JSRef!.Get<string>("poster"); set => JSRef!.Set("poster", value); }
        /// <summary>
        /// Indicates if the user agent should suggest the picture-in-picture to users, or not.
        /// </summary>
        public bool DisablePictureInPicture { get => JSRef!.Get<bool>("disablePictureInPicture"); set => JSRef!.Set("disablePictureInPicture", value); }
        /// <summary>
        /// A string that reflects the width HTML attribute, which specifies the width of the display area, in CSS pixels.
        /// </summary>
        public string? Width { get => JSRef!.Get<string?>("width"); set => JSRef!.Set("width", value); }
        /// <summary>
        /// A string that reflects the height HTML attribute, which specifies the height of the display area, in CSS pixels.
        /// </summary>
        public string? Height { get => JSRef!.Get<string?>("height"); set => JSRef!.Set("height", value); }
        /// <summary>
        /// Fired when one or both of the videoWidth and videoHeight properties have just been updated.
        /// </summary>
        public ActionEvent<Event> OnResize { get => new ActionEvent<Event>("resize", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the HTMLVideoElement enters picture-in-picture mode successfully.
        /// </summary>
        public ActionEvent<Event> OnEnterPictureInPicture { get => new ActionEvent<Event>("enterpictureinpicture", AddEventListener, RemoveEventListener); set { } }
        /// <summary>
        /// Fired when the HTMLVideoElement leaves picture-in-picture mode successfully.
        /// </summary>
        public ActionEvent<Event> OnLeavePictureInPicture { get => new ActionEvent<Event>("leavepictureinpicture", AddEventListener, RemoveEventListener); set { } }
    }
}