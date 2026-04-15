# TextTrackCue

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/TextTrackCue.cs`  
**MDN Reference:** [TextTrackCue on MDN](https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCue)

> The TextTrackCue interface of the WebVTT API is the abstract base class for the various derived cue types, such as VTTCue; you will work with these derived types rather than the base class. These cues represent strings of text presented for some duration of time during the performance of a TextTrack. The cue includes the start time (the time at which the text will be displayed) and the end time (the time at which it will be removed from the display), as well as other information. https://developer.mozilla.org/en-US/docs/Web/API/TextTrackCue

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Track` | `TextTrack?` | get/set | The TextTrack that this cue belongs to, or null if it doesn't belong to any. |
| `Id` | `string` | get | A string that identifies the cue. |
| `StartTime` | `double` | get | A double that represents the video time that the cue will start being displayed, in seconds. |
| `EndTime` | `double` | get | A double that represents the video time that the cue will stop being displayed, in seconds. |
| `PauseOnExit` | `bool` | get | A boolean for whether the video will pause when this cue stops being displayed. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnEnter` | `ActionEvent<Event>` | Fired when a cue becomes active. |
| `OnExit` | `ActionEvent<Event>` | Fired when the cue has stopped being active. |

