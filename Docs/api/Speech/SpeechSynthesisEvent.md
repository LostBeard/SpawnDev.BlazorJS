# SpeechSynthesisEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/Speech/SpeechSynthesisEvent.cs`  

> The SpeechSynthesisEvent interface of the Web Speech API contains information about the current state of SpeechSynthesisUtterance objects that have been processed in the speech service.

## Constructors

| Signature | Description |
|---|---|
| `SpeechSynthesisEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Utterance` | `SpeechSynthesisUtterance` | get | Returns the SpeechSynthesisUtterance instance that the event was triggered on. |
| `CharIndex` | `int` | get | Returns the index position of the character in the SpeechSynthesisUtterance.text that was being spoken when the event was triggered. |
| `CharLength` | `int?` | get | Returns the length of the character in the SpeechSynthesisUtterance.text that was being spoken when the event was triggered. |
| `ElapsedTime` | `float` | get | Returns the elapsed time in seconds after the SpeechSynthesisUtterance.text started being spoken that the event was triggered at. |
| `Name` | `string` | get | Returns the name associated with certain types of events occurring as the SpeechSynthesisUtterance.text is being spoken: the name of the SSML marker reached in the case of a mark event, or the type of boundary reached in the case of a boundary event. |

