# RTCConfiguration

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Source:** `JSObjects/WebRTC/RTCConfiguration.cs`  
**MDN Reference:** [RTCConfiguration on MDN](https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#configuration)

> Configuration passed to new RTCPeerConnection https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#configuration

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `RTCConfiguration` | `class` | get | Configuration passed to new RTCPeerConnection https://developer.mozilla.org/en-US/docs/Web/API/RTCPeerConnection/RTCPeerConnection#configuration |
| `IceServers` | `RTCIceServer[]?` | get |  |
| `BundlePolicy` | `string?` | get/set |  |
| `Certificates` | `RTCCertificate[]?` | get |  |
| `IceCandidatePoolSize` | `ushort?` | get |  |
| `IceTransportPolicy` | `string?` | get/set |  |
| `PeerIdentity` | `string?` | get |  |
| `RtcMuxPolicy` | `string?` | get |  |
| `SdpSemantics` | `string?` | get/set | SDPSemantics determines which style of SDP offers and answers |

## Constants

| Name | Value | Description |
|---|---|---|
| `SdpSemanticsUnifiedPlanWithFallback` | `"unified-plan-with-fallback"` | SDPSemanticsUnifiedPlanWithFallback prefers unified-plan offers and answers, but will respond to a plan-b offer with a plan-b answer |
| `SdpSemanticsUnifiedPlan` | `"unified-plan"` | SDPSemanticsUnifiedPlan uses unified-plan offers and answers (the default in Chrome since M72) https://tools.ietf.org/html/draft-roach-mmusic-unified-plan-00 |
| `SdpSemanticsPlanB` | `"plan-b"` | SDPSemanticsPlanB uses plan-b offers and answers NB: This format should be considered deprecated https://tools.ietf.org/html/draft-uberti-rtcweb-plan-00 |

