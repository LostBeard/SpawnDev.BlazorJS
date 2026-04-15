# GamepadPose

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/GamepadPose.cs`  
**MDN Reference:** [GamepadPose on MDN](https://developer.mozilla.org/en-US/docs/Web/API/GamepadPose)

> The GamepadPose interface of the Gamepad API represents the pose of a WebVR controller at a given timestamp (which includes orientation, position, velocity, and acceleration information). This interface is accessible through the Gamepad.pose property. https://developer.mozilla.org/en-US/docs/Web/API/GamepadPose

## Constructors

| Signature | Description |
|---|---|
| `GamepadPose(IJSInProcessObjectReference _ref)` | Deserialization constructor |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `HasOrientation` | `bool` | get | Returns a boolean indicating whether the gamepad is capable of returning orientation information (true) or not (false). |
| `HasPosition` | `bool` | get | Returns a boolean indicating whether the gamepad is capable of returning position information (true) or not (false). |
| `Position` | `Float32Array?` | get | The position read-only property of the GamepadPose interface returns the position of the Gamepad as a 3D vector. The coordinate system is as follows: Positive X is to the user's right. Positive Y is up. Positive Z is behind the user. Positions are measured in meters from an origin point - this point is the position the sensor was first read at. |
| `LinearVelocity` | `Float32Array?` | get | The linearVelocity read-only property of the GamepadPose interface returns an array representing the linear velocity vector of the Gamepad, in meters per second. In other words, the current velocity at which the sensor is moving along the x, y, and z axes. |
| `LinearAcceleration` | `Float32Array?` | get | The linearAcceleration read-only property of the GamepadPose interface returns an array representing the linear acceleration vector of the Gamepad, in meters per second per second. In other words, the current acceleration of the sensor, along the x, y, and z axes. |
| `Orientation` | `Float32Array?` | get | The orientation read-only property of the GamepadPose interface returns the orientation of the Gamepad, as a quarternion value. The value is a Float32Array, made up of the following values: pitch - rotation around the X axis. yaw - rotation around the Y axis. roll - rotation around the Z axis. w - the fourth dimension(usually 1). The orientation yaw(rotation around the y axis) is relative to the initial yaw of the sensor when it was first read. |
| `AngularVelocity` | `Float32Array?` | get | The angularVelocity read-only property of the GamepadPose interface returns an array representing the angular velocity vector of the Gamepad, in radians per second. In other words, the current velocity at which the sensor is rotating around the x, y, and z axes. |
| `AngularAcceleration` | `Float32Array?` | get | The angularAcceleration read-only property of the GamepadPose interface returns an array representing the angular acceleration vector of the Gamepad, in meters per second per second. In other words, the current acceleration of the sensor's rotation around the x, y, and z axes. |

