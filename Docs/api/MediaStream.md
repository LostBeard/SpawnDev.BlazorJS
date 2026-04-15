# MediaStream

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/MediaStream.cs`  
**MDN Reference:** [MediaStream on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaStream)

> The MediaStream interface of the Media Capture and Streams API represents a stream of media content. A stream consists of several tracks, such as video or audio tracks. Each track is specified as an instance of MediaStreamTrack. https://developer.mozilla.org/en-US/docs/Web/API/MediaStream

## Constructors

| Signature | Description |
|---|---|
| `MediaStream(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MediaStream()` | Creates a new instance of MediaStream |
| `MediaStream(MediaStream stream)` | Creates a new instance of MediaStream A different MediaStream object whose tracks are added to the newly-created stream automatically. The tracks are not removed from the original stream, so they're shared by the two streams. |
| `MediaStream(IEnumerable<MediaStreamTrack> tracks)` | Creates a new instance of MediaStream An Array of MediaStreamTrack objects, one for each track to add to the stream. |
| `MediaStream(Array<MediaStreamTrack> tracks)` | Creates a new instance of MediaStream An Array of MediaStreamTrack objects, one for each track to add to the stream. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Active` | `bool` | get | The active read-only property of the MediaStream interface returns a Boolean value which is true if the stream is currently active; otherwise, it returns false. A stream is considered active if at least one of its MediaStreamTracks does not have its property MediaStreamTrack.readyState set to ended. Once every track has ended, the stream's active property becomes false. |
| `Id` | `string` | get | The MediaStream.id read-only property is a string containing 36 characters denoting a unique identifier (GUID) for the object. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `RemoveTrack(MediaStreamTrack track)` | `void` | Removes the MediaStreamTrack given as argument. If the track is not part of the MediaStream object, nothing happens. |
| `AddTrack(MediaStreamTrack track)` | `void` | Stores a copy of the MediaStreamTrack given as argument. If the track has already been added to the MediaStream object, nothing happens. |
| `Clone()` | `MediaStream` | Returns a clone of the MediaStream object. The clone will, however, have a unique value for id. |
| `GetTrackById(string id)` | `MediaStreamTrack?` | Returns the track whose ID corresponds to the one given in parameters, trackid. If no parameter is given, or if no track with that ID does exist, it returns null. If several tracks have the same ID, it returns the first one. |
| `GetTracksLength()` | `int` | Returns the total number of tracks |
| `GetTracks()` | `Array<MediaStreamTrack>` | Returns a list of all MediaStreamTrack objects stored in the MediaStream object, regardless of the value of the kind attribute. The order is not defined, and may not only vary from one browser to another, but also from one call to another. |
| `GetVideoTracks()` | `Array<MediaStreamTrack>` | Returns a list of the MediaStreamTrack objects stored in the MediaStream object that have their kind attribute set to "video". The order is not defined, and may not only vary from one browser to another, but also from one call to another. |
| `GetAudioTracks()` | `Array<MediaStreamTrack>` | Returns a list of the MediaStreamTrack objects stored in the MediaStream object that have their kind attribute set to audio. The order is not defined, and may not only vary from one browser to another, but also from one call to another. |
| `GetFirstVideoTrack()` | `MediaStreamTrack?` | Returns the first video track or null |
| `GetFirstVideoTrackSettings()` | `MediaTrackSettings?` | Returns the first video track settings |
| `GetFirstAudioTrackSettings()` | `MediaTrackSettings?` | Returns the first audio track settings |
| `GetFirstAudioTrack()` | `MediaStreamTrack?` | Returns the first audio track or null |
| `StopAllTracks()` | `void` | Calls stop on all tracks |
| `RemoveAllTracks(bool stopTracks)` | `void` | Removes all tracks and optionally stops them first (default) If true, stop() will be called on the track before removing |
| `RemoveAllVideoTracks(bool stopTracks)` | `void` | Removes all video tracks and optionally stops them first (default) If true, stop() will be called on the track before removing |
| `RemoveAllAudioTracks(bool stopTracks)` | `void` | Removes all audio tracks and optionally stops them first (default) If true, stop() will be called on the track before removing |

## Events

| Event | Type | Description |
|---|---|---|
| `OnAddTrack` | `ActionEvent<MediaStreamTrackEvent>` | The addtrack event is fired when a new MediaStreamTrack object has been added to a MediaStream. |
| `OnRemoveTrack` | `ActionEvent<MediaStreamTrackEvent>` | The removetrack event is fired when a new MediaStreamTrack object has been removed from a MediaStream. |

