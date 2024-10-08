﻿using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Text;

namespace SpawnDev.BlazorJS.JSObjects.WebRTC
{
    /// <summary>
    /// The RTCPeerConnection interface represents a WebRTC connection between the local computer and a remote peer. It provides methods to connect to a remote peer, maintain and monitor the connection, and close the connection once it's no longer needed.<br/>
    /// https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection
    /// </summary>
    public class RTCPeerConnection : EventTarget
    {
        /// <summary>
        /// Creates an X.509 certificate and its corresponding private key, returning a Promise that resolves with the new RTCCertificate once it is generated.
        /// </summary>
        /// <param name="keygenAlgorithm"></param>
        /// <returns></returns>
        public static RTCCertificate GenerateCertificate(RsaHashedKeyGenParams keygenAlgorithm) => JS.Call<RTCCertificate>("generateCertificate", keygenAlgorithm);
        /// <summary>
        /// Creates an X.509 certificate and its corresponding private key, returning a Promise that resolves with the new RTCCertificate once it is generated.
        /// </summary>
        /// <param name="keygenAlgorithm"></param>
        /// <returns></returns>
        public static RTCCertificate GenerateCertificate(string keygenAlgorithm) => JS.Call<RTCCertificate>("generateCertificate", keygenAlgorithm);
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="_ref"></param>
        public RTCPeerConnection(IJSInProcessObjectReference _ref) : base(_ref) { }
        /// <summary>
        /// The RTCPeerConnection() constructor returns a newly-created RTCPeerConnection, which represents a connection between the local device and a remote peer.
        /// </summary>
        public RTCPeerConnection() : base(JS.New(nameof(RTCPeerConnection))) { }
        /// <summary>
        /// The RTCPeerConnection() constructor returns a newly-created RTCPeerConnection, which represents a connection between the local device and a remote peer.
        /// </summary>
        /// <param name="configuration"></param>
        public RTCPeerConnection(RTCConfiguration configuration) : base(JS.New(nameof(RTCPeerConnection), configuration)) { }
        /// <summary>
        /// Returns a Promise that resolves to an RTCIdentityAssertion which contains a string identifying the remote peer. Once this promise resolves successfully, the resulting identity is the target peer identity and will not change for the duration of the connection.
        /// </summary>
        public Task<RTCIdentityAssertion> PeerIdentity => JSRef!.GetAsync<RTCIdentityAssertion>("peerIdentity");
        /// <summary>
        /// The read-only property RTCPeerConnection.iceConnectionState returns a string which state of the ICE agent associated with the RTCPeerConnection: new, checking, connected, completed, failed, disconnected, and closed.
        /// </summary>
        public string IceConnectionState => JSRef!.Get<string>("iceConnectionState");
        /// <summary>
        /// Returns a string that describes connection's ICE gathering state. This lets you detect, for example, when collection of ICE candidates has finished. Possible values are: new, gathering, or complete.
        /// </summary>
        public string IceGatheringState => JSRef!.Get<string>("iceGatheringState");
        /// <summary>
        /// The read-only RTCPeerConnection property canTrickleIceCandidates returns a boolean value which indicates whether or not the remote peer can accept trickled ICE candidates.
        /// </summary>
        public bool CanTrickleIceCandidates => JSRef!.Get<bool>("canTrickleIceCandidates");
        /// <summary>
        /// The read-only connectionState property of the RTCPeerConnection interface indicates the current state of the peer connection by returning one of the following string values: new, connecting, connected, disconnected, failed, or closed.
        /// </summary>
        public string ConnectionState => JSRef!.Get<string>("connectionState");
        /// <summary>
        /// The read-only signalingState property on the RTCPeerConnection interface returns a string value describing the state of the signaling process on the local end of the connection while connecting or reconnecting to another peer. See Signaling in our WebRTC session lifetime page.
        /// </summary>
        public string SignalingState => JSRef!.Get<string>("signalingState");
        /// <summary>
        /// Returns an RTCSctpTransport object describing the SCTP transport layer over which SCTP data is being sent and received. If SCTP hasn't been negotiated, this value is null.
        /// </summary>
        public RTCSctpTransport? Sctp => JSRef!.Get<RTCSctpTransport>("sctp");
        /// <summary>
        /// The read-only property RTCPeerConnection.localDescription returns an RTCSessionDescription describing the session for the local end of the connection. If it has not yet been set, this is null.
        /// </summary>
        public RTCSessionDescription? LocalDescription => JSRef!.Get<RTCSessionDescription?>("localDescription");
        /// <summary>
        /// Returns an RTCSessionDescription object describing a pending configuration change for the local end of the connection. This does not describe the connection as it currently stands, but as it may exist in the near future.
        /// </summary>
        public RTCSessionDescription? PendingLocalDescription => JSRef!.Get<RTCSessionDescription?>("pendingLocalDescription");
        /// <summary>
        /// Returns an RTCSessionDescription object describing a pending configuration change for the remote end of the connection. This does not describe the connection as it currently stands, but as it may exist in the near future.
        /// </summary>
        public RTCSessionDescription? PendingRemoteDescription => JSRef!.Get<RTCSessionDescription?>("pendingRemoteDescription");
        /// <summary>
        /// Returns an RTCSessionDescription object describing the session, including configuration and media information, for the remote end of the connection. If this hasn't been set yet, this returns null.
        /// </summary>
        public RTCSessionDescription? RemoteDescription => JSRef!.Get<RTCSessionDescription?>("remoteDescription");
        /// <summary>
        /// The read-only property RTCPeerConnection.currentLocalDescription returns an RTCSessionDescription object describing the local end of the connection as it was most recently successfully negotiated since the last time the RTCPeerConnection finished negotiating and connecting to a remote peer. Also included is a list of any ICE candidates that may already have been generated by the ICE agent since the offer or answer represented by the description was first instantiated.
        /// </summary>
        public RTCSessionDescription? CurrentLocalDescription => JSRef!.Get<RTCSessionDescription?>("currentLocalDescription");
        /// <summary>
        /// The read-only property RTCPeerConnection.currentRemoteDescription returns an RTCSessionDescription object describing the remote end of the connection as it was most recently successfully negotiated since the last time the RTCPeerConnection finished negotiating and connecting to a remote peer. Also included is a list of any ICE candidates that may already have been generated by the ICE agent since the offer or answer represented by the description was first instantiated.
        /// </summary>
        public RTCSessionDescription? CurrentRemoteDescription => JSRef!.Get<RTCSessionDescription?>("currentRemoteDescription");

        /// <summary>
        /// When a website or app using RTCPeerConnection receives a new ICE candidate from the remote peer over its signaling channel, it delivers the newly-received candidate to the browser's ICE agent by calling RTCPeerConnection.addIceCandidate(). This adds this new remote candidate to the RTCPeerConnection's remote description, which describes the state of the remote end of the connection.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public Task AddIceCandidate(RTCIceCandidate candidate) => JSRef!.CallVoidAsync("addIceCandidate", candidate);
        /// <summary>
        /// When a website or app using RTCPeerConnection receives a new ICE candidate from the remote peer over its signaling channel, it delivers the newly-received candidate to the browser's ICE agent by calling RTCPeerConnection.addIceCandidate(). This adds this new remote candidate to the RTCPeerConnection's remote description, which describes the state of the remote end of the connection.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public Promise AddIceCandidatePromise(RTCIceCandidate candidate) => JSRef!.Call<Promise>("addIceCandidate", candidate);
        /// <summary>
        /// When a website or app using RTCPeerConnection receives a new ICE candidate from the remote peer over its signaling channel, it delivers the newly-received candidate to the browser's ICE agent by calling RTCPeerConnection.addIceCandidate(). This adds this new remote candidate to the RTCPeerConnection's remote description, which describes the state of the remote end of the connection.
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>
        public Task AddIceCandidate(string candidate) => JSRef!.CallVoidAsync("addIceCandidate", candidate);
        /// <summary>
        /// The RTCPeerConnection.close() method closes the current peer connection.
        /// </summary>
        public void Close() => JSRef!.CallVoid("close");
        /// <summary>
        /// The createAnswer() method on the RTCPeerConnection interface creates an SDP answer to an offer received from a remote peer during the offer/answer negotiation of a WebRTC connection. The answer contains information about any media already attached to the session, codecs and options supported by the browser, and any ICE candidates already gathered. The answer is delivered to the returned Promise, and should then be sent to the source of the offer to continue the negotiation process.
        /// </summary>
        /// <returns></returns>
        public Task<RTCSessionDescription> CreateAnswer() => JSRef!.CallAsync<RTCSessionDescription>("createAnswer");
        /// <summary>
        /// The createAnswer() method on the RTCPeerConnection interface creates an SDP answer to an offer received from a remote peer during the offer/answer negotiation of a WebRTC connection. The answer contains information about any media already attached to the session, codecs and options supported by the browser, and any ICE candidates already gathered. The answer is delivered to the returned Promise, and should then be sent to the source of the offer to continue the negotiation process.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<RTCSessionDescription> CreateAnswer(RTCAnswerOptions options) => JSRef!.CallAsync<RTCSessionDescription>("createAnswer", options);
        /// <summary>
        /// The createDataChannel() method on the RTCPeerConnection interface creates a new channel linked with the remote peer, over which any kind of data may be transmitted. This can be useful for back-channel content, such as images, file transfer, text chat, game update packets, and so forth.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public RTCDataChannel CreateDataChannel(string label, RTCDataChannelOptions? options = null) => JSRef!.Call<RTCDataChannel>("createDataChannel", label, options);
        /// <summary>
        /// The createOffer() method of the RTCPeerConnection interface initiates the creation of an SDP offer for the purpose of starting a new WebRTC connection to a remote peer. The SDP offer includes information about any MediaStreamTrack objects already attached to the WebRTC session, codec, and options supported by the browser, and any candidates already gathered by the ICE agent, for the purpose of being sent over the signaling channel to a potential peer to request a connection or to update the configuration of an existing connection.
        /// </summary>
        /// <returns></returns>
        public Task<RTCSessionDescription> CreateOffer()  => JSRef!.CallAsync<RTCSessionDescription>("createOffer");
        /// <summary>
        /// The createOffer() method of the RTCPeerConnection interface initiates the creation of an SDP offer for the purpose of starting a new WebRTC connection to a remote peer. The SDP offer includes information about any MediaStreamTrack objects already attached to the WebRTC session, codec, and options supported by the browser, and any candidates already gathered by the ICE agent, for the purpose of being sent over the signaling channel to a potential peer to request a connection or to update the configuration of an existing connection.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public Task<RTCSessionDescription> CreateOffer(RTCOfferOptions options) => JSRef!.CallAsync<RTCSessionDescription>("createOffer", options);
        /// <summary>
        /// The RTCPeerConnection method setLocalDescription() changes the local description associated with the connection. This description specifies the properties of the local end of the connection, including the media format. The method takes a single parameter—the session description—and it returns a Promise which is fulfilled once the description has been changed, asynchronously.
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        public Task SetLocalDescription(RTCSessionDescription desc) => JSRef!.CallVoidAsync("setLocalDescription", desc);
        /// <summary>
        /// The RTCPeerConnection method setLocalDescription() changes the local description associated with the connection. This description specifies the properties of the local end of the connection, including the media format. The method takes a single parameter—the session description—and it returns a Promise which is fulfilled once the description has been changed, asynchronously.
        /// </summary>
        /// <returns></returns>
        public Task SetLocalDescription() => JSRef!.CallVoidAsync("setLocalDescription");
        /// <summary>
        /// The RTCPeerConnection method setRemoteDescription() sets the specified session description as the remote peer's current offer or answer. The description specifies the properties of the remote end of the connection, including the media format. The method takes a single parameter—the session description—and it returns a Promise which is fulfilled once the description has been changed, asynchronously.
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        public Task SetRemoteDescription(RTCSessionDescription desc) => JSRef!.CallVoidAsync("setRemoteDescription", desc);
        /// <summary>
        /// The RTCPeerConnection method setRemoteDescription() sets the specified session description as the remote peer's current offer or answer. The description specifies the properties of the remote end of the connection, including the media format. The method takes a single parameter—the session description—and it returns a Promise which is fulfilled once the description has been changed, asynchronously.
        /// </summary>
        /// <param name="desc"></param>
        /// <returns></returns>
        public Promise SetRemoteDescriptionPromise(RTCSessionDescription desc) => JSRef!.Call<Promise>("setRemoteDescription", desc);
        /// <summary>
        /// The WebRTC API's RTCPeerConnection interface offers the restartIce() method to allow a web application to easily request that ICE candidate gathering be redone on both ends of the connection. This simplifies the process by allowing the same method to be used by either the caller or the receiver to trigger an ICE restart.
        /// </summary>
        public void RestartIce() => JSRef!.CallVoid("restartIce");
        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="track">A MediaStreamTrack object representing the media track to add to the peer connection.</param>
        /// <returns>The RTCRtpSender object which will be used to transmit the media data.</returns>
        public RTCRtpSender AddTrack(MediaStreamTrack track) => JSRef!.Call<RTCRtpSender>("addTrack", track);
        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="trackOrKind"></param>
        /// <returns></returns>
        public RTCRtpTransceiver AddTransceiver(string trackOrKind) => JSRef!.Call<RTCRtpTransceiver>("addTransceiver", trackOrKind);
        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="trackOrKind"></param>
        /// <returns></returns>
        public RTCRtpTransceiver AddTransceiver(MediaStreamTrack trackOrKind) => JSRef!.Call<RTCRtpTransceiver>("addTransceiver", trackOrKind);
        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="trackOrKind"></param>
        /// <param name="init"></param>
        /// <returns></returns>
        public RTCRtpTransceiver AddTransceiver(string trackOrKind, RTCRtpTransceiverOptions init) => JSRef!.Call<RTCRtpTransceiver>("addTransceiver", trackOrKind);
        /// <summary>
        /// The RTCPeerConnection method addTrack() adds a new media track to the set of tracks which will be transmitted to the other peer.
        /// </summary>
        /// <param name="trackOrKind"></param>
        /// <param name="init"></param>
        /// <returns></returns>
        public RTCRtpTransceiver AddTransceiver(MediaStreamTrack trackOrKind, RTCRtpTransceiverOptions init) => JSRef!.Call<RTCRtpTransceiver>("addTransceiver", trackOrKind);
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
            return JSRef!.CallApply<RTCRtpSender>("addTrack", args.ToArray());
        }
        /// <summary>
        /// The RTCPeerConnection.removeTrack() method tells the local end of the connection to stop sending media from the specified track, without actually removing the corresponding RTCRtpSender from the list of senders as reported by RTCPeerConnection.getSenders(). If the track is already stopped, or is not in the connection's senders list, this method has no effect.
        /// </summary>
        /// <param name="sender"></param>
        public void RemoveTrack(RTCRtpSender sender) => JSRef!.CallVoid("removeTrack", sender);
        /// <summary>
        /// The RTCPeerConnection method getSenders() returns an array of RTCRtpSender objects, each of which represents the RTP sender responsible for transmitting one track's data. A sender object provides methods and properties for examining and controlling the encoding and transmission of the track's data.
        /// </summary>
        /// <returns></returns>
        public RTCRtpSender[] GetSenders() => JSRef!.Call<RTCRtpSender[]>("getSenders");
        /// <summary>
        /// The RTCPeerConnection.getReceivers() method returns an array of RTCRtpReceiver objects, each of which represents one RTP receiver. Each RTP receiver manages the reception and decoding of data for a MediaStreamTrack on an RTCPeerConnection.
        /// </summary>
        /// <returns></returns>
        public RTCRtpReceiver[] GetReceivers() => JSRef!.Call<RTCRtpReceiver[]>("getReceivers");
        /// <summary>
        /// Returns a Promise which resolves with data providing statistics about either the overall connection or about the specified MediaStreamTrack.
        /// </summary>
        /// <param name="selector">A MediaStreamTrack for which to gather statistics. If this is null (the default value), statistics will be gathered for the entire RTCPeerConnection.</param>
        /// <returns></returns>
        public Task<RTCStatsReport> GetStats(MediaStreamTrack? selector = null) => JSRef!.CallAsync<RTCStatsReport>("getStats", selector);
        // TODO ... 
        // unless there is a compatibility issue ...
        // switch to ActionEvent with AddEventListener instead of using property assigning which limits usage more... 
        // however, a lot of these events should only be handled by a single event handler but that should be up to the consuming code
        public ActionEvent<Event> OnConnectionStateChange { get => new ActionEvent<Event>("onconnectionstatechange", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// A datachannel event is sent to an RTCPeerConnection instance when an RTCDataChannel has been added to the connection, as a result of the remote peer calling RTCPeerConnection.createDataChannel().
        /// </summary>
        public ActionEvent<RTCDataChannelEvent> OnDataChannel { get => new ActionEvent<RTCDataChannelEvent>("ondatachannel", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// An icecandidate event is sent to an RTCPeerConnection when:<br/>
        /// - An RTCIceCandidate has been identified and added to the local peer by a call to RTCPeerConnection.setLocalDescription(),<br/>
        /// - Every RTCIceCandidate correlated with a particular username fragment and password combination (a generation) has been so identified and added, and<br/>
        /// - All ICE gathering on all transports is complete.
        /// </summary>
        public ActionEvent<RTCPeerConnectionEvent> OnIceCandidate { get => new ActionEvent<RTCPeerConnectionEvent>("onicecandidate", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// The WebRTC API event icecandidateerror is sent to an RTCPeerConnection if an error occurs while performing ICE negotiations through a STUN or TURN server. The event object is of type RTCPeerConnectionIceErrorEvent, and contains information describing the error in some amount of detail.
        /// </summary>
        public ActionEvent<RTCPeerConnectionIceErrorEvent> OnIceCandidateError { get => new ActionEvent<RTCPeerConnectionIceErrorEvent>("onicecandidateerror", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// An iceconnectionstatechange event is sent to an RTCPeerConnection object each time the ICE connection state changes during the negotiation process. The new ICE connection state is available in the object's iceConnectionState property.
        /// </summary>
        public ActionEvent<Event> OnIceConnectionStateChange { get => new ActionEvent<Event>("oniceconnectionstatechange", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// The icegatheringstatechange event is sent to the onicegatheringstatechange event handler on an RTCPeerConnection when the state of the ICE candidate gathering process changes. This signifies that the value of the connection's iceGatheringState property has changed.
        /// </summary>
        public ActionEvent<Event> OnIceGatheringStateChange { get => new ActionEvent<Event>("onicegatheringstatechange", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// A negotiationneeded event is sent to the RTCPeerConnection when negotiation of the connection through the signaling channel is required. This occurs both during the initial setup of the connection as well as any time a change to the communication environment requires reconfiguring the connection.
        /// </summary>
        public ActionEvent<Event> OnNegotiationNeeded { get => new ActionEvent<Event>("onnegotiationneeded", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// A signalingstatechange event is sent to an RTCPeerConnection to notify it that its signaling state, as indicated by the signalingState property, has changed.
        /// </summary>
        public ActionEvent<Event> OnSignalingStateChange { get => new ActionEvent<Event>("onsignalingstatechange", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
        /// <summary>
        /// The track event is sent to the ontrack event handler on RTCPeerConnections after a new track has been added to an RTCRtpReceiver which is part of the connection.
        /// </summary>
        public ActionEvent<RTCTrackEvent> OnTrack { get => new ActionEvent<RTCTrackEvent>("ontrack", JSRef!.Set, (eventName, callback) => JSRef!.Set(eventName, null)); set { } }
    }
}
