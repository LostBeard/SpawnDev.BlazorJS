using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    // https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection
    [JsonConverter(typeof(JSObjectConverter<RTCPeerConnection>))]
    public class RTCPeerConnection : EventTarget
    {
        
        public RTCPeerConnection(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCPeerConnection() : base(JS.New(nameof(RTCPeerConnection))) { }
        public RTCPeerConnection(RTCConfiguration configuration) : base(JS.New(nameof(RTCPeerConnection), configuration)) { }
        public bool CanTrickleIceCandidates => JSRef.Get<bool>("canTrickleIceCandidates");
        public string ConnectionState => JSRef.Get<string>("connectionState");
        public string SignalingState => JSRef.Get<string>("signalingState");
        public RTCSessionDescription CurrentLocalDescription => JSRef.Get<RTCSessionDescription>("currentLocalDescription");
        public RTCSessionDescription CurrentRemoteDescription => JSRef.Get<RTCSessionDescription>("currentRemoteDescription");
        public ValueTask AddIceCandidate(RTCIceCandidate candidate) => JSRef.CallVoidAsync("addIceCandidate", candidate);
        public ValueTask AddIceCandidate(string candidate) => JSRef.CallVoidAsync("addIceCandidate", candidate);
        public void Close() => JSRef.CallVoid("close");
        public async Task<T> CreateAnswer<T>() where T : IRTCSessionDescription => await JSRef.CallAsync<T>("createAnswer");
        public RTCDataChannel CreateDataChannel(string label, RTCDataChannelOptions? options = null) => JSRef.Call<RTCDataChannel>("createDataChannel", label, options);
        public async Task<T> CreateOffer<T>() where T : IRTCSessionDescription => await JSRef.CallAsync<T>("createOffer");
        public void SetLocalDescription(IRTCSessionDescription desc) => JSRef.CallVoid("setLocalDescription", desc);
        public void SetRemoteDescription(IRTCSessionDescription desc) => JSRef.CallVoid("setRemoteDescription", desc);
    }
}
