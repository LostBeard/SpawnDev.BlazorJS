# MediaEncryptedEvent

**Namespace:** `SpawnDev.BlazorJS.JSObjects`  
**Inherits:** `Event`  
**Source:** `JSObjects/MediaEncryptedEvent.cs`  

> The MediaEncryptedEvent interface of the Encrypted Media Extensions API contains the information associated with an encrypted event sent to a HTMLMediaElement when some initialization data is encountered in the media.

## Constructors

| Signature | Description |
|---|---|
| `MediaEncryptedEvent(IJSInProcessObjectReference _ref)` | Creates a new instance of `MediaEncryptedEvent`. |

## Properties

| Property | Type | Access | Description |
|---|---|---|---|
| `InitData` | `ArrayBuffer?` | get | Returns an ArrayBuffer containing the initialization data found. If there is no initialization data associated with the format, it returns null. |
| `InitDataType` | `string` | get | Returns a case-sensitive string with the type of the format of the initialization data found. |

