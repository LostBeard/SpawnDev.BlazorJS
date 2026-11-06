# RTCRtcpParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebRTC/RTCRtcpParameters.cs`  

> RTCP (RTP Control Protocol) parameters carried on RTCRtpParameters. Read-only in practice - browsers populate these from the negotiated SDP; consumers round-trip them through setParameters unchanged. https://www.w3.org/TR/webrtc/#dom-rtcrtcpparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Cname` | `string?` | get/set | Canonical Name (CNAME) identifying the RTP source (RFC 3550 §6.5.1). |
| `ReducedSize` | `bool?` | get/set | Whether reduced-size RTCP (RFC 5506) is in use on this stream. |
