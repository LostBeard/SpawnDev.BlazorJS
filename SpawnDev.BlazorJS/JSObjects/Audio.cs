using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects {
    public class Audio : HTMLMediaElement
    {
        public Audio(IJSInProcessObjectReference _ref) : base(_ref) { }
        public Audio(string url) : base(JS.New(nameof(Audio), url)) { }
        //public void Play() => JSRef.CallVoid("play");
    }
}
