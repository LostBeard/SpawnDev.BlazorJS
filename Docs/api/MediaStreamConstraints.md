# MediaStreamConstraints

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaStreamConstraints.cs`  

> The MediaStreamConstraints dictionary is used to instruct the User Agent what sort of MediaStreamTracks to include in the MediaStream returned by getUserMedia(). https://www.w3.org/TR/mediacapture-streams/#dom-mediastreamconstraints

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaStreamConstraints` | `class` | get | The MediaStreamConstraints dictionary is used to instruct the User Agent what sort of MediaStreamTracks to include in the MediaStream returned by getUserMedia(). https://www.w3.org/TR/mediacapture-streams/#dom-mediastreamconstraints |
| `Audio` | `Union<bool, MediaTrackConstraints>?` | get |  |
| `Video` | `Union<bool, MediaTrackConstraints>?` | get/set | video of type (boolean or MediaTrackConstraints), defaulting to false If true, it requests that the returned MediaStream contain a video track.If a Constraints structure is provided, it further specifies the nature and settings of the video Track.If false, the MediaStream MUST NOT contain a video Track. |

