# AudioListener

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebAudio/AudioListener.cs`  
**MDN Reference:** [AudioListener on MDN](https://developer.mozilla.org/en-US/docs/Web/API/AudioListener)

> The AudioListener interface represents the position and orientation of the unique person listening to the audio scene, and is used in audio spatialization. All PannerNodes spatialize in relation to the AudioListener stored in the BaseAudioContext.listener attribute. https://developer.mozilla.org/en-US/docs/Web/API/AudioListener

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `PositionX` | `AudioParam` | get | Represents the horizontal position of the listener in a right-hand cartesian coordinate system. The default is 0. |
| `PositionY` | `AudioParam` | get | Represents the vertical position of the listener in a right-hand cartesian coordinate system. The default is 0. |
| `PositionZ` | `AudioParam` | get | Represents the longitudinal (back and forth) position of the listener in a right-hand cartesian coordinate system. The default is 0. |
| `ForwardX` | `AudioParam` | get | Represents the horizontal position of the listener's forward direction in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0. |
| `ForwardY` | `AudioParam` | get | Represents the vertical position of the listener's forward direction in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0. |
| `ForwardZ` | `AudioParam` | get | Represents the longitudinal (back and forth) position of the listener's forward direction in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is -1. |
| `UpX` | `AudioParam` | get | Represents the horizontal position of the top of the listener's head in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0. |
| `UpY` | `AudioParam` | get | Represents the vertical position of the top of the listener's head in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 1. |
| `UpZ` | `AudioParam` | get | Represents the longitudinal (back and forth) position of the top of the listener's head in the same cartesian coordinate system as the position (positionX, positionY, and positionZ) values. The forward and up values are linearly independent of each other. The default is 0. |

