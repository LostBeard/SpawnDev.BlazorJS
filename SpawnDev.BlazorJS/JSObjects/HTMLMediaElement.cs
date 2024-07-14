using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    /// <summary>
    /// The HTMLMediaElement interface adds to HTMLElement the properties and methods needed to support basic media-related capabilities that are common to audio and video.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement
    /// </summary>
    public class HTMLMediaElement : HTMLElement
    {
        /// <summary>
        /// Explicit conversion from ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLMediaElement?(ElementReference elementReference) => elementReference.Context == null || string.IsNullOrEmpty(elementReference.Id) ? null : new HTMLMediaElement(elementReference);
        /// <summary>
        /// Explicit conversion from ElementReference?
        /// </summary>
        /// <param name="elementReference"></param>
        public static explicit operator HTMLMediaElement?(ElementReference? elementReference) => elementReference == null || elementReference.Value.Context == null || string.IsNullOrEmpty(elementReference.Value.Id) ? null : new HTMLMediaElement(elementReference.Value);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLMediaElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Get an instance from an ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLMediaElement(ElementReference elementReference) : base(elementReference) { }

        #region Properties
        /// <summary>
        /// A MediaStream representing the media to play or that has played in the current HTMLMediaElement, or null if not assigned.
        /// </summary>
        public Union<MediaStream, File, Blob, MediaSource>? SrcObject { get => JSRef!.Get<Union<MediaStream, File, Blob, MediaSource>?>("srcObject"); set => JSRef!.Set("srcObject", value); }
        public T? GetSrcObject<T>() => JSRef!.Get<T>("srcObject");
        /// <summary>
        /// A string that reflects the src HTML attribute, which contains the URL of a media resource to use.
        /// </summary>
        public string? Src { get => JSRef!.Get<string>("src"); set => JSRef!.Set("src", value); }
        /// <summary>
        /// A double-precision floating-point value indicating the current playback time in seconds; if the media has not started to play and has not been seeked, this value is the media's initial playback time. Setting this value seeks the media to the new time. The time is specified relative to the media's timeline.
        /// </summary>
        public double CurrentTime { get => JSRef!.Get<double>("currentTime"); set => JSRef!.Set("currentTime", value); }
        /// <summary>
        /// A read-only double-precision floating-point value indicating the total duration of the media in seconds. If no media data is available, the returned value is NaN. If the media is of indefinite length (such as streamed live media, a WebRTC call's media, or similar), the value is +Infinity.
        /// </summary>
        public double? Duration => JSRef!.Get<double?>("duration");
        /// <summary>
        /// A double indicating the audio volume, from 0.0 (silent) to 1.0 (loudest).
        /// </summary>
        public double Volume { get => JSRef!.Get<double>("volume"); set => JSRef!.Set("volume", value); }
        /// <summary>
        /// A double indicating the default playback rate for the media.
        /// </summary>
        public double DefaultPlaybackRate { get => JSRef!.Get<double>("defaultPlaybackRate"); set => JSRef!.Set("defaultPlaybackRate", value); }
        /// <summary>
        /// A double that indicates the rate at which the media is being played back.
        /// </summary>
        public double PlaybackRate { get => JSRef!.Get<double>("playbackRate"); set => JSRef!.Set("playbackRate", value); }
        /// <summary>
        /// A boolean value that reflects the autoplay HTML attribute, indicating whether playback should automatically begin as soon as enough media is available to do so without interruption.
        /// </summary>
        public bool AutoPlay { get => JSRef!.Get<bool>("autoplay"); set => JSRef!.Set("autoplay", value); }
        /// <summary>
        /// A boolean that determines whether audio is muted. true if the audio is muted and false otherwise.
        /// </summary>
        public bool Muted { get => JSRef!.Get<bool>("muted"); set => JSRef!.Set("muted", value); }
        /// <summary>
        /// A boolean that reflects the muted HTML attribute, which indicates whether the media element's audio output should be muted by default.
        /// </summary>
        public bool DefaultMuted { get => JSRef!.Get<bool>("defaultMuted"); set => JSRef!.Set("defaultMuted", value); }
        /// <summary>
        /// A boolean that sets or returns the remote playback state, indicating whether the media element is allowed to have a remote playback UI.
        /// </summary>
        public bool DisableRemotePlayback { get => JSRef!.Get<bool>("disableRemotePlayback"); set => JSRef!.Set("disableRemotePlayback", value); }
        /// <summary>
        /// A boolean that reflects the controls HTML attribute, indicating whether user interface items for controlling the resource should be displayed.
        /// </summary>
        public bool Controls { get => JSRef!.Get<bool>("controls"); set => JSRef!.Set("controls", value); }
        /// <summary>
        /// Returns a boolean that indicates whether the media element is paused.
        /// </summary>
        public bool Paused => JSRef!.Get<bool>("paused");
        /// <summary>
        /// Returns a boolean that indicates whether the media element has finished playing.
        /// </summary>
        public bool Ended => JSRef!.Get<bool>("ended");
        /// <summary>
        /// A boolean that reflects the loop HTML attribute, which indicates whether the media element should start over when it reaches the end.
        /// </summary>
        public bool Loop { get => JSRef!.Get<bool>("loop"); set => JSRef!.Set("loop", value); }
        /// <summary>
        /// Returns a string with the absolute URL of the chosen media resource.
        /// </summary>
        public string? CurrentSrc => JSRef!.Get<string?>("currentSrc");
        /// <summary>
        /// A string indicating the CORS setting for this media element.
        /// </summary>
        public string? CrossOrigin { get => JSRef!.Get<string?>("crossOrigin"); set => JSRef!.Set("crossOrigin", value); }
        /// <summary>
        /// Returns a MediaError object for the most recent error, or null if there has not been an error.
        /// </summary>
        public MediaError? Error => JSRef!.Get<MediaError?>("error");
        /// <summary>
        /// Returns a unsigned short (enumeration) indicating the readiness state of the media.<br/>
        /// 0 HAVE_NOTHING - No information is available about the media resource.<br/>
        /// 1 HAVE_METADATA - Enough of the media resource has been retrieved that the metadata attributes are initialized. Seeking will no longer raise an exception.<br/>
        /// 2 HAVE_CURRENT_DATA	- Data is available for the current playback position, but not enough to actually play more than one frame.<br/>
        /// 3 HAVE_FUTURE_DATA - Data for the current playback position as well as for at least a little bit of time into the future is available (in other words, at least two frames of video, for example).<br/>
        /// 4 HAVE_ENOUGH_DATA - Enough data is available—and the download rate is high enough—that the media can be played through to the end without interruption.<br/>
        /// </summary>
        public ushort ReadyState => JSRef!.Get<ushort>("readyState");
        #endregion

        #region Methods
        /// <summary>
        /// Begins playback of the media.
        /// </summary>
        /// <returns></returns>
        public Task Play() => JSRef!.CallVoidAsync("play");
        /// <summary>
        /// Pauses the media playback.
        /// </summary>
        public void Pause() => JSRef!.CallVoid("pause");
        /// <summary>
        /// Resets the media to the beginning and selects the best available source from the sources provided using the src attribute or the source element.
        /// </summary>
        public void Load() => JSRef!.CallVoid("load");
        /// <summary>
        /// Given a string specifying a MIME media type (potentially with the codecs parameter included), canPlayType() returns the string probably if the media should be playable, maybe if there's not enough information to determine whether the media will play or not, or an empty string if the media cannot be played.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public string CanPlayType(string mimeType) => JSRef!.Call<string>("canPlayType", mimeType);
        /// <summary>
        /// Returns MediaStream, captures a stream of the media content.
        /// </summary>
        /// <returns></returns>
        public MediaStream CaptureStream() => JSRef!.Call<MediaStream>("capture");
        #endregion

        #region Events

        /// <summary>
        /// Fired when the resource was not fully loaded, but not as the result of an error.
        /// </summary>
        public JSEventCallback<Event> OnAbort { get => new JSEventCallback<Event>(JSRef, "abort", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content.
        /// </summary>
        public JSEventCallback<Event> OnCanPlay { get => new JSEventCallback<Event>(JSRef, "canplay", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content.
        /// </summary>
        public JSEventCallback<Event> OnCanPlayThrough { get => new JSEventCallback<Event>(JSRef, "canplaythrough", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the duration property has been updated.
        /// </summary>
        public JSEventCallback<Event> OnDurationChange { get => new JSEventCallback<Event>(JSRef, "durationchange", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the media has become empty; for example, when the media has already been loaded (or partially loaded), and the HTMLMediaElement.load() method is called to reload it.
        /// </summary>
        public JSEventCallback<Event> OnEmptied { get => new JSEventCallback<Event>(JSRef, "emptied", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the media encounters some initialization data indicating it is encrypted.
        /// </summary>
        public JSEventCallback<MediaEncryptedEvent> OnEncrypted { get => new JSEventCallback<MediaEncryptedEvent>(JSRef, "encrypted", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback stops when end of the media (audio or video) is reached or because no further data is available.
        /// </summary>
        public JSEventCallback<Event> OnEnded { get => new JSEventCallback<Event>(JSRef, "ended", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the first frame of the media has finished loading.
        /// </summary>
        public JSEventCallback<Event> OnLoadedData { get => new JSEventCallback<Event>(JSRef, "loadeddata", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the metadata has been loaded.
        /// </summary>
        public JSEventCallback<Event> OnLoadedMetadata { get => new JSEventCallback<Event>(JSRef, "loadedmetadata", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the browser has started to load a resource.
        /// </summary>
        public JSEventCallback<Event> OnLoadStart { get => new JSEventCallback<Event>(JSRef, "loadstart", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when a request to pause play is handled and the activity has entered its paused state, most commonly occurring when the media's HTMLMediaElement.pause() method is called.
        /// </summary>
        public JSEventCallback<Event> OnPause { get => new JSEventCallback<Event>(JSRef, "pause", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the paused property is changed from true to false, as a result of the HTMLMediaElement.play() method, or the autoplay attribute.
        /// </summary>
        public JSEventCallback<Event> OnPlay { get => new JSEventCallback<Event>(JSRef, "play", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback is ready to start after having been paused or delayed due to lack of data.
        /// </summary>
        public JSEventCallback<Event> OnPlaying { get => new JSEventCallback<Event>(JSRef, "playing", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired periodically as the browser loads a resource.
        /// </summary>
        public JSEventCallback<Event> OnProgress { get => new JSEventCallback<Event>(JSRef, "progress", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the playback rate has changed.
        /// </summary>
        public JSEventCallback<Event> OnRateChange { get => new JSEventCallback<Event>(JSRef, "ratechange", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when one or both of the videoWidth and videoHeight properties have just been updated.
        /// </summary>
        public JSEventCallback<Event> OnResize { get => new JSEventCallback<Event>(JSRef, "resize", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when a seek operation completes.
        /// </summary>
        public JSEventCallback<Event> OnSeeked { get => new JSEventCallback<Event>(JSRef, "seeked", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when a seek operation begins.
        /// </summary>
        public JSEventCallback<Event> OnSeeking { get => new JSEventCallback<Event>(JSRef, "seeking", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the user agent is trying to fetch media data, but data is unexpectedly not forthcoming.
        /// </summary>
        public JSEventCallback<Event> OnStalled { get => new JSEventCallback<Event>(JSRef, "stalled", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the media data loading has been suspended.
        /// </summary>
        public JSEventCallback<Event> OnSuspend { get => new JSEventCallback<Event>(JSRef, "suspend", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the time indicated by the currentTime property has been updated.
        /// </summary>
        public JSEventCallback<Event> OnTimeUpdate { get => new JSEventCallback<Event>(JSRef, "timeupdate", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the volume has changed.
        /// </summary>
        public JSEventCallback<Event> OnVolumeChange { get => new JSEventCallback<Event>(JSRef, "volumechange", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback has stopped because of a temporary lack of data.
        /// </summary>
        public JSEventCallback<Event> OnWaiting { get => new JSEventCallback<Event>(JSRef, "waiting", "addEventListener", "removeEventListener"); set { } }
        #endregion
    }
}
