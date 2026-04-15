# PannerNode

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `AudioNode`  
**Source:** `JSObjects/WebAudio/PannerNode.cs`  
**MDN Reference:** [PannerNode on MDN](https://developer.mozilla.org/en-US/docs/Web/API/PannerNode)

> The PannerNode interface defines an audio-processing object that represents the location, direction, and behavior of an audio source signal in a simulated physical space. This AudioNode uses right-hand Cartesian coordinates to describe the source's position as a vector and its orientation as a 3D directional cone. A PannerNode always has exactly one input and one output: the input can be mono or stereo but the output is always stereo (2 channels); you can't have panning effects without at least two audio channels! https://developer.mozilla.org/en-US/docs/Web/API/PannerNode

## Constructors

| Signature | Description |
|---|---|
| `PannerNode(BaseAudioContext context)` | The PannerNode() constructor of the Web Audio API creates a new PannerNode object instance. |
| `PannerNode(BaseAudioContext context, PannerOptions options)` | The PannerNode() constructor of the Web Audio API creates a new PannerNode object instance. A BaseAudioContext representing the audio context you want the node to be associated with. PannerOptions |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `ConeInnerAngle` | `double` | get | A double value describing the angle, in degrees, of a cone inside of which there will be no volume reduction. |
| `ConeOuterAngle` | `double` | get | A double value describing the angle, in degrees, of a cone outside of which the volume will be reduced by a constant value, defined by the coneOuterGain property. |
| `ConeOuterGain` | `double` | get | A double value describing the amount of volume reduction outside the cone defined by the coneOuterAngle attribute. Its default value is 0, meaning that no sound can be heard. |
| `DistanceModel` | `string` | get | An enumerated value determining which algorithm to use to reduce the volume of the audio source as it moves away from the listener. Possible values are "linear", "inverse" and "exponential". The default value is "inverse". |
| `MaxDistance` | `double` | get | A double value representing the maximum distance between the audio source and the listener, after which the volume is not reduced any further. |
| `OrientationX` | `AudioParam` | get | Represents the horizontal position of the audio source's vector in a right-hand Cartesian coordinate system. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 1. |
| `OrientationY` | `AudioParam` | get | Represents the vertical position of the audio source's vector in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0. |
| `OrientationZ` | `AudioParam` | get | Represents the longitudinal (back and forth) position of the audio source's vector in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0. |
| `PanningModel` | `string` | get | An enumerated value determining which spatialization algorithm to use to position the audio in 3D space. |
| `PositionX` | `AudioParam` | get | Represents the horizontal position of the audio in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0. |
| `PositionY` | `AudioParam` | get | Represents the vertical position of the audio in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0. |
| `PositionZ` | `AudioParam` | get | Represents the longitudinal (back and forth) position of the audio in a right-hand Cartesian coordinate system. The default is 0. While this AudioParam cannot be directly changed, its value can be altered using its value property. The default is value is 0. |
| `RefDistance` | `double` | get | A double value representing the reference distance for reducing volume as the audio source moves further from the listener. For distances greater than this the volume will be reduced based on rolloffFactor and distanceModel. |
| `RolloffFactor` | `double` | get | A double value describing how quickly the volume is reduced as the source moves away from the listener. This value is used by all distance models. |

