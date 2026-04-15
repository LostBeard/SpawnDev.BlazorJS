# MediaStreamTrackEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/MediaStreamTrackEvent.cs`  

> The MediaStreamTrackEvent interface of the Media Capture and Streams API represents events which indicate that a MediaStream has had tracks added to or removed from the stream through calls to Media Capture and Streams API methods. These events are sent to the stream when these changes occur.

## Constructors

| Signature | Description |
|---|---|
| `MediaStreamTrackEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Track` | `MediaStreamTrack` | get | Returns a MediaStreamTrack object representing the track associated with the event. |

