# SpeechSynthesisVoice

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Speech/SpeechSynthesisVoice.cs`  

> The SpeechSynthesisVoice interface of the Web Speech API represents a voice that the system supports. Every SpeechSynthesisVoice has its own relative speech service including information about language, name and URI.

## Constructors

| Signature | Description |
|---|---|
| `SpeechSynthesisVoice(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Default` | `bool` | get | A Boolean indicating whether the voice is the default voice for the current app language (true), or not (false). |
| `Lang` | `string` | get | Returns a BCP 47 language tag indicating the language of the voice. |
| `LocalService` | `bool` | get | Returns a Boolean indicating whether the voice is supplied by a local speech synthesizer service (true) or a remote speech synthesizer service (false). |
| `Name` | `string` | get | Returns a human-readable name that represents the voice. |
| `VoiceURI` | `string` | get | Returns the type of URI and location of the speech synthesis service for this voice. |

