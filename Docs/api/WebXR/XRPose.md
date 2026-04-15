# XRPose

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `JSObject`  
**Source:** `JSObjects/WebXR/XRPose.cs`  
**MDN Reference:** [XRPose on MDN](https://developer.mozilla.org/en-US/docs/Web/API/XRPose)

> XRPose is a WebXR API interface representing a position and orientation in the 3D space, relative to the XRSpace within which it resides. The XRSpace-which is either an XRReferenceSpace or an XRBoundedReferenceSpace-defines the coordinate system used for the pose and, in the case of an XRViewerPose, its underlying views. To obtain the XRPose for the XRSpace used as the local coordinate system of an object, call XRFrame.getPose(), specifying that local XRSpace and the space to which you wish to convert: https://developer.mozilla.org/en-US/docs/Web/API/XRPose

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `AngularVelocity` | `DOMPointReadOnly` | get | A DOMPointReadOnly describing the angular velocity in radians per second relative to the base XRSpace. |
| `Transform` | `XRRigidTransform` | get | A XRRigidTransform which provides the position and orientation of the pose relative to the base XRSpace. |
| `LinearVelocity` | `DOMPointReadOnly` | get | A DOMPointReadOnly describing the linear velocity in meters per second relative to the base XRSpace. |
| `EmulatedPosition` | `bool` | get | A Boolean value which is false if the position and orientation given by transform is obtained directly from a full six degree of freedom (6DoF) XR device (that is, a device which tracks not only the pitch, yaw, and roll of the head but also the forward, backward, and side-to-side motion of the viewer). If any component of the transform is computed or created artificially (such as by using mouse or keyboard controls to move through space), this value is instead true, indicating that the transform is in part emulated in software. |

