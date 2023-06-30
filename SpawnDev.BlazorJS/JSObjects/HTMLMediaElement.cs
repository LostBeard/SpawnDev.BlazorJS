using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    // https://developer.mozilla.org/en-US/docs/Web/API/HTMLMediaElement
    public class HTMLMediaElement : HTMLElement {
        public HTMLMediaElement(IJSInProcessObjectReference _ref) : base(_ref) { }
        // MediaStream, MediaSource, Blob, or File
        public JSObject? SrcObject {
            get => JSRef.Get<JSObject>("srcObject");
            set => JSRef.Set("srcObject", value);
        }
        public string? Src {
            get => JSRef.Get<string>("src");
            set => JSRef.Set("src", value);
        }
        public double CurrentTime {
            get => JSRef.Get<double>("currentTime");
            set => JSRef.Set("currentTime", value);
        }
        public double Duration
        {
            get => JSRef.Get<double>("duration");
        }

        public float Volume
        {
            get => JSRef.Get<float>("volume");
            set => JSRef.Set("volume", value);
        }
        public bool AutoPlay
        {
            get => JSRef.Get<bool>("autoplay");
            set => JSRef.Set("autoplay", value);
        }
        public bool Muted
        {
            get => JSRef.Get<bool>("muted");
            set => JSRef.Set("muted", value);
        }
        public bool Paused
        {
            get => JSRef.Get<bool>("paused");
            set => JSRef.Set("paused", value);
        }
        public string? CurrentSrc {
            get => JSRef.Get<string?>("currentSrc");
        }
        public string? CrossOrigin
        {
            get => JSRef.Get<string?>("crossOrigin");
            set => JSRef.Set("crossOrigin", value);
        }
        public T? GetSrcObject<T>() => JSRef.Get<T>("srcObject");
        public Task Play() => JSRef.CallVoidAsync("play");
        public void Pause() => JSRef.CallVoid("pause");
        public void Load() => JSRef.CallVoid("load");
        public string CanPlayType(string mimeType) => JSRef.Call<string>("canPlayType", mimeType);
        public MediaStream CaptureStream() => JSRef.Call<MediaStream>("capture");

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
        public JSEventCallback OnEncrypted { get => new JSEventCallback(JSRef, "encrypted", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when playback stops when end of the media (<audio> or <video>) is reached or because no further data is available.
        /// </summary>
        public JSEventCallback OnEnded { get => new JSEventCallback(JSRef, "ended", "addEventListener", "removeEventListener"); set { } }
        /// <summary>
        /// Fired when the resource could not be loaded due to an error.
        /// </summary>
        public JSEventCallback OnError { get => new JSEventCallback(JSRef, "error", "addEventListener", "removeEventListener"); set { } }
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

    }
}
