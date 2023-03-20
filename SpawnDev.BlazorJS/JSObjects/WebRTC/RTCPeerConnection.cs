using Microsoft.JSInterop;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC {
    // https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection
    public class RTCPeerConnection : EventTarget {
        public RTCPeerConnection(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCPeerConnection() : base(JS.New(nameof(RTCPeerConnection))) { }
        public RTCPeerConnection(RTCConfiguration configuration) : base(JS.New(nameof(RTCPeerConnection), configuration)) { }
        public bool CanTrickleIceCandidates => JSRef.Get<bool>("canTrickleIceCandidates");
        public string ConnectionState => JSRef.Get<string>("connectionState");
        public string SignalingState => JSRef.Get<string>("signalingState");
        public RTCSessionDescription CurrentLocalDescription => JSRef.Get<RTCSessionDescription>("currentLocalDescription");
        public RTCSessionDescription CurrentRemoteDescription => JSRef.Get<RTCSessionDescription>("currentRemoteDescription");
        public Task AddIceCandidate(RTCIceCandidate candidate) => JSRef.CallVoidAsync("addIceCandidate", candidate);
        public Task AddIceCandidate(string candidate) => JSRef.CallVoidAsync("addIceCandidate", candidate);
        public void Close() => JSRef.CallVoid("close");
        public Task<T> CreateAnswer<T>() where T : IRTCSessionDescription => JSRef.CallAsync<T>("createAnswer");
        public RTCDataChannel CreateDataChannel(string label, RTCDataChannelOptions? options = null) => JSRef.Call<RTCDataChannel>("createDataChannel", label, options);
        public Task<T> CreateOffer<T>() where T : IRTCSessionDescription => JSRef.CallAsync<T>("createOffer");
        public Task SetLocalDescription(IRTCSessionDescription desc) => JSRef.CallVoidAsync("setLocalDescription", desc);
        public Task SetRemoteDescription(IRTCSessionDescription desc) => JSRef.CallVoidAsync("setRemoteDescription", desc);
    }
}
