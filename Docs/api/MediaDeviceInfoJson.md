# MediaDeviceInfoJson

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/MediaDeviceInfoJson.cs`  

> JSON representation of the MediaDeviceInfo object acquired from MediaDeviceInfo.ToJSON()

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `MediaDeviceInfoJson` | `class` | get/set | JSON representation of the MediaDeviceInfo object acquired from MediaDeviceInfo.ToJSON() |
| `Kind` | `string` | get | Returns an enumerated value that is either "videoinput", "audioinput" or "audiooutput". |
| `Label` | `string` | get | Returns a string describing this device (for example "External USB Webcam"). Note: For security reasons, the label field is always blank unless an active media stream exists or the user has granted persistent permission for media device access. The set of device labels could otherwise be used as part of a fingerprinting mechanism to identify a user. |
| `GroupId` | `string` | get/set | Returns a string that is a group identifier. Two devices have the same group identifier if they belong to the same physical device - for example a monitor with both a built-in camera and a microphone. |
| `Facing` | `EnumString<VideoFacingModeEnum>?` | get | Facing mode |
| `DeviceId` | `string` | get/set | Returns a string that is an identifier for the represented device that is persisted across sessions. It is un-guessable by other applications and unique to the origin of the calling application. It is reset when the user clears cookies (for Private Browsing, a different identifier is used that is not persisted across sessions). |

