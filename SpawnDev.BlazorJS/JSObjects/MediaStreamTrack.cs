using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class MediaStreamTrack : JSObject {
        public bool Active => JSRef.Get<bool>("active");
        public bool Enabled => JSRef.Get<bool>("enabled");
        public bool Muted => JSRef.Get<bool>("muted");
        public string Id => JSRef.Get<string>("id");
        public string Kind => JSRef.Get<string>("kind");
        public string ContentHint => JSRef.Get<string>("contentHint");
        public string Label => JSRef.Get<string>("label");
        public string ReadyState => JSRef.Get<string>("readyState");

        public MediaStreamTrack(IJSInProcessObjectReference _ref) : base(_ref) { }

        public T GetSettings<T>() where T : MediaStreamTrackSettings => JSRef.Call<T>("getSettings");
        public MediaStreamTrackSettings GetSettings() => JSRef.Call<MediaStreamTrackSettings>("getSettings");

        public void Stop() => JSRef.CallVoid("stop");
    }
}
