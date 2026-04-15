# AudioScheduledSourceNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/AudioScheduledSourceNode.cs`  
**MDN Reference:** [AudioScheduledSourceNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioScheduledSourceNode)

> The AudioScheduledSourceNode interface-part of the Web Audio API-is a parent interface for several types of audio source node interfaces which share the ability to be started and stopped, optionally at specified times. Specifically, this interface defines the start() and stop() methods, as well as the ended event. https://developer.mozilla.org/en-US/docs/Web/API/AudioScheduledSourceNode

## Methods

| Method | Return Type | Description |
|---|---|---|
| `Start(float? when)` | `void` | Schedules the node to begin playing the constant sound at the specified time. If no time is specified, the node begins playing immediately. The time, in seconds, at which the sound should begin to play. This value is specified in the same time coordinate system as the AudioContext is using for its currentTime attribute. A value of 0 (or omitting the when parameter entirely) causes the sound to start playback immediately. |
| `Stop(float? when)` | `void` | Schedules the node to stop playing at the specified time. If no time is specified, the node stops playing at once. The time, in seconds, at which the sound should stop playing. This value is specified in the same time coordinate system as the AudioContext is using for its currentTime attribute. Omitting this parameter, specifying a value of 0, or passing a negative value causes the sound to stop playback immediately. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnEnded` | `ActionEvent<Event>` | Fired when the source node has stopped playing, either because it's reached a predetermined stop time, the full duration of the audio has been performed, or because the entire buffer has been played. |

