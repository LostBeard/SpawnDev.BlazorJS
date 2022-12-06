using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    [JsonConverter(typeof(JSObjectConverter<RTCPeerConnection>))]
    public class RTCPeerConnection : EventTarget
    {
        
        public RTCPeerConnection(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCPeerConnection() : base("RTCPeerConnection") { }
        public RTCPeerConnection(RTCConfiguration configuration) : base("RTCPeerConnection", configuration) { }
        public bool CanTrickleIceCandidates => _ref.Get<bool>("canTrickleIceCandidates");
        public string ConnectionState => _ref.Get<string>("connectionState");
        public string SignalingState => _ref.Get<string>("signalingState");
        public RTCSessionDescription CurrentLocalDescription => _ref.Get<RTCSessionDescription>("currentLocalDescription");
        public RTCSessionDescription CurrentRemoteDescription => _ref.Get<RTCSessionDescription>("currentRemoteDescription");
        public ValueTask AddIceCandidate(RTCIceCandidate candidate) => _ref.CallVoidAsync("addIceCandidate", candidate);
        public ValueTask AddIceCandidate(string candidate) => _ref.CallVoidAsync("addIceCandidate", candidate);
        public void Close() => _ref.CallVoid("close");
        public async Task<T> CreateAnswer<T>() where T : IRTCSessionDescription => await _ref.GetAsync<T>("createAnswer");
        public RTCDataChannel CreateDataChannel(string label, RTCDataChannelOptions? options = null) => _ref.Call<RTCDataChannel>("createDataChannel", label, options);
        public async Task<T> CreateOffer<T>() where T : IRTCSessionDescription => await _ref.GetAsync<T>("createOffer");
        public void SetLocalDescription(IRTCSessionDescription desc) => _ref.CallVoid("setLocalDescription", desc);
        public void SetRemoteDescription(IRTCSessionDescription desc) => _ref.CallVoid("setRemoteDescription", desc);
    }
}
