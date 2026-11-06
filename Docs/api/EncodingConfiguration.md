# EncodingConfiguration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/EncodingConfiguration.cs`  

> An object with a property type and either a video or audio property containing a configuration of the appropriate type

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `EncodingConfiguration` | `class` | get | An object with a property type and either a video or audio property containing a configuration of the appropriate type |
| `Audio` | `EncodingConfigurationAudio?` | get |  |
| `Video` | `EncodingConfigurationVideo?` | get |  |
| `Type` | `string?` | get/set | The type of media being tested. This takes one of two values: record - Represents a configuration for recording of media, e.g. using MediaRecorder. webrtc - Represents a configuration meant to be transmitted over electronic means(e.g. using RTCPeerConnection). Note: Firefox uses transmission for this type, and webrtc does not work. transmission - Non-standard. The synonym of webrtc to be used in Firefox. |

