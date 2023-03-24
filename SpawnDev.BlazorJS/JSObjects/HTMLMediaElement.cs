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


        public event Action OnCanPlay { add => JSRef?.CallVoid("addEventListener", "canplay", value); remove => JSRef?.CallVoid("removeEventListener", "canplay", value); }

        public T? GetSrcObject<T>() => JSRef.Get<T>("srcObject");

        public Task Play() => JSRef.CallVoidAsync("play");
        public void Pause() => JSRef.CallVoid("pause");
        public void Load() => JSRef.CallVoid("load");
        public string CanPlayType(string mimeType) => JSRef.Call<string>("canPlayType", mimeType);
    }
}
