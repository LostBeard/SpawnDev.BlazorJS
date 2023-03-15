using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC {
    public class RTCSessionDescription : JSObject, IRTCSessionDescription {
        public RTCSessionDescription(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string ToJSON() => JSRef.Call<string>("toJSON");
        public string Type => JSRef.Get<string>("type");
        public string Sdp => JSRef.Get<string>("sdp");
    }
}
