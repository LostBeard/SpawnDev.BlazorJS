# MediaElementAudioSourceNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/MediaElementAudioSourceNode.cs`  
**MDN Reference:** [MediaElementAudioSourceNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/MediaElementAudioSourceNode)

> The MediaElementAudioSourceNode interface represents an audio source consisting of an HTML audio or video element. It is an AudioNode that acts as an audio source. https://developer.mozilla.org/en-US/docs/Web/API/MediaElementAudioSourceNode

## Constructors

| Signature | Description |
|---|---|
| `MediaElementAudioSourceNode(IJSInProcessObjectReference _ref)` | Deserialization constructor |
| `MediaElementAudioSourceNode(AudioContext context, MediaElementAudioSourceNodeOptions options)` | The MediaElementAudioSourceNode() constructor creates a new MediaElementAudioSourceNode object instance. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaElement` | `HTMLMediaElement` | get | The HTMLMediaElement used when constructing this MediaStreamAudioSourceNode. |

