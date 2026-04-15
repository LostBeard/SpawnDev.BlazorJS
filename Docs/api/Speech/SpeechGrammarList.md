# SpeechGrammarList

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/Speech/SpeechGrammarList.cs`  

> The SpeechGrammarList interface of the Web Speech API represents a list of SpeechGrammar objects.

## Constructors

| Signature | Description |
|---|---|
| `SpeechGrammarList(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `SpeechGrammarList()` | Creates a new SpeechGrammarList. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Length` | `int` | get | Returns the number of SpeechGrammar objects contained in the list. |

## Methods

| Method | Return Type | Description |
|---|---|---|
| `AddFromString(string src, float weight)` | `void` | Takes a grammar and adds it to the SpeechGrammarList. |
| `AddFromURI(string src, float weight)` | `void` | Takes a grammar and adds it to the SpeechGrammarList. |

