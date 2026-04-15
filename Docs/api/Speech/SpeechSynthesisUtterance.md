# SpeechSynthesisUtterance

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `EventTarget`  
**Source:** `JSObjects/Speech/SpeechSynthesisUtterance.cs`  

> The SpeechSynthesisUtterance interface of the Web Speech API represents a speech request. It contains the content the speech service should read and information about how to read it (e.g. language, pitch and volume.)

## Constructors

| Signature | Description |
|---|---|
| `SpeechSynthesisUtterance(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `SpeechSynthesisUtterance(string text)` | Creates a new SpeechSynthesisUtterance. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Lang` | `string` | get | Gets and sets the language of the utterance. |
| `Pitch` | `float` | get | Gets and sets the pitch at which the utterance will be spoken at. |
| `Rate` | `float` | get | Gets and sets the speed at which the utterance will be spoken at. |
| `Text` | `string` | get | Gets and sets the text that will be synthesized when the utterance is spoken. |
| `Voice` | `SpeechSynthesisVoice` | get | Gets and sets the voice that will be used to speak the utterance. |
| `Volume` | `float` | get | Gets and sets the volume that the utterance will be spoken at. |

## Events

| Event | Type | Description |
|---|---|---|
| `OnBoundary` | `ActionEvent<SpeechSynthesisEvent>` | Fired when the spoken utterance reaches a word or sentence boundary. |
| `OnEnd` | `ActionEvent<SpeechSynthesisEvent>` | Fired when the utterance has finished being spoken. |
| `OnError` | `ActionEvent<SpeechSynthesisEvent>` | Fired when an error occurs that prevents the utterance from being spoken. |
| `OnMark` | `ActionEvent<SpeechSynthesisEvent>` | Fired when the spoken utterance reaches a named SSML "mark" tag. |
| `OnPause` | `ActionEvent<SpeechSynthesisEvent>` | Fired when the utterance is paused part way through. |
| `OnResume` | `ActionEvent<SpeechSynthesisEvent>` | Fired when a paused utterance is resumed. |
| `OnStart` | `ActionEvent<SpeechSynthesisEvent>` | Fired when the utterance has begun to be spoken. |

