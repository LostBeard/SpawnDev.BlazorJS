# RTCRtpHeaderExtensionParameters

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/WebRTC/RTCRtpHeaderExtensionParameters.cs`  

> One RTP header extension (RFC 8285) parameter entry carried on RTCRtpParameters. Negotiated via SDP `a=extmap`; consumers round-trip these through setParameters rather than editing them. https://www.w3.org/TR/webrtc/#dom-rtcrtpheaderextensionparameters

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Uri` | `string` | get/set | URI identifying the header extension (e.g. `"urn:ietf:params:rtp-hdrext:ssrc-audio-level"`). |
| `Id` | `int` | get/set | Extension ID (1-14 one-byte header or 1-255 two-byte header) negotiated in SDP. |
| `Encrypted` | `bool?` | get/set | Whether this extension is carried over SRTP-encrypted header extensions (RFC 6904). |
