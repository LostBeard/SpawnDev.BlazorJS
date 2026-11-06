# DecodingConfiguration

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Source:** `JSObjects/DecodingConfiguration.cs`  

> An object with a property type and either a video or audio property containing a configuration of the appropriate type

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `DecodingConfiguration` | `class` | get | An object with a property type and either a video or audio property containing a configuration of the appropriate type |
| `Audio` | `EncodingConfigurationAudio?` | get |  |
| `Video` | `EncodingConfigurationVideo?` | get |  |
| `Type` | `string?` | get/set | The type of media being tested. This takes one of three values: file - Represents a configuration that is meant to be used for a plain file playback. media-source - Represents a configuration that is meant to be used for playback of a MediaSource. webrtc - Represents a configuration that is meant to be received using RTCPeerConnection. |

