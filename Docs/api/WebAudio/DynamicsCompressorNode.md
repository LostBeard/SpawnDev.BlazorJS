# DynamicsCompressorNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/DynamicsCompressorNode.cs`  
**MDN Reference:** [DynamicsCompressorNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/DynamicsCompressorNode)

> The DynamicsCompressorNode interface provides a compression effect, which lowers the volume of the loudest parts of the signal in order to help prevent clipping and distortion that can occur when multiple sounds are played and mixed together at once. https://developer.mozilla.org/en-US/docs/Web/API/DynamicsCompressorNode

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `Threshold` | `AudioParam` | get | An k-rate AudioParam representing the decibel value above which the compression will start taking effect. |
| `Knee` | `AudioParam` | get | An k-rate AudioParam representing the amount of change, in dB, needed in the input for a 1 dB change in the output. |
| `Ratio` | `AudioParam` | get | An k-rate AudioParam representing the amount of attenuation, in dB, that is being applied to the signal. |
| `Attack` | `AudioParam` | get | An k-rate AudioParam representing the amount of time, in seconds, required to reduce the gain by 10 dB. |
| `Release` | `AudioParam` | get | An k-rate AudioParam representing the amount of time, in seconds, required to increase the gain by 10 dB. |

