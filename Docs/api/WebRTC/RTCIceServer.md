# RTCIceServer

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCIceServer.cs`  
**MDN Reference:** [RTCIceServer on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#iceservers)

> Describes one server which may be used by the ICE agent; these are typically STUN and/or TURN servers. If this isn't specified, the connection attempt will be made with no STUN or TURN server available, which limits the connection to local peers. https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#iceservers

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCIceServer` | `class` | get | Describes one server which may be used by the ICE agent; these are typically STUN and/or TURN servers. If this isn't specified, the connection attempt will be made with no STUN or TURN server available, which limits the connection to local peers. https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#iceservers |
| `Urls` | `Union<string, string[]>?` | get |  |
| `Username` | `string?` | get |  |

