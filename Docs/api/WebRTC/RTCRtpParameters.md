# RTCRtpParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebRTC/RTCRtpParameters.cs`  

> Base dictionary for RTCRtpSender.GetParameters / SetParameters and RTCRtpReceiver.GetParameters. Carries the round-trip-only fields (codecs, header extensions, rtcp) that browsers set from the negotiated SDP and consumers must not edit. https://www.w3.org/TR/webrtc/#dom-rtcrtpparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Codecs` | `RTCRtpCodecParameters[]?` | get/set | Negotiated codecs for this sender/receiver. Read-from getParameters + pass back unchanged on setParameters - use setCodecPreferences on the transceiver to actually influence codec selection. |
| `HeaderExtensions` | `RTCRtpHeaderExtensionParameters[]?` | get/set | Negotiated RTP header extensions. Round-trip-only. |
| `Rtcp` | `RTCRtcpParameters?` | get/set | RTCP parameters (cname, reducedSize). Round-trip-only. |
