# RTCDTMFSender

**Namespace:** `SpawnDev.BlazorJS.JSObjects.WebRTC`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/WebRTC/RTCDTMFSender.cs`  

> The RTCDTMFSender interface allows to send DTMF tones to a remote peer.

## Constructors

| Signature | Description |
|---|---|
| `RTCDTMFSender(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ToneBuffer` | `string` | get | Returns a string containing the list of DTMF tones currently queued to be sent. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `InsertDTMF(string tones, int duration, int interToneGap)` | `void` | Sends DTMF tones over the connection. A string containing the DTMF tones to send (characters 0-9, A-D, # and *). Duration each tone should play, in milliseconds. Must be between 40 and 6000. Defaults to 100. Silence between tones, in milliseconds. Must be at least 30. Defaults to 70. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnToneChange` | `ActionEvent<Event>` | Fired when a DTMF tone has been played. |

