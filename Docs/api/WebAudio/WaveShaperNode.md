# WaveShaperNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/WaveShaperNode.cs`  
**MDN Reference:** [WaveShaperNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/WaveShaperNode)

> The WaveShaperNode interface represents a non-linear distorter. It is an AudioNode that use a curve to apply a wave shaping distortion to the signal. Beside obvious distortion effects, it is often used to add a warm feeling to the signal. https://developer.mozilla.org/en-US/docs/Web/API/WaveShaperNode

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Curve` | `Float32Array?` | get | A Float32Array of numbers describing the distortion to apply. |
| `Oversample` | `string` | get | A string indicating whether to oversample the signal or not. |

