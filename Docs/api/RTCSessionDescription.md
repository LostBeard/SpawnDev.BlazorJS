# RTCSessionDescription

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inheritance:** `JSObject` -> `RTCSessionDescription`  
**MDN Reference:** [RTCSessionDescription](https://developer.mozilla.org/en-US/docs/Web/API/RTCSessionDescription)

> The `RTCSessionDescription` class represents an SDP (Session Description Protocol) description of a WebRTC session. It contains the type of description (offer, answer, pranswer, rollback) and the SDP string itself. Used with `RTCPeerConnection.SetLocalDescription()` and `RTCPeerConnection.SetRemoteDescription()`.

## Constructors

| Signature | Description |
|-----------|-------------|
| `RTCSessionDescription(IJSInProcessObjectReference _ref)` | Deserialization constructor. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Type` | `string` | The type of description: `"offer"`, `"answer"`, `"pranswer"`, or `"rollback"`. |
| `Sdp` | `string` | The SDP string describing the session. |

## Example

```csharp
// Create an offer
using var offer = await pc.CreateOffer();
Console.WriteLine($"Type: {offer.Type}");  // "offer"
Console.WriteLine($"SDP:\n{offer.Sdp}");

await pc.SetLocalDescription(offer);

// Set a remote description received from signaling
await pc.SetRemoteDescription(new RTCSessionDescription
{
    Type = "answer",
    Sdp = receivedSdpString
});
```
