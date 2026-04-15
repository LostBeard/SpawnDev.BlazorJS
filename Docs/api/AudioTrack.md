# AudioTrack

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `MediaTrack`  
**Source:** `JSObjects/AudioTrack.cs`  
**MDN Reference:** [AudioTrack on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioTrack)

> The AudioTrack interface represents a single audio track from one of the HTML media elements, &lt;audio> or &lt;video>. The most common use for accessing an AudioTrack object is to toggle its enabled property in order to mute and unmute the track. https://developer.mozilla.org/en-US/docs/Web/API/AudioTrack

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Enabled` | `bool` | get | A Boolean value which controls whether or not the audio track's sound is enabled. Setting this value to false mutes the track's audio. |
| `Kind` | `string` | get | A string specifying the category into which the track falls. For example, the main audio track would have a kind of "main". |
| `Label` | `string` | get | A string providing a human-readable label for the track. For example, an audio commentary track for a movie might have a label of "Commentary with director Christopher Nolan and actors Leonardo DiCaprio and Elliot Page." This string is empty if no label is provided. |
| `Language` | `string` | get | A string specifying the audio track's primary language, or an empty string if unknown. The language is specified as a BCP 47 language tag, such as "en-US" or "pt-BR". |
| `SourceBuffer` | `SourceBuffer?` | get | The SourceBuffer that created the track. Returns null if the track was not created by a SourceBuffer or the SourceBuffer has been removed from the MediaSource.sourceBuffers attribute of its parent media source. |

