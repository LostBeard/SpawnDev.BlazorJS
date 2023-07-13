using Microsoft.JSInterop;


namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
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
        public Promise SetRemoteDescriptionPromise(IRTCSessionDescription desc) => JSRef.Call<Promise>("setRemoteDescription", desc);
        public string IceConnectionState => JSRef.Get<string>("iceConnectionState");
        public void RestartIce() => JSRef.CallVoid("restartIce");

        // TODO ... 
        // unless there is a compatibility issue ...
        // switch to JSEventCallback with AddEventListener instead of using property assigning which limits usage more... 
        // however, a lot of these events should only be handled by a single event handler but that should be up to the consuming code
        public JSEventCallback OnConnectionStateChange { get => new JSEventCallback(JSRef, "onconnectionstatechange"); set { } }
        public JSEventCallback<RTCDataChannelEvent> OnDataChannel { get => new JSEventCallback<RTCDataChannelEvent>(JSRef, "ondatachannel"); set { } }
        public JSEventCallback<RTCPeerConnectionEvent> OnIceCandidate { get => new JSEventCallback<RTCPeerConnectionEvent>(JSRef, "onicecandidate"); set { } }
        public JSEventCallback<RTCPeerConnectionIceErrorEvent> OnIceCandidateError { get => new JSEventCallback<RTCPeerConnectionIceErrorEvent>(JSRef, "onicecandidateerror"); set { } }
        public JSEventCallback OnIceConnectionStateChange { get => new JSEventCallback(JSRef, "oniceconnectionstatechange"); set { } }
        public JSEventCallback OnIceGatheringStateChange { get => new JSEventCallback(JSRef, "onicegatheringstatechange"); set { } }
        public JSEventCallback OnNegotiationNeeded { get => new JSEventCallback(JSRef, "onnegotiationneeded"); set { } }
        public JSEventCallback OnSignalingStateChange { get => new JSEventCallback(JSRef, "onsignalingstatechange"); set { } }
        public JSEventCallback<RTCTrackEvent> OnTrack { get => new JSEventCallback<RTCTrackEvent>(JSRef, "ontrack"); set { } }

        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="track">A MediaStreamTrack object representing the media track to add to the peer connection.</param>
        /// <returns>The RTCRtpSender object which will be used to transmit the media data.</returns>
        public RTCRtpSender AddTrack(MediaStreamTrack track) => JSRef.Call<RTCRtpSender>("addTrack", track);
        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="track">A MediaStreamTrack object representing the media track to add to the peer connection.</param>
        /// <param name="mediaStreams">One or more local MediaStream objects to which the track should be added.</param>
        /// <returns></returns>
        public RTCRtpSender AddTrack(MediaStreamTrack track, params MediaStream[] mediaStreams)
        {
            var args = new List<object> { track };
            args.AddRange(mediaStreams);
            return JSRef.CallApply<RTCRtpSender>("addTrack", args.ToArray());
        }


        public void RemoveTrack(RTCRtpSender sender) => JSRef.CallVoid("removeTrack", sender);

        public RTCRtpSender[] GetSenders() => JSRef.Call<RTCRtpSender[]>("getSenders");
        public RTCRtpReceiver[] GetReceivers() => JSRef.Call<RTCRtpReceiver[]>("getReceivers");

    }
}
