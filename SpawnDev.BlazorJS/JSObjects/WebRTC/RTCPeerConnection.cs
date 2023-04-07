using Microsoft.JSInterop;
using System.Threading.Channels;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    public class RTCRtpTransceiver : JSObject
    {
        public RTCRtpTransceiver(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    public class RTCRtpReceiver : JSObject
    {
        public RTCRtpReceiver(IJSInProcessObjectReference _ref) : base(_ref) { }
    }
    public class RTCTrackEvent : Event
    {
        public RTCTrackEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCRtpReceiver Receiver => JSRef.Get<RTCRtpReceiver>("receiver");
        public MediaStream[] Streams => JSRef.Get<MediaStream[]>("streams");
        public MediaStreamTrack Track => JSRef.Get<MediaStreamTrack>("track");
        public RTCRtpTransceiver Transceiver => JSRef.Get<RTCRtpTransceiver>("transceiver");
    }
    public class RTCPeerConnectionIceErrorEvent : Event
    {
        public RTCPeerConnectionIceErrorEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public string? Address => JSRef.Get<string?>("address");
        public uint? Port => JSRef.Get<uint?>("port");
        public uint ErrorCode => JSRef.Get<uint>("errorCode");
        public string ErrorText => JSRef.Get<string>("errorText");
        public string Url => JSRef.Get<string>("url");
    }
    public class RTCPeerConnectionEvent : Event
    {
        public RTCPeerConnectionEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCIceCandidate Candidate => JSRef.Get<RTCIceCandidate>("candidate");
    }
    public class RTCDataChannelEvent : Event
    {
        public RTCDataChannelEvent(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCDataChannel Channel => JSRef.Get<RTCDataChannel>("channel");
    }

    // https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection
    public class RTCPeerConnection : EventTarget
    {
        public RTCPeerConnection(IJSInProcessObjectReference _ref) : base(_ref) { }
        public RTCPeerConnection() : base(JS.New(nameof(RTCPeerConnection))) { }
        public RTCPeerConnection(RTCConfiguration configuration) : base(JS.New(nameof(RTCPeerConnection), configuration)) { }
        public bool CanTrickleIceCandidates => JSRef.Get<bool>("canTrickleIceCandidates");
        public string ConnectionState => JSRef.Get<string>("connectionState");
        public string SignalingState => JSRef.Get<string>("signalingState");
        public RTCSessionDescription LocalDescription => JSRef.Get<RTCSessionDescription>("localDescription");
        public RTCSessionDescription CurrentLocalDescription => JSRef.Get<RTCSessionDescription>("currentLocalDescription");
        public RTCSessionDescription CurrentRemoteDescription => JSRef.Get<RTCSessionDescription>("currentRemoteDescription");
        public Task AddIceCandidate(RTCIceCandidate candidate) => JSRef.CallVoidAsync("addIceCandidate", candidate);
        public Promise AddIceCandidatePromise(RTCIceCandidate candidate) => JSRef.Call<Promise>("addIceCandidate", candidate);
        public Task AddIceCandidate(string candidate) => JSRef.CallVoidAsync("addIceCandidate", candidate);
        public void Close() => JSRef.CallVoid("close");
        public Task<T> CreateAnswer<T>() where T : IRTCSessionDescription => JSRef.CallAsync<T>("createAnswer");
        public RTCDataChannel CreateDataChannel(string label, RTCDataChannelOptions? options = null) => JSRef.Call<RTCDataChannel>("createDataChannel", label, options);
        public Task<T> CreateOffer<T>() where T : IRTCSessionDescription => JSRef.CallAsync<T>("createOffer");
        public Task SetLocalDescription(IRTCSessionDescription desc) => JSRef.CallVoidAsync("setLocalDescription", desc);
        public Task SetLocalDescription() => JSRef.CallVoidAsync("setLocalDescription");
        public Task SetRemoteDescription(IRTCSessionDescription desc) => JSRef.CallVoidAsync("setRemoteDescription", desc);
        public string IceConnectionState => JSRef.Get<string>("iceConnectionState");
        public void RestartIce() => JSRef.CallVoid("restartIce");
        public ActionCallback OnConnectionStateChange { set { JSRef.Set("onconnectionstatechange", value); } }
        public ActionCallback<RTCDataChannelEvent> OnDataChannel { set { JSRef.Set("ondatachannel", value); } }
        public ActionCallback<RTCPeerConnectionEvent> OnIceCandidate { set { JSRef.Set("onicecandidate", value); } }
        public ActionCallback<RTCPeerConnectionIceErrorEvent> OnIceCandidateError { set { JSRef.Set("onicecandidateerror", value); } }
        public ActionCallback OnIceConnectionStateChange { set { JSRef.Set("oniceconnectionstatechange", value); } }
        public ActionCallback OnIceGatheringStateChange { set { JSRef.Set("onicegatheringstatechange", value); } }
        public ActionCallback OnNegotiationNeeded { set { JSRef.Set("onnegotiationneeded", value); } }
        public ActionCallback OnSignalingStateChange { set { JSRef.Set("onsignalingstatechange", value); } }
        public ActionCallback<RTCTrackEvent> OnTrack { set { JSRef.Set("ontrack", value); } }

    }
}
