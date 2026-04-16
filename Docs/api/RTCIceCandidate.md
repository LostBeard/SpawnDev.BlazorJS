# RTCIceCandidate

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inheritance:** `JSObject` -> `RTCIceCandidate`  
**MDN Reference:** [RTCIceCandidate](https://developer.mozilla.org/en-US/docs/Web/API/RTCIceCandidate)

> The `RTCIceCandidate` class represents an ICE (Interactive Connectivity Establishment) candidate for establishing a WebRTC peer-to-peer connection. ICE candidates describe the protocols and routing needed for WebRTC to communicate. They are gathered automatically and delivered via the `OnIceCandidate` event on `RTCPeerConnection`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `RTCIceCandidate(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Candidate` | `string` | The candidate string describing the ICE candidate (transport address, priority, etc.). |
| `SdpMid` | `string?` | The media stream identification tag for the media component this candidate is associated with. |
| `SdpMLineIndex` | `int?` | The zero-based index of the m-line in the SDP this candidate is associated with. |
| `UsernameFragment` | `string?` | The ICE username fragment ("ice-ufrag"). |
| `Component` | `string?` | The component type: `"rtp"` or `"rtcp"`. |
| `Foundation` | `string?` | The candidate foundation string. |
| `Port` | `int?` | The port number. |
| `Priority` | `long?` | The candidate priority. |
| `Protocol` | `string?` | The transport protocol: `"tcp"` or `"udp"`. |
| `Type` | `string?` | The candidate type: `"host"`, `"srflx"`, `"prflx"`, `"relay"`. |
| `Address` | `string?` | The IP address or hostname. |
| `RelatedAddress` | `string?` | The related address (for server-reflexive or relayed candidates). |
| `RelatedPort` | `int?` | The related port. |
| `TcpType` | `string?` | TCP candidate type: `"active"`, `"passive"`, `"so"`. |

## Example

```csharp
// Subscribe using a named method (required for proper cleanup)
pc.OnIceCandidate += Pc_OnIceCandidate;

// Add a remote ICE candidate
await pc.AddIceCandidate(new RTCIceCandidateInfo
{
    Candidate = "candidate:842163049 1 udp 1677729535 ...",
    SdpMid = "0",
    SdpMLineIndex = 0
});

// Clean up event handler before disposal
pc.OnIceCandidate -= Pc_OnIceCandidate;

void Pc_OnIceCandidate(RTCPeerConnectionIceEvent evt)
{
    using var candidate = evt.Candidate;
    if (candidate != null)
    {
        Console.WriteLine($"Candidate: {candidate.Candidate}");
        Console.WriteLine($"SDP Mid: {candidate.SdpMid}");
        Console.WriteLine($"Type: {candidate.Type}");
        Console.WriteLine($"Protocol: {candidate.Protocol}");
        Console.WriteLine($"Address: {candidate.Address}:{candidate.Port}");

        // Serialize and send to remote peer via signaling
        var info = new RTCIceCandidateInfo
        {
            Candidate = candidate.Candidate,
            SdpMid = candidate.SdpMid,
            SdpMLineIndex = candidate.SdpMLineIndex
        };
        SendToRemotePeer(info);
    }
    evt.Dispose();
}
```
