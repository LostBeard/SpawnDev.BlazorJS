using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects
{
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement
    public class HTMLMediaElement : HTMLElement
    {

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public HTMLMediaElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// Constructor fro man ElementReference
        /// </summary>
        /// <param name="elementReference"></param>
        public HTMLMediaElement(ElementReference elementReference) : base(elementReference) { }

        #region Properties
        /// <summary>
        /// A MediaStream representing the media to play or that has played in the current HTMLMediaElement, or null if not assigned.
        /// </summary>
        public JSObject? SrcObject { get => JSRef.Get<JSObject>("srcObject"); set => JSRef.Set("srcObject", value); }
        public T? GetSrcObject<T>() => JSRef.Get<T>("srcObject");
        /// <summary>
        /// A string that reflects the src HTML attribute, which contains the URL of a media resource to use.
        /// </summary>
        public string? Src { get => JSRef.Get<string>("src"); set => JSRef.Set("src", value); }
        /// <summary>
        /// A double-precision floating-point value indicating the current playback time in seconds; if the media has not started to play and has not been seeked, this value is the media's initial playback time. Setting this value seeks the media to the new time. The time is specified relative to the media's timeline.
        /// </summary>
        public double CurrentTime { get => JSRef.Get<double>("currentTime"); set => JSRef.Set("currentTime", value); }
        /// <summary>
        /// A read-only double-precision floating-point value indicating the total duration of the media in seconds. If no media data is available, the returned value is NaN. If the media is of indefinite length (such as streamed live media, a WebRTC call's media, or similar), the value is +Infinity.
        /// </summary>
        public double? Duration => JSRef.Get<double?>("duration");
        /// <summary>
        /// A double indicating the audio volume, from 0.0 (silent) to 1.0 (loudest).
        /// </summary>
        public double Volume { get => JSRef.Get<double>("volume"); set => JSRef.Set("volume", value); }
        /// <summary>
        /// A boolean value that reflects the autoplay HTML attribute, indicating whether playback should automatically begin as soon as enough media is available to do so without interruption.
        /// </summary>
        public bool AutoPlay { get => JSRef.Get<bool>("autoplay"); set => JSRef.Set("autoplay", value); }
        /// <summary>
        /// A boolean that determines whether audio is muted. true if the audio is muted and false otherwise.
        /// </summary>
        public bool Muted { get => JSRef.Get<bool>("muted"); set => JSRef.Set("muted", value); }
        /// <summary>
        /// Returns a boolean that indicates whether the media element is paused.
        /// </summary>
        public bool Paused => JSRef.Get<bool>("paused");
        /// <summary>
        /// A boolean that reflects the loop HTML attribute, which indicates whether the media element should start over when it reaches the end.
        /// </summary>
        public bool Loop { get => JSRef.Get<bool>("loop"); set => JSRef.Set("loop", value); }
        /// <summary>
        /// Returns a string with the absolute URL of the chosen media resource.
        /// </summary>
        public string? CurrentSrc => JSRef.Get<string?>("currentSrc");
        /// <summary>
        /// A string indicating the CORS setting for this media element.
        /// </summary>
        public string? CrossOrigin { get => JSRef.Get<string?>("crossOrigin"); set => JSRef.Set("crossOrigin", value); }

        #endregion

        #region Methods
        /// <summary>
        /// Begins playback of the media.
        /// </summary>
        /// <returns></returns>
        public Task Play() => JSRef.CallVoidAsync("play");
        /// <summary>
        /// Pauses the media playback.
        /// </summary>
        public void Pause() => JSRef.CallVoid("pause");
        /// <summary>
        /// Resets the media to the beginning and selects the best available source from the sources provided using the src attribute or the source element.
        /// </summary>
        public void Load() => JSRef.CallVoid("load");
        /// <summary>
        /// Given a string specifying a MIME media type (potentially with the codecs parameter included), canPlayType() returns the string probably if the media should be playable, maybe if there's not enough information to determine whether the media will play or not, or an empty string if the media cannot be played.
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public string CanPlayType(string mimeType) => JSRef.Call<string>("canPlayType", mimeType);
        /// <summary>
        /// Returns MediaStream, captures a stream of the media content.
        /// </summary>
        /// <returns></returns>
        public MediaStream CaptureStream() => JSRef.Call<MediaStream>("capture");
        #endregion

        #region Events

        /// <summary>
        /// Fired when the resource was not fully loaded, but not as the result of an error.
        /// </summary>
        public JSEventCallback OnAbort { get => new JSEventCallback(JSRef, "abort", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the user agent can play the media, but estimates that not enough data has been loaded to play the media up to its end without having to stop for further buffering of content.
        /// </summary>
        public JSEventCallback OnCanPlay { get => new JSEventCallback(JSRef, "canplay", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the user agent can play the media, and estimates that enough data has been loaded to play the media up to its end without having to stop for further buffering of content.
        /// </summary>
        public JSEventCallback OnCanPlayThrough { get => new JSEventCallback(JSRef, "canplaythrough", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the duration property has been updated.
        /// </summary>
        public JSEventCallback OnDurationChange { get => new JSEventCallback(JSRef, "durationchange", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the media has become empty; for example, when the media has already been loaded (or partially loaded), and the HTMLMediaElement.load() method is called to reload it.
        /// </summary>
        public JSEventCallback OnEmptied { get => new JSEventCallback(JSRef, "emptied", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the media encounters some initialization data indicating it is encrypted.
        /// </summary>
        public JSEventCallback OnEncrypted { get => new JSEventCallback(JSRef, "encrypted", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback stops when end of the media (<audio> or <video>) is reached or because no further data is available.
        /// </summary>
        public JSEventCallback OnEnded { get => new JSEventCallback(JSRef, "ended", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the first frame of the media has finished loading.
        /// </summary>
        public JSEventCallback OnLoadedData { get => new JSEventCallback(JSRef, "loadeddata", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the metadata has been loaded.
        /// </summary>
        public JSEventCallback OnLoadedMetadata { get => new JSEventCallback(JSRef, "loadedmetadata", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the browser has started to load a resource.
        /// </summary>
        public JSEventCallback OnLoadStart { get => new JSEventCallback(JSRef, "loadstart", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when a request to pause play is handled and the activity has entered its paused state, most commonly occurring when the media's HTMLMediaElement.pause() method is called.
        /// </summary>
        public JSEventCallback OnPause { get => new JSEventCallback(JSRef, "pause", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the paused property is changed from true to false, as a result of the HTMLMediaElement.play() method, or the autoplay attribute.
        /// </summary>
        public JSEventCallback OnPlay { get => new JSEventCallback(JSRef, "play", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback is ready to start after having been paused or delayed due to lack of data.
        /// </summary>
        public JSEventCallback OnPlaying { get => new JSEventCallback(JSRef, "playing", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired periodically as the browser loads a resource.
        /// </summary>
        public JSEventCallback OnProgress { get => new JSEventCallback(JSRef, "progress", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the playback rate has changed.
        /// </summary>
        public JSEventCallback OnRateChange { get => new JSEventCallback(JSRef, "ratechange", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when one or both of the videoWidth and videoHeight properties have just been updated.
        /// </summary>
        public JSEventCallback OnResize { get => new JSEventCallback(JSRef, "resize", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when a seek operation completes.
        /// </summary>
        public JSEventCallback OnSeeked { get => new JSEventCallback(JSRef, "seeked", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when a seek operation begins.
        /// </summary>
        public JSEventCallback OnSeeking { get => new JSEventCallback(JSRef, "seeking", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the user agent is trying to fetch media data, but data is unexpectedly not forthcoming.
        /// </summary>
        public JSEventCallback OnStalled { get => new JSEventCallback(JSRef, "stalled", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the media data loading has been suspended.
        /// </summary>
        public JSEventCallback OnSuspend { get => new JSEventCallback(JSRef, "suspend", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the time indicated by the currentTime property has been updated.
        /// </summary>
        public JSEventCallback OnTimeUpdate { get => new JSEventCallback(JSRef, "timeupdate", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the volume has changed.
        /// </summary>
        public JSEventCallback OnVolumeChange { get => new JSEventCallback(JSRef, "volumechange", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback has stopped because of a temporary lack of data.
        /// </summary>
        public JSEventCallback OnWaiting { get => new JSEventCallback(JSRef, "waiting", "addEventListener", "removeEventListener"); set { } }
        #endregion
    }
}
