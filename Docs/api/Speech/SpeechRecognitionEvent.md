# SpeechRecognitionEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/Speech/SpeechRecognitionEvent.cs`  

> The SpeechRecognitionEvent interface of the Web Speech API represents the event object for the result and nomatch events, and contains all the data associated with an interim or final speech recognition result.

## Constructors

| Signature | Description |
|---|---|
| `SpeechRecognitionEvent(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ResultIndex` | `int` | get | Returns the lowest index value result in the SpeechRecognitionResultList "array" that has actually changed. |
| `Results` | `SpeechRecognitionResultList` | get | Returns a SpeechRecognitionResultList object representing all the speech recognition results for the current session. |

