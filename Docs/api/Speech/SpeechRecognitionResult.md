# SpeechRecognitionResult

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Speech/SpeechRecognitionResult.cs`  

> The SpeechRecognitionResult interface of the Web Speech API represents a single recognition match, which may contain multiple SpeechRecognitionAlternative objects.

## Constructors

| Signature | Description |
|---|---|
| `SpeechRecognitionResult(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `IsFinal` | `bool` | get | A boolean value that states whether this result is final (true) or interim (false). |
| `Length` | `int` | get | Returns the number of SpeechRecognitionAlternative objects contained in this result. |

